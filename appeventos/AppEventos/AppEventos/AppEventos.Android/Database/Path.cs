using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using AppEventos.DataBase;
using System.IO;
using AppEventos.Droid.Database;


[assembly:Dependency(typeof(AndroidPath))]
namespace AppEventos.Droid.Database
{
    public class AndroidPath : IPath
    {

        public string GetPath(string nomeDataBase)
        {

            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            string dataBasePath = Path.Combine(folderPath, nomeDataBase);

            return dataBasePath;
        }
    }
}