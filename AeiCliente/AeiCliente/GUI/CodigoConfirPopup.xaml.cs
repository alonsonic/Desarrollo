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
    public sealed partial class CodigoConfirPopup : UserControl
    {
        private Popup popup = null;

        public CodigoConfirPopup(Popup padre)
        {
            if (padre == null) throw new ArgumentNullException("Debe asignar un Popup al controlador");
            this.popup = padre;
            this.InitializeComponent();
        }

        private async void buttonEnviar_Click(object sender, RoutedEventArgs e)
        {
            if (BufferUsuario.Usuario.CodigoActivacion != int.Parse(textCodigo.Text))
            {
                MessageDialog mensajeError = new MessageDialog("El código de autorización no coincide");
                mensajeError.ShowAsync();

            }
            else
            {
                BufferUsuario.Usuario.Status = "A";
                ServicioAEIClient servicio = new ServicioAEIClient();
                int error = await servicio.modificarUsuarioAsync(BufferUsuario.Usuario);
                popup.IsOpen = false;

            }
        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            popup.IsOpen = false;
        }
		
    }
}
