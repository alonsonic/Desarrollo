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

namespace AeiCliente.GUI
{

    public sealed partial class PerfilPageAgregar : Page
    {
        private ServicioAEIClient servicio = new ServicioAEIClient();
        public static string padre;

        public PerfilPageAgregar()
        {
            this.InitializeComponent();
            agregarDia();
            agregarAño();
            buttonElimanarDireccion.Visibility = Visibility.Collapsed;
            if (padre == "Agregar usuario")
            {    
                ComboMes.SelectedIndex = 0;
            }
            else
            {
                textBoxNombre.Text = BufferUsuario.Usuario.Nombre;
                textBoxApellido.Text = BufferUsuario.Usuario.Apellido;
                textCorreoEditable.Text = BufferUsuario.Usuario.Email;
                textCorreoEditable.IsEnabled = false;
                textPasaporteEditable.Text = BufferUsuario.Usuario.Pasaporte;
                textPasaporteEditable.IsEnabled = false;
                comboAno.SelectedValue = BufferUsuario.Usuario.FechaNacimiento.Year;
                comboDia.SelectedIndex = BufferUsuario.Usuario.FechaNacimiento.Day;
                ComboMes.SelectedIndex = BufferUsuario.Usuario.FechaNacimiento.Month;
                cargarDireciones();
               
            }
             
        }

        

        private void botonAgregarDireccion_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Popup popup = new Popup();
            DireccionPopup direcPopup = new DireccionPopup(popup, this);
            popup.Child = direcPopup;
            popup.IsOpen = true;

        }

        public void cargarDireciones()
        {
            listBoxDireccion.Items.Clear();
            List<Direccion> listaDirecciones = BufferUsuario.Usuario.Direcciones;
            for (int indexDireccion = 0; indexDireccion < listaDirecciones.Count(); indexDireccion++)
            {
                listBoxDireccion.Items.Add("Estado: " + listaDirecciones[indexDireccion].Estado + " Ciudad: " + listaDirecciones[indexDireccion].Ciudad +
                    " Codigo postal: " + listaDirecciones[indexDireccion].CodigoPostal + " Descripcion: " + listaDirecciones[indexDireccion].Descripcion);
            }

        }

        private void agregarAño()
        {
            comboAno.Items.Add("Año");
            for (int index = 1913; index <= 2011; index++)
                comboAno.Items.Add(index);

            comboAno.SelectedIndex = 0;
            
        }

        private void agregarDia()
        {
            comboDia.Items.Add("Dia");
            for (int index = 1; index <= 31; index++)
            {
                if (index < 10) comboDia.Items.Add("0" + index.ToString());
                else comboDia.Items.Add(index);
            }

            comboDia.SelectedIndex = 0;
        }
        

        private void buttonCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }


        

        private async void buttonEnviar_Click(object sender, RoutedEventArgs e)
        {
            string mes=ComboMes.SelectedIndex+"";
            if (ComboMes.SelectedIndex < 10) mes = "0" + mes;
           
            if (padre == "Agregar usuario")
            {
                Usuario usuario = await servicio.agregarUsuarioAsync(textBoxNombre.Text, textBoxApellido.Text, textPasaporteEditable.Text,
                                      textCorreoEditable.Text, comboAno.SelectedValue.ToString() + "-" + mes + "-" + comboDia.SelectedValue.ToString());
                
                if (usuario == null)
                {
                    MessageDialog mensajeError = new MessageDialog("Error no se pudo agregar al sistema");
                    mensajeError.ShowAsync();
                }
                else
                {
                    BufferUsuario.Usuario = usuario;
                    int error = await servicio.enviarCorreoDeBienvenidaAsync(usuario);
                    if (error == 1)
                    {
                        MessageDialog mensajeError = new MessageDialog("Se envió un código de activación a su correo, activelo y dirigase a su  perfil para completar su informacion");
                        mensajeError.ShowAsync();

                    }
                    else
                    {
                        MessageDialog mensajeError = new MessageDialog("Error no se pudo enviar el código de activación. Envíe un correo electrónico a aeiStoreSoporte@gmail.com reportando su caso");
                        mensajeError.ShowAsync();
                    }
                    this.Frame.Navigate(typeof(PerfilPage));
                }
            }
            else
            {
                 BufferUsuario.Usuario.Nombre = textBoxNombre.Text;
                 BufferUsuario.Usuario.Apellido = textBoxApellido.Text;
                try
                {
                   string fecha = comboAno.SelectedValue.ToString()+ "-"+mes+ "-" +comboDia.SelectedValue.ToString();
                   DateTime datetime = DateTime.ParseExact(fecha, "yyyy-MM-dd", null);
                   BufferUsuario.Usuario.FechaNacimiento = datetime;
                }
                catch
                {
                    MessageDialog mensajeError = new MessageDialog("Error Fecha invalidad");
                    mensajeError.ShowAsync();
                }


                int error = await servicio.modificarUsuarioAsync(BufferUsuario.Usuario);
                if (error == 1)
                {
                    servicio.enviarCorreoDeModificacionAsync(BufferUsuario.Usuario);
                    this.Frame.Navigate(typeof(PerfilPage));
                    
                }
                else
                {
                    MessageDialog mensajeError = new MessageDialog("Error no se pudo modificar su perfil. Envíe un correo electrónico a aeiStoreSoporte@gmail.com reportando su caso");
                    mensajeError.ShowAsync();
                }
            }
        }


        private void botonLupa_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
        	// TODO: Agregar implementación de controlador de eventos aquí.
        }

        private void botonPerfil_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
        	// TODO: Agregar implementación de controlador de eventos aquí.
        }

        private void botonCarrito_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
        	// TODO: Agregar implementación de controlador de eventos aquí.
        }

        private void listBoxDireccion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            buttonElimanarDireccion.Visibility = Visibility.Visible;

        }

        private async void buttonElimanarDireccion_Click(object sender, RoutedEventArgs e)
        {
            int seleccionBoxDireccion = listBoxDireccion.SelectedIndex;
            if(seleccionBoxDireccion>=0 )
            {
                Direccion direccion = BufferUsuario.Usuario.Direcciones[seleccionBoxDireccion];
                direccion.Status = "I";
                int error =  await servicio.modificarDireccionAsync(direccion);
                if (error == 1)
                {
                    BufferUsuario.Usuario.Direcciones.RemoveAt(seleccionBoxDireccion);
                    cargarDireciones();
                }
                else
                {
                    MessageDialog mensajeError = new MessageDialog("Error no se pudo eliminar la dirección. Envíe un correo electrónico a aeiStoreSoporte@gmail.com reportando su caso");
                    mensajeError.ShowAsync();
                }

            }
        }

        private void comboDia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        
    }
}
