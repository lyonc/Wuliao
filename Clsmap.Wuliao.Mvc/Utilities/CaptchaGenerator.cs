// CaptchaGenerator.cs
//
// Author:
//       Lyon <qinhutu@gmail.com>
//
// Copyright (c) 2015 © Clsmap Inc.
//
//
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Clsmap.Wuliao.Mvc.Utilities
{
    public class CaptchaGenerator
    {
        public Int32 Length{ get; set; }

        public CaptchaGenerator()
            : this(5)
        {
        }

        public CaptchaGenerator(Int32 length)
        {
            Length = length;
        }

        public String CreateCode(Int32 length)
        {
            var randMembers = new Int32[length];

            var random = new Random();
            for (int i = 0; i < length; i++)
            {
                randMembers[i] = random.Next(0, 9);
            }

            var code = String.Empty;
            foreach (var character in randMembers)
            {
                code += character;
            }

            return code;
        }

        public Byte[] CreateImage(String code)
        {
            var image = new Bitmap(ImageWidth(Length), ImageHeight());
            var g = Graphics.FromImage(image);
            try
            {
                g.Clear(Color.White);

                var random = new Random();
                for (int i = 0; i < 25; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                }

                var font = new Font("Arial", 12, (FontStyle.Bold | FontStyle.Italic));
                var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                                new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2F, true);
                g.DrawString(code, font, brush, 3, 2);

                for (var i = 0; i < 100; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }

                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);

                using (var stream = new System.IO.MemoryStream())
                {
                    image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);

                    return stream.ToArray();
                }
            }
            finally
            {
                image.Dispose();
                g.Dispose();
            }
        }

        private Int32 ImageWidth(Int32 codeLength)
        {
            return codeLength * 12;
        }

        private Int32 ImageHeight()
        {
            return 20;
        }
    }
}

