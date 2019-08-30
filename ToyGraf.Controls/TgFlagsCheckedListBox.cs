﻿namespace ToyGraf.Controls
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    public partial class TgFlagsCheckedListBox : CheckedListBox
    {
        #region Constructor

        public TgFlagsCheckedListBox() => InitializeComponent();

        #endregion

        #region Public Properties

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
        public Enum EnumValue
        {
            get => (Enum)Enum.ToObject(_EnumType, GetCurrentValue());
            set
            {
                Items.Clear();
                _EnumValue = value;
                _EnumType = value.GetType();
                Populate();
                Apply();
            }
        }

        #endregion

        #region Public Methods

        public TgFlagsCheckedListBoxItem Add(string text, int value) =>
            Add(new TgFlagsCheckedListBoxItem(text, value));

        public TgFlagsCheckedListBoxItem Add(TgFlagsCheckedListBoxItem item)
        {
            Items.Add(item);
            return item;
        }

        public int GetCurrentValue()
        {
            var result = 0;
            for (var index = 0; index < Items.Count; index++)
                if (GetItemChecked(index))
                    result |= ((TgFlagsCheckedListBoxItem)Items[index]).Value;
            return result;
        }

        #endregion

        #region Protected Methods

        protected override void OnItemCheck(ItemCheckEventArgs e)
        {
            base.OnItemCheck(e);
            if (!Updating)
                UpdateItems((TgFlagsCheckedListBoxItem)Items[e.Index], e.NewValue);
        }

        protected void UpdateItems(TgFlagsCheckedListBoxItem item, CheckState state)
        {
            if (item.Value == 0)
                UpdateItems(0);
            var result = 0;
            for (var index = 0; index < Items.Count; index++)
                if (GetItemChecked(index))
                    result |= ((TgFlagsCheckedListBoxItem)Items[index]).Value;
            if (state == CheckState.Unchecked)
                result &= ~item.Value;
            else
                result |= item.Value;
            UpdateItems(result);
        }

        protected void UpdateItems(int value)
        {
            Updating = true;
            for (var index = 0; index < Items.Count; index++)
            {
                var item = (TgFlagsCheckedListBoxItem)Items[index];
                SetItemChecked(index, item.Value == 0
                    ? value == 0
                    : (item.Value & value) == item.Value && item.Value != 0);
            }
            Updating = false;
        }

        #endregion

        #region Private Fields

        private Type _EnumType;
        private Enum _EnumValue;
        private bool Updating;

        #endregion

        #region Private Methods

        private void Apply() => UpdateItems((int)Convert.ChangeType(_EnumValue, typeof(int)));

        private void Populate()
        {
            foreach (var name in Enum.GetNames(_EnumType))
                Add(name, (int)Convert.ChangeType(Enum.Parse(_EnumType, name), typeof(int)));
        }

        #endregion
    }
}
