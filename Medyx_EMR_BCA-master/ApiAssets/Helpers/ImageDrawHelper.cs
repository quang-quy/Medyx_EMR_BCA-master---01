using Microsoft.AspNetCore.Hosting;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace Medyx_EMR_BCA.ApiAssets.Helpers
{
    public class ImageDrawHelper
    {
        public const int _defaultX = 190;
        public const int _defaultY = 11;
        public const int _defaultIncreateX = 63;
        public const int _defaultIncreateY = 12;
        private static Image resizeImage(Image imgToResize, Size size)
        {
            //Get the image current width  
            int sourceWidth = imgToResize.Width;
            //Get the image current height  
            int sourceHeight = imgToResize.Height;
            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            //Calulate  width with new desired size  
            nPercentW = ((float)size.Width / (float)sourceWidth);
            //Calculate height with new desired size  
            nPercentH = ((float)size.Height / (float)sourceHeight);
            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;
            //New Width  
            int destWidth = (int)(sourceWidth * nPercent);
            //New Height  
            int destHeight = (int)(sourceHeight * nPercent);
            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((System.Drawing.Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            // Draw image with new width and height  
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            return (System.Drawing.Image)b;
        }
        public static string DrawImage(IHostingEnvironment hostingEnvironment, Action<Graphics> callback, int width = 775, int height = 420)
        {
            var copyFile = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            var pathFileCopy = $"Storage/Print/{copyFile}.png";
            File.Copy(hostingEnvironment.WebRootPath + $"/Template/Image.png", pathFileCopy, true);
            var time = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            var path = $"Storage/Print/{time}.png";
            using (Image img = Image.FromFile(pathFileCopy))
            {
                using (Graphics g = Graphics.FromImage(img))
                {
                    callback(g);
                }
                if(width == 0 || height == 0)
                {
                    img.Save(path);
                }
                else
                {
                    using (var bmpTemp = new Bitmap(img))
                    {
                        var imgNew = resizeImage(bmpTemp, new Size(width, height));
                        var i2 = new Bitmap(imgNew);
                        i2.Save(path);
                        i2.Dispose();
                    }
                }
            }
            if (File.Exists(pathFileCopy))
            {
                File.Delete(pathFileCopy);
            }
            return Path.GetFullPath(path);
        }
        public static void DrawPoint(Graphics g, int x = _defaultX, int y = _defaultY)
        {
            Brush aBrush = (Brush)Brushes.Red;
            FillCircle(g, aBrush, x, y, 3);
        }
        public static void DrawLine(Graphics g, Point[] points)
        {
            if (points.Length > 1)
            {
                Pen pen = new Pen(Color.Blue, 2);
                g.DrawLines(pen, points);
            }
        }

        public static void DrawPlus(Graphics g, int x = _defaultX, int y = _defaultY)
        {
            Pen pen = new Pen(Color.Blue, 3);
            const int deviant = 5;
            Point[] verticalPoints = new Point[]
            {
               new Point(x, y + deviant + 1),
               new Point(x, y - deviant),
            };
            Point[] horizontalPoints = new Point[]
            {
               new Point(x - deviant, y),
               new Point(x + deviant + 1, y),
            };
            g.DrawLines(pen, verticalPoints);
            g.DrawLines(pen, horizontalPoints);
        }
        public static void DrawCircle(Graphics g, Pen pen,
                                  float centerX, float centerY, float radius)
        {
            g.DrawEllipse(pen, centerX - radius, centerY - radius,
                          radius + radius, radius + radius);
        }

        public static void FillCircle(Graphics g, Brush brush,
                                      float centerX, float centerY, float radius)
        {
            g.FillEllipse(brush, centerX - radius, centerY - radius,
                          radius + radius, radius + radius);
        }
    }
}