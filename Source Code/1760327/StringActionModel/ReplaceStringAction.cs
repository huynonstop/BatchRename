using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Controls;
using _1760327.Model;
using System.IO;
using System.Windows;

namespace _1760327.StringActionModel
{
    public class ReplaceStringArgs : StringArgs, INotifyPropertyChanged
    {
        private string _needle;
        private string _hammer;
        public bool CheckArgs()
        {

            if (Needle == "" || Needle == null) return false;
            if (Hammer == "" || Hammer == null) return false;
            if (Needle.IndexOfAny(new char[] { '/', '\\' , ':', '*' ,'?' ,'"' ,'<' ,'>' ,'|'}) != -1)
                return false;
            if (Hammer.IndexOfAny(new char[] { '/', '\\', ':', '*', '?', '"', '<', '>', '|' }) != -1)
                return false;
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public string Needle
        {
            get => _needle;
            set
            {
                _needle = value;
                NotifyChange("Needle");
                NotifyChange("Details");
            }
        }
        public string Hammer
        {
            get => _hammer;
            set
            {
                _hammer = value;
                NotifyChange("Hammer");
                NotifyChange("Details");
            }
        }
        public string Details => $"Replace \"{Needle }\" with \"{Hammer }\"";
        public override string ToString()
        {
            return "<Args>\n" + $"{Needle}\n{Hammer}\n<\\>\n";
        }
        private void NotifyChange(string v)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(v));
            }
        }
        //ReplaceArgsList
        // Needle
        // Hammer
        public string setArgs(List<string> argsList)
        {
            Needle = argsList[0];
            Hammer = argsList[1];
            return argsList.ToString();
        }
    }
    public class ReplaceStringAction : StringAction
    {
        public string Name => "Replace String Action";
        public StringMethod Method => _replace;

        private string _replace(string origin)
        {
            var myArgs = Args as ReplaceStringArgs;
            var needle = myArgs.Needle;
            var hammer = myArgs.Hammer;

            string result = origin.Replace(needle, hammer);

            return result;
        }

        public StringArgs Args { get; set; }
        public StringAction Clone()
        {
            return new ReplaceStringAction()
            {
                Args = new ReplaceStringArgs()
            };
        }
        public override string ToString()
        {
            return "<Action>\n" + $"{Name}\n" + Args.ToString();
        }
        public void ShowEditDialog(ListView listView,ListBox methodListBox)
        {
            ReplaceArgsDialog dialog = new ReplaceArgsDialog(Args as ReplaceStringArgs);

            if (dialog.ShowDialog() == true )
            {
                var myArgs = Args as ReplaceStringArgs;
                var temp1 = myArgs.Needle;
                var temp2 = myArgs.Hammer;
                myArgs.Needle = dialog.Needle;
                myArgs.Hammer = dialog.Hammer;
                if (myArgs.CheckArgs())
                {
                    MyAppItem.ReloadList(listView, methodListBox);
                }
                else
                {
                    myArgs.Needle = temp1;
                    myArgs.Hammer = temp2;
                    MessageBox.Show("Invalid Input");
                }
                //if (listView.Name == "filesListView")
                //{
                //    foreach (var item in listView.ItemsSource as BindingList<ItemFile>)
                //    {
                //        item.GetNewName(methodListBox.ItemsSource as BindingList<ItemMethod>);
                //    }
                //}
            }
           
        }
    }
}
