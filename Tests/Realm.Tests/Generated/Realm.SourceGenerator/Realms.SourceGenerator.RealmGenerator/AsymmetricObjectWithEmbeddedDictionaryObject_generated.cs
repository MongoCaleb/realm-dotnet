﻿// <auto-generated />
#nullable enable

using MongoDB.Bson;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Realms;
using Realms.Dynamic;
using Realms.Exceptions;
using Realms.Schema;
using Realms.Sync;
using Realms.Tests.Sync;
using Realms.Weaving;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TestAsymmetricObject = Realms.IAsymmetricObject;

namespace Realms.Tests.Sync
{
    [Generated]
    [Woven(typeof(AsymmetricObjectWithEmbeddedDictionaryObjectObjectHelper)), Realms.Preserve(AllMembers = true)]
    public partial class AsymmetricObjectWithEmbeddedDictionaryObject : IAsymmetricObject, INotifyPropertyChanged, IReflectableType
    {
        /// <summary>
        /// Defines the schema for the <see cref="AsymmetricObjectWithEmbeddedDictionaryObject"/> class.
        /// </summary>
        public static Realms.Schema.ObjectSchema RealmSchema = new Realms.Schema.ObjectSchema.Builder("AsymmetricObjectWithEmbeddedDictionaryObject", ObjectSchema.ObjectType.AsymmetricObject)
        {
            Realms.Schema.Property.Primitive("_id", Realms.RealmValueType.ObjectId, isPrimaryKey: true, indexType: IndexType.None, isNullable: false, managedName: "Id"),
            Realms.Schema.Property.ObjectDictionary("EmbeddedDictionaryObject", "EmbeddedIntPropertyObject", managedName: "EmbeddedDictionaryObject"),
        }.Build();

        #region IAsymmetricObject implementation

        private IAsymmetricObjectWithEmbeddedDictionaryObjectAccessor? _accessor;

        Realms.IRealmAccessor Realms.IRealmObjectBase.Accessor => Accessor;

        private IAsymmetricObjectWithEmbeddedDictionaryObjectAccessor Accessor => _accessor ??= new AsymmetricObjectWithEmbeddedDictionaryObjectUnmanagedAccessor(typeof(AsymmetricObjectWithEmbeddedDictionaryObject));

        /// <inheritdoc />
        [IgnoreDataMember, XmlIgnore]
        public bool IsManaged => Accessor.IsManaged;

        /// <inheritdoc />
        [IgnoreDataMember, XmlIgnore]
        public bool IsValid => Accessor.IsValid;

        /// <inheritdoc />
        [IgnoreDataMember, XmlIgnore]
        public bool IsFrozen => Accessor.IsFrozen;

        /// <inheritdoc />
        [IgnoreDataMember, XmlIgnore]
        public Realms.Realm? Realm => Accessor.Realm;

        /// <inheritdoc />
        [IgnoreDataMember, XmlIgnore]
        public Realms.Schema.ObjectSchema ObjectSchema => Accessor.ObjectSchema!;

        /// <inheritdoc />
        [IgnoreDataMember, XmlIgnore]
        public Realms.DynamicObjectApi DynamicApi => Accessor.DynamicApi;

        /// <inheritdoc />
        [IgnoreDataMember, XmlIgnore]
        public int BacklinksCount => Accessor.BacklinksCount;

        void ISettableManagedAccessor.SetManagedAccessor(Realms.IRealmAccessor managedAccessor, Realms.Weaving.IRealmObjectHelper? helper, bool update, bool skipDefaults)
        {
            var newAccessor = (IAsymmetricObjectWithEmbeddedDictionaryObjectAccessor)managedAccessor;
            var oldAccessor = _accessor;
            _accessor = newAccessor;

            if (helper != null && oldAccessor != null)
            {
                if (!skipDefaults)
                {
                    newAccessor.EmbeddedDictionaryObject.Clear();
                }

                if (!skipDefaults || oldAccessor.Id != default(MongoDB.Bson.ObjectId))
                {
                    newAccessor.Id = oldAccessor.Id;
                }
                Realms.CollectionExtensions.PopulateCollection(oldAccessor.EmbeddedDictionaryObject, newAccessor.EmbeddedDictionaryObject, update, skipDefaults);
            }

            if (_propertyChanged != null)
            {
                SubscribeForNotifications();
            }

            OnManaged();
        }

        #endregion

        /// <summary>
        /// Called when the object has been managed by a Realm.
        /// </summary>
        /// <remarks>
        /// This method will be called either when a managed object is materialized or when an unmanaged object has been
        /// added to the Realm. It can be useful for providing some initialization logic as when the constructor is invoked,
        /// it is not yet clear whether the object is managed or not.
        /// </remarks>
        partial void OnManaged();

        private event PropertyChangedEventHandler? _propertyChanged;

        /// <inheritdoc />
        public event PropertyChangedEventHandler? PropertyChanged
        {
            add
            {
                if (_propertyChanged == null)
                {
                    SubscribeForNotifications();
                }

                _propertyChanged += value;
            }

            remove
            {
                _propertyChanged -= value;

                if (_propertyChanged == null)
                {
                    UnsubscribeFromNotifications();
                }
            }
        }

        /// <summary>
        /// Called when a property has changed on this class.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <remarks>
        /// For this method to be called, you need to have first subscribed to <see cref="PropertyChanged"/>.
        /// This can be used to react to changes to the current object, e.g. raising <see cref="PropertyChanged"/> for computed properties.
        /// </remarks>
        /// <example>
        /// <code>
        /// class MyClass : IRealmObject
        /// {
        ///     public int StatusCodeRaw { get; set; }
        ///     public StatusCodeEnum StatusCode => (StatusCodeEnum)StatusCodeRaw;
        ///     partial void OnPropertyChanged(string propertyName)
        ///     {
        ///         if (propertyName == nameof(StatusCodeRaw))
        ///         {
        ///             RaisePropertyChanged(nameof(StatusCode));
        ///         }
        ///     }
        /// }
        /// </code>
        /// Here, we have a computed property that depends on a persisted one. In order to notify any <see cref="PropertyChanged"/>
        /// subscribers that <c>StatusCode</c> has changed, we implement <see cref="OnPropertyChanged"/> and
        /// raise <see cref="PropertyChanged"/> manually by calling <see cref="RaisePropertyChanged"/>.
        /// </example>
        partial void OnPropertyChanged(string? propertyName);

        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            _propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            OnPropertyChanged(propertyName);
        }

        private void SubscribeForNotifications()
        {
            Accessor.SubscribeForNotifications(RaisePropertyChanged);
        }

        private void UnsubscribeFromNotifications()
        {
            Accessor.UnsubscribeFromNotifications();
        }

        /// <summary>
        /// Converts a <see cref="Realms.RealmValue"/> to <see cref="AsymmetricObjectWithEmbeddedDictionaryObject"/>. Equivalent to <see cref="Realms.RealmValue.AsNullableRealmObject{T}"/>.
        /// </summary>
        /// <param name="val">The <see cref="Realms.RealmValue"/> to convert.</param>
        /// <returns>The <see cref="AsymmetricObjectWithEmbeddedDictionaryObject"/> stored in the <see cref="Realms.RealmValue"/>.</returns>
        public static explicit operator AsymmetricObjectWithEmbeddedDictionaryObject?(Realms.RealmValue val) => val.Type == Realms.RealmValueType.Null ? null : val.AsRealmObject<AsymmetricObjectWithEmbeddedDictionaryObject>();

        /// <summary>
        /// Implicitly constructs a <see cref="Realms.RealmValue"/> from <see cref="AsymmetricObjectWithEmbeddedDictionaryObject"/>.
        /// </summary>
        /// <param name="val">The value to store in the <see cref="Realms.RealmValue"/>.</param>
        /// <returns>A <see cref="Realms.RealmValue"/> containing the supplied <paramref name="val"/>.</returns>
        public static implicit operator Realms.RealmValue(AsymmetricObjectWithEmbeddedDictionaryObject? val) => val == null ? Realms.RealmValue.Null : Realms.RealmValue.Object(val);

        /// <summary>
        /// Implicitly constructs a <see cref="Realms.QueryArgument"/> from <see cref="AsymmetricObjectWithEmbeddedDictionaryObject"/>.
        /// </summary>
        /// <param name="val">The value to store in the <see cref="Realms.QueryArgument"/>.</param>
        /// <returns>A <see cref="Realms.QueryArgument"/> containing the supplied <paramref name="val"/>.</returns>
        public static implicit operator Realms.QueryArgument(AsymmetricObjectWithEmbeddedDictionaryObject? val) => (Realms.RealmValue)val;

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TypeInfo GetTypeInfo() => Accessor.GetTypeInfo(this);

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is InvalidObject)
            {
                return !IsValid;
            }

            if (obj is not Realms.IRealmObjectBase iro)
            {
                return false;
            }

            return Accessor.Equals(iro.Accessor);
        }

        /// <inheritdoc />
        public override int GetHashCode() => IsManaged ? Accessor.GetHashCode() : base.GetHashCode();

        /// <inheritdoc />
        public override string? ToString() => Accessor.ToString();

        [EditorBrowsable(EditorBrowsableState.Never), Realms.Preserve(AllMembers = true)]
        private class AsymmetricObjectWithEmbeddedDictionaryObjectObjectHelper : Realms.Weaving.IRealmObjectHelper
        {
            public void CopyToRealm(Realms.IRealmObjectBase instance, bool update, bool skipDefaults)
            {
                throw new InvalidOperationException("This method should not be called for source generated classes.");
            }

            public Realms.ManagedAccessor CreateAccessor() => new AsymmetricObjectWithEmbeddedDictionaryObjectManagedAccessor();

            public Realms.IRealmObjectBase CreateInstance() => new AsymmetricObjectWithEmbeddedDictionaryObject();

            public bool TryGetPrimaryKeyValue(Realms.IRealmObjectBase instance, out RealmValue value)
            {
                value = ((IAsymmetricObjectWithEmbeddedDictionaryObjectAccessor)instance.Accessor).Id;
                return true;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never), Realms.Preserve(AllMembers = true)]
        internal interface IAsymmetricObjectWithEmbeddedDictionaryObjectAccessor : Realms.IRealmAccessor
        {
            MongoDB.Bson.ObjectId Id { get; set; }

            System.Collections.Generic.IDictionary<string, Realms.Tests.EmbeddedIntPropertyObject?> EmbeddedDictionaryObject { get; }
        }

        [EditorBrowsable(EditorBrowsableState.Never), Realms.Preserve(AllMembers = true)]
        internal class AsymmetricObjectWithEmbeddedDictionaryObjectManagedAccessor : Realms.ManagedAccessor, IAsymmetricObjectWithEmbeddedDictionaryObjectAccessor
        {
            public MongoDB.Bson.ObjectId Id
            {
                get => (MongoDB.Bson.ObjectId)GetValue("_id");
                set => SetValueUnique("_id", value);
            }

            private System.Collections.Generic.IDictionary<string, Realms.Tests.EmbeddedIntPropertyObject?> _embeddedDictionaryObject = null!;
            public System.Collections.Generic.IDictionary<string, Realms.Tests.EmbeddedIntPropertyObject?> EmbeddedDictionaryObject
            {
                get
                {
                    if (_embeddedDictionaryObject == null)
                    {
                        _embeddedDictionaryObject = GetDictionaryValue<Realms.Tests.EmbeddedIntPropertyObject?>("EmbeddedDictionaryObject");
                    }

                    return _embeddedDictionaryObject;
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never), Realms.Preserve(AllMembers = true)]
        internal class AsymmetricObjectWithEmbeddedDictionaryObjectUnmanagedAccessor : Realms.UnmanagedAccessor, IAsymmetricObjectWithEmbeddedDictionaryObjectAccessor
        {
            public override ObjectSchema ObjectSchema => AsymmetricObjectWithEmbeddedDictionaryObject.RealmSchema;

            private MongoDB.Bson.ObjectId _id = ObjectId.GenerateNewId();
            public MongoDB.Bson.ObjectId Id
            {
                get => _id;
                set
                {
                    _id = value;
                    RaisePropertyChanged("Id");
                }
            }

            public System.Collections.Generic.IDictionary<string, Realms.Tests.EmbeddedIntPropertyObject?> EmbeddedDictionaryObject { get; } = new Dictionary<string, Realms.Tests.EmbeddedIntPropertyObject?>();

            public AsymmetricObjectWithEmbeddedDictionaryObjectUnmanagedAccessor(Type objectType) : base(objectType)
            {
            }

            public override Realms.RealmValue GetValue(string propertyName)
            {
                return propertyName switch
                {
                    "_id" => _id,
                    _ => throw new MissingMemberException($"The object does not have a gettable Realm property with name {propertyName}"),
                };
            }

            public override void SetValue(string propertyName, Realms.RealmValue val)
            {
                switch (propertyName)
                {
                    case "_id":
                        throw new InvalidOperationException("Cannot set the value of a primary key property with SetValue. You need to use SetValueUnique");
                    default:
                        throw new MissingMemberException($"The object does not have a settable Realm property with name {propertyName}");
                }
            }

            public override void SetValueUnique(string propertyName, Realms.RealmValue val)
            {
                if (propertyName != "_id")
                {
                    throw new InvalidOperationException($"Cannot set the value of non primary key property ({propertyName}) with SetValueUnique");
                }

                Id = (MongoDB.Bson.ObjectId)val;
            }

            public override IList<T> GetListValue<T>(string propertyName)
            {
                throw new MissingMemberException($"The object does not have a Realm list property with name {propertyName}");
            }

            public override ISet<T> GetSetValue<T>(string propertyName)
            {
                throw new MissingMemberException($"The object does not have a Realm set property with name {propertyName}");
            }

            public override IDictionary<string, TValue> GetDictionaryValue<TValue>(string propertyName)
            {
                return propertyName switch
                {
                    "EmbeddedDictionaryObject" => (IDictionary<string, TValue>)EmbeddedDictionaryObject,
                    _ => throw new MissingMemberException($"The object does not have a Realm dictionary property with name {propertyName}"),
                };
            }
        }
    }
}
