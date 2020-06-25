using MessagingToolkit.QRCode.Codec;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyConnect.POSSimulator.Utils
{
    public class QRCode
    {
        public static string QRPath = AppDomain.CurrentDomain.BaseDirectory + @"Images\";
        public static Bitmap GenerateQR(int width, int height, string text)
        {
            QRCodeEncoder encoder = new QRCodeEncoder();
            var qrcode = encoder.Encode(text);
            //pictureBox1.Image = qrcode as Image;//Displays generated code in PictureBox

            //decode
            //QRCodeDecoder dec = new QRCodeDecoder();
            //textBox2.Text = (dec.decode(new QRCodeBitmapImage(pictureBox1.Image as Bitmap)));

            //var bw = new ZXing.BarcodeWriter();
            //var encOptions = new ZXing.Common.EncodingOptions() { Width = width, Height = height, Margin = 0 };
            //bw.Options = encOptions;
            //bw.Format = ZXing.BarcodeFormat.QR_CODE;
            //var result = new Bitmap(bw.Write(text));

            qrcode.Save(QRPath + "bm1.bmp", ImageFormat.Bmp);

            return qrcode;
        }
    }
}
