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
	public partial class CadastrodeEventos : ContentPage
	{
		public CadastrodeEventos ()
		{
			InitializeComponent ();
           
		}

        public void SalvarAction(object sender, EventArgs args) {

            Evento evento = new Evento();
            evento.Nome = Nome.Text;
            evento.Descricao = Descricao.Text;
            evento.Local = Local.Text;
            evento.Data = Data.Text;
            evento.Horario = Horario.Text;
            evento.Organizador = Organizador.Text;
            evento.Valor = Valor.Text;
            evento.Telefone = Telefone.Text;
            evento.Email = Email.Text;
            evento.Site = Site.Text;
            evento.Imagem = Imagem.Text;

            Database database = new Database();
            database.CadastrarEvento(evento);

            App.Current.MainPage = new NavigationPage(new ListaEventos());

        }
	}
}