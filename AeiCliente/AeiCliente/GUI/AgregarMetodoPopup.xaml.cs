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
    public sealed partial class AgregarMetodoPopup : UserControl
    {
        private Popup popup = null;
        private ServicioAEIClient servicioAei = new ServicioAEIClient();

        public AgregarMetodoPopup(Popup padre)
        {
            if (padre == null) throw new ArgumentNullException("Debe asignar un Popup al controlador");
            this.popup = padre;
            this.InitializeComponent();
        }

        private void cargarCombos()
        {
            comboMetodo.Items.Add("Visa");
            comboMetodo.Items.Add("Master Card");
            comboMetodo.SelectedIndex = 0;
        }
        private void botonBack_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            popup.IsOpen = false;
        }

        private async void botonAgregar_Click(object sender, RoutedEventArgs e)
        {
            DateTime dateTime = new DateTime();
            string fechaVenc = texBoxFechaVencimiento.Text + "-01";
            if (texBoxFechaVencimiento.Text.Length != 0 && textNumero.Text.Length != 0)
            {
                try
                {
                    dateTime = DateTime.ParseExact(fechaVenc, "yyyy-MM-dd", null);
                    MetodoPago metodo = new MetodoPago();
                    metodo.Marca = comboMetodo.SelectionBoxItem.ToString();
                    metodo.Numero = textNumero.Text;
                    metodo.FechaVencimiento = dateTime;
                    BufferUsuario.Usuario = await servicioAei.agregarMetodoPagoAsync(metodo, BufferUsuario.Usuario);
                    if (BufferUsuario.Usuario != null)
                    {
                        popup.IsOpen = false;
                        Popup popupp = new Popup();
                        VerMetodoPagoPopup ver = new VerMetodoPagoPopup(popupp);
                        popupp.IsOpen = true;
                        MessageDialog mensajeError = new MessageDialog("Operación exitosa");
                        mensajeError.ShowAsync();
                    }
                }
                catch
                {
                    MessageDialog mensajeError = new MessageDialog("Error en la fecha no tiene el formato indicada");
                    mensajeError.ShowAsync();
                }
            }
            else
            {
                MessageDialog mensajeError = new MessageDialog("Error todos los campos son obligatorios");
                mensajeError.ShowAsync();

            }
        }

        private void comboMetodo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
	
}
