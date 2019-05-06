using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Controls;
using _1760327.Model;
using System.IO;
using System.Globalization;
using System.Windows;

namespace _1760327.StringActionModel
{
    public class FullNameStringActionArgs : StringArgs, INotifyPropertyChanged
    {
        public string Details { get; } = "Get fullname normalize string";
        public event PropertyChangedEventHandler PropertyChanged;
        public override string ToString()
        {
            return "<Args>\n<\\>\n";
        }
        public bool CheckArgs()
        {
            return true;
        }
        //FullNameStringActionArgsList
        public string setArgs(List<string> argsList)
        {
            return argsList.ToString();
        }
    }
    public class FullNameStringAction : StringAction
    {
        public string Name => "Name Normalize String Action";
        public StringMethod Method => _fullNameNormalize;

        private string _fullNameNormalize(string origin)
        {
            string result = origin;
            result = result.Trim();
            result = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(result.ToLower());
            return result;
        }

        public StringArgs Args { get; set; }
        public StringAction Clone()
        {
            return new FullNameStringAction()
            {
                Args = new FullNameStringActionArgs()
            };
        }

        public override string ToString()
        {
            return "<Action>\n" + $"{Name}\n" + Args.ToString();
        }
        public void ShowEditDialog(ListView listView, ListBox methodListBox)
        {
            MessageBox.Show("Can not Edit");
        }
    }
}
