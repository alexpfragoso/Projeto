using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppEventos.Modelos;
using AppEventos.DataBase;

namespace AppEventos.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListaEventos : ContentPage
	{

        List<Evento> lista { get; set; }

		public ListaEventos ()
		{
			InitializeComponent ();
            Database database = new Database();
            lista = database.ListarEventos();
            ListViewEventos.ItemsSource = lista;

            EventosCount.Text = lista.Count.ToString();
		}

        public void CadastrarEvento(object sender, EventArgs args) {

            Navigation.PushAsync(new CadastrodeEventos());
        }

        public void EditarEvento(object sender, EventArgs args){

            Navigation.PushAsync(new EditarEventos());
        }

        public void MaisInformacoesAction(object sender, EventArgs args) {

            Label lbDetalhe = (Label)sender;
            TapGestureRecognizer tapGest = (TapGestureRecognizer)lbDetalhe.GestureRecognizers[0];
            Evento evento = tapGest.CommandParameter as Evento;

            Navigation.PushAsync(new DetalhesEvento(evento));

        }

        public void PesquisarAction(object sender, TextChangedEventArgs args){

            ListViewEventos.ItemsSource = lista.Where(a => a.Nome.Contains(args.NewTextValue)).ToList();
            
        }


     }
}