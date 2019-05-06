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
    /// Interaction logic for MoveStringArgsDialog.xaml
    /// </summary>
    public partial class MoveStringArgsDialog : Window
    {
        public int TypeMove = 0;
        public int Length = 0;
        public int Index = 0;
        public MoveStringArgsDialog(MoveStringActionArgs args)
        {
            InitializeComponent();
            TypeMove = args.TypeMove;
            switch (TypeMove)
            {
                case 1:
                    radioBtn2.IsChecked = true;
                    break;
                default:
                    radioBtn1.IsChecked = true;
                    break;
            }
            indexTextbox.Text = args.Index.ToString();
            lengthTextbox.Text = args.Length.ToString();
        }

        private void RadioBtn1_Checked(object sender, RoutedEventArgs e)
        {
            TypeMove = 0;
        }

        private void RadioBtn2_Checked(object sender, RoutedEventArgs e)
        {
            TypeMove = 1;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            int tempIndex;
            int tempLength;
            if(int.TryParse(indexTextbox.Text, out tempIndex))
            {
                if(int.TryParse(lengthTextbox.Text, out tempLength))
                {
                    Index = tempIndex;
                    Length = tempLength;
                    this.DialogResult = true;
                    return;
                }
            }
            MessageBox.Show("Invalid Input");
            this.Close();
        }
    }
}
