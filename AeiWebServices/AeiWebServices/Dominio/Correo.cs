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
            servidor.Credentials = new System.Net.NetworkCredential("mail@gmail.com", "clave");
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

        public void enviarCorreoDeBienvenida(string mail, string nombre, string apellido)
        {
            try
            {
                MailMessage mensaje = new MailMessage();

                mensaje.To.Add(mail);
                mensaje.From = new MailAddress("mail@gmail.com", "AEI STORE", System.Text.Encoding.UTF8);
                mensaje.Subject = "¡Bienvenido a AEI STORE!";
                mensaje.IsBodyHtml = true;
                mensaje.Body = "<img src = '' /><h2>Estimado(a) "+nombre+" "+apellido+".</h2><p>Aei Store te da la bienvenida. Este es la mejor tienda  de juguetes donde encontraras los mejores productos y precios. Con nuestras aplicación podrás comprar fácilmente desde tu hogar.</p><p>¡Gracias por registrarte en aei Store<br /> Atentamente, <br />El equipo de aei Store</p>";
                enviarCorreo(mensaje);
            }
            catch
            {
                Console.WriteLine("El Correo NO se pudo enviar");

            }

        }


    }
}