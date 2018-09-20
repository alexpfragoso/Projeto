using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppEventos.DataBase;
using System.IO;
using Xamarin.Forms;
using AppEventos.UWP.DataBase;
using Windows.Storage;

[assembly: Dependency(typeof(UWPPath))]
namespace AppEventos.UWP.DataBase
{
    class UWPPath : IPath
    {
        public string GetPath(string nomeDataBase)
        {
            string folderPath = ApplicationData.Current.LocalFolder.Path;

            string dataBasePath = Path.Combine(folderPath, nomeDataBase);

            return dataBasePath;
        }
    }
}
