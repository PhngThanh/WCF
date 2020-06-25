using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS.ReviewScreen.Media;
namespace POS.ReviewScreen
{
    public partial class formMonitor3 : Form
    {
        public int height = 800;
        public int width = 600;
        public formMonitor3()
        {
            InitializeComponent();
        }

        private void Monitor3_Load(object sender, EventArgs e)
        {

            Generate gen = new Generate();

            List<ImageItem> images = new List<ImageItem>();

            //TO DO load list image from json or database
            //@@currentDir : dir local 
            images.Add(new ImageItem()
            {
                Name = "Pic 1",
                Url = @"@@currentDir/images/combo1.jpg",
                Delay = 3,
            });

            images.Add(new ImageItem()
            {
                Name = "Pic 2",
                Url = @"@@currentDir/images/combo2.png",
                Delay = 3,
            });

            images.Add(new ImageItem()
            {
                Name = "Pic 3",
                Url = @"@@currentDir/images/combo3.jpg",
                Delay = 3,
            });

            images.Add(new ImageItem()
            {
                Name = "Pic 4",
                Url = @"@@currentDir/images/combo4.jpg",
                Delay = 3,
            });

            string templateData = gen.GenerateMediaHTML(images);// Create Image HTML CODE
            string html = gen.GenerateTemplateHTML("image", templateData); // Create HTML Template CODE
            WebBrowser webbrowser = new WebBrowser();
            webbrowser.DocumentText = html;
            webbrowser.Size = new Size(height, width);
            webbrowser.ScrollBarsEnabled = false;
            webbrowser.ScriptErrorsSuppressed = true;
            
            pnlView.Size = new Size(height, width);
            pnlView.Location = new Point(0 , 0);
            pnlView.Controls.Add(webbrowser);

        }
    }
}
