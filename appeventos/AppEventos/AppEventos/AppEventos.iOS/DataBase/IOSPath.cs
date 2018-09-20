using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

using AppEventos.DataBase;
using Xamarin.Forms;
using System.IO;
using AppEventos.iOS.DataBase;


[assembly:Dependency(typeof(IOSPath))]
namespace AppEventos.iOS.DataBase
{
    public class IOSPath : IPath
    {

        public string GetPath(string nomeDataBase)
        {

            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            string libraryPath = Path.Combine(folderPath, "..","Library");

            string dataBasePath = Path.Combine(libraryPath, nomeDataBase);

            return dataBasePath;
        }

    }
}