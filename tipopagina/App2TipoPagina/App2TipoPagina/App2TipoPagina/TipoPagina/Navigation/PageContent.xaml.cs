using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2TipoPagina.TipoPagina.Navigation
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageContent : ContentPage
	{
		public PageContent ()
		{
			InitializeComponent ();
		}

        private void MudarPagina2(object sender, EventArgs args)
        {
            Navigation.PushAsync(new PageDois());
        }

    }
}