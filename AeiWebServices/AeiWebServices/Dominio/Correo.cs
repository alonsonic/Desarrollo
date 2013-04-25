using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace AeiWebServices.Dominio
{
    public class Correo
    {
        private SmtpClient servidor = new SmtpClient("smtp.gmail.com", 587);
        public Correo()
        {
            servidor.Credentials = new System.Net.NetworkCredential("aeiStoreSoporte@gmail.com", "aei12345");
            servidor.Port = 587;
            servidor.Host = "smtp.gmail.com";
            servidor.EnableSsl = true;
        }

        private void enviarCorreo(MailMessage mensaje)
        {

            mensaje.SubjectEncoding = System.Text.Encoding.UTF8;
            mensaje.BodyEncoding = System.Text.Encoding.UTF8;
            servidor.Send(mensaje);

        }

        public int enviarCorreoDeBienvenida(string mail, string nombre, string apellido, int codigoActivacion)
        {
            try
            {
                MailMessage mensaje = new MailMessage();

                mensaje.To.Add(mail);
                mensaje.From = new MailAddress("aeiStoreSoporte@gmail.com", "aei Store", System.Text.Encoding.UTF8);
                mensaje.Subject = "¡Bienvenido a aei Store!";
                mensaje.IsBodyHtml = true;
                mensaje.Body = @"<img src = '' />
                                <h2>Estimado(a) "+nombre+" "+apellido+ @".</h2>
                                <p><strong>aei Store</strong> te da la bienvenida.</p>
                                <p>
                                    En nuestra tienda de juguetes encontrarás los
                                    mejores productos y precios. Con nuestra aplicación podrás comprar fácilmente desde cualquier lugar.
                                </p>
                                <p>
                                    Para concluir con su registro debe ingresar el siguiente código en la aplicación:<br/>
                                    <h2>"+codigoActivacion.ToString()+@"</h2>
                                </p>
                                <p>¡Gracias por registrarte!<br /> 
                                    Atentamente, <br />
                                    El equipo de aei Store</p>";
                enviarCorreo(mensaje);
                return 1;
            }
            catch
            {
                return 0;
            }

        }


    }
}