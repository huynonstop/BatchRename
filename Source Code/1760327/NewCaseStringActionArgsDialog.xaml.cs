using _1760327.StringActionModel;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace _1760327
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class NewCaseStringArgsDialog : Window
    {
        public int TypeCase = 0;
        public NewCaseStringArgsDialog(NewCaseStringActionArgs args)
        {
            InitializeComponent();
            TypeCase = args.TypeCase;
            switch (TypeCase)
            {
                case 1:
                    radioBtn2.IsChecked = true;
                    break;
                case 2:
                    radioBtn3.IsChecked = true;
                    break;
                default:
                    radioBtn1.IsChecked = true;
                    break;
            }
        }

        private void RadioBtn1_Checked(object sender, RoutedEventArgs e)
        {
            TypeCase = 0;
        }

        private void RadioBtn2_Checked(object sender, RoutedEventArgs e)
        {
            TypeCase = 1;
        }

        private void RadioBtn3_Checked(object sender, RoutedEventArgs e)
        {
            TypeCase = 2;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
