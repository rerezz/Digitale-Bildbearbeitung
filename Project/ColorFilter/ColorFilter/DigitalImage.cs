using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Diagnostics;

namespace ColorFilter
{
    internal class DigitalImage
    {
        private string m_OriginalFileSource;
        private SortedDictionary<Coordinate, Pixel> m_ImagePixel = new SortedDictionary<Coordinate, Pixel>();
        private ImageObject m_ImageObject = new ImageObject();

        public int Width { get; private set; }
        public int Height { get; private set; }


        public DigitalImage(string filename)
        {
            m_OriginalFileSource = filename;
            this.ReadImage(filename);
        }
        
        private void ReadImage(string filename)
        {
            Pixel pixel;
            Color currentColor;

            Bitmap image = new Bitmap(filename);
            this.Width = image.Width;
            this.Height = image.Height;

            for (int y = 0; y < this.Height; y++)
            {
                for (int x = 0; x < this.Width; x++)
                {
                    currentColor = image.GetPixel(x,y);

                    pixel = new Pixel(new Coordinate(x,y),currentColor.R,currentColor.G,currentColor.B);

                    m_ImagePixel.Add(pixel.PixelPosition, pixel);
                }
            }
        }

        public ImageObject DetectImageObjects()
        {
            m_ImageObject = new ImageObject();
            SetObjectPixel();
            m_ImageObject.DetectCorners();

            return m_ImageObject;
        }

        private void SetObjectPixel()
        {
            foreach (Pixel pixel in m_ImagePixel.Values)
            {
                // Set coordinate origin to left lower corner
                pixel.TransformKoordinates(0, this.Height);

                if (pixel.RGBSum < 500)
                {
                    pixel.ContainsToObject = 0;
                    m_ImageObject.AddPixel(pixel);
                }
            }
        }
        
        public string FilterAndSaveImageToTempFile(Filter filter)
        {
            Bitmap image = new Bitmap(this.Width, this.Height);

            foreach (Pixel pix in this.m_ImagePixel.Values)
            {
                ApplyFilter(filter, pix);
                image.SetPixel(pix.PixelPosition.X, pix.PixelPosition.Y, Color.FromArgb(pix.R, pix.G, pix.B));
            }

            return this.SaveImageToTempFile(image);
        }

        public string TurnAndSaveToTempFile(int turnPointX, int turnPointY, int angle, int height, int width, bool correction)
        {
            Coordinate position;
            Pixel sourcePixel;
            Pixel targetPixel;
            Bitmap image = new Bitmap(this.Width, this.Height);

            int turnFromX = turnPointX - width/2;
            int turnToX = turnPointX + width/2;
            int turnFromY = turnPointY - height/2;
            int turnToY = turnPointY + height/2;

            double radAngle = Math.PI * angle / 180;
            double cx, cy;
            int floorx, floory, ceilx, ceily;

            // Create new image and convert to coordinate system for turn
            foreach (Pixel pix in this.m_ImagePixel.Values)
            {
                pix.TransformKoordinates(turnPointX, turnPointY);

                pix.SaveOriginalValue();

                image.SetPixel(pix.PixelPosition.X, pix.PixelPosition.Y, Color.FromArgb(pix.R, pix.G, pix.B));
            }

            for (int y = turnFromY ; y < turnToY ; y++)
            {
                for (int x = turnFromX; x < turnToX; x++)
                {
                    position = new Coordinate(x, y)
                        {
                            TransformedX = x - turnPointX, TransformedY = turnPointY - y
                        };

                    if (m_ImagePixel.TryGetValue(position, out sourcePixel))
                    {
                        cx = Math.Cos(radAngle) * sourcePixel.PixelPosition.TransformedX + -1 * Math.Sin(radAngle) * sourcePixel.PixelPosition.TransformedY;
                        cy = Math.Sin(radAngle) * sourcePixel.PixelPosition.TransformedX + Math.Cos(radAngle) * sourcePixel.PixelPosition.TransformedY;

                        if (correction)
                        {
                            floorx = Convert.ToInt32(Math.Floor(cx));
                            floory = Convert.ToInt32(Math.Floor(cy));
                            ceilx = Convert.ToInt32(Math.Ceiling(cx));
                            ceily = Convert.ToInt32(Math.Ceiling(cy));
                        }
                        else
                        {
                            floorx = Convert.ToInt32(cx);
                            floory = Convert.ToInt32(cy);
                            ceilx = floorx;
                            ceily = floory;
                        }

                        for (int i = floory; i <= ceily; i++)
                        {
                            for (int j = floorx; j <= ceilx; j++)
                            {
                                // Turn position
                                position.TransformedX = j;
                                position.TransformedY = i;
                                position.X = position.TransformedX + turnPointX;
                                position.Y = turnPointY - position.TransformedY;

                                if (m_ImagePixel.TryGetValue(position, out targetPixel))
                                {
                                    targetPixel.R = sourcePixel.OriginalR;
                                    targetPixel.G = sourcePixel.OriginalG;
                                    targetPixel.B = sourcePixel.OriginalB;

                                    image.SetPixel(targetPixel.PixelPosition.X, targetPixel.PixelPosition.Y, Color.FromArgb(targetPixel.R, targetPixel.G, targetPixel.B));
                                }
                                else
                                {
                                    Debug.WriteLine("Target not found : " + position.ToString());
                                }
                            }
                        }
                    }
                    else
                    {
                        Debug.WriteLine("Source not found : " + position.ToString());
                    }
                }
            }

            return this.SaveImageToTempFile(image);
        }

        private string SaveImageToTempFile(Bitmap image)
        {
            string tempFilename = Path.Combine(Path.GetTempPath(), Path.GetTempFileName());
            image.Save(tempFilename);
            return tempFilename;
        }

        private string SaveImageToTempFile()
        {
            Bitmap image = new Bitmap(this.Width, this.Height);

            foreach (Pixel pix in this.m_ImagePixel.Values)
            {
                image.SetPixel(pix.PixelPosition.X, pix.PixelPosition.Y, Color.FromArgb(pix.R, pix.G, pix.B));
            }

            return this.SaveImageToTempFile(image);
        }

        private void ApplyFilter(Filter filter, Pixel pixel)
        {
            switch (filter)
            {
                case Filter.Gray:
                    {
                        pixel.ConvertToGray();
                        return;
                    }
                case Filter.Red:
                    {
                        pixel.ConvertToRed();
                        return;
                    }
                case Filter.Green:
                    {
                        pixel.ConvertToGreen();
                        return;
                    }
                case Filter.Blue:
                    {
                        pixel.ConvertToBlue();
                        return;
                    }
                default: return;
            }
        }

    }
}
