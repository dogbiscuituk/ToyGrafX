namespace ToyGraf.Controls
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Windows.Forms;

    public class TgCollectionEditor : CollectionEditor
    {
        public TgCollectionEditor(Type type) : base(type) { }

        public ITypeDescriptorContext GetContext() => Context;

        /// <summary>
        /// Provide static hooks into events on the CollectionForm.
        /// </summary>
        /// <returns></returns>
        protected override CollectionForm CreateCollectionForm()
        {
            var form = base.CreateCollectionForm();
            AttachEventHandlers(form, true);
            if (form.Controls[0] is TableLayoutPanel panel)
            {
                if (panel.Controls[4] is ListBox listBox)
                {
                    listBox.DrawMode = DrawMode.Normal;
                }
                if (panel.Controls[5] is PropertyGrid propertyGrid)
                {
                    CollectionFormGridInit?.Invoke(this, new PropertyGridInitEventArgs(propertyGrid));
                    propertyGrid.PropertyValueChanged += CollectionItemPropertyValueChanged;
                }
            }
            return form;
        }

        private void CollectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var collectionForm = (Form)sender;
            DialogResult = collectionForm.DialogResult;
            CollectionFormClosing?.Invoke(sender, e);
            if (!e.Cancel)
                AttachEventHandlers(collectionForm, false);
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            var result = base.EditValue(context, provider, value);
            CollectionEdited?.Invoke(this, new CollectionEditedEventArgs(context, provider, value, DialogResult));
            return result;
        }

        private DialogResult DialogResult;

        public static event EventHandler
            CollectionFormActivated,
            CollectionFormDeactivate,
            CollectionFormEnter,
            CollectionFormLeave,
            CollectionFormLoad,
            CollectionFormShown;

        public static event EventHandler<CollectionEditedEventArgs> CollectionEdited;
        public static event FormClosedEventHandler CollectionFormClosed;
        public static event FormClosingEventHandler CollectionFormClosing;
        public static event EventHandler<PropertyGridInitEventArgs> CollectionFormGridInit;
        public static event CancelEventHandler CollectionFormHelpButtonClicked;
        public static event LayoutEventHandler CollectionFormLayout;
        public static event PropertyValueChangedEventHandler CollectionItemPropertyValueChanged;

        #region Private Methods

        private void AttachEventHandlers(Form form, bool attach)
        {
            if (attach)
            {
                form.Activated += CollectionFormActivated;
                form.Deactivate += CollectionFormDeactivate;
                form.Enter += CollectionFormEnter;
                form.FormClosed += CollectionFormClosed;
                form.FormClosing += CollectionForm_FormClosing;
                form.HelpButtonClicked += CollectionFormHelpButtonClicked;
                form.Layout += CollectionFormLayout;
                form.Enter += CollectionFormLeave;
                form.Load += CollectionFormLoad;
                form.Shown += CollectionFormShown;
            }
            else
            {
                form.Activated -= CollectionFormActivated;
                form.Deactivate -= CollectionFormDeactivate;
                form.Enter -= CollectionFormEnter;
                form.FormClosed -= CollectionFormClosed;
                form.FormClosing -= CollectionForm_FormClosing;
                form.HelpButtonClicked -= CollectionFormHelpButtonClicked;
                form.Layout -= CollectionFormLayout;
                form.Enter -= CollectionFormLeave;
                form.Load -= CollectionFormLoad;
                form.Shown -= CollectionFormShown;
            }
        }

        #endregion
    }

    public class CollectionEditedEventArgs : EventArgs
    {
        public CollectionEditedEventArgs(ITypeDescriptorContext context,
            IServiceProvider provider, object value, DialogResult dialogResult)
        {
            Context = context;
            Provider = provider;
            Value = value;
            DialogResult = dialogResult;
        }

        public ITypeDescriptorContext Context { get; set; }
        public DialogResult DialogResult;
        public IServiceProvider Provider { get; set; }
        public object Value { get; set; }
    }

    public class PropertyGridInitEventArgs : EventArgs
    {
        public PropertyGridInitEventArgs(PropertyGrid propertyGrid) : base()
            => PropertyGrid = propertyGrid;

        public PropertyGrid PropertyGrid { get; set; }
    }
}
