﻿using AeiCliente.GUI;
using AeiCliente.ServicioAEI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (BufferUsuario.Usuario != null)
            {
                validarStatusUsuario();
            }
        }

        private void validarStatusUsuario()
        {
            if (BufferUsuario.Usuario != null)
                if (BufferUsuario.Usuario.Status.Equals("I "))
                {
                    Popup popup = new Popup();
                    CodigoConfirPopup direcPopup = new CodigoConfirPopup(popup);
                    popup.Child = direcPopup;
                    popup.IsOpen = true;
                }
        }

        public void cargarDireciones()
        {
            listBoxDireccion.Items.Clear();
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



        private void botonEditarInformacion_Click(object sender, RoutedEventArgs e)
        {
            PerfilPageAgregar.padre = "Editar informacion";
            this.Frame.Navigate(typeof(PerfilPageAgregar));
        }

        private void botonHome_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void botonBack_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void botonLupa_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ListaProductoPage));
        }

        private void botonPerfil_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            MessageDialog mensajeError = new MessageDialog("Debe iniciar sesión para acceder a su perfil.");

            if (BufferUsuario.isConectado())
            {
                this.Frame.Navigate(typeof(PerfilPage));
            }
            else
            {
                mensajeError.ShowAsync();
            }
        }

        private void botonCarrito_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            MessageDialog mensajeError = new MessageDialog("Debe iniciar sesión para llevar una lista de compras.");

            if (BufferUsuario.isConectado())
                this.Frame.Navigate(typeof(ListaCompraPage));
            else
            {
                mensajeError.ShowAsync();
            }
        }

        private void botonVerDetalleCompra_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxHistorial.SelectedIndex >= 0)
            {
                HistorialCompraPage.indexCompra =  listBoxHistorial.SelectedIndex;
                this.Frame.Navigate(typeof(HistorialCompraPage));
            }
            else
            {
                MessageDialog mensajeError = new MessageDialog("Debe seleccionar un item del historial de compras.");
                mensajeError.ShowAsync();
            }
        }

        private void botonGestionarMetodo_Click(object sender, RoutedEventArgs e)
        {
            Popup popup = new Popup();
            VerMetodoPagoPopup metodoPopup = new VerMetodoPagoPopup(popup);
            popup.Child = metodoPopup;
            popup.IsOpen = true;
        }

        private void listBoxDireccion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
