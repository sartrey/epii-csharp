using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace EPII.UI.WinForms
{
    public partial class SelectField : FieldControl
    {
        public class OptionItem 
        {
            private string _Text;
            private object _Value;

            public string Text 
            {
                get { return _Text; }
            }

            public object Value 
            {
                get { return _Value; }
            }

            public OptionItem(string text, object value)
            {
                _Text = text;
                _Value = value;
            }
        }

        private List<OptionItem> _Options 
            = new List<OptionItem>();

        [Browsable(false)]
        public bool HasSelected 
        {
            get { return 
                (GetContent() as ComboBox).SelectedIndex >= 0; }
        }

        [Browsable(false)]
        public object SelectedValue 
        {
            get 
            {
                var index = (GetContent() as ComboBox).SelectedIndex;
                if (index < 0)
                    return null;
                var item = _Options[index];
                return item.Value;
            }
        }

        public SelectField()
        {
            var combobox = new ComboBox();
            combobox.DropDownStyle = ComboBoxStyle.DropDownList;
            SetContent(combobox);
        }

        public void AddOption(string text, object value) 
        {
            var option = new OptionItem(text, value);
            _Options.Add(option);
            (GetContent() as ComboBox).Items.Add(text);
        }
    }
}
