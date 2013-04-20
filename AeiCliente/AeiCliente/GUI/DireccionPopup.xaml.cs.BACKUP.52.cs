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
using AeiCliente.ServicioDireccion;
using Windows.UI.Popups;
<<<<<<< HEAD
=======
using AeiCliente.ServicioDireccion;

>>>>>>> Listo resuelto errores...

namespace AeiCliente
{
    public sealed partial class DireccionPopup : UserControl
    {
        private Popup popup = null;
        private ServicioDireccionClient servicioDireccion = new ServicioDireccionClient();
        private List<Direccion> listaEstados = null;
        private  List<Direccion> listaCiudad = null;

        public DireccionPopup(Popup padre)
        {
            if (padre == null) throw new ArgumentNullException("Debe asignar un Popup al controlador");
            this.popup = padre;
            this.InitializeComponent();
            cargarEstados();
        }

        private async void cargarEstados()
        {
            listaEstados = await servicioDireccion.consultarEstadosAsync();
            comboBoxEstado.Items.Add("Selecione");
            for (int i = 0; i < listaEstados.Count(); i++)
            {
                comboBoxEstado.Items.Add(listaEstados[i].Estado);
            }
            comboBoxEstado.SelectedIndex = 0;

        }

        private async void comboBoxEstado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idEstado = listaEstados[comboBoxEstado.SelectedIndex+1].Id;
            listaCiudad = await servicioDireccion.consultarCiudadAsync(idEstado);
            for (int i = 0; i < listaCiudad.Count(); i++)
            {
                comboBoxCiudad.Items.Add(listaCiudad[i].Ciudad);
                
            }

        }

        private async void buttonAgregar_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog mensajeError = new MessageDialog("Los campos con * son OBLIGATORIOS");
            int error = -1;

            if (comboBoxCiudad.SelectedIndex != 0 && comboBoxEstado.SelectedIndex != 0 && textboxCodigoPostal.Text.Length != 0)
            {
                int idCiudad = listaCiudad[comboBoxCiudad.SelectedIndex].Id;
                error = await servicioDireccion.agregarDireccionUsuarioAsync(-1, idCiudad, textBoxDetalle.Text, int.Parse(textboxCodigoPostal.Text));
                
            }
            else
            {
                mensajeError.ShowAsync();
            }

            if (error == 0)
            {
                mensajeError.Content = "No se pudo agregar la nueva dirección";
                mensajeError.ShowAsync();

            }

        }

       

    }
}
