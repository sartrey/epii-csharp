using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace EPII.UI.WinForms
{
    [ToolboxItem(false)]
    public class View : UserControl
    {
        protected static object _Mutex = null;

        protected Table<Delegate> _Handlers
            = new Table<Delegate>();
        protected object _Model = null;

        public object Model
        {
            get { return _Model; }
            set
            {
                if (value != null && value.Equals(_Model))
                    return;
                _Model = value;
                if (!UpdateModel(true))
                    throw new ArgumentException();
            }
        }

        public virtual bool IsMutexView
        {
            get { return false; }
        }

        public View()
        {
            if (IsMutexView) {
                if (_Mutex != null)
                    throw new InvalidOperationException();
                else
                    _Mutex = new object();
            }
        }

        public View(object model)
            : this()
        {
            _Model = model;
        }

        /// <summary>
        /// <para>update model with view</para>
        /// <para>update model to view if render is true</para>
        /// <para>update view to model if render is false</para>
        /// </summary>
        public virtual bool UpdateModel(bool render = true)
        {
            return true;
        }

        protected virtual void ApplyStyle() 
        {
        }

        protected virtual void OnParentClosing(FormClosingEventArgs e)
        {
        }

        protected virtual void OnParentShown()
        {
        }

        protected override void OnParentChanged(EventArgs e)
        {
            var window = Parent as WindowEx;
            if (window != null) {
                var handler_shown = new EventHandler(
                    (a, b) => { OnParentShown(); });
                var handler_closing = new FormClosingEventHandler(
                    (a, b) => { OnParentClosing(b); });
                window.Shown += handler_shown;
                window.FormClosing += handler_closing;
                _Handlers["shown"] = handler_shown;
                _Handlers["closing"] = handler_closing;
            }
            base.OnParentChanged(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            try {
                ApplyStyle();
            } catch {
                Console.WriteLine("failed to apply style");
            }
            base.OnLoad(e);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                var window = Parent as WindowEx;
                var handler_shown = _Handlers["shown"] as EventHandler;
                var handler_closing = _Handlers["closing"] as FormClosingEventHandler;
                if (handler_shown != null)
                    window.Shown -= handler_shown;
                if (handler_closing != null)
                    window.FormClosing -= handler_closing;
                _Handlers.Clear();
                if (IsMutexView)
                    _Mutex = null;
            }
            base.Dispose(disposing);
        }

        protected void FinishDialog(DialogResult result)
        {
            var window = Parent as WindowEx;
            window.FinishDialog(result);
        }
    }
}