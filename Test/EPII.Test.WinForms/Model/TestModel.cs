using System;

namespace EPII.Test.WinForms
{
    public class TestModel
    {
        private DateTime _Time;
        private string _Text;

        public DateTime Time 
        {
            get { return _Time; }
            set { _Time = value; }
        }

        public string Text 
        {
            get { return _Text; }
            set { _Text = value; }
        }
    }
}
