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
            base.SelectedObject = Wrap;
        }

        #endregion

        #region Private Fields

        private AttributeCollection _HiddenAttrs, _VisibleAttrs;
        private string[] _HiddenProps, _VisibleProps;
        private readonly List<PropertyDescriptor> Props = new List<PropertyDescriptor>();
        private TgWrap Wrap;
        private IEnumerable<TgWrap> Wraps;

        #endregion

        #region Public Properties

        [Browsable(false)]
        public AttributeCollection HiddenAttributes
        {
            get => _HiddenAttrs;
            set
            {
                if (_HiddenAttrs != value)
                {
                    _HiddenAttrs = value;
                    _VisibleAttrs = null;
                    UpdateProps();
                }
            }
        }

        public string[] HiddenProperties
        {
            get => _HiddenProps;
            set
            {
                if (_HiddenProps != value)
                {
                    _HiddenProps = value;
                    UpdateProps();
                }
            }
        }

        public new object SelectedObject
        {
            get => Wrap?.Object;
            set
            {
                if (value == null)
                {
                    Wrap = null;
                    base.SelectedObject = null;
                    return;
                }
                SelectedObjects = null;
                if (Wrap == null)
                {
                    Wrap = new TgWrap(value);
                    UpdateProps();
                }
                else if (Wrap.Object != value)
                {
                    bool change = value?.GetType() != Wrap.Object.GetType();
                    Wrap.Object = value;
                    if (change)
                        UpdateProps();
                }
                Wrap.PropertyDescriptors = Props;
                base.SelectedObject = Wrap.Object != null ? Wrap : null;
            }
        }

        public new object[] SelectedObjects
        {
            get => Wraps?.Select(w => w.Object)?.ToArray();
            set
            {
                if (value == null)
                {
                    Wraps = null;
                    base.SelectedObjects = null;
                    return;
                }
                SelectedObject = null;
                Wraps = value.Select(o => new TgWrap(o)).ToList();
                UpdateProps();
                foreach (var wrap in Wraps)
                    wrap.PropertyDescriptors = Props;
                base.SelectedObjects = Wraps.Select(w => w.Object).ToArray();
            }
        }

        [Browsable(false)]
        public AttributeCollection VisibleAttributes
        {
            get => _VisibleAttrs;
            set
            {
                if (_VisibleAttrs != value)
                {
                    _HiddenAttrs = null;
                    _VisibleAttrs = value;
                    UpdateProps();
                }
            }
        }

        public string[] VisibleProperties
        {
            get => _VisibleProps;
            set
            {
                if (_VisibleProps != value)
                {
                    _VisibleProps = value;
                    UpdateProps();
                }
            }
        }

        #endregion

        #region Private Methods

        private void HideAttr(TgWrap wrap, Attribute attr)
        {
            var props = TypeDescriptor.GetProperties(wrap.Object, new Attribute[] { attr });
            if (props != null && props.Count > 0)
                foreach (PropertyDescriptor prop in props)
                    HideProp(prop);
        }

        private void HideProp(PropertyDescriptor prop)
        {
            if (Props.Contains(prop))
                Props.Remove(prop);
        }

        private void ShowAttr(TgWrap wrap, Attribute attr)
        {
            var props = TypeDescriptor.GetProperties(wrap.Object, new Attribute[] { attr });
            if (props != null && props.Count > 0)
                foreach (PropertyDescriptor prop in props)
                    ShowProp(prop);
        }

        private void ShowProp(PropertyDescriptor prop)
        {
            if (!Props.Contains(prop))
                Props.Add(prop);
        }

        private void UpdateProps()
        {
            if (Wrap != null)
                UpdateProps(Wrap);
            else if (Wraps != null && Wraps.Any())
                UpdateProps(Wraps.First());
        }

        private void UpdateProps(TgWrap wrap)
        {
            if (wrap?.Object == null)
                return;
            Props.Clear();
            if (_VisibleAttrs != null)
                foreach (Attribute attr in _VisibleAttrs)
                    ShowAttr(wrap, attr);
            else
            {
                Props.AddRange(TypeDescriptor.GetProperties(wrap.Object).Cast<PropertyDescriptor>());
                if (_HiddenAttrs != null)
                    foreach (Attribute attr in _HiddenAttrs)
                        HideAttr(wrap, attr);
            }
            var props = TypeDescriptor.GetProperties(wrap.Object);
            if (_HiddenProps != null)
                foreach (string name in _HiddenProps)
                    HideProp(props[name]);
            if (_VisibleProps != null)
                foreach (string name in _VisibleProps)
                    ShowProp(props[name]);
            Refresh();
        }

        #endregion
    }
}
