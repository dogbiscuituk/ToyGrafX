﻿namespace ToyGraf.Controls
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

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
}
