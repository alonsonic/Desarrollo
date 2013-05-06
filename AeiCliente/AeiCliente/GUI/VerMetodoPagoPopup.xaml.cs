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
    public sealed partial class VerMetodoPagoPopup : UserControl
    {
        private Popup popup = null;
        private ServicioAEIClient servicioAei = new ServicioAEIClient();
        List<MetodoPago> metodos = null;

        public VerMetodoPagoPopup(Popup padre)
        {
            if (padre == null) throw new ArgumentNullException("Debe asignar un Popup al controlador");
            this.popup = padre;
            this.InitializeComponent();
            cargarMetodoPago();
        }

        private void cargarMetodoPago()
        {
            bool flag = false;
            listBoxMetodosPago.Items.Clear();
            metodos= new List<MetodoPago>();
            List<MetodoPago> listaMetodoPago = BufferUsuario.Usuario.MetodosPago;
            for (int indexMetodo = 0; indexMetodo < listaMetodoPago.Count(); indexMetodo++)
            {
                if (listaMetodoPago[indexMetodo].Status !="I")
                {
                    listBoxMetodosPago.Items.Add("Marca: " + listaMetodoPago[indexMetodo].Marca.ToString() + ".    Numero:" + listaMetodoPago[indexMetodo].Numero + ".    Fecha de Vencimiento:" + listaMetodoPago[indexMetodo].FechaVencimiento.ToString("MM/yyyy"));
                    metodos.Add(listaMetodoPago[indexMetodo]);
                    flag = true;
                }
            }
            if (flag == false)
            {
                this.listBoxMetodosPago.IsEnabled = false;
                this.botonEliminar.IsEnabled = false;
            }
        }

        private void botonBack_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            popup.IsOpen = false;
        }

        private async void botonAgregar_Click(object sender, RoutedEventArgs e)
        {
            Popup popupp = new Popup();
            AgregarMetodoPopup agregarPopup = new AgregarMetodoPopup(popupp);
            popupp.Child = agregarPopup;
            popupp.IsOpen = true;
            popup.IsOpen = false;
        }

        private async void botonEliminar_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog mensajeError=null;
            if (listBoxMetodosPago.SelectedIndex > -1)
            {
                ServicioAEIClient servicio = new ServicioAEIClient();
                BufferUsuario.Usuario = await servicio.eliminarMetodoPagoAsync(metodos[listBoxMetodosPago.SelectedIndex], BufferUsuario.Usuario);
                if (BufferUsuario.Usuario != null)
                {
                    popup.IsOpen = false;
                    mensajeError = new MessageDialog("Operación exitosa");
                    mensajeError.ShowAsync();
                }
                else
                {
                    mensajeError = new MessageDialog("No se pudo realizar la operacion. Por favor comuniquese con aeistoresoporte@gmail.com");
                    mensajeError.ShowAsync();
                }
            }
            else
            {
                mensajeError = new MessageDialog("Por favor, seleccione uno de sus metodos de pago");
                mensajeError.ShowAsync();
            }
            
        }  


    }
	
}
