using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using MessagingToolkit.QRCode.Codec;
using POS.Utils;

namespace POS.VPOS
{
    public partial class TCPConnectionInfoScreen : UserControl
    {
    //    private static readonly ILog log =
    //        LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public TCPConnectionInfoScreen()
        {
            InitializeComponent();

            this.GenerateQRCode();
        }

        private void GenerateQRCode()
        {
            try
            {
                //Assign the any IP of the machine and listen on port number 1000
                QRCodeEncoder encoder = new QRCodeEncoder();
                Bitmap img;

                IPHostEntry ipEntry = Dns.GetHostEntry(Dns.GetHostName());
                foreach (IPAddress entry in ipEntry.AddressList)
                {
                    if (entry.AddressFamily == AddressFamily.InterNetwork)
                    {
                        img = encoder.Encode(entry.ToString());
                        this.imgQRCode.Image = img;
                    }
                }
            }
            catch (Exception ex)
            {
                //log.Error("GenerateQRCode - " + ex);
                //Program._log.SendLogError(ex);
            }
        }
    }
}
