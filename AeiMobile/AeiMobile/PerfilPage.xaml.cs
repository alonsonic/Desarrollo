using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace AeiMobile
{
    public partial class PerfilPage : PhoneApplicationPage
    {
        private bool menuAbierto = false;

        public PerfilPage()
        {
            InitializeComponent();
            cargarInformacionUsuario();
            Menu.Children.Add(new MenuControl());
        }

        private void cargarInformacionUsuario()
        {
            this.textUsuario.Text = BufferUsuario.Usuario.Nombre +" "+BufferUsuario.Usuario.Apellido;
            this.textCorreo.Text = BufferUsuario.Usuario.Email;
            this.textNacimiento.Text = BufferUsuario.Usuario.FechaNacimiento.ToString("yyyy-MM-dd");
            cargarListaDirecciones();
        }

        private void cargarListaDirecciones()
        {
            int contador = 0;
            foreach (var item in BufferUsuario.Usuario.Direcciones)
            {
                contador++;
                this.listDireccion.Items.Add(contador.ToString()+") Estado: " + item.Estado + " Ciudad: " + item.Ciudad +"\nDescripción: " + item.Descripcion);
            }
        }

        private void botonMenu_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
        }
    }
}