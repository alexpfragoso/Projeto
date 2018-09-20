using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppEventos.Modelos;

namespace AppEventos.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalhesEvento : ContentPage
	{
		public DetalhesEvento (Evento evento)
		{
			InitializeComponent ();

            BindingContext = evento;
		}
	}
}