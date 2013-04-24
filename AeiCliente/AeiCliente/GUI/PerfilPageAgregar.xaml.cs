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

namespace AeiCliente.GUI
{

    public sealed partial class PerfilPageAgregar : Page
    {
        private ServicioAEIClient servicio = new ServicioAEIClient();

        public PerfilPageAgregar()
        {
            this.InitializeComponent();
        }

        private void buttonCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private async void buttonEnviar_Click(object sender, RoutedEventArgs e)
        {

            Usuario usuario = await servicio.agregarUsuarioAsync(textBoxNombre.Text, textBoxApellido.Text, textPasaporteEditable.Text, textCorreoEditable.Text,
                                        ComboAno.SelectedValue.ToString() + "-" + ComboMes.SelectedValue.ToString() + "-" + ComboDia.SelectedValue.ToString());
            if (usuario == null)
            {
                MessageDialog mensajeError = new MessageDialog("Error no se pudo agregar al sistema");
                mensajeError.ShowAsync();
            }
            else
            {
                BufferUsuario.Usuario = usuario;
            }

        }
    }
}
