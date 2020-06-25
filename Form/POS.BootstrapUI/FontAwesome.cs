using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POS.CustomControl
{

    public  class FontAwesome : IDisposable
    {
        private Dictionary<string, string> Contents { get; set; }
        private PrivateFontCollection FontCollection { get; set; }
        private FontFamily AwesomeFontFamily { get; set; }

        #region Constructor and Initializing Methods

        public FontAwesome()
        {
            this.ParseCss(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory , @"Resources\font-awesome.css"), Encoding.UTF8));

            this.FontCollection = new PrivateFontCollection();
            this.FontCollection.AddFontFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory , @"Resources\fontawesome-webfont.ttf"));
            this.AwesomeFontFamily = this.FontCollection.Families.First();
        }

        private void ParseCss(string cssContent)
        {
            // Extract all character contents
            var cssParser = new ExCSS.Parser();
            var styleSheet = cssParser.Parse(cssContent);

            var first = styleSheet.StyleRules.First();

            var faContentRules = styleSheet.StyleRules.Where(q =>
                q.Selector.ToString().Contains(".fa-") &&
                q.Declarations.Properties.Any(p => p.Name.ToLower() == "content"));

            // Parse the class name and its content
            this.Contents = new Dictionary<string, string>();
            foreach (var faContent in faContentRules)
            {
                var names = this.ExtractFaClassName(faContent.Selector.ToString());

                var term = faContent.Declarations.Properties.First(q => q.Name.ToLower() == "content").Term.ToString();
                var value = term.Substring(1, term.Length - 2);

                foreach (var name in names)
                {
                    this.Contents.Add(name, value);
                }
            }
        }

        #endregion

        public Bitmap Generate(string key, float size, Color color, int padding = 0)
        {
            var content = this.Contents[key];

            var font = new Font(this.AwesomeFontFamily, size, GraphicsUnit.Pixel);
            var textSize = TextRenderer.MeasureText(content, font);

            // Do not apply using for the Bitmap, it is returned for further usage

            var result = new Bitmap(textSize.Width + padding * 2, textSize.Height + padding * 2);
            using (var graphics = Graphics.FromImage(result))
            {
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                graphics.DrawString(content, font, new SolidBrush(color), padding, padding);
            }

            return result;
        }

        public Bitmap GenerateIconWithText(string iconKey, float size, Color iconColor, string text, Font textFont, Color textColor, int padding,int imageTextPadding, bool isVertical)
        {
            //Get Icon Size
            var icon = this.Contents[iconKey];
            var fontIcon = new Font(this.AwesomeFontFamily, size, GraphicsUnit.Pixel);
            var iconSize = TextRenderer.MeasureText(icon, fontIcon);

            //Get Text Size
            var textSize = TextRenderer.MeasureText(text, textFont);

            Size imageSize = new Size();
            Point textLocation;
            Point iconLocation;
            if (isVertical)
            {
                imageSize.Width = Math.Max(iconSize.Width, textSize.Width) + padding * 2;
                imageSize.Height = iconSize.Height + imageTextPadding + textSize.Height + padding * 2;
                iconLocation = new Point((imageSize.Width - iconSize.Width) / 2, padding);
                textLocation = new Point((imageSize.Width - textSize.Width) / 2, padding + iconSize.Height + imageTextPadding);
            }
            else
            {
                imageSize.Height = Math.Max(iconSize.Height, textSize.Height) + padding * 2;
                imageSize.Width = iconSize.Width + imageTextPadding + textSize.Width + padding * 2;
                iconLocation = new Point(padding, (imageSize.Height - iconSize.Height) / 2);
                textLocation = new Point(padding + iconSize.Width + imageTextPadding, (imageSize.Height - textSize.Height)/2);
            }


            // Do not apply using for the Bitmap, it is returned for further usage

            var result = new Bitmap(imageSize.Width,imageSize.Height);
            using (var graphics = Graphics.FromImage(result))
            {
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;


                graphics.DrawString(icon, fontIcon, new SolidBrush(iconColor), iconLocation.X,iconLocation.Y);

                graphics.DrawString(text, textFont, new SolidBrush(textColor), textLocation.X, textLocation.Y);
            }

            return result;
        }

        public void Dispose()
        {
            this.Contents = null;
            this.FontCollection.Dispose();
        }

        private List<string> ExtractFaClassName(string cssSelector)
        {
            const string prefix = ".fa-";
            const int prefixLength = 4;
            const string postfix = ":before";

            var result = new List<string>();

            int position = -1;
            do
            {
                position = cssSelector.IndexOf(prefix, position + 1);

                if (position > -1)
                {
                    var endPosition = cssSelector.IndexOf(postfix, position + 1);

                    if (endPosition > -1)
                    {
                        result.Add(cssSelector.Substring(position + prefixLength, endPosition - position - prefixLength));
                    }
                }
            } while (position > -1);

            return result;
        }
    }
}
