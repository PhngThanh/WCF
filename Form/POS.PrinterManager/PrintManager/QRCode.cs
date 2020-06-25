using System.Drawing;
using MessagingToolkit.QRCode.Codec;
using System;
using SkyConnect.POSLib.Domains;
using SkyConnect.POSLib.Utils;
using POS.Repository;

namespace PrinterManager.PrintManager
{
    public class QRCode
    {
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

            return qrcode;
        }



        const char BELL_CHAR = ((char)7);

        const string VERSION = "2";
        const string TRAN_TYPE = "7";

        const string REFERENCE_1 = "ref1";
        const string REFERENCE_2 = "ref2";

        const string SHOW_POPUP_ON = "1";
        const string SHOW_POPUP_OFF = "0";

        public static string GenerateStrMomo(string serviceId, string orderCode, string amount, string description, DateTime time)
        {
            var dateCode = time.ToString("-yyMMdd-HHmm");
            var billId = orderCode + dateCode;

            var str = VERSION + BELL_CHAR +
                      TRAN_TYPE + BELL_CHAR +
                      serviceId + BELL_CHAR +
                      billId + BELL_CHAR +
                      amount + BELL_CHAR +
                      REFERENCE_1 + BELL_CHAR +
                      REFERENCE_2 + BELL_CHAR +
                      description + BELL_CHAR + //REFERENCE_2 + BELL_CHAR +
                      SHOW_POPUP_ON;
            return str;
        }

        public static string SkyConnectGenerateStrQRCode(string orderCode, string amount, DateTime time)
        {
            time = DateTime.SpecifyKind(time, DateTimeKind.Utc);
            var config = StoreInfoManager.GetStoreInfo(true).SkyConnectConfig;
            var pDomain = new SkyConnectPaymentDomain(config);
            //var paymentType = Program.context.getCurrentOrderManager().paymentType;
            var paymentType = PaymentTypeEnum.MoMo;// sửa lại cái này
            var str = "";
            try
            {
                if (paymentType == PaymentTypeEnum.MoMo)
                {
                    str = pDomain.GetQRCode(orderCode, time, double.Parse(amount), (int)SkyConnectPartnerEnum.Momo);
                }
                else if (paymentType == PaymentTypeEnum.ZaloPay)
                {
                    str = pDomain.GetQRCode(orderCode, time, double.Parse(amount), (int)SkyConnectPartnerEnum.ZaloPay);
                }
            }
            catch (Exception ex)
            {
                
            }

            return str;
        }
    }
}
