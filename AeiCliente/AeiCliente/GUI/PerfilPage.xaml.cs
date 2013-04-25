using AeiCliente.ServicioAEI;
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

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

namespace AeiCliente
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class PerfilPage : Page
    {
        private Usuario usuario = BufferUsuario.Usuario;
        public PerfilPage()
        {
            this.InitializeComponent();
            cargarUsuario();
        }

        private void cargarUsuario()
        {
            cargarHistorialCompra();
            cargarInformacionBasica();
            cargarFechaNacimiento();
            cargarDireciones();
            bloquear(false);
        }

        public void cargarDireciones()
        {
            List<Direccion> listaDirecciones = usuario.Direcciones;
            for (int indexDireccion = 0; indexDireccion < listaDirecciones.Count(); indexDireccion++)
            {
                listBoxDireccion.Items.Add("Estado: " + listaDirecciones[indexDireccion].Estado + " Ciudad: " + listaDirecciones[indexDireccion].Ciudad+
                    " Codigo postal: " + listaDirecciones[indexDireccion].CodigoPostal+ " Descripcion: " + listaDirecciones[indexDireccion].Descripcion);
            }

        }

        private void cargarHistorialCompra()
        {
            for (int indexCompra = 0; indexCompra < usuario.Compras.Count(); indexCompra++)
            {
                listBoxHistorial.Items.Add("Compra solicitada el: " + usuario.Compras.ElementAt(indexCompra).FechaSolicitud.ToString());
            }
        }

        private void cargarFechaNacimiento()
        {
            ComboDia.Items.Add(usuario.FechaNacimiento.Day.ToString());
            ComboDia.SelectedIndex = 0;
            ComboMes.SelectedIndex = int.Parse(usuario.FechaNacimiento.Month.ToString())-1;    
            ComboAno.Items.Add(usuario.FechaNacimiento.Year.ToString());
            ComboAno.SelectedIndex = 0;

        }

        private void cargarInformacionBasica()
        {
            textCorreoEditable.Text = usuario.Email;
            textPasaporteEditable.Text = usuario.Pasaporte;
            textNombre.Text = usuario.Nombre + " " + usuario.Apellido;

        }

        private void bloquear(Boolean boolean)
        {
            ComboDia.IsEnabled = boolean;
            ComboMes.IsEnabled = boolean;
            ComboAno.IsEnabled = boolean;
        }

        private void botonAgregarDireccion_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
        	Popup popup = new Popup();
            DireccionPopup direcPopup= new DireccionPopup(popup, this);
            popup.Child = direcPopup;
            popup.IsOpen = true;
        }

        private void botonEditarInformacion_Click(object sender, RoutedEventArgs e)
        {
            bloquear(true);

        }
    }
}
