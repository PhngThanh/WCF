using Newtonsoft.Json.Linq;
using POS.ReviewScreen.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.ReviewScreen
{
    public partial class Monitor2 : Form
    {
        private int posImage = 0;
        private List<Images> listImages = null;
        public Monitor2()
        {
            InitializeComponent();
            listImages =  GetImagesJSON();
            loadImage();
        }
        private void loadImage()
        {
            if (listImages.Count > posImage)
            {
                string pathImage = listImages[posImage].ImageURL;
                Bitmap bmp = new Bitmap(new Bitmap(pathImage), new Size(picBox.Width, picBox.Height));
                picBox.Image = bmp;
            }
        }



        private void Monitor2_Load(object sender, EventArgs e)
        {
            var primaryDisplay = Screen.AllScreens.ElementAtOrDefault(0);
            var extendedDisplay = Screen.AllScreens.FirstOrDefault(s => s != primaryDisplay) ?? primaryDisplay;

            this.Left = extendedDisplay.WorkingArea.Left + (extendedDisplay.Bounds.Size.Width / 2) - (this.Size.Width / 2);
            this.Top = extendedDisplay.WorkingArea.Top + (extendedDisplay.Bounds.Size.Height / 2) - (this.Size.Height / 2);
            this.WindowState = FormWindowState.Maximized;
            
            

        }
        public List<Images> GetImagesJSON()
        {
            List<Images> listImages = new List<Images>();
            var currentDir = Environment.CurrentDirectory;
            var pathImagesInfo = currentDir + @"\Configuration\imagesInfo.json";
            var imagesFolder = currentDir + @"\Resources\";

            using (StreamReader r = new StreamReader(pathImagesInfo))
            {
                string json = r.ReadToEnd();
                JObject ps = JObject.Parse(json);
                foreach (var p in ps["Images"])
                {
                    listImages.Add(new Images()
                    {
                        ImageName = (string)p["ImageName"],
                        ImageURL = imagesFolder + (string)p["ImageUrl"],
                        ImageTime = int.Parse((string)p["ImageTime"]),
                    });
                    
                }

            }
            return listImages;
        }

        public class Images
        {
            public string ImageName { get; set; }
            public string ImageURL { get; set; }
            public int ImageTime { get; set; }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            posImage = (posImage == 0) ? listImages.Count - 1 : posImage-1;
            loadImage();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            posImage = (posImage == listImages.Count-1) ? posImage=0 : posImage+1;
            loadImage();
        }
    }
}
