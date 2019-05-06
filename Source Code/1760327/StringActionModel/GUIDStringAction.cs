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
    public class GUIDStringActionArgs : StringArgs, INotifyPropertyChanged
    {
        public string Details { get; } = "Get GUID string";
        public event PropertyChangedEventHandler PropertyChanged;
        public override string ToString()
        {
            return "<Args>\n<\\>\n";
        }
        public bool CheckArgs()
        {
            return true;
        }
        //GUIDStringActionArgsList
        public string setArgs(List<string> argsList)
        {
            return argsList.ToString();
        }
    }
    class GUIDStringAction : StringAction
    {
        public string Name => "GUID String Action";
        public StringMethod Method => _guid;

        private string _guid(string origin)
        {
            string result = Guid.NewGuid().ToString();
            return result;
        }

        public StringArgs Args { get; set; }
        public StringAction Clone()
        {
            return new GUIDStringAction()
            {
                Args = new GUIDStringActionArgs()
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
