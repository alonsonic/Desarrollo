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
    public sealed partial class CheckoutPopup : UserControl
    {
        private Popup popup = null;
        private ServicioAEIClient servicioAei = new ServicioAEIClient();

        public CheckoutPopup(Popup padre)
        {
            if (padre == null) throw new ArgumentNullException("Debe asignar un Popup al controlador");
            this.popup = padre;
            this.InitializeComponent();
            cargarCombos();
        }

        private void botonBack_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            popup.IsOpen = false;
        }

        private void cargarCombos()
        {
            List<Direccion> direcciones = BufferUsuario.Usuario.Direcciones;
            List<MetodoPago> metodosPago = BufferUsuario.Usuario.MetodosPago;

            for (int index = 0; index < direcciones.Count(); index++)
            {
                comboDireccion.Items.Add("Estado: " + direcciones[index].Estado + " Ciudad: " + direcciones[index].Ciudad
                                    + " Detalle: " + direcciones[index].Descripcion);
                
            }

            for (int index = 0; index < metodosPago.Count(); index++)
            {
                comboMetodo.Items.Add("Marca: " + metodosPago[index].Marca + " Numero tarjeta: " + metodosPago[index].Numero);
            }
            comboDireccion.SelectedIndex = 0;
            comboMetodo.SelectedIndex = 0;
        }

        private void botonComprar_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
        	
        }

    }
}
