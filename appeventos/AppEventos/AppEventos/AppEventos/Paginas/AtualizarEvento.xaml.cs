using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppEventos.Modelos;
using AppEventos.DataBase;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace AppEventos.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AtualizarEvento : ContentPage
	{
        public string imagem = "eventosample.jpg";
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
            Imagem.Source = evento.Imagem;
                        
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
            evento.Imagem = imagem;

            Database database = new Database();
            database.AlterarEvento(evento);

            App.Current.MainPage = new NavigationPage(new ListaEventos());


        }

        private async void TirarFoto(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsTakePhotoSupported || !CrossMedia.Current.IsCameraAvailable)
            {
                await DisplayAlert("Ops", "Nenhuma câmera detectada.", "OK");

                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(
                new StoreCameraMediaOptions
                {
                    SaveToAlbum = true,
                    Directory = "Demo"
                });

            if (file == null)
                return;
            imagem = file.Path.ToString();

            Imagem.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;

            });
        }

        private async void EscolherFoto(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Ops", "Galeria de fotos não suportada.", "OK");

                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync();


            if (file == null)
                return;

            imagem = file.Path.ToString();

            Imagem.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();

                return stream;

            });
        }


    }
}