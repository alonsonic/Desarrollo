using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Rendering;
using System.Drawing;
using System.Drawing.Imaging;

namespace AeiWebServices.Dominio
{
    public class CodigoQr
    {
        public void generar(Compra compra)
        {
            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
            QrCode qrCode = qrEncoder.Encode(compra.Id.ToString());
            Renderer renderer = new Renderer(5, Brushes.Black, Brushes.White);
            renderer.CreateImageFile(qrCode.Matrix, "c:/Qr" + compra.Id.ToString() + ".png", ImageFormat.Png);
        }
    }
}