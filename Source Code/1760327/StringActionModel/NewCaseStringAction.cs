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

namespace _1760327.StringActionModel
{
    public class NewCaseStringActionArgs : StringArgs, INotifyPropertyChanged
    {
        string[] _detail = { "1.Upper Case", "2.Lower Case", "3.Proper Case" };
        int _typeCase = 0;
        public bool CheckArgs()
        {
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public int TypeCase
        {
            get => _typeCase;
            set
            {
                _typeCase = value;
                NotifyChange("TypeCase");
                NotifyChange("Details");
            }
        }
        public string Details => _detail[_typeCase];

        private void NotifyChange(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(v));
            }
        }
        public override string ToString()
        {
            return "<Args>\n" + $"{TypeCase}\n<\\>\n";
        }
        //NewCaseStringActionArgsList
        // TypeCase
        public string setArgs(List<string> argsList)
        {
            TypeCase = int.Parse(argsList[0]);
            return argsList.ToString();
        }
    }
    public class NewCaseStringAction : StringAction
    {
        public string Name => "New Case String Action";
        public StringMethod Method => _newCase;

        private string _newCase(string origin)
        {
            var myArgs = Args as NewCaseStringActionArgs;
            int myCase = myArgs.TypeCase;
            string result = origin;
            switch (myCase)
            {
                case 0:
                    result = result.ToUpper();
                    break;
                case 1:
                    result = result.ToLower();
                    break;
                case 2:
                    result = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(result.ToLower());
                    break;
                default:
                    break;
            }
            return result;
        }

        public StringArgs Args { get; set; }
        public StringAction Clone()
        {
            return new NewCaseStringAction()
            {
                Args = new NewCaseStringActionArgs()
            };
        }
        public override string ToString()
        {
            return "<Action>\n" + $"{Name}\n" + Args.ToString();
        }
        public void ShowEditDialog(ListView listView, ListBox methodListBox)
        {
            NewCaseStringArgsDialog dialog = new NewCaseStringArgsDialog(Args as NewCaseStringActionArgs);

            if (dialog.ShowDialog() == true)
            {
                var myArgs = Args as NewCaseStringActionArgs;
                myArgs.TypeCase = dialog.TypeCase;
                if (myArgs.CheckArgs())
                {
                    MyAppItem.ReloadList(listView, methodListBox);
                }
            }
        }
    }
}
