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
using TwitterRtLibrary;
using AeiCliente.ServicioTwitter;
namespace AeiCliente.GUI
{
   
    public sealed partial class TwitterPage : Page
    {
        TwitterRt conexionTwitter = new TwitterRt("hLDGH8KA49YpSsGuMMhraQ", "m6TBRfQJMVtTYIERY1IBRICT0gGdnXsIrzw4Sm3BwQ", "http://www.tweetlai.com/");
        ServicioTwitterClient servicioTwitter = new ServicioTwitterClient();

        public TwitterPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private async void botonEnviar_Click(object sender, RoutedEventArgs e)
        {
            if (Usuario.Text != null && Contraseña.Text != null)
            {
                Twitter twitter= await servicioTwitter.getTwitterAsync(Usuario.Text);
                if (twitter!=null)
                {
                    conexionTwitter.ScreenName = twitter.ScreenName;
                    conexionTwitter.UserID = twitter.IdUsuario;
                    conexionTwitter.OauthTokenSecret = twitter.OauthTokenSecret;
                    conexionTwitter.OauthToken = twitter.OauthToken;
                    conexionTwitter.Status="Access granted";
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

                    }
                }
            }
        }
    }
}
