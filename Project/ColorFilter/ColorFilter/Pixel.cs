using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColorFilter
{
    internal class Pixel
    {
        private int m_ContainsToObject = -1;

        public int ContainsToObject
        {
            get { return m_ContainsToObject; }
            set { m_ContainsToObject = value; }
        }

        public Coordinate PixelPosition { get; private set; }
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }
        public int OriginalR { get; set; }
        public int OriginalG { get; set; }
        public int OriginalB { get; set; }

        public int RGBSum
        {
            get
            {
                return this.R + this.G + this.B;
            }
        }

        public Pixel(Coordinate position)
        {
            this.PixelPosition = position;
        }

        public Pixel(Coordinate position, int r, int g, int b)
           : this(position)
        {
            this.R = r;
            this.G = g;
            this.B = b;
        }

        public void ConvertToGray()
        {
            int rgbPart = GetRgbPart();

            this.R = rgbPart;
            this.G = rgbPart;
            this.B = rgbPart;
        }

        public void ConvertToRed()
        {
            this.R = GetRgbPart();
            this.G = 0;
            this.B = 0;
        }

        public void ConvertToGreen()
        {
            this.R = 0;
            this.G = GetRgbPart();
            this.B = 0;
        }

        public void ConvertToBlue()
        {
            this.R = 0;
            this.G = 0;
            this.B = GetRgbPart();
        }

        private int GetRgbPart()
        {
            return this.RGBSum / 3;
        }

        public void SaveOriginalValue()
        {
            this.OriginalR = this.R;
            this.OriginalG = this.G;
            this.OriginalB = this.B;
        }

        public void TransformKoordinates(int originX, int originY)
        {
            this.PixelPosition.TransformedX = this.PixelPosition.X - originX;
            this.PixelPosition.TransformedY = originY - this.PixelPosition.Y;
        }
    }
}
