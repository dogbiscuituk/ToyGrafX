namespace ToyGraf.Controls
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    /// <summary>
    /// An object wrapper class for controlling property visibilities in a TgPropertyGrid.
    /// </summary>
    internal class TgObject : ICustomTypeDescriptor
    {
        #region Constructor

        internal TgObject(object obj) => Object = obj;

        #endregion

        #region Public Properties

        /// <summary>
        /// The list of visible properties.
        /// </summary>
        public List<PropertyDescriptor> PropertyDescriptors { get; set; } = new List<PropertyDescriptor>();

        #endregion

        #region Internal Fields

        internal object Object;

        #endregion

        #region ICustomTypeDescriptor Getter Methods

        public AttributeCollection GetAttributes() => TypeDescriptor.GetAttributes(Object, true);
        public string GetClassName() => TypeDescriptor.GetClassName(Object, true);
        public string GetComponentName() => TypeDescriptor.GetComponentName(Object, true);
        public TypeConverter GetConverter() => TypeDescriptor.GetConverter(Object, true);
        public EventDescriptor GetDefaultEvent() => TypeDescriptor.GetDefaultEvent(Object, true);
        public PropertyDescriptor GetDefaultProperty() => TypeDescriptor.GetDefaultProperty(Object, true);
        public object GetEditor(Type type) => TypeDescriptor.GetEditor(this, type, true);
        public EventDescriptorCollection GetEvents() => TypeDescriptor.GetEvents(Object, true);
        public EventDescriptorCollection GetEvents(Attribute[] attrs) => TypeDescriptor.GetEvents(Object, attrs, true);
        public PropertyDescriptorCollection GetProperties() => new PropertyDescriptorCollection(PropertyDescriptors.ToArray(), true);
        public PropertyDescriptorCollection GetProperties(Attribute[] _) => GetProperties();
        public object GetPropertyOwner(PropertyDescriptor pd) => Object;

        #endregion
    }
}
