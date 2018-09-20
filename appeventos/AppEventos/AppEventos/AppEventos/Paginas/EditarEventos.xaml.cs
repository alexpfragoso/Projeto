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
	public partial class EditarEventos : ContentPage
	{
        List<Evento> lista { get; set; }
        public EditarEventos ()
		{
			InitializeComponent ();
            ConsultarEventos();
        }

        private void ConsultarEventos() {
            Database database = new Database();
            lista = database.ListarEventos();
            ListViewEventos.ItemsSource = lista;

            EventosCount.Text = lista.Count.ToString();

        }


        public void EditarAction(object sender, EventArgs args)
        {
            Label lbEditar = (Label)sender;
            TapGestureRecognizer tapGest = (TapGestureRecognizer)lbEditar.GestureRecognizers[0];
            Evento evento = tapGest.CommandParameter as Evento;

            Navigation.PushAsync(new AtualizarEvento(evento));


        }
        public void ExcluirAction(object sender, EventArgs args)
        {
            Label lbExcluir = (Label)sender;
            TapGestureRecognizer tapGest = (TapGestureRecognizer)lbExcluir.GestureRecognizers[0];
            Evento evento = tapGest.CommandParameter as Evento;

            Database database = new Database();
            database.ExcluirEvento(evento);
            ConsultarEventos();

        }
        public void PesquisarAction(object sender, TextChangedEventArgs args)
        {

            ListViewEventos.ItemsSource = lista.Where(a => a.Nome.Contains(args.NewTextValue)).ToList();

        }
    }
}