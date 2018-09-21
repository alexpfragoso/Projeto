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
	public partial class CadastrodeEventos : ContentPage
	{
        public string imagem = "eventosample.jpg";

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
            evento.Imagem = imagem;

            Database database = new Database();
            database.CadastrarEvento(evento);

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

            MinhaImagem.Source = ImageSource.FromStream(() =>
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

            MinhaImagem.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();

                return stream;

            });
        }

    }
}
