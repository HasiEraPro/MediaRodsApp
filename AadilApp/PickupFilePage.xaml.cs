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
    /// Interaction logic for PickupFilePage.xaml
    /// </summary>
    public partial class PickupFilePage : Window
    {
        private string  _Path { get; set; }

        private string _PathImage { get; set; } = "";
        private string _Name { get; set; }
        private string _Nameimage { get; set; } = "";

        private int _number { get; set; }


        public PickupFilePage(int number)
        {
            InitializeComponent();
            this._number = number;

            if (App.rodsArray[number] == null)
            {
                App.Rods rod = new App.Rods(number);
                App.rodsArray[number] = rod;

            }
            
            
            btnAudiofile.IsEnabled = false;
            btnVideofile.IsEnabled = false;
            lblrodNumber.Content = number;

        }

        private void BtnVideofile_Copy1_Click(object sender, RoutedEventArgs e)
        {


            //App.RodNumberRed = (int)lblrodNumber.Content;

            App.rodsArray[this._number]._redOrGreen = false;

            this.Close();
            var page = new MainWindow();
            page.Show();
        }

        private void BtnVideofile_Click(object sender, RoutedEventArgs e)
        {
            string fullPath = string.Empty;
            // Create a "Save As" dialog for selecting a directory (HACK)
            var dialog = new Microsoft.Win32.OpenFileDialog();

            if ((string)videolabel.Content == "Images")
            {
              
                // dialog.InitialDirectory = textbox.Text; // Use current value for initial dir
                dialog.Title = "Select a Directory"; // instead of default "Save As"
                dialog.Filter = "All image Files |*.jpg;*.png; *.bmp;*.jpeg;";
                //"Directory|*.this.directory"; // Prevents displaying files
                dialog.FileName = "select"; // Filename will then be "select.this.directory"
                if (dialog.ShowDialog() == true)
                {
                    string path = dialog.FileName;
                    if (!string.IsNullOrEmpty(path))
                    {
                        lblVideoFileName.Content = path;
                        _PathImage = path;
                        _Nameimage = dialog.SafeFileName;
                    }
                }




            }

            else
            {
                // dialog.InitialDirectory = textbox.Text; // Use current value for initial dir
                dialog.Title = "Select a Directory"; // instead of default "Save As"
                dialog.Filter = "All Videos Files |*.3gp;*.mkv; *.mov;*.mp4; *.wmv; *.qt;";
                //"Directory|*.this.directory"; // Prevents displaying files
                dialog.FileName = "select"; // Filename will then be "select.this.directory"
                if (dialog.ShowDialog() == true)
                {
                    string path = dialog.FileName;
                    if (!string.IsNullOrEmpty(path))
                    {
                        lblVideoFileName.Content = path;
                        _Path = path;
                        _Name = dialog.SafeFileName;
                    }
                }
            }
            
        }

        private void BtnAudiofile_Click(object sender, RoutedEventArgs e)
        {
            string fullPath = string.Empty;
            // Create a "Save As" dialog for selecting a directory (HACK)
            var dialog = new Microsoft.Win32.OpenFileDialog();
            // dialog.InitialDirectory = textbox.Text; // Use current value for initial dir
            dialog.Title = "Select a Directory"; // instead of default "Save As"
            dialog.Filter = "All Audio Files |*.mp3;*.aac; *.m4a;*.wav;";
            //"Directory|*.this.directory"; // Prevents displaying files
            dialog.FileName = "select"; // Filename will then be "select.this.directory"
            if (dialog.ShowDialog() == true)
            {
                string path = dialog.FileName;
                
                if (!string.IsNullOrEmpty(path))
                {
                    lblAudioFileName.Content = path;
                    _Path = path;
                    _Name = dialog.SafeFileName;

                }
            }
        }

       

        private void Rdaudio_Checked(object sender, RoutedEventArgs e)
        {
            btnAudiofile.IsEnabled = true;
            btnVideofile.IsEnabled = true;
            videolabel.Content = "Images";
            lblVideoFileName.Content = "";

        }

        private void Rdvideo_Checked(object sender, RoutedEventArgs e)
        {
            btnVideofile.IsEnabled = true;
            videolabel.Content = "Video";
            btnAudiofile.IsEnabled = false;
            lblAudioFileName.Content = "";

        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(_Path))
            {
                //App.Path = _Path;
                App.rodsArray[this._number]._pathList.Add(_Path);

                if (this._PathImage != "")
                {
                    App.rodsArray[this._number]._pathList.Add(_PathImage);
                    Console.Write("pathlistimageadded: "); Console.WriteLine(_PathImage);
                }
                //App.FileName = _Name;
                App.rodsArray[this._number]._fileNameList.Add(_Name);

                if (this._Nameimage != "")
                {
                    App.rodsArray[this._number]._fileNameList.Add(_Nameimage);
                    Console.Write("pathlistimageadded: "); Console.WriteLine(_Nameimage);

                }

                //App.Extension = _Name.Split('.')[1];
                App.rodsArray[this._number]._extensionList.Add(_Name.Split('.')[1]);

                if (this._Nameimage != "")
                {
                    App.rodsArray[this._number]._extensionList.Add(_Nameimage.Split('.')[1]);
                    Console.Write("pathextensionimageadded: "); Console.WriteLine(_Nameimage);

                }
                

                //App.RodNumberGreen = (int)lblrodNumber.Content;
                App.rodsArray[this._number]._redOrGreen = true;

                
                this.Close();
                var page = new MainWindow();
                page.Show();
            }
        }
    }
}
