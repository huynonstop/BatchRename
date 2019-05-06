using _1760327.Model;
using _1760327.StringActionModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1760327
{
    class Preset
    {
        BindingList<ItemMethod> _list;
        public BindingList<ItemMethod> List
        {
            get => _list;
        }
        private Preset()
        {

            _list = null;
        }
        public Preset(BindingList<ItemMethod> listMethod)
        {
            _list = new BindingList<ItemMethod>(listMethod);
        }
        public Preset(string presetPath, BindingList<StringAction> prototypes)
        {
            _list = new BindingList<ItemMethod>();
            string line;

            using (StreamReader fReadStream = new StreamReader(presetPath))
            {
                while((line = fReadStream.ReadLine()) != null)
                {
                    if (!line.Contains("<ItemMethod>"))
                    {
                        List<string> itemMethodPreset = new List<string>();
                        while (!line.Contains("<\\>"))
                        {
                            itemMethodPreset.Add(line);
                            line = fReadStream.ReadLine();
                        }
                        ItemMethod newItem = new ItemMethod(itemMethodPreset, prototypes);
                        _list.Add(newItem);
                    }
                }
            }
        }
        public string ToFile(string presetPath)
        {
            File.Delete(presetPath);
            foreach(var item in List)
            {
                File.AppendAllText(presetPath, item.ToString());
            }
            return presetPath;
        }
    }
}
