using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1760327.Model
{
    public class ItemFolder : ItemFile, INotifyPropertyChanged
    {
        ItemFolder()
        {
            _fullPath = null;
            _name = null;
            _upperPath = null;
            _error = null;
            _newName = null;
        }
        public ItemFolder(string path, BindingList<ItemMethod> methodList, BindingList<ItemFolder> listItem)
        {
            if (Directory.Exists(path))
            {
                FullPath = path;
                Name = Path.GetFileNameWithoutExtension(path);
                Extension = Path.GetExtension(FullPath);
                UpperPath = Directory.GetParent(path).ToString();
                this.GetNewName(methodList, listItem);
                Error = this.GetNewError(listItem);
            }
        }
        public bool SetNewPath(BindingList<ItemMethod> methodList, BindingList<ItemFolder> listItem)
        {
         string newPath = GetFullNewPath();
            if (!Directory.Exists(newPath))
            {
                Directory.Move(this.FullPath, newPath);
                FullPath = newPath;
                Name = Path.GetFileNameWithoutExtension(newPath);
                Extension = Path.GetExtension(newPath);
                UpperPath = Directory.GetParent(newPath).ToString();
                this.GetNewName(methodList, listItem);
                Error = this.GetNewError(listItem);
            }
            return false;
        }
        public void GetNewName(BindingList<ItemMethod> methodList, BindingList<ItemFolder> listItem)
        {
            if (Directory.Exists(FullPath))
            {
                NewName = Name;
                foreach (ItemMethod action in methodList)
                {
                    if (action.IsActive)
                    {
                        NewName = action.Item.Method.Invoke(NewName);
                    }
                }
                Error = this.GetNewError(listItem);
            }
            else
            {
                //listItem.Remove(this);
                Error = this.GetNewError(listItem);
            }
        }
        public new string GetFullNewPath()
        {
            return UpperPath + "\\" + NewName;
        }
        public string GetNewError(BindingList<ItemFolder> listItem)
        {
            try
            {
                if (Directory.Exists(FullPath))
                {
                    if (NewName != null && NewName != "")
                    {

                        if (NewName == Name)
                        {
                            return "OK";
                        }
                        if (Directory.Exists(this.GetFullNewPath()))
                        {
                            return "New Name conflict";
                        }
                        string fullNewName = this.GetFullNewPath();
                        int count = 0;
                        foreach (ItemFolder item in listItem)
                        {
                            string itemFullNewName = item.GetFullNewPath();
                            if (fullNewName == itemFullNewName)
                            {
                                if (count != 0)
                                {
                                    return "New Name conflict";
                                }
                                else
                                {
                                    count++;
                                }
                            }
                            if (fullNewName == item.FullPath)
                            {
                                return "New Name conflict";
                            }
                        }
                        return "OK";
                    }
                    else
                    {
                        return "No set new name";
                    }
                }
                else
                {
                    return "Folder not Exists";
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
   