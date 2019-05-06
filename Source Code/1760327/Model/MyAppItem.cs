using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.IO;
using System.Windows;

namespace _1760327.Model
{
    public class MyAppItem
    {
        /// <summary>
        /// refresh all item in a listview 
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="methodListBox"></param>
        public static void ReloadList(ListView listView, ListBox methodListBox)
        {
            MyAppItem.RemoveItemNotExist(listView);
            if (listView.Name == "filesListView")
            {
                foreach (var item in listView.ItemsSource as BindingList<ItemFile>)
                {
                    if (item.Error != "File not Exists")
                    {
                        //get new name new error status
                        item.GetNewName(methodListBox.ItemsSource as BindingList<ItemMethod>, listView.ItemsSource as BindingList<ItemFile>);
                    }
                    else
                    {
                        MessageBox.Show("Bugged still have a not Existing file\n" + item.FullPath + " " + item.Error);
                    }
                }
            }
            else if (listView.Name == "folderListView")
            {
                foreach (var item in listView.ItemsSource as BindingList<ItemFolder>)
                {
                    if (item.Error != "File not Exists")
                    {
                        //get new name new error status
                        item.GetNewName(methodListBox.ItemsSource as BindingList<ItemMethod>, listView.ItemsSource as BindingList<ItemFolder>);
                    }
                    else
                    {
                        MessageBox.Show("Bugged still have a not Existing folder\n" + item.FullPath + " " + item.Error);
                    }
                }
            }
        }
        /// <summary>
        /// clear all item not Existing
        /// </summary>
        /// <param name="listView"></param>
        public static void RemoveItemNotExist(ListView listView)
        {
            if (listView.Name == "filesListView")
            {
                var itemList = listView.ItemsSource as BindingList<ItemFile>;
                for(int i=0; i < itemList.Count(); i++)
                {
                    if(!File.Exists(itemList[i].FullPath))
                    {
                        itemList.RemoveAt(i);
                    }
                }
            }
            else if (listView.Name == "folderListview")
            {
                var itemList = listView.ItemsSource as BindingList<ItemFolder>;
                for (int i = 0; i < itemList.Count(); i++)
                {
                    if (!Directory.Exists(itemList[i].FullPath))
                    {
                        itemList.RemoveAt(i);
                    }
                }
            }
        }
        public static void Move<T>(BindingList<T> listItem,int firstIndex,int secondIndex)
        {
            if(secondIndex >= 0 && secondIndex < listItem.Count)
            {
                T temp = listItem[firstIndex];
                listItem.RemoveAt(firstIndex);
                listItem.Insert(secondIndex, temp);
                listItem.ResetBindings();
            }
        }
        public static void StartBatch(ListView listView, ListBox methodListBox,bool isSkip)
        {
            int nochange = 0;
            int success = 0;
            int skip = 0;
            int error = 0;
            if (listView.Name == "filesListView")
            {
                var listItem = listView.ItemsSource as BindingList<ItemFile>;
                foreach (var item in listItem) // O(n)
                {
                    if (item.Error == "New Name conflict")
                    {
                        if (isSkip == true)
                        {
                            item.Error = "Skipped";
                            skip++;
                        }
                        else
                        {
                            int i = 1;
                            string tempNewName = item.NewName;
                            while (File.Exists(item.GetFullNewPath()) && item.Error != "OK")
                            {
                                item.NewName = tempNewName + $" ({i})";
                                item.Error = item.GetNewError(listItem);// O(n)
                                i++;
                            }
                            if (item.SetNewPath(methodListBox.ItemsSource as BindingList<ItemMethod>,
                                            listItem))
                            {
                                success++;
                            }
                            else
                            {
                                nochange++;
                            }
                        }                       
                    }
                    else if (item.Error == "OK")
                    {
                        if (item.SetNewPath(methodListBox.ItemsSource as BindingList<ItemMethod>,
                                           listItem))
                        {
                            success++;
                        }
                        else
                        {
                            nochange++;
                        }                       
                    }
                    else
                    {
                        error++;
                        MessageBox.Show(item.FullPath + "\n" + item.Error);
                    }
                } //O(n^2)
            }
            else if (listView.Name == "folderListView")
            {
                var listItem = listView.ItemsSource as BindingList<ItemFolder>;
                foreach (var item in listItem) // O(n)
                {
                    if (item.Error == "New Name conflict")
                    {
                        if (isSkip == true)
                        {
                            item.Error = "Skipped";
                            skip++;
                        }
                        else
                        {
                            int i = 1;
                            string tempNewName = item.NewName;
                            while (Directory.Exists(item.GetFullNewPath()) && item.Error != "OK")
                            {
                                item.NewName = tempNewName + $" ({i})";
                                item.Error = item.GetNewError(listView.ItemsSource as BindingList<ItemFolder>);// O(n)
                                i++;
                            }
                            if (item.SetNewPath(methodListBox.ItemsSource as BindingList<ItemMethod>,
                                            listItem))
                            {
                                success++;
                            }
                            else
                            {
                                nochange++;
                            }
                        }
                    }
                    else if (item.Error == "OK")
                    {
                        if (item.SetNewPath(methodListBox.ItemsSource as BindingList<ItemMethod>,
                                           listItem))
                        {
                            success++;
                        }
                        else
                        {
                            nochange++;
                        }
                    }
                    else
                    {
                        error++;
                        MessageBox.Show(item.FullPath + "\n" + item.Error);
                    }
                } //O(n^2)
            }
            MessageBox.Show("Renamed: " + success + "\n" + "No Change: " + nochange + "\n"
                            + "Skipped: " + skip + "\n" + "Error: " + error + "\n");
        }
        /// <summary>
        /// check a new path to add to my item list
        /// </summary>
        /// <param name="path"></param>
        /// <param name="itemFiles"></param>
        /// <returns></returns>
        public static bool IsNewPathCanAdd(string path, BindingList<ItemFile> itemFiles)
        {
            foreach(var item in itemFiles)
            {
                if (path == item.FullPath)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
