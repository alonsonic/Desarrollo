using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using AeiCliente.ServicioAEI;
using Windows.UI.Popups;
using TwitterRtLibrary;
using AeiCliente.ServicioAEI;

namespace AeiCliente
{   

    public sealed partial class TwitterPopup : UserControl
    {
        public static string tweet;
        TwitterRt conexionTwitter = new TwitterRt("hLDGH8KA49YpSsGuMMhraQ", "m6TBRfQJMVtTYIERY1IBRICT0gGdnXsIrzw4Sm3BwQ", "http://www.tweetlai.com/");
        ServicioAEIClient servicioTwitter = new ServicioAEIClient();
        Popup popup = null;
        private ItemProducto pagina;

        public TwitterPopup(Popup padre, ItemProducto pagina)
        {
            this.InitializeComponent();
            if (padre == null) throw new ArgumentNullException("Debe asignar un Popup al controlador.");
            this.popup = padre;
            this.InitializeComponent();
            this.pagina = pagina;
            this.Tweet.Text = tweet;
        }

        private async void Enviar_Click(object sender, RoutedEventArgs e)
        {
            if (Usuario.Text != null)
            {
                Twitter twitter = await servicioTwitter.getTwitterAsync(Usuario.Text);
                if (twitter != null)
                {
                    conexionTwitter.ScreenName = twitter.ScreenName;
                    conexionTwitter.UserID = twitter.IdUsuario;
                    conexionTwitter.OauthTokenSecret = twitter.OauthTokenSecret;
                    conexionTwitter.OauthToken = twitter.OauthToken;
                    conexionTwitter.Status = "Access granted";
                    conexionTwitter.AccessGranted = true;
                }
                await conexionTwitter.UpdateStatus(Tweet.Text);
                if (conexionTwitter.Status == "The remote server returned an error: (401) Unauthorized.")
                {
                    conexionTwitter.ResetSettings();
                    if (await conexionTwitter.GainAccessToTwitter() == true)
                    {
                        await conexionTwitter.UpdateStatus(Tweet.Text);
                        int resp = await servicioTwitter.agregarTwitterAsync(conexionTwitter.UserID, conexionTwitter.ScreenName, conexionTwitter.OauthToken, conexionTwitter.OauthTokenSecret);
                        if (resp == 0)
                        {
                            MessageDialog mensajeError = new MessageDialog("Lo sentimos su tweet no ha sido enviado! Ha ocurrido un error... Intentelo de nuevo");
                            mensajeError.ShowAsync();
                        }
                        else
                        {
                            MessageDialog mensajeError = new MessageDialog("Su tweet ha sido enviado con exito");
                            mensajeError.ShowAsync();
                            popup.IsOpen = false;
                        }
                    }
                }
                else
                {
                    MessageDialog mensajeError = new MessageDialog("Su tweet ha sido enviado con exito");
                    mensajeError.ShowAsync();
                    popup.IsOpen = false;
                }
            }
        }

    }
	
}