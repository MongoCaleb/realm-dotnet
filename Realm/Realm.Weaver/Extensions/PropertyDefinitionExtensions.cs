﻿////////////////////////////////////////////////////////////////////////////
//
// Copyright 2016 Realm Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
////////////////////////////////////////////////////////////////////////////

using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Mono.Cecil;
using Mono.Cecil.Cil;
using RealmWeaver;
using static RealmWeaver.Weaver;

[EditorBrowsable(EditorBrowsableState.Never)]
internal static class PropertyDefinitionExtensions
{
    private static readonly IEnumerable<string> _indexableTypes = new[]
    {
        StringTypeName,
        CharTypeName,
        ByteTypeName,
        Int16TypeName,
        Int32TypeName,
        Int64TypeName,
        BooleanTypeName,
        DateTimeOffsetTypeName,
        ObjectIdTypeName,
        GuidTypeName,
    };

    internal static bool IsAutomatic(this PropertyDefinition property)
    {
        return property.GetMethod.CustomAttributes.Any(attr => attr.AttributeType.FullName == typeof(CompilerGeneratedAttribute).FullName);
    }

    private static bool IsIList(this PropertyDefinition property)
    {
        return property.IsType("IList`1", "System.Collections.Generic");
    }

    private static bool IsISet(this PropertyDefinition property)
    {
        return property.IsType("ISet`1", "System.Collections.Generic");
    }

    private static bool IsIDictionary(this PropertyDefinition property)
    {
        return property.IsType("IDictionary`2", "System.Collections.Generic");
    }

    internal static bool IsCollection(this PropertyDefinition property, out RealmCollectionType collectionType)
    {
        if (property.IsISet())
        {
            collectionType = RealmCollectionType.ISet;
            return true;
        }

        if (property.IsIList())
        {
            collectionType = RealmCollectionType.IList;
            return true;
        }

        if (property.IsIDictionary())
        {
            collectionType = RealmCollectionType.IDictionary;
            return true;
        }

        collectionType = RealmCollectionType.None;
        return false;
    }

    internal static bool IsCollection(this PropertyDefinition property, TypeReference elementType)
    {
        return (IsIList(property) || IsISet(property)) && ((GenericInstanceType)property.PropertyType).GenericArguments.Last().IsSameAs(elementType);
    }

    internal static bool IsCollection(this PropertyDefinition property, System.Type elementType)
    {
        return property.IsCollection(out _) && ((GenericInstanceType)property.PropertyType).GenericArguments.Last().FullName == elementType.FullName;
    }

    internal static bool IsIQueryable(this PropertyDefinition property)
    {
        return property.IsType("IQueryable`1", "System.Linq");
    }

    internal static bool IsDateTimeOffset(this PropertyDefinition property)
    {
        return property.PropertyType.FullName == DateTimeOffsetTypeName;
    }

    internal static bool IsNullable(this PropertyDefinition property)
    {
        return property.PropertyType.IsNullable();
    }

    internal static bool IsSingle(this PropertyDefinition property)
    {
        return property.PropertyType.FullName == SingleTypeName;
    }

    internal static bool IsDouble(this PropertyDefinition property)
    {
        return property.PropertyType.FullName == DoubleTypeName;
    }

    internal static bool IsDecimal(this PropertyDefinition property)
    {
        return property.PropertyType.FullName == DecimalTypeName;
    }

    internal static bool IsDecimal128(this PropertyDefinition property)
    {
        return property.PropertyType.FullName == Decimal128TypeName;
    }

    internal static bool IsObjectId(this PropertyDefinition property)
    {
        return property.PropertyType.FullName == ObjectIdTypeName;
    }

    internal static bool IsGuid(this PropertyDefinition property)
    {
        return property.PropertyType.FullName == GuidTypeName;
    }

    internal static bool IsString(this PropertyDefinition property)
    {
        return property.PropertyType.FullName == StringTypeName;
    }

    internal static bool IsRealmValue(this PropertyDefinition property)
    {
        return property.PropertyType.FullName == RealmValueTypeName;
    }

    internal static bool IsDescendantOf(this PropertyDefinition property, TypeReference other)
    {
        return property.PropertyType.Resolve().BaseType.IsSameAs(other);
    }

    internal static FieldReference? GetBackingField(this PropertyDefinition property)
    {
        return property.GetMethod.Body.Instructions
            .Where(o => o.OpCode == OpCodes.Ldfld)
            .Select(o => o.Operand)
            .OfType<FieldReference>()
            .SingleOrDefault();
    }

    internal static bool IsPrimaryKey(this PropertyDefinition property, ImportedReferences references)
    {
        Debug.Assert(property.DeclaringType.IsValidRealmObjectBaseInheritor(references), "Primary key properties only make sense on RealmObject/EmbeddedObject classes");
        return property.CustomAttributes.Any(a => a.AttributeType.Name == "PrimaryKeyAttribute");
    }

    internal static bool IsRequired(this PropertyDefinition property, ImportedReferences references)
    {
        Debug.Assert(property.DeclaringType.IsValidRealmObjectBaseInheritor(references), "Required properties only make sense on RealmObject/EmbeddedObject classes");
        return property.CustomAttributes.Any(a => a.AttributeType.Name == "RequiredAttribute");
    }

    internal static bool IsIndexable(this PropertyDefinition property, ImportedReferences references)
    {
        Debug.Assert(property.DeclaringType.IsValidRealmObjectBaseInheritor(references), "Indexed properties only make sense on RealmObject/EmbeddedObject classes");
        var propertyType = property.PropertyType;
        if (propertyType.IsRealmInteger(out var isNullable, out var backingType))
        {
            if (isNullable)
            {
                return false;
            }

            propertyType = backingType;
        }

        return _indexableTypes.Contains(propertyType.FullName);
    }

    public static bool ContainsRealmObject(this PropertyDefinition property, ImportedReferences references) =>
        property.PropertyType.Resolve().IsRealmObjectInheritor(references);

    public static bool ContainsAsymmetricObject(this PropertyDefinition property, ImportedReferences references) =>
        property.PropertyType.Resolve().IsAsymmetricObjectInheritor(references);

    public static bool ContainsEmbeddedObject(this PropertyDefinition property, ImportedReferences references) =>
        property.PropertyType.Resolve().IsEmbeddedObjectInheritor(references);

    private static bool IsType(this PropertyDefinition property, string name, string @namespace)
    {
        return property.PropertyType.Name == name && property.PropertyType.Namespace == @namespace;
    }

    public static SequencePoint? GetSequencePoint(this PropertyDefinition property) => property.GetMethod?.DebugInformation?.SequencePoints.FirstOrDefault() ?? property.SetMethod?.DebugInformation?.SequencePoints.FirstOrDefault();
}
