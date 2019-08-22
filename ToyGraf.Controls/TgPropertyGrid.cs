namespace ToyGraf.Controls
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;

    public partial class TgPropertyGrid : PropertyGrid
    {
        #region Constructor

        public TgPropertyGrid()
        {
            InitializeComponent();
            base.SelectedObject = Object;
        }

        #endregion

        #region Private Fields

        private AttributeCollection _BrowsableAttributes, _HiddenAttributes;
        private string[] _BrowsableProperties, _HiddenProperties;
        private TgObject Object;
        private readonly List<PropertyDescriptor> PropertyDescriptors = new List<PropertyDescriptor>();

        #endregion

        #region Public Properties

        public new AttributeCollection BrowsableAttributes
        {
            get => _BrowsableAttributes;
            set
            {
                if (_BrowsableAttributes != value)
                {
                    _HiddenAttributes = null;
                    _BrowsableAttributes = value;
                    UpdateProps();
                }
            }
        }

        public string[] BrowsableProperties
        {
            get => _BrowsableProperties;
            set
            {
                if (_BrowsableProperties != value)
                {
                    _BrowsableProperties = value;
                    //m_HiddenProperties = null;
                    UpdateProps();
                }
            }
        }

        public AttributeCollection HiddenAttributes
        {
            get => _HiddenAttributes;
            set
            {
                if (_HiddenAttributes != value)
                {
                    _HiddenAttributes = value;
                    _BrowsableAttributes = null;
                    UpdateProps();
                }
            }
        }

        public string[] HiddenProperties
        {
            get => _HiddenProperties;
            set
            {
                if (_HiddenProperties != value)
                {
                    //m_BrowsableProperties = null;
                    _HiddenProperties = value;
                    UpdateProps();
                }
            }
        }

        public new object SelectedObject
        {
            get => Object != null ? ((TgObject)base.SelectedObject).Object : null;
            set
            {
                if (Object == null)
                {
                    Object = new TgObject(value);
                    UpdateProps();
                }
                else if (Object.Object != value)
                {
                    bool change = value?.GetType() != Object.Object.GetType();
                    Object.Object = value;
                    if (change)
                        UpdateProps();
                }
                Object.PropertyDescriptors = PropertyDescriptors;
                base.SelectedObject = Object.Object != null ? Object : null;
            }
        }

        #endregion

        #region Private Methods

        private void HideAttr(Attribute attribute)
        {
            var props = TypeDescriptor.GetProperties(Object.Object, new Attribute[] { attribute });
            if (props == null || props.Count == 0)
                throw new ArgumentException("Attribute not found", attribute.ToString());
            foreach (PropertyDescriptor prop in props)
                HideProp(prop);
        }

        private void HideProp(PropertyDescriptor prop)
        {
            if (PropertyDescriptors.Contains(prop))
                PropertyDescriptors.Remove(prop);
        }

        private void ShowAttr(Attribute attribute)
        {
            var props = TypeDescriptor.GetProperties(Object.Object, new Attribute[] { attribute });
            if (props == null || props.Count == 0)
                throw new ArgumentException("Attribute not found", attribute.ToString());
            foreach (PropertyDescriptor prop in props)
                ShowProp(prop);
        }

        private void ShowProp(PropertyDescriptor prop)
        {
            if (!PropertyDescriptors.Contains(prop))
                PropertyDescriptors.Add(prop);
        }

        private void UpdateProps()
        {
            if (Object == null)
                return;
            PropertyDescriptors.Clear();
            if (_BrowsableAttributes != null && _BrowsableAttributes.Count > 0)
                foreach (Attribute attr in _BrowsableAttributes)
                    ShowAttr(attr);
            else
            {
                PropertyDescriptors.AddRange(TypeDescriptor.GetProperties(Object.Object).OfType<PropertyDescriptor>());
                if (_HiddenAttributes != null)
                    foreach (Attribute attr in _HiddenAttributes)
                        HideAttr(attr);
            }
            var props = TypeDescriptor.GetProperties(Object.Object);
            if (_HiddenProperties != null && _HiddenProperties.Length > 0)
                foreach (string name in _HiddenProperties)
                    try
                    {
                        HideProp(props[name]);
                    }
                    catch (Exception ex)
                    {
                        throw new ArgumentException(ex.Message);
                    }
            if (_BrowsableProperties != null && _BrowsableProperties.Length > 0)
                foreach (string name in _BrowsableProperties)
                    try
                    {
                        ShowProp(props[name]);
                    }
                    catch (Exception)
                    {
                        throw new ArgumentException("Property not found", name);
                    }
        }

        #endregion
    }
}
