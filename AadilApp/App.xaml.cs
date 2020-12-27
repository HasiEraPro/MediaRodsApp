using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AadilApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 
    public partial class App : Application
    {

     
       // public static string FolderFileName { get; set; }
        //public static string Path { get; set; }
             
       // public static string FileName { get; set; }
        //public static string Extension { get; set; }
       // public static int? RodNumberGreen { get; set; }
       // public static int RodNumberRed { get; set; }




        public static string FolderPath { get; set; }
        public static string profilePicPath { get; set; } = "";

        public static List<string> profilePicList = new List<string>();

        public static string catogory { get; set; } = "";
        public static string userName { get; set; }
        public static string profileName { get; set; }


        public static Rods[] rodsArray = new Rods[15];


        public class Rods
        {
            public int _number { get; set; }


            public List<string> _pathList = new List<string>();

            public bool _redOrGreen { get; set; } = false; //true is green false is red

           

            

            public List<string> _extensionList = new List<string>();

      

            public List<string> _fileNameList = new List<string>();

            public Rods(int number)
            {

                this._number = number;


            }


            

        }
    }
}
