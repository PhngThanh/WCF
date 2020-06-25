using System;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using POS.Properties;
using POS.Utils;

namespace POS.Common
{
    public sealed class ClockControl : Panel
    {
        private readonly Timer _updateTick;

        public ClockControl()
        {
            _updateTick = new Timer { Interval = 1000 };
            _updateTick.Tick += ClockTick;
            //AutoSize = false;
            //Height = 50;
            //Width = 230;
            BackColor = Color.Transparent;

            var fonts = new PrivateFontCollection();
            var fontFm = Resources.OPENSANS_REGULAR;
            //var fontFm = Resources.opensans_regular1;
            var fontPtr = Marshal.AllocCoTaskMem(fontFm.Length);
            Marshal.Copy(fontFm, 0, fontPtr, fontFm.Length);
            fonts.AddMemoryFont(fontPtr, Resources.OPENSANS_REGULAR.Length);
            _privateFontCollection = fonts;
            StartClock();
        }


        public static readonly string[] Month = {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "Septemper",
            "October",
            "November",
            "December",
        };

        private readonly PrivateFontCollection _privateFontCollection;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var time = UtcDateTime.Now();
            var h = time.Hour < 10 ? "0" + time.Hour : time.Hour.ToString();
            var m = time.Minute < 10 ? "0" + time.Minute : time.Minute.ToString();
            var s = time.Second < 10 ? "0" + time.Second : time.Second.ToString();
            var fontL = new Font(_privateFontCollection.Families[0], 26, FontStyle.Regular);
            var fontN = new Font(_privateFontCollection.Families[0], 22, FontStyle.Regular);
            var fontSr = new Font(_privateFontCollection.Families[0], 8, FontStyle.Regular);
            var fontSb = new Font(_privateFontCollection.Families[0], 8, FontStyle.Bold);
            e.Graphics.DrawString(h, fontL, new SolidBrush(Color.White), 10, 0);
            e.Graphics.DrawString(":" + m + ":" + s, fontN, new SolidBrush(Color.White), 51, 6);
            e.Graphics.DrawString(Month[time.Month - 1], fontSb, new SolidBrush(Color.White), 141, 13);
            e.Graphics.DrawString(time.ToString("dd/MM/yyyy"), fontSr, new SolidBrush(Color.White), 141, 26);
        }

        public void StartClock()
        {
            _updateTick.Start();
        }

        private void ClockTick(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
