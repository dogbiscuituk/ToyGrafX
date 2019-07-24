namespace ToyGraf.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ToyGraf.Models;

    #region Abstract Base Command

    public abstract class Command<TValue> : ICommand
    {
        protected Command(object subject) { Subject = subject; }

        public object Subject { get; private set; }
        public abstract string RedoAction { get; }
        public abstract string UndoAction { get; }
        public TValue Value { get; set; }

        /// <summary>
        /// Invoke the Run method of the command, then immediately invert
        /// the command in readiness for its transfer between the Undo and
        /// Redo stacks. Since most commands are their own inverses (they
        /// just tell the Scene "Swap your property value with the one I'm
        /// carrying", the Invert() method is almost always empty. See the
        /// SceneInsertTraceCommand and SceneDeleteTraceCommand classes
        /// for two notable exceptions to this rule.
        /// </summary>
        /// <param name="scene"></param>
        public bool Do(Scene scene)
        {
            var result = Run(scene);
            Invert();
            return result;
        }

        public virtual void Invert() { }
        public abstract bool Run(Scene scene);

        protected string Detail { get; set; }
        protected abstract string Target { get; }
    }

    #endregion

    #region Abstract Property Commands

    public abstract class PropertyCommand<TItem, TValue> : Command<TValue>, IPropertyCommand
    {
        protected PropertyCommand(object subject, string detail,
            TValue value, Func<TItem, TValue> get, Action<TItem, TValue> set)
            : base(subject)
        {
            Detail = detail;
            Value = value;
            Get = get;
            Set = set;
        }

        public override string RedoAction => Action;
        public override string UndoAction => Action;

        public override bool Run(Scene scene)
        {
            TValue value = GetValue(scene);
            var result = !Equals(value, Value);
            if (result)
            {
                SetValue(scene, Value);
                Value = value;
            }
            return result;
        }

        public override string ToString() => $"{Target} {Detail} = {Value}";
        private string Action => $"{Detail} change";

        protected Func<TItem, TValue> Get;
        protected Action<TItem, TValue> Set;

        protected abstract TItem GetItem(Scene scene);
        protected TValue GetValue(Scene scene) => Get(GetItem(scene));
        protected void SetValue(Scene scene, TValue value) => Set(GetItem(scene), value);
    }

    public abstract class ScenePropertyCommand<TValue> : PropertyCommand<Scene, TValue>, IScenePropertyCommand
    {
        protected ScenePropertyCommand(string detail,
            TValue value, Func<Scene, TValue> get, Action<Scene, TValue> set)
            : base(0, detail, value, get, set) { }

        public void RunOn(Scene scene) => Set(scene, Value);
        protected override string Target => "scene";
        protected override Scene GetItem(Scene scene) => scene;
    }

    public abstract class TracePropertyCommand<TValue> : PropertyCommand<Trace, TValue>, ITracePropertyCommand
    {
        protected TracePropertyCommand(Trace trace, string detail,
            TValue value, Func<Trace, TValue> get, Action<Trace, TValue> set)
            : base(trace, detail, value, get, set) { }

        public void RunOn(Trace trace) => Set(trace, Value);
        protected override string Target => $"Trace";
        protected override Trace GetItem(Scene scene) => (Trace)Subject;
    }

    #endregion

    #region Collection Commands

    /// <summary>
    /// Common ancestor for collection management (item insert and delete) commands.
    /// Those descendant classes differ only in the value of a private boolean flag,
    /// "Adding", which controls their appearance and behaviour. While most commands
    /// are their own inverses, since they just tell the Scene "Swap your property
    /// value with the one I'm carrying", the Invert() method is usually empty. But
    /// in the case of these commands, toggling the "Adding" flag converts one into
    /// the other, prior to the command processor moving them between the Undo and
    /// Redo stacks.
    /// </summary>
    public abstract class CollectionCommand<TItem> : Command<TItem>, ICollectionCommand
    {
        internal CollectionCommand(int index, bool add) : base(index) { Adding = add; }

        public int Index => (int)Subject;

        public bool Adding { get; set; }
        public override string RedoAction => GetAction(false);
        public override string UndoAction => GetAction(true);

        public override void Invert() { Adding = !Adding; }
        public override string ToString() => $"{(Adding ? "Add" : "Remove")} {Target}";

        public override bool Run(Scene scene)
        {
            var count = GetItemsCount(scene);
            if (Adding)
            {
                if (Value == null)
                    Value = GetNewItem(scene);
                if (Index >= 0 && Index < count)
                    InsertItem(scene);
                else if (Index == count)
                    AddItem(scene);
            }
            else
                RemoveItem(scene);
            return true;
        }

        protected abstract int GetItemsCount(Scene scene);
        protected abstract TItem GetNewItem(Scene scene);

        protected abstract void AddItem(Scene scene);
        protected abstract void InsertItem(Scene scene);
        protected abstract void RemoveItem(Scene scene);

        private string GetAction(bool undo) => $"{Detail} {(Adding ^ undo ? "addition" : "removal")}";
    }

    public class TracesCommand : CollectionCommand<Trace>, ITracesCommand
    {
        internal TracesCommand(int index, bool add) : base(index, add) { Detail = "trace"; }

        protected override string Target => "Trace";
        protected override int GetItemsCount(Scene scene) => scene.Traces.Count;
        protected override Trace GetNewItem(Scene scene) => scene.NewTrace(Index);

        protected override void AddItem(Scene scene) => scene.AddTrace(Value);
        protected override void InsertItem(Scene scene) => scene.InsertTrace(Index, Value);
        protected override void RemoveItem(Scene scene) => scene.RemoveTrace(Index);
    }

    #endregion
}
