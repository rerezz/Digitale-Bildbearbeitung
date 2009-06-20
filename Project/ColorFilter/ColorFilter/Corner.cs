using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColorFilter 
{
    internal class Corner 
    {
        private Pixel m_CornerPixel;

        public double CornerAngle { get; set; }
        public Pixel CornerPixel 
        {
            get 
            {
                return m_CornerPixel;
            }
        }

        public Corner(Pixel cornerPixel) {
            m_CornerPixel = cornerPixel;
        }
    }
}
