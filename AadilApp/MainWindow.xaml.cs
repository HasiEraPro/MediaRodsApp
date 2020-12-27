using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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

namespace AadilApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _path { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }


        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            _path = App.FolderPath;

            txtFileName.Text = App.profileName;
           

            if (App.profilePicPath != "")
            {
                ImageBrush myBrush = new ImageBrush();
                myBrush.ImageSource =
                    new BitmapImage(new Uri(App.profilePicPath));
                imgProfile.Fill = myBrush;


            }
            foreach (var rod in App.rodsArray)
            {
                if (rod != null)
                {

                    ColorSwitch(rod._number);
                   

                }

            }
           
           
        }
        public void ColorSwitch(int number)
        {

            switch (number)
            {
                case 1:
                    if(App.rodsArray[1]._redOrGreen) rod1.Background = Brushes.Green;
                    else
                    {
                        rod1.Background = Brushes.Red;
                    }
                    break;

                case 2:
                    if (App.rodsArray[2]._redOrGreen) rod2.Background = Brushes.Green;
                    else
                    {
                        rod2.Background = Brushes.Red;
                    }
                    break;
                case 3:
                    if (App.rodsArray[3]._redOrGreen) rod3.Background = Brushes.Green;
                    else
                    {
                        rod3.Background = Brushes.Red;
                    }
                    break;
                case 4:
                    if (App.rodsArray[4]._redOrGreen) rod4.Background = Brushes.Green;
                    else
                    {
                        rod4.Background = Brushes.Red;
                    }
                    break;
                case 5:
                    if (App.rodsArray[5]._redOrGreen) rod5.Background = Brushes.Green;
                    else
                    {
                        rod5.Background = Brushes.Red;
                    }
                    break;
                case 6:
                    if (App.rodsArray[6]._redOrGreen) rod6.Background = Brushes.Green;
                    else
                    {
                        rod6.Background = Brushes.Red;
                    }
                    break;
                case 7:
                    if (App.rodsArray[7]._redOrGreen) rod7.Background = Brushes.Green;
                    else
                    {
                        rod7.Background = Brushes.Red;
                    }
                    break;
                case 8:
                    if (App.rodsArray[8]._redOrGreen) rod8.Background = Brushes.Green;
                    else
                    {
                        rod8.Background = Brushes.Red;
                    }
                    break;
                case 9:
                    if (App.rodsArray[9]._redOrGreen) rod9.Background = Brushes.Green;
                    else
                    {
                        rod9.Background = Brushes.Red;
                    }
                    break;
                case 10:
                    if (App.rodsArray[10]._redOrGreen) rod10.Background = Brushes.Green;
                    else
                    {
                        rod10.Background = Brushes.Red;
                    }
                    break;
                case 11:
                    if (App.rodsArray[11]._redOrGreen) rod11.Background = Brushes.Green;
                    else
                    {
                        rod11.Background = Brushes.Red;
                    }
                    break;
                case 12:
                    if (App.rodsArray[12]._redOrGreen) rod12.Background = Brushes.Green;
                    else
                    {
                        rod12.Background = Brushes.Red;
                    }
                    break;
                case 13:
                    if (App.rodsArray[13]._redOrGreen) rod13.Background = Brushes.Green;
                    else
                    {
                        rod13.Background = Brushes.Red;
                    }
                    break;
                case 14:
                    if (App.rodsArray[14]._redOrGreen) rod14.Background = Brushes.Green;
                    else
                    {
                        rod14.Background = Brushes.Red;
                    }
                    break;
                default:
                    break;
            }
        }

       
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            App.catogory = ((boxCategory.SelectedItem as ListBoxItem).Content.ToString());

        }

        private void BtnUploadfile_Click(object sender, RoutedEventArgs e)
        {
            _path = getFolderPath();
            App.FolderPath = _path;
        }


        public string getFolderPath()
        {
            string fullPath = string.Empty;
            // Create a "Save As" dialog for selecting a directory (HACK)
            var dialog = new Microsoft.Win32.SaveFileDialog();
            // dialog.InitialDirectory = textbox.Text; // Use current value for initial dir
            dialog.Title = "Select a Directory"; // instead of default "Save As"
            dialog.Filter = "Directory|*.this.directory"; // Prevents displaying files
            dialog.FileName = "select"; // Filename will then be "select.this.directory"
            if (dialog.ShowDialog() == true)
            {
                string path = dialog.FileName;
                // Remove fake filename from resulting path
                path = path.Replace("\\select.this.directory", "");
                path = path.Replace(".this.directory", "");
                // If user has changed the filename, create the new directory
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }
                // Our final value is in path
                // textbox.Text = path;
                fullPath = path;


                Console.Write("directoryPath:");Console.WriteLine(fullPath);
            }
            return fullPath;
        }

        private void RodOpen(int number)
        {
            if (string.IsNullOrEmpty(_path) || string.IsNullOrEmpty(txtFileName.Text))
            {
                MessageBox.Show("Please Fill File Name / Folder Path");
            }
            else
            {
                App.profileName = txtFileName.Text;
                var page = new PickupFilePage(number);
                this.Hide();
                page.Show();
            }
        }
        private void Rod1_Click(object sender, RoutedEventArgs e)
        {
            RodOpen(1);
           


        }

        private void Rod2_Click(object sender, RoutedEventArgs e)
        {
            RodOpen(2);
           

        }

        private void Rod3_Click(object sender, RoutedEventArgs e)
        {
            RodOpen(3);
          
        }

        private void Rod4_Click(object sender, RoutedEventArgs e)
        {
            RodOpen(4);
            

        }

        private void Rod5_Click(object sender, RoutedEventArgs e)
        {
            RodOpen(5);
        

        }

        private void Rod6_Click(object sender, RoutedEventArgs e)
        {
            RodOpen(6);
            

        }

        private void Rod7_Click(object sender, RoutedEventArgs e)
        {
            RodOpen(7);
         

        }

        private void Rod8_Click(object sender, RoutedEventArgs e)
        {
            RodOpen(8);
          
        }

        private void Rod9_Click(object sender, RoutedEventArgs e)
        {
            RodOpen(9);
            
        }

        private void Rod10_Click(object sender, RoutedEventArgs e)
        {
            RodOpen(10);
            
        }

        private void Rod11_Click(object sender, RoutedEventArgs e)
        {
            RodOpen(11);
           
        }

        private void Rod12_Click(object sender, RoutedEventArgs e)
        {
            RodOpen(12);
            

        }

        private void Rod13_Click(object sender, RoutedEventArgs e)
        {
            RodOpen(13);
           

        }

        private void Rod14_Click(object sender, RoutedEventArgs e)
        {
            RodOpen(14);
           
        }

        private void BtnStickUsb_Click(object sender, RoutedEventArgs e)
        {


            if (!string.IsNullOrEmpty(App.FolderPath))
            {
                


                string root = App.FolderPath+@"\"+"Profiles";
                string subdir = root+@"\"+App.profileName;
                string mediaDir = subdir + @"\" + "media";
                string userDir  = subdir + @"\" + "user";

                string jsonPath = subdir+ @"\" + "profile" + ".json";

                // If directory does not exist, create it. 
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                    Directory.CreateDirectory(subdir);
                    Directory.CreateDirectory(mediaDir);
                    Directory.CreateDirectory(userDir);


                }
                else
                {

                    Directory.CreateDirectory(subdir);
                    Directory.CreateDirectory(mediaDir);
                    Directory.CreateDirectory(userDir);


                }



                //var _data = new
                //{
                //    // fileName = 
                //};

                //using (StreamWriter file = File.CreateText(_path))
                //{
                //    JsonSerializer serializer = new JsonSerializer();
                //    //serialize object directly into file stream
                //    serializer.Serialize(file, _data);
                //}
                // for (int i = 1; i <= 14; i++)
                //{

                //var data = new List<Items>();
                //data.Add(new Items()
                //{
                //    rodNr = App.RodNumberGreen != null ? App.RodNumberGreen : i,
                //    graphicName = App.FileName == "" ? " " : App.FileName,
                //     Type = !string.IsNullOrEmpty(App.FileName) ? "" : boxCategory.Text,

                //  });
                //




                var dataJson = JsonConvert.SerializeObject(new itemsForJson());

                    // write JSON directly to a file
                    using (StreamWriter writer = File.CreateText(jsonPath))
                    {
                        writer.Write(dataJson);
                    }

                
                foreach (var rod in App.rodsArray)
                {
                    
                    if (rod != null)
                    {
                        var FilesAndExtensions = rod._pathList.Zip(rod._extensionList, (n,w) => new { file = n, extension = w });
                        foreach (var nw in FilesAndExtensions)
                        {
                            System.IO.File.Copy(nw.file, mediaDir+@"\"+rod._number+"."+nw.extension, true);
                        }


                    }
                    
                }

                try


                {
                    int i = 0;
                    foreach (var file in App.profilePicList)
                    {
                        i++;
                                
                                string extension = file.Split('.')[1];
                  
                        
                        System.IO.File.Copy(file, userDir + @"\" + App.profileName+"_"+i.ToString()+"."+extension, true);
                    }
                    


                    
                }
                catch (Exception aw)
                {

                    Console.WriteLine(aw.Data);
                }



                MessageBox.Show("saved success !!!!");
               // }
            }
        }

       // public class Items
      //  {
         ///   public int? rodNr { get; set; }
        //    public string graphicName { get; set; } //graphicname = filename
         //   public string Type { get; set; }
       // }
        
        public class itemsForJson
        {
            public string profileName = App.profileName;
            public string categoryName = App.catogory;

            public List<Dictionary<string, string>> barMedia = new List<Dictionary<string, string>>();



            public string username = App.userName;

            public itemsForJson()
            {
             
                fillMedia();


            }
            public void fillMedia()
            {

                foreach (var rod in App.rodsArray)
                {

                    if (rod != null)
                    {
                        foreach (var item in rod._fileNameList)
                        {


                            Dictionary<string, string> xyz = new Dictionary<string, string>();

                           xyz.Add("barNr" ,rod._number.ToString());
                            xyz.Add("graphicName" , item);

                            barMedia.Add(xyz);


                             
                            


                        }


                    }
                    
                      

                }
                

            }
                
                
        }


        private void imgProfile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var page = new ProfilePicturePage();
            this.Hide();
            page.Show();
        }

        private void txtFileName_TextChanged(object sender, TextChangedEventArgs e)
        {
            App.profileName = txtFileName.Text;

        }

        private void Window_Closed(object sender, EventArgs e)
        {

            this.Close();
        }
    }
}