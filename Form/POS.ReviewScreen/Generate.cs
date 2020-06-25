using System;
using System.Collections.Generic;
using POS.ReviewScreen.Media;

namespace POS.ReviewScreen
{
    public class Generate
    {
        public bool _isLocal;

        public Generate()
        {
            _isLocal = true;
        }
        public Generate(bool isLocal)
        {
            _isLocal = isLocal;
        }

        public string GenerateMediaHTML(List<ImageItem> images)
        {
            string imagesText = "";
            foreach (var image in images)
            {
                imagesText += String.Format(@"<img src=""{0}"">", image.Url);
                imagesText += Environment.NewLine;
            }
            return imagesText;
        }

        public string GenerateMediaHTML(List<VideoItem> videos)
        {
            string videosText = "";
            foreach (var video in videos)
            {
                videosText += String.Format(@"<video width=""100%"" height=""100%"" autoplay><source src=""{0}"" type=""video/mp4""></video>", video.Url);
                videosText += Environment.NewLine;
            }
            return videosText;
        }
        public string GenerateTemplateHTML(string templateName, string templateData)
        {
            var currentDir = Environment.CurrentDirectory+ @"\Resources"; 
            string html = "";
            string pathTemplate = "";
            if (_isLocal)
            {
                pathTemplate = currentDir;
            }
            pathTemplate += @"\template\" + templateName + ".html";

            string rawTemplate = System.IO.File.ReadAllText(pathTemplate);

            html = rawTemplate.Replace("@@TemplateData", templateData);
            if (_isLocal)
            {
                html = html.Replace("@@currentDir", currentDir);
            }
            return html;
        }

    }
}
