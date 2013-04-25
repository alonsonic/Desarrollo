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
            agregarDia();
            agregarAño();
            ComboMes.SelectedIndex = 0;
        }
     
        private void agregarAño()
        {
            ComboAno.Items.Add("Año");
            for (int index = 1913; index <= 2011; index++)
                ComboAno.Items.Add(index);

            ComboAno.SelectedIndex = 0;
        }

        private void agregarDia()
        {
            ComboDia.Items.Add("Dia");
            for (int index = 1; index <= 31; index++)
            {
                if (index < 10) ComboDia.Items.Add("0" + index.ToString());
                else ComboDia.Items.Add(index);
            }

            ComboDia.SelectedIndex = 0;
        }
        

        private void buttonCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private async void buttonEnviar_Click(object sender, RoutedEventArgs e)
        {
            string mes=ComboMes.SelectedIndex+"";
            if (ComboMes.SelectedIndex < 10) mes = "0" + mes;
            Usuario usuario = await servicio.agregarUsuarioAsync(textBoxNombre.Text, textBoxApellido.Text, textPasaporteEditable.Text, textCorreoEditable.Text,
                                        ComboAno.SelectedValue.ToString() + "-" + mes + "-" + ComboDia.SelectedValue.ToString());
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
