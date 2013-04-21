// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved

using System;
using System.Linq;
using System.Collections.Generic;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Security.Authentication.Web;
using AeiCliente;
using System.Net;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using AeiCliente.ServicioUsuario;
using System.Threading.Tasks;

namespace AeiCliente
{
	public sealed partial class OpenIdClient : Page
	{
		// A pointer back to the main page which is used to gain access to the input and output frames and their content.
        string token = "";
        Button botonSender = null;


		public OpenIdClient()
		{
			InitializeComponent();
		}

		#region Template-Related Code - Do not remove
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
            //// Get a pointer to our main page
            //rootPage = e.Parameter as MainPage;

			// We want to be notified with the OutputFrame is loaded so we can get to the content.
            //rootPage.OutputFrameLoaded += new System.EventHandler(rootPage_OutputFrameLoaded);
		}

		protected override void OnNavigatedFrom(NavigationEventArgs e)
		{
            //rootPage.OutputFrameLoaded -= new System.EventHandler(rootPage_OutputFrameLoaded);
		}

		#endregion

        #region Use this code if you need access to elements in the output frame - otherwise delete
        void rootPage_OutputFrameLoaded(object sender, object e)
        {
            // At this point, we know that the Output Frame has been loaded and we can go ahead
            // and reference elements in the page contained in the Output Frame.

            // Get a pointer to the content within the OutputFrame.
            //Page outputFrame = (Page)rootPage.OutputFrame.Content;

            // Go find the elements that we need for this scenario.
            // ex: flipView1 = outputFrame.FindName("FlipView1") as FlipView;

        }
        #endregion

        private void DebugPrint(String Trace)
        {
            TextBlock GoogleDebugArea = textDebug;
            GoogleDebugArea.Text += Trace + "\r\n";
        }

        private void OutputToken(String TokenUri)
        {
            TextBlock GoogleReturnedToken = textDebug;
            GoogleReturnedToken.Text = TokenUri;
        }

        public async void clickOpenID(object sender, RoutedEventArgs e)
        {
            botonSender = sender as Button;
            if(GoogleClientID.Text == "")
            {
                //rootPage.NotifyUser("Please enter an Client ID.", NotifyType.StatusMessage);
            }
            else if(GoogleCallbackUrl.Text == "")
            {
                //rootPage.NotifyUser("Please enter an Callback URL.", NotifyType.StatusMessage);
            }

            try
            {
                String GoogleURL = "https://accounts.google.com/o/oauth2/auth?client_id=" + Uri.EscapeDataString(GoogleClientID.Text) + "&redirect_uri=" + Uri.EscapeDataString(GoogleCallbackUrl.Text) + "&display=touch&response_type=code&scope= openid profile email";
                System.Uri StartUri = new Uri(GoogleURL);
                // When using the desktop flow, the success code is displayed in the html title of this end uri
                System.Uri EndUri = new Uri("https://accounts.google.com/o/oauth2/approval?");

                DebugPrint("Navigating to: " + GoogleURL);

                WebAuthenticationResult WebAuthenticationResult = await WebAuthenticationBroker.AuthenticateAsync(
                                                        WebAuthenticationOptions.UseTitle,
                                                        StartUri,
                                                        EndUri);
                
                if (WebAuthenticationResult.ResponseStatus == WebAuthenticationStatus.Success)
                {
                    OutputToken(WebAuthenticationResult.ResponseData.ToString());
                    WebAuthenticationResult.ResponseData.ToString().Split('=').Last();
                    getToken(WebAuthenticationResult.ResponseData.ToString().Split('=').Last());
                }
                else if (WebAuthenticationResult.ResponseStatus == WebAuthenticationStatus.ErrorHttp)
                {
                    OutputToken("HTTP Error returned by AuthenticateAsync() : " + WebAuthenticationResult.ResponseErrorDetail.ToString());
                    botonSender.Content = "Ingresar";
                    BufferUsuario.Usuario = null;
                }
                else
                {
                    OutputToken("Error returned by AuthenticateAsync() : " + WebAuthenticationResult.ResponseStatus.ToString());
                    botonSender.Content = "Ingresar";
                    BufferUsuario.Usuario = null;
                }
                
            }
            catch (Exception Error)
            {
                //
                // Bad Parameter, SSL/TLS Errors and Network Unavailable errors are to be handled here.
                //
                DebugPrint(Error.ToString());
            }
            return;
	    }
        public async void getToken(string code)
        {

            var form = new Dictionary<string, string>
            {
            {"code", code},
            {"client_id", "484156375778.apps.googleusercontent.com"},
            {"client_secret", "PH0hTcYgaOvpXKpeCyWW6690"},
            {"redirect_uri", "urn:ietf:wg:oauth:2.0:oob"},
            {"grant_type", "authorization_code"},
            };
               
            var content = new FormUrlEncodedContent(form);               
            var client = new HttpClient(); 
            var response = await client.PostAsync("https://accounts.google.com/o/oauth2/token", content);
            var json = await response.Content.ReadAsStringAsync();
 
            JObject respuestaJson = JObject.Parse(json);
            token = (string)respuestaJson.SelectToken("access_token");

            var respuesta = await client.GetAsync("https://www.googleapis.com/oauth2/v1/userinfo?access_token=" + token);
            json = await respuesta.Content.ReadAsStringAsync();
            respuestaJson = JObject.Parse(json);
            string email = (string)respuestaJson.SelectToken("email");

            BufferUsuario.Usuario = new Usuario();
            BufferUsuario.Usuario.Nombre = "ALonso";
            BufferUsuario.Usuario.Status = "I";

            botonSender.Content = "Salir";

            return;
        }
    }
}
