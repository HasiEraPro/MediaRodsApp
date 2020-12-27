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

namespace AadilApp
{
    /// <summary>
    /// Interaction logic for ProfilePicturePage.xaml
    /// </summary>
    public partial class ProfilePicturePage : Window
    {

        private string _username = "";

        private List<string> photoList = new List<string>();

        public ProfilePicturePage()
        {
            InitializeComponent();
            
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
            var page = new MainWindow();
            page.Show();
        }

     

        private void okbtn_Click(object sender, RoutedEventArgs e)
        {
            App.userName = (string)this._username;
            Console.Write("username:=");Console.WriteLine(App.userName);
            try
            {
                App.profilePicPath = this.photoList[listBox.Items.IndexOf(listBox.SelectedItem)];
            }
            catch (Exception eg)
            {

                Console.WriteLine(eg.Message);
            }
            
            Console.WriteLine(App.profilePicPath);

            this.Close();
            var page = new MainWindow();
            page.Show();

        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            string fullPath = string.Empty;
            // Create a "Save As" dialog for selecting a directory (HACK)
            var dialog = new Microsoft.Win32.OpenFileDialog();
            // dialog.InitialDirectory = textbox.Text; // Use current value for initial dir
            dialog.Title = "Select Image"; // instead of default "Save As"
            dialog.Filter = "All Image Files |*.jpg;*.png; *.bmp;*.jpeg;";
            //"Directory|*.this.directory"; // Prevents displaying files
            dialog.FileName = "select"; // Filename will then be "select.this.directory"
            if (dialog.ShowDialog() == true)
            {
                string path = dialog.FileName;

                if (!string.IsNullOrEmpty(path))
                {
                    this.photoList.Add(path);
                    App.profilePicList.Add(path);
                   
                    listBox.Items.Add(dialog.SafeFileName);
                    //_Path = path;
                    //_Name = dialog.SafeFileName;////

                }
            }
        }

        private void removePicBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                listBox.Items.RemoveAt(listBox.Items.IndexOf(listBox.SelectedItem));
            }
            catch (Exception rr)
            {

                Console.WriteLine(rr.Message);

            }
            

        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _username = textBox.Text;
            
        }
    }
}
