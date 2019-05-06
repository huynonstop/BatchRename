using _1760327.StringActionModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1760327.Model
{
    public class ItemMethod : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool _isActive = false;
        public StringAction Item { get; }
        public bool IsActive
        {
            get => _isActive;
            set
            {
                _isActive = value;
                NotifyChange("IsActive");
            }
        }

        private void NotifyChange(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(v));
            }
        }

        ItemMethod() { Item = null; IsActive = false; }
        public override string ToString()
        {
            return "<ItemMethod>\n" + IsActive.ToString()+"\n" + Item.ToString();
        }
        public ItemMethod(ItemMethod method)
        {
            IsActive = method.IsActive;
            Item = method.Item;
        }
        public ItemMethod(string name, BindingList<StringAction> prototypes)
        {
            foreach(var prototype in prototypes)
            {
                if(name == prototype.Name)
                {
                    Item = prototype.Clone();
                    break;
                }
            }
            IsActive = false;
        }
        /*
         * item method preset format
         * <ItemMethod>
         *  IsActive                0
         * <Action>                 1
         *  StringAction.Name       2
         * <Args>                   3
         *  StringAction.Args       4
         *  ...                     ...
         *  StringAction.Args       preset.Count -1
         * <\>
         */
        public ItemMethod(List<string> itemMethodPreset, BindingList<StringAction> prototypes)
        {
            foreach (var prototype in prototypes)
            {
                if (itemMethodPreset[2] == prototype.Name)
                {
                    Item = prototype.Clone();
                    break;
                }
            }
            IsActive = (itemMethodPreset[0] == "True");
            List<string> argsList = new List<string>();
            for(int i = 4; i < itemMethodPreset.Count; i++)
            {
                argsList.Add(itemMethodPreset[i]);
            }
            Item.Args.setArgs(argsList);
        }
    }
}
