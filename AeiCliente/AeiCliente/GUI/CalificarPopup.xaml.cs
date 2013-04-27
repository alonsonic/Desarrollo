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
    public sealed partial class CalificarPopup : UserControl
    {
        private Popup popup = null;
        private ServicioAEIClient servicioAei = new ServicioAEIClient();
        Producto producto = null;

        public CalificarPopup(Popup padre, Producto producto)
        {
            if (padre == null) throw new ArgumentNullException("Debe asignar un Popup al controlador");
            this.popup = padre;
            this.InitializeComponent();
            cargarCombo();
            this.producto = producto;
        }


        private void cargarCombo()
        {
            comboPuntacion.Items.Clear();
            for (int index = 1; index <= 5; index++)
                comboPuntacion.Items.Add(index.ToString());
            comboPuntacion.SelectedIndex = 0;
        }

        private void botonBack_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            popup.IsOpen = false;
        }

        private async void botonAgregar_Click(object sender, RoutedEventArgs e)
        {
            Calificacion calificacion = new Calificacion();
            calificacion.Puntaje = comboPuntacion.SelectedIndex+1;
            calificacion.Comentario = textComentario.Text;
            int error = await servicioAei.agregarCalificacionAsync(producto.Id, BufferUsuario.Usuario.Id, calificacion);
            if (error == 1)
            {
                MessageDialog mensajeError = new MessageDialog("Operación realizada");
                mensajeError.ShowAsync();
                popup.IsOpen = false;

            }
            else
            {
                MessageDialog mensajeError = new MessageDialog("Error no se pudo agregar su comentrario. Envíe un correo electrónico a aeiStoreSoporte@gmail.com reportando su caso");
                mensajeError.ShowAsync();

            }

        }

    }
}
