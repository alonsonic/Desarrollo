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
            for (int i = 0; i < listaEstados.Count(); i++)
            {
                comboBoxEstado.Items.Add(listaEstados[i].Estado);
            }

        }

        private async void comboBoxEstado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listaCiudad = await servicioDireccion.consultarCiudadAsync(comboBoxEstado.SelectedIndex);
            for (int i = 0; i < listaCiudad.Count(); i++)
            {
                comboBoxCiudad.Items.Add(listaCiudad[i].Ciudad);
                
            }

        }

        private void buttonAgregar_Click(object sender, RoutedEventArgs e)
        {

        }

       

    }
}
