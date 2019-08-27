﻿namespace ToyGraf.Controls
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Windows.Forms;
    using ToyGraf.Controls.Events;
    using ToyGraf.Engine.Utility;

    public class TgCollectionEditor : CollectionEditor
    {
        #region Public Interface

        public TgCollectionEditor(Type type) : base(type) { }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            var result = base.EditValue(context, provider, value);
            CollectionEdited?.Invoke(this, new CollectionEditedEventArgs(context, provider, value, DialogResult));
            return result;
        }

        public ITypeDescriptorContext GetContext() => Context;

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

        #endregion

        #region Private Properties

        private DialogResult DialogResult;
        private PropertyGrid PropertyGrid => PropertyGridAdapter.PropertyGrid;
        private TgPropertyGridAdapter PropertyGridAdapter;
        private bool Updating;

        #endregion

        #region Private Event Handlers

        private void CollectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var form = (Form)sender;
            DialogResult = form.DialogResult;
            CollectionFormClosing?.Invoke(sender, e);
            if (!e.Cancel)
                DetachEventHandlers(form);
        }

        private void PropertyGrid_SelectedObjectsChanged(object sender, EventArgs e)
        {
            if (!Updating)
            {
                Updating = true;
                PropertyGridAdapter.SelectedObjects = PropertyGrid.SelectedObjects;
                Updating = false;
            }
        }

        #endregion

        #region Non-Public Methods

        private void AttachEventHandlers(Form form)
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
            PropertyGrid.SelectedObjectsChanged += PropertyGrid_SelectedObjectsChanged;
        }

        protected override CollectionForm CreateCollectionForm()
        {
            var form = base.CreateCollectionForm();
            if (form.Controls[0] is TableLayoutPanel panel)
            {
                if (panel.Controls[4] is ListBox listBox)
                    listBox.DrawMode = DrawMode.Normal;
                if (panel.Controls[5] is PropertyGrid propertyGrid)
                {
                    CollectionFormGridInit?.Invoke(this, new PropertyGridInitEventArgs(propertyGrid));
                    propertyGrid.PropertyValueChanged += CollectionItemPropertyValueChanged;
                    PropertyGridAdapter = new TgPropertyGridAdapter(propertyGrid)
                    {
                        HiddenAttributes = new AttributeCollection(new CategoryAttribute(Categories.SystemRO))
                    };
                }
            }
            AttachEventHandlers(form);
            return form;
        }

        private void DetachEventHandlers(Form form)
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
            PropertyGrid.SelectedObjectsChanged -= PropertyGrid_SelectedObjectsChanged;
        }

        #endregion
    }
}
