﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

namespace AeiWebServices.Dominio
{
    public class Pdf
    {

        public void generar(Usuario usuario, List<DetalleCompra> listaDeCompra)
        {
            string file = "C:/MiPrimer.pdf";

            string html = @"<img src='C:\Users\Liliana\Desktop\UCAB\aei-logo.png' alt='aei store - logo'>
	                        <h2 align='right'><font color='#F05D13'>Pre-orden</font></h2>
	                        <p align='right'>
		                        <strong>Fecha: </strong>"+DateTime.Today.ToString("dd-MM-yyyy")+@"<br />
		                        <strong>Nro. Orden: </strong> 123124
	                        </p>
	                        <h2><font color='#F05D13'><strong>Datos del Cliente</strong></font></h2>
	                        <p>
		                        <strong>Nombre completo: </strong>"+usuario.Nombre+@"<br />
                                <strong>C&eacute;dula: </strong>"+usuario.Pasaporte+@"<br />
                                <strong>Correo Electr&oacute;nico:</strong>"+usuario.Email + @"<br />
                                <strong>Direcci&oacute;n: </strong><br />
	                        </p>
	                        <br />
                            <div class='datagrid'>
                            <table>
		                        <thead><tr>
			                        <th width='50%'>Producto</th>
			                        <th width='10%'>Cantidad</th>
			                        <th width='20%'>Precio unitario Bs.</th>
			                        <th width='20%'>Total Bs.</th></tr>
		                        </thead>
                                    <tbody>";

                            for(int i = 0; i<listaDeCompra.Count() ; i++)
                            {
		                        
			                       html= html + @"<tr>
				                                    <td>"+listaDeCompra[i].Producto.Nombre+ @"</td><td>"+listaDeCompra[i].Cantidad.ToString() + @"</td><td>"+listaDeCompra[i].Monto.ToString()+ @"</td><td>data</td>
			                                    </tr>";
                            }
                            html = html + "</tbody></table></div>";
                            html = html + @"<table>
		                                    <tbody>
			                                    <tr ><td width='50%' style='background-color:white;'></td><td width='10%' style='background-color:white;'></td>
			                                    <td width='20%'><strong>
				                                    Total a Pagar Bs
			                                    </strong></td><td width='20%'>
				                                    data
			                                    </td></tr>
		                                    </tbody>
	                                    </table>";
            Document document = new Document(PageSize.A4, 80, 50, 30, 65);
            PdfWriter.GetInstance(document, new FileStream(file, FileMode.Create));
            document.Open();
            foreach (IElement E in HTMLWorker.ParseToList(new StringReader(html), new StyleSheet())) document.Add(E); document.Close();

        }

    }
}