using System;
using System.Windows.Forms;

namespace EPII.UI.WinForms
{
    public partial class DateField : FieldControl
    {
        public event EventHandler ValueChanged
        {
            add { (GetContent() as DateTimePicker).ValueChanged += value; }
            remove { (GetContent() as DateTimePicker).ValueChanged -= value; }
        }

        public DateTime SelectedDate
        {
            get { return (GetContent() as DateTimePicker).Value; }
            set { (GetContent() as DateTimePicker).Value = value; }
        }

        public DateField()
        {
            var picker = new DateTimePicker();
            SetContent(picker);
        }
    }
}