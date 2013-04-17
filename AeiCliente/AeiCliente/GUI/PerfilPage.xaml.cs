using AeiCliente.ServiceReference2;
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
        public PerfilPage()
        {
            this.InitializeComponent();
            cargarUsuario();
        }

        private void cargarUsuario()
        {
            Usuario usuario = BufferUsuario.Usuario;

            textCorreoEditable.Text = usuario.Email;
            textPasaporteEditable.Text = usuario.Pasaporte;
            textNombre.Text = usuario.Nombre + " " + usuario.Apellido;

            for (int indexCompra = 0; indexCompra < usuario.Compras.Count(); indexCompra++)
            {
                listBoxHistorial.Items.Add("Compra solicitada el: " + usuario.Compras.ElementAt(indexCompra).FechaSolicitud.ToString());
            }
            
        }

        /// <summary>
        /// Se invoca cuando esta página se va a mostrar en un objeto Frame.
        /// </summary>
        /// <param name="e">Datos de evento que describen cómo se llegó a esta página. La propiedad Parameter
        /// se usa normalmente para configurar la página.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}
