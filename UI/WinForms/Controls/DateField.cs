namespace EPII.UI.WinForms
{
    using System;
    using System.Windows.Forms;

    public partial class DateField : FieldPanel
    {
        public event EventHandler ValueChanged
        {
            add { (Content as DateTimePicker).ValueChanged += value; }
            remove { (Content as DateTimePicker).ValueChanged -= value; }
        }

        public DateTime SelectedDate
        {
            get { return (Content as DateTimePicker).Value; }
            set { (Content as DateTimePicker).Value = value; }
        }

        public DateField()
        {
            var picker = new DateTimePicker();
            Content = picker;
        }
    }
}