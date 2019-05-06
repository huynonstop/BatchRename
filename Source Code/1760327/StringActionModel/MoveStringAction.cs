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
    public class MoveStringActionArgs : StringArgs, INotifyPropertyChanged
    {
        string[] _des = { "head","tail"};
        int _typeMove = 0;
        int _index = 0;
        int _length = 0;
        public bool CheckArgs()
        {
            if(TypeMove == 0 || TypeMove == 1)
            {
                if(Index >=0 && Length >= 0)
                {
                    return true;
                }
            }
            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public int TypeMove
        {
            get => _typeMove;
            set
            {
                _typeMove = value;
                NotifyChange("TypeMove");
                NotifyChange("Details");
            }
        }
        public int Index
        {
            get => _index;
            set
            {
                _index = value;
                NotifyChange("Details");
                NotifyChange("Index");
            }
        }
        public int Length
        {
            get => _length;
            set
            {
                _length = value;
                NotifyChange("Length");
                NotifyChange("Details");
            }
        }
        public string Details => "Move to: " + _des[_typeMove] + $" Start index: {Index} Length: {Length}" ;
        public override string ToString()
        {
            return "<Args>\n" + $"{TypeMove}\n{Index}\n{Length}\n<\\>\n";
        }
        private void NotifyChange(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(v));
            }
        }
        //MoveStringActionArgsList
        // TypeCase
        public string setArgs(List<string> argsList)
        {
            TypeMove = int.Parse(argsList[0]);
            Index = int.Parse(argsList[1]);
            Length = int.Parse(argsList[2]);
            return argsList.ToString();
        }
    }
    public class MoveStringAction : StringAction
    {
        public string Name => "Move String Action";
        public StringMethod Method => _move;

        private string _move(string origin)
        {
            var myArgs = Args as MoveStringActionArgs;
            int TypeMove = myArgs.TypeMove;
            int Length = myArgs.Length;
            int Index = myArgs.Index;
            
            string result = origin;
            string subString = "";

            //chuoi move 012345 6
            if (Index + Length - 1 >= origin.Length)//qua dai
            {
                Length = origin.Length - Index;//set ve lai vua du
            }
            if(Index < origin.Length)
            {
                subString = result.Substring(Index, Length);
                result = result.Remove(Index, Length);
            }
            if (TypeMove == 0)
            {
                result = subString + result;
            }
            else
            {
                result = result + subString;
            }
            return result;
        }

        public StringArgs Args { get; set; }
        public StringAction Clone()
        {
            return new MoveStringAction()
            {
                Args = new MoveStringActionArgs()
            };
        }
        public override string ToString()
        {
            return "<Action>\n" + $"{Name}\n" + Args.ToString();
        }
        public void ShowEditDialog(ListView listView, ListBox methodListBox)
        {
            MoveStringArgsDialog dialog = new MoveStringArgsDialog(Args as MoveStringActionArgs);

            if (dialog.ShowDialog() == true)
            {
                var myArgs = Args as MoveStringActionArgs;
                myArgs.TypeMove = dialog.TypeMove;
                myArgs.Length = dialog.Length;
                myArgs.Index = dialog.Index;

                if (myArgs.CheckArgs())
                {
                    MyAppItem.ReloadList(listView, methodListBox);
                }
            }
        }
    }
}
