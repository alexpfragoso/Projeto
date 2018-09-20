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
	public partial class AtualizarEvento : ContentPage
	{
        private Evento evento { get; set; }
		public AtualizarEvento (Evento evento)
		{
			InitializeComponent ();
            this.evento = evento;

            Nome.Text = evento.Nome;
            Descricao.Text = evento.Descricao;
            Local.Text = evento.Local;
            Data.Text = evento.Data;
            Horario.Text = evento.Horario;
            Organizador.Text = evento.Organizador;
            Valor.Text = evento.Valor;
            Telefone.Text = evento.Telefone;
            Email.Text = evento.Email;
            Site.Text = evento.Site;
            Imagem.Text = evento.Imagem;
                        
        }
        public void SalvarAction(object sender, EventArgs args)
        {
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
            database.AlterarEvento(evento);

            App.Current.MainPage = new NavigationPage(new ListaEventos());


        }
    }
}