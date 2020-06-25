using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace POS.Common
{
    public static class DrawUtility
    {
        #region DrawBorderRadiusRectangle
        public static GraphicsPath DrawBorderRadiusRectangle(int x1, int y1, int x2, int y2,
            int radius1, int radius2, int radius3, int radius4)
        {
            var path = new GraphicsPath();
            path.StartFigure();
            path.AddLine(x1, y1 + radius1, x1, y2 - radius4);
            if (radius4 != 0)
            {
                path.AddArc(x1, y2 - 2 * radius4, 2 * radius4, 2 * radius4, 180, -90);
            }
            path.AddLine(x1 + radius4, y2, x2 - radius3, y2);
            if (radius3 != 0)
            {
                path.AddArc(x2 - 2 * radius3, y2 - 2 * radius3, 2 * radius3, 2 * radius3, 90, -90);
            }
            path.AddLine(x2, y2 - radius3, x2, y1 + radius2);
            if (radius2 != 0)
            {
                path.AddArc(x2 - 2 * radius2, y1, 2 * radius2, 2 * radius2, 0, -90);
            }
            path.AddLine(x1 + radius1, y1, x2 - radius2, y1);
            if (radius1 != 0)
            {
                path.AddArc(x1, y1, 2 * radius1, 2 * radius1, 270, -90);
            }
            path.CloseFigure();
            return path;
        }

        public static GraphicsPath DrawBorderRadiusRectangle(int x1, int y1, int x2, int y2, int radius)
        {
            return DrawBorderRadiusRectangle(
                x1,
                y1,
                x2,
                y2,
                radius,
                radius,
                radius,
                radius);
        }
        //public static GraphicsPath DrawBorderRadiusRectangle(Point point1, Point point2, int radius)
        //{
        //    return DrawBorderRadiusRectangle(
        //        point1.X,
        //        point1.Y,
        //        point2.X,
        //        point2.Y,
        //        radius);
        //}

        public static GraphicsPath DrawBorderRadiusRectangle(Rectangle rectangle, int radius)
        {
            return DrawBorderRadiusRectangle(
                rectangle.Left,
                rectangle.Top,
                rectangle.Right,
                rectangle.Bottom,
                radius);
        }

        public static GraphicsPath DrawBorderRadiusRectangle(Rectangle rectangle, int radius1, int radius2,
            int radius3, int radius4)
        {
            return DrawBorderRadiusRectangle(
                rectangle.Left,
                rectangle.Top,
                rectangle.Right,
                rectangle.Bottom,
                radius1,
                radius2,
                radius3,
                radius4);
        }
        #endregion

        #region DrawSmoothEdgeRectangle

        public static GraphicsPath DrawSmoothEdgeRectangle(int x1, int y1, int x2, int y2, int top,
            int right, int bottom, int left)
        {
            var path = new GraphicsPath();

            path.StartFigure();
            if (top > 0)
            {
                DrawArc(x1, y1, x2 - x1, top, 270, path);
            }
            else if (top == 0)
            {
                path.AddLine(x1, y1, x2, y1);
            }
            else
            {
                DrawArc(x1, y1, x2 - x1, top, 90, path);
            }
            if (right > 0)
            {
                DrawArc(x2, y1, y2 - y1, right, 0, path);
            }
            else
            {
                path.AddLine(x2, y1, x2, y2);
            }
            if (bottom > 0)
            {
                DrawArc(x2, y2, x2 - x1, bottom, 90, path);
            }
            else
            {
                path.AddLine(x2, y2, x1, y2);
            }
            if (left > 0)
            {
                DrawArc(x1, y2, y2 - y1, left, 180, path);
            }
            else
            {
                path.AddLine(x1, y2, x1, y1);
            }
            path.CloseFigure();
            return path;
        }

        private static void DrawArc(int x, int y, int width, int height, int angle, GraphicsPath path)
        {
            var flag = height > 0;
            height = Math.Abs(height);
            var radius = (width * width) / (8 * height) + (height / 2);
            var tmpX = x - (angle == 90 && flag ? (width + radius - width / 2) : (radius - width / 2));
            var tmpY = y - (angle == 90 ? (2 * radius - height) : height);
            if (angle == 0 || angle == 180)
            {
                tmpX = x - (angle == 0 ? (2 * radius - height) : height);
                tmpY = y - radius + width / 2;
            }
            var startAngle = (float)(angle - Math.Asin((width / 2.0) / radius) * 180 / Math.PI);
            var sweepAngle = (float)(Math.Asin((width / 2.0) / radius) * 180 * 2 / Math.PI);
            startAngle += flag ? 0 : sweepAngle;
            sweepAngle = flag ? sweepAngle : -sweepAngle;
            path.AddArc(tmpX, tmpY, 2 * radius, 2 * radius, startAngle, sweepAngle);
        }
        public static GraphicsPath DrawSmoothEdgeRectangleWithHaft(int x1, int y1, int x2, int y2, int top,
          int bottom, int cropWidth)
        {
            var path = new GraphicsPath();

            path.StartFigure();
            if (top > 0)
            {
                DrawHaftArc(x1, y1, x2 - x1, top, 270, path, Math.Abs(cropWidth), cropWidth > 0);
            }
            else if (top == 0)
            {
                path.AddLine(x1, y1, cropWidth, y1);
            }
            else
            {
                DrawHaftArc(x1, y1, x2 - x1, top, 90, path, Math.Abs(cropWidth), cropWidth > 0);
            }
            if (bottom > 0)
            {
                DrawHaftArc(x2, y2, x2 - x1, bottom, 90, path, Math.Abs(cropWidth), cropWidth < 0);
            }
            else
            {
                path.AddLine(x2, y2, x1, y2);
            }
            path.CloseFigure();
            return path;
        }
        private static void DrawHaftArc(int x, int y, int width, int height, int angle, GraphicsPath path, int cropWidth, bool isFollow = true)
        {
            var flag = height > 0;
            height = Math.Abs(height);
            var tmp = Math.Sqrt(cropWidth * cropWidth + height * height);
            var radius = (width * width) / (8 * height) + (height / 2);

            var tmpX = x - (angle == 90 && flag ? (width + radius - width / 2) : (radius - width / 2));
            var tmpY = y - (angle == 90 ? (2 * radius - height) : height);
            if (angle == 0 || angle == 180)
            {
                tmpX = x - (angle == 0 ? (2 * radius - height) : height);
                tmpY = y - radius + width / 2;
            }
            var startAngle = (float)(angle - Math.Asin((width / 2.0) / radius) * 180 / Math.PI);
            var sweepAngle = (float)(Math.Asin((width / 2.0) / radius) * 180 * 2 / Math.PI);
            var sAngle = (float)(Math.Asin((tmp / 2.0) / radius) * 180 * 2 / Math.PI);
            startAngle += flag ? 0 : sweepAngle;
            sweepAngle = flag ? sweepAngle : -sweepAngle;
            sAngle = flag ? sAngle : -sAngle;
            startAngle = (float)(isFollow ? startAngle : startAngle +sweepAngle- sAngle);
            sweepAngle = (float)(isFollow ? sAngle : (sweepAngle + sAngle));
            path.AddArc(tmpX, tmpY, 2 * radius, 2 * radius, startAngle, sweepAngle);
        }

        #endregion

        #region DrawTagRectangle

        public static GraphicsPath DrawTagRectangle(int x, int y, int width, int height, int tagWidth,
            bool isLeft = true)
        {
            var path = new GraphicsPath();

            if (isLeft)
            {
                path.StartFigure();
                path.AddLine(x, y + height / 2, tagWidth + x, y);
                path.AddLine(x + width, y, x + width, y + height);
                path.AddLine(tagWidth + x, y + height, x, y + height / 2);
                path.CloseFigure();
            }
            else
            {
                path.StartFigure();
                path.AddLine(x, y + height, x, y);
                path.AddLine(x + width - tagWidth, y, x + width, y + height / 2);
                path.AddLine(x + width - tagWidth, y + height, x, y + height);
                path.CloseFigure();
            }
            return path;
        }

        #endregion

        public static Image Resize(this Image value, int maxWidth, int maxHeight)
        {
            var orRatio = value.Width * 1.0F / value.Height;
            var newRatio = maxWidth * 1.0F / maxHeight;
            return orRatio > newRatio
                ? new Bitmap(value, maxWidth, (int)(maxHeight / orRatio))
                : new Bitmap(value, (int)(maxWidth * orRatio), maxHeight);
        }
    }
}
