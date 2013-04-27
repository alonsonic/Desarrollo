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

        private async void botonComprar_Click(object sender, RoutedEventArgs e)
        {
            DateTime dateTime = new DateTime();
            string fecha = texBoxFechaVencimiento + "01";
            try
            {
                dateTime = DateTime.ParseExact(fecha, "yyyy-MM-dd", null);
            }
            catch
            {
                MessageDialog mensajeError = new MessageDialog("Error en la fecha no tiene el formato indicada");
                mensajeError.ShowAsync();
            }
            MetodoPago metodo = new MetodoPago();
            metodo.Marca = comboMetodo.SelectedValue.ToString();
            metodo.Numero = textNumero.Text;
            metodo.FechaVencimiento = dateTime;
            BufferUsuario.Usuario =  await servicioAei.agregarMetodoPagoAsync(metodo, BufferUsuario.Usuario);
        }

    }
	
}
