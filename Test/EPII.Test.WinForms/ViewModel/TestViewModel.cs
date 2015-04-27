using EPII.FEA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPII.Test.WinForms
{
    public class TestViewModel : IViewModel
    {
        //private DateTime _Time;
        //private string _Text;
        private TestModel _Model;

        public DateTime Time 
        {
            get 
            {
                //return _Time;
                return _Model.Time; 
            }
            set 
            {
                //_Time = value;
                _Model.Time = value;
                //do something
                Mark("Time");
                Sync("Time");
            }
        }

        public string Text 
        {
            get 
            {
                //return _Text;
                return _Model.Text; 
            }
            set 
            {
                //_Text = value;
                _Model.Text = value; 
                //do something
                Mark("Time");
                Sync("Time");
            }
        }

        public TestViewModel(TestModel model) 
        {
            //_Time = model.Time;
            //_Text = model.Text;
            _Model = model;
        }

        public void Mark(string name)
        {
            throw new NotImplementedException();
        }

        public void Sync(string name)
        {
            throw new NotImplementedException();
        }

        public void Undo(string name)
        {
            throw new NotImplementedException();
        }
    }
}
