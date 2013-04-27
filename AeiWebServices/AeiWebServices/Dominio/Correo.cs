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
                mensaje.Body = @"<img src = 'https://fbcdn-sphotos-c-a.akamaihd.net/hphotos-ak-ash4/381399_10201016661237859_441547910_n.jpg' />
                                <h2>Estimado(a) " +nombre+" "+apellido+ @".</h2>
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

        public int enviarCorreoDeModificacion(string mail, string nombre, string apellido)
        {
            try
            {
                MailMessage mensaje = new MailMessage();

                mensaje.To.Add(mail);
                mensaje.From = new MailAddress("aeiStoreSoporte@gmail.com", "aei Store", System.Text.Encoding.UTF8);
                mensaje.Subject = "Notificación de actualización en perfil aei Store";
                mensaje.IsBodyHtml = true;
                mensaje.Body = @"
                                    <img src = 'https://fbcdn-sphotos-c-a.akamaihd.net/hphotos-ak-ash4/381399_10201016661237859_441547910_n.jpg' />
                                    <h2>Estimado(a)" + nombre+" "+apellido+@",</h2>
                                    <p>
                                        Le informamos que el día "+DateTime.Today.ToString("dd-MM-yyyy")+@" se han hecho modificaciones en su perfil personal en su cuenta de aei Store.
                                    </p>
                                    <p>
                                         Si usted no reconoce haber realizado esta operación, comuníquese inmediatamente con nosotros a
                                            través del correo electrónico aeiStoreSoporte@gmail.com.
                                    </p>
                                    <p>
                                        Gracias por su preferencia,
                                    </p>
                                    <p>
                                        Atte,
                                        El equipo de aei Store.
                                    </p>";
                enviarCorreo(mensaje);
                return 1;
            }
            catch
            {
                return 0;
            }

        }


        public int enviarCorreoDeFactura(Usuario usuario, Compra compra)
        {
            try
            {
                MailMessage mensaje = new MailMessage();
                Pdf pdf = new Pdf();
                pdf.generar(usuario, compra);
                mensaje.To.Add(usuario.Email);
                mensaje.From = new MailAddress("aeiStoreSoporte@gmail.com", "aei Store", System.Text.Encoding.UTF8);
                mensaje.Subject = "Notificación de actualización en perfil aei Store";
                mensaje.IsBodyHtml = true;
                mensaje.Body = @"
                                    <img src = 'https://fbcdn-sphotos-c-a.akamaihd.net/hphotos-ak-ash4/381399_10201016661237859_441547910_n.jpg' />
                                    <h2>Estimado(a)" + usuario.Nombre + " " + usuario.Apellido + @",</h2>
                                    <p>
                                        Su pago en aei Store fue procesado. Le enviamos su factura electrónica, la cual le servirá para el recibo de su pedido. 
                                    </p>
                                    <h2>
                                        ¡Gracias por comprar en aei Store!
                                    </h2>
                                    <p>
                                      Si no reconoces haber realizado esta operación, o tienes cualquier duda, por favor escríbenos al correo electrónico aeiStoreSoporte@gmail.com.
                                    </p>";
                mensaje.Attachments.Add(new Attachment("C:/Factura" + compra.Id + ".pdf"));
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