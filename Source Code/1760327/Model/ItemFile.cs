using System;
using System.ComponentModel;
using System.IO;

namespace _1760327.Model
{
    public class ItemFile : INotifyPropertyChanged
    {
        protected string _fullPath;
        protected string _name;
        protected string _upperPath;
        protected string _error;
        protected string _newName;
        private string _extension;
        public string FullPath
        {
            get => _fullPath;
            set
            {
                _fullPath = value;
                NotifyChange("FullPatch");
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                NotifyChange("Name");
            }
        }
        public string UpperPath
        {
            get => _upperPath;
            set
            {
                _upperPath = value;
                NotifyChange("UpperPath");
            }
        }
        public string Error
        {
            get => _error;
            set
            {
                _error = value;
                NotifyChange("Error");
            }
        }
        public string NewName
        {
            get => _newName;
            set
            {
                _newName = value;
                NotifyChange("NewName");
            }
        }

        public string Extension
        {
            get => _extension;
            set
            {
                _extension = value;
                NotifyChange("Extension");
            }
        }
        protected ItemFile()
        {
            _fullPath = null;
            _name = null;
            _upperPath = null;
            _error = null;
            _newName = null;
            _extension = null;
        }
        public ItemFile(string path)
        {
            if (File.Exists(path))
            {
                FullPath = path;
                Name = Path.GetFileNameWithoutExtension(path);
                Extension = Path.GetExtension(path);
                UpperPath = Directory.GetParent(path).ToString();
            }
        }
        public ItemFile(string path, BindingList<ItemMethod> methodList, BindingList<ItemFile> listItem)
        {
            if (File.Exists(path))
            {
                FullPath = path;
                Name = Path.GetFileNameWithoutExtension(path);
                Extension = Path.GetExtension(path);
                UpperPath = Directory.GetParent(path).ToString();
                this.GetNewName(methodList, listItem);
                Error = this.GetNewError(listItem);
            }
        }
        public bool SetNewPath(BindingList<ItemMethod> methodList, BindingList<ItemFile> listItem)
        {
            string newPath = GetFullNewPath();
            if (!File.Exists(newPath))
            {
                File.Move(this.FullPath, newPath);
                FullPath = newPath;
                Name = Path.GetFileNameWithoutExtension(newPath);
                Extension = Path.GetExtension(newPath);
                UpperPath = Directory.GetParent(newPath).ToString();
                this.GetNewName(methodList, listItem);
                Error = this.GetNewError(listItem);
                return true;
            }
            //else if (NewName.ToLower() == Name.ToLower())
            //{
            //    string tempPath = this.UpperPath + "\\" + this.Name + "_Temp" + this.Extension;
            //    File.Move(this.FullPath, tempPath); 
            //    File.Move(tempPath, newPath);
            //    FullPath = newPath;
            //    Name = Path.GetFileNameWithoutExtension(newPath);
            //    Extension = Path.GetExtension(newPath);
            //    UpperPath = Directory.GetParent(newPath).ToString();
            //    this.GetNewName(methodList, listItem);
            //    Error = this.GetkNewError(listItem);
            //    return true;
            //}
            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyChange(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(v));
            }
        }
        /// <summary>
        /// lay new name
        /// </summary>
        /// <param name="methodList"></param>
        public void GetNewName(BindingList<ItemMethod> methodList, BindingList<ItemFile> listItem)
        {
            if (File.Exists(FullPath))
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
        public string GetFullNewPath()
        {
            return UpperPath + "\\" + NewName + Extension;
        }
        public string GetNewError(BindingList<ItemFile> listItem)
        {           
            try
            {
                if (File.Exists(FullPath))
                {
                    if(NewName != null && NewName != "")
                    {   
                       
                        if (NewName == Name)
                        {
                            return "OK";
                        }
                        //if(NewName.ToLower() == Name.ToLower())
                        //{
                        //    return "OK";
                        //}
                        if (File.Exists(this.GetFullNewPath()))
                        {
                            return "New Name conflict";
                        }
                        string fullNewName = this.GetFullNewPath();
                        int count = 0;
                        foreach (ItemFile item in listItem)
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
                    return "File not Exists";
                }
            }
            catch(Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
