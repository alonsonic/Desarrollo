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

namespace AeiCliente
{
    public sealed partial class RegistroUsuarioPopup : UserControl
    {
        private Popup popup = null;
        private object botonSender = null;
        MainPage pagina = new MainPage();

        public RegistroUsuarioPopup(Popup padre, object sender, MainPage pagina)
        {
            if (padre == null) throw new ArgumentNullException("Debe asignar un Popup al controlador");
            this.popup = padre;
            this.InitializeComponent();
            this.botonSender = sender;
            this.pagina = pagina;
        }

        private void buttonNo_Click(object sender, RoutedEventArgs e)
        {
            OpenIdClient openId = new OpenIdClient();
            openId.clickOpenID(this.botonSender, e);
            popup.IsOpen = false;
        }

        private void buttonCancelar_Click(object sender, RoutedEventArgs e)
        {
            popup.IsOpen = false;
        }

        private void buttonSI_Click(object sender, RoutedEventArgs e)
        {
            pagina.llamarAgregarPerfilPage();
            popup.IsOpen = false;
        }

		
    }
}
