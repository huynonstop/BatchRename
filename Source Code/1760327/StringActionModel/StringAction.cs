using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace _1760327.StringActionModel
{
    public delegate string StringMethod(string origin);
    public interface StringArgs
    {
        string Details { get; }
        bool CheckArgs();
        string ToString();
        string setArgs(List<string> argsList);
    }
    public interface StringAction
    {
        string Name { get; }
        StringMethod Method { get; }
        StringArgs Args { get; set; }
        StringAction Clone();
        void ShowEditDialog(ListView listView,ListBox methodListBox);
        string ToString();
    }
    //public class StringActionFactory
    //{
    //    public string Name { get; } = "StringActionFactory";
    //    public StringAction FactoryMethod(string name)
    //    {
    //        if(name == "ReplaceAction")
    //        {
    //            return new ReplaceAction()
    //            {
    //                Args = new ReplaceArgs()
    //            };
    //        }
    //        else if (name == "NewCaseStringAction")
    //        {
    //            return new NewCaseStringAction()
    //            {
    //                Args = new NewCaseStringActionArgs()
    //            };
    //        }
    //        else
    //            return null;
    //    }
    //}
}
