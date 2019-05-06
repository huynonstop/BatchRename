using _1760327.Model;
using _1760327.StringActionModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _1760327
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {  
        BindingList<StringAction> _prototypes = null;
        BindingList<ItemMethod> _methodList = null;
        BindingList<ItemFile> _fileList = null;
        BindingList<ItemFolder> _folderList = null;
        BindingList<ItemMethod> _presetList = null;
        ListView _seclectingListView = null;
        private bool _isSkip = true;
        public MainWindow()
        {
            InitializeComponent();
            _prototypes = new BindingList<StringAction>()
            {
                new ReplaceStringAction(),
                new NewCaseStringAction(),
                new FullNameStringAction(),
                new GUIDStringAction(),
                new MoveStringAction()
            };

            _methodList = new BindingList<ItemMethod>();

            _fileList = new BindingList<ItemFile>();

            _folderList = new BindingList<ItemFolder>();

            _presetList = new BindingList<ItemMethod>();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          
            addMethodMenu.ItemsSource = _prototypes;
          
            methodListBox.ItemsSource = _methodList;
           
            filesListView.ItemsSource = _fileList;
          
            folderListView.ItemsSource = _folderList;

            presetComboBox.ItemsSource = _presetList;

            _seclectingListView = filesListView;
        }

        private void MenuMethod_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock prototypeBlock = sender as TextBlock;
            ItemMethod instance = new ItemMethod(prototypeBlock.Text, _prototypes);
            _methodList.Add(instance);
            if(instance.Item.Name != "Name Normalize String Action" && instance.Item.Name != "GUID String Action")
            {
                instance.Item.ShowEditDialog(_seclectingListView, methodListBox);
            }
        }

        private void ContextMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var method = methodListBox.SelectedItem as ItemMethod;
            method.Item.ShowEditDialog(_seclectingListView, methodListBox);    
        }

        private void FileAddButton_Click(object sender, RoutedEventArgs e)
        {
            //var screen = new OpenFileDialog();
            //screen.Multiselect = true;
            var folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            if (folderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK /*screen.ShowDialog() == true*/)
            {
                //foreach (var file in screen.FileNames)
                //{
                //    if (MyAppItem.IsNewPathCanAdd(file,_fileList)) // khi nao can add tu nhieu noi khac nhau, add nhieu lan
                //    {
                //        ItemFile newFile = new ItemFile(file, _methodList);
                //        _fileList.Add(newFile);
                //        consoleText.Text += $"added {file}\n";
                //    }
                //}
                _fileList.Clear();
                string folderPath = folderBrowser.SelectedPath;
                foreach (var file in Directory.GetFiles(folderPath))
                {
                    ItemFile newFile = new ItemFile(file, _methodList, _fileList);
                    //if (!MyAppItem.IsNewPathCanAdd(file, _fileList)) // khi nao can add tu nhieu noi khac nhau, add nhieu lan
                    //{
                    //    foreach(var item in _fileList)
                    //    {
                    //        if (item.FullPath == newFile.FullPath)
                    //        {
                    //            item.Error = "Already in list";
                    //            break;
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    _fileList.Add(newFile);
                    //}
                    if (File.Exists(file))
                    {
                        _fileList.Add(newFile);
                    }
                    else
                    {

                    }
                  
                }
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            MyAppItem.ReloadList(_seclectingListView, methodListBox);
            //Handling conflict
            MyAppItem.StartBatch(_seclectingListView, methodListBox, _isSkip);
        }

        private void Tab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Tab.SelectedIndex == 0 && _seclectingListView == filesListView) return;
            if (Tab.SelectedIndex == 1 && _seclectingListView == folderListView) return;
            if (Tab.SelectedIndex == 0)
            {
                _seclectingListView = filesListView;
            }
            else
            {
                _seclectingListView = folderListView;
            }
            if (_seclectingListView.ItemsSource != null)
            {
                MyAppItem.ReloadList(_seclectingListView, methodListBox);
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var method = methodListBox.SelectedItem as ItemMethod;
            if (method.Item.Args.CheckArgs() )
            {
                MyAppItem.ReloadList(_seclectingListView, methodListBox);
            }
            else
            {
                method.IsActive = false;
                MessageBox.Show("Invalid " + method.Item.Name + " Argument");
            }
            
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            MyAppItem.ReloadList(_seclectingListView, methodListBox);
        }

        private void DeleteMethod_Button(object sender, RoutedEventArgs e)
        {
            if(methodListBox.SelectedIndex != -1)
            {
                _methodList.RemoveAt(methodListBox.SelectedIndex);
                MyAppItem.ReloadList(_seclectingListView, methodListBox);
            }
        }

        private void ClearMethodMenuButton_Click(object sender, RoutedEventArgs e)
        {
            _methodList.Clear();
            MyAppItem.ReloadList(_seclectingListView, methodListBox);
        }

        private void Skip_Checked(object sender, RoutedEventArgs e)
        {
            _isSkip = true;
        }

        private void AddSuffixes_Checked(object sender, RoutedEventArgs e)
        {
            _isSkip = false;
        }

        private void FolderAddButton_Click(object sender, RoutedEventArgs e)
        {
            var folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            if (folderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK /*screen.ShowDialog() == true*/)
            {
                //foreach (var file in screen.FileNames)
                //{
                //    if (MyAppItem.IsNewPathCanAdd(file,_fileList)) // khi nao can add tu nhieu noi khac nhau, add nhieu lan
                //    {
                //        ItemFile newFile = new ItemFile(file, _methodList);
                //        _fileList.Add(newFile);
                //        consoleText.Text += $"added {file}\n";
                //    }
                //}
                _folderList.Clear();
                string folderPath = folderBrowser.SelectedPath;
                foreach (var folder in Directory.GetDirectories(folderPath))
                {
                    ItemFolder newFolder = new ItemFolder(folder, _methodList, _folderList);
                    //if (!MyAppItem.IsNewPathCanAdd(file, _fileList)) // khi nao can add tu nhieu noi khac nhau, add nhieu lan
                    //{
                    //    foreach(var item in _fileList)
                    //    {
                    //        if (item.FullPath == newFile.FullPath)
                    //        {
                    //            item.Error = "Already in list";
                    //            break;
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    _fileList.Add(newFile);
                    //}
                    if (Directory.Exists(folder))
                    {
                        _folderList.Add(newFolder);
                    }
                    else
                    {
                    }

                }
            }
        }

        private void MethodMenuTopButton_Click(object sender, RoutedEventArgs e)
        {
            int index = methodListBox.SelectedIndex;
            if (index != -1)
            {
                MyAppItem.Move(_methodList, index, 0);
                MyAppItem.ReloadList(_seclectingListView, methodListBox);
            }
        }

        private void MethodMenuUpButton_Click(object sender, RoutedEventArgs e)
        {
            int index = methodListBox.SelectedIndex;
            if (index != -1)
            {
                MyAppItem.Move(_methodList, index, index - 1);
                MyAppItem.ReloadList(_seclectingListView, methodListBox);
            }
        }

        private void MethodMenuDownButton_Click(object sender, RoutedEventArgs e)
        {
            int index = methodListBox.SelectedIndex;
            if (index != -1)
            {
                MyAppItem.Move(_methodList, index, index + 1);
                MyAppItem.ReloadList(_seclectingListView, methodListBox);
            }
        }

        private void MethodMenuBotButton_Click(object sender, RoutedEventArgs e)
        {
            int index = methodListBox.SelectedIndex;
            if (index != -1)
            {
                MyAppItem.Move(_methodList, index, _methodList.Count - 1);
                MyAppItem.ReloadList(_seclectingListView, methodListBox);
            }
        }

        private void FileMenuTopButton_Click(object sender, RoutedEventArgs e)
        {
            int index = _seclectingListView.SelectedIndex;
            if (index != -1)
            {
                MyAppItem.Move(_fileList, index, 0);
                MyAppItem.ReloadList(_seclectingListView, methodListBox);
            }
        }

        private void FileMenuUpButton_Click(object sender, RoutedEventArgs e)
        {
            int index = _seclectingListView.SelectedIndex;
            if (index != -1)
            {
                MyAppItem.Move(_fileList, index, index - 1);
                MyAppItem.ReloadList(_seclectingListView, methodListBox);
            }
        }

        private void FileMenuDownButton_Click(object sender, RoutedEventArgs e)
        {
            int index = _seclectingListView.SelectedIndex;
            if (index != -1)
            {
                MyAppItem.Move(_fileList, index, index + 1);
                MyAppItem.ReloadList(_seclectingListView, methodListBox);
            }
        }

        private void FileMenuBotButton_Click(object sender, RoutedEventArgs e)
        {
            int index = _seclectingListView.SelectedIndex;
            if (index != -1)
            {
                MyAppItem.Move(_fileList, index, _fileList.Count - 1);
                MyAppItem.ReloadList(_seclectingListView, methodListBox);
            }
        }

        private void FolderMenuTopButton_Click(object sender, RoutedEventArgs e)
        {
            int index = _seclectingListView.SelectedIndex;
            if (index != -1)
            {
                MyAppItem.Move(_folderList, index, 0);
                MyAppItem.ReloadList(_seclectingListView, methodListBox);
            }
        }

        private void FolderMenuUpButton_Click(object sender, RoutedEventArgs e)
        {
            int index = _seclectingListView.SelectedIndex;
            if (index != -1)
            {
                MyAppItem.Move(_folderList, index, index - 1);
                MyAppItem.ReloadList(_seclectingListView, methodListBox);
            }
        }

        private void FolderMenuDownButton_Click(object sender, RoutedEventArgs e)
        {
            int index = _seclectingListView.SelectedIndex;
            if (index != -1)
            {
                MyAppItem.Move(_folderList, index, index + 1);
                MyAppItem.ReloadList(_seclectingListView, methodListBox);
            }
        }

        private void FolderMenuBotButton_Click(object sender, RoutedEventArgs e)
        {
            int index = _seclectingListView.SelectedIndex;
            if (index != -1)
            {
                MyAppItem.Move(_folderList, index, _folderList.Count - 1);
                MyAppItem.ReloadList(_seclectingListView, methodListBox);
            }
        }
        //preset
        private void MethodMenuOpenButton_Click(object sender, RoutedEventArgs e)
        {
            var openDialog = new OpenFileDialog()
            {
                Title = "Save Preset",
                DefaultExt = "pre",
                Filter = "My preset files (*.pre)|*.pre",
                CheckFileExists = true,
                CheckPathExists = true
            };
            if(openDialog.ShowDialog() == true)
            {
                Preset preset = null;
                try
                {
                    preset = new Preset(openDialog.FileName, _prototypes);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error: File corupted" + ex.ToString());
                    return;
                }
                _presetList.Clear();
                foreach(var item in preset.List)
                {
                    var method = new ItemMethod(item);
                    _presetList.Add(method);
                }
                MyAppItem.ReloadList(_seclectingListView, methodListBox);
            }
        }

        private void MethodMenuSaveButton_Click(object sender, RoutedEventArgs e)
        {
            var saveDialog = new SaveFileDialog()
            {
                Title = "Save Preset",
                DefaultExt = "pre",
                Filter = "My preset files (*.pre)|*.pre",
                //CheckFileExists = true,
                CheckPathExists = true
            };
            Preset preset = new Preset(_methodList);
            if(saveDialog.ShowDialog() == true)
            {
               preset.ToFile(saveDialog.FileName);
            }
        }

        private void PresetComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (presetComboBox.SelectedItem == null) return;
            var index = presetComboBox.SelectedIndex;
            var selectedMethod = presetComboBox.SelectedItem as ItemMethod;
            _methodList.Add(selectedMethod);
        }

        private void FileDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (_seclectingListView.SelectedIndex != -1)
            {
               _fileList.RemoveAt(_seclectingListView.SelectedIndex);
                MyAppItem.ReloadList(_seclectingListView, methodListBox);
            }
        }

        private void FolderDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (_seclectingListView.SelectedIndex != -1)
            {
                _folderList.RemoveAt(_seclectingListView.SelectedIndex);
                MyAppItem.ReloadList(_seclectingListView, methodListBox);
            }
        }
    }
}
