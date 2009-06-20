using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColorFilter
{
    internal class ImageObject
    {
        private SortedDictionary<Coordinate, Pixel> m_ObjectPixel = new SortedDictionary<Coordinate, Pixel>();
        private SortedDictionary<double, Corner> m_Corners = new SortedDictionary<double, Corner>();
        private List<double> m_CornerAnglesValues = new List<double>();
        private int m_MinX = Int32.MaxValue;
        private int m_MaxX = Int32.MinValue;
        private int m_MinY = Int32.MaxValue;
        private int m_MaxY = Int32.MinValue;

        public int MinX
        {
            get { return m_MinX; }
            private set { m_MinX = value; }
        }
        public int MaxX
        {
            get { return m_MaxX; }
            private set { m_MaxX = value; }
        }
        public int MinY
        {
            get { return m_MinY; }
            private set { m_MinY = value; }
        }
        public int MaxY
        {
            get { return m_MaxY; }
            private set { m_MaxY = value; }
        }
        public int CornerCount
        {
            get
            {
                return m_Corners.Count;
            }
        }

        public List<double> CornerAnglesSortedByValue()
        {
            m_CornerAnglesValues.Sort();
            return m_CornerAnglesValues;
        }

        public void AddPixel(Pixel pixel)
        {
            m_ObjectPixel.Add(pixel.PixelPosition, pixel);

            SetMaxMinValues(pixel.PixelPosition.TransformedX, pixel.PixelPosition.TransformedY);
        }

        public void DetectCorners()
        {
            IOrderedEnumerable<Pixel> minX = from pix in m_ObjectPixel.Values 
                           where pix.PixelPosition.TransformedX == m_MinX
                           orderby pix.PixelPosition.TransformedY
                           select pix;

            AddCorners(minX);

            IOrderedEnumerable<Pixel> maxX = from pix in m_ObjectPixel.Values
                           where pix.PixelPosition.TransformedX == m_MaxX
                           orderby pix.PixelPosition.TransformedY
                           select pix;

            AddCorners(maxX);

            IOrderedEnumerable<Pixel> minY = from pix in m_ObjectPixel.Values
                           where pix.PixelPosition.TransformedY == m_MinY
                           orderby pix.PixelPosition.TransformedY
                           select pix;

            AddCorners(minY);

            IOrderedEnumerable<Pixel> maxY = from pix in m_ObjectPixel.Values
                           where pix.PixelPosition.TransformedY == m_MaxY
                           orderby pix.PixelPosition.TransformedX
                           select pix;

            AddCorners(maxY);

            MessureCornerAngles();
        }

        private void MessureCornerAngles() {
            int v1x, v1y, v2x, v2y;
            int posBefore, posAfter;
            double angle;

            for (int i = 0; i < m_Corners.Count; i++) {
                posBefore = (i == 0) ? m_Corners.Count - 1 : i-1;
                posAfter = (i == m_Corners.Count - 1) ? 0 : i+1;

                v1x = m_Corners.ElementAt(posBefore).Value.CornerPixel.PixelPosition.X 
                    - m_Corners.ElementAt(i).Value.CornerPixel.PixelPosition.X;
                v1y = m_Corners.ElementAt(posBefore).Value.CornerPixel.PixelPosition.Y
                    - m_Corners.ElementAt(i).Value.CornerPixel.PixelPosition.Y;
                v2x = m_Corners.ElementAt(posAfter).Value.CornerPixel.PixelPosition.X
                    - m_Corners.ElementAt(i).Value.CornerPixel.PixelPosition.X;
                v2y = m_Corners.ElementAt(posAfter).Value.CornerPixel.PixelPosition.Y
                    - m_Corners.ElementAt(i).Value.CornerPixel.PixelPosition.Y;

                angle = VectorAngle(v1x, v1y, v2x, v2y);
                m_Corners.ElementAt(i).Value.CornerAngle =angle;
                m_CornerAnglesValues.Add(angle);
            }
        }

        private void AddCorners(IOrderedEnumerable<Pixel> cornerCandidates)
        {
            if (cornerCandidates.Count() > 50)
            {
                //First and Last point are corners
                MassureAngleAndAddCorner(cornerCandidates.First());
                MassureAngleAndAddCorner(cornerCandidates.Last());
            }
            else
            {
                // middle point is corner
                int index = cornerCandidates.Count() / 2;
                MassureAngleAndAddCorner(cornerCandidates.ElementAt(index));
            }
        }

        private void MassureAngleAndAddCorner(Pixel pixel)
        {
            int vx = pixel.PixelPosition.TransformedX - GetCenterX();
            int vy = pixel.PixelPosition.TransformedY - GetCenterY();

            double angle = VectorAngle(1, 0, vx, vy);

            if (vy < 0)
            {
                angle = 2 * Math.PI - angle;
            }

            if (IsNewCorner(pixel.PixelPosition))
            {
                m_Corners.Add(angle, new Corner(pixel));
            }
        }

        private bool IsNewCorner(Coordinate position)
        {
            foreach (Corner existingCorner in m_Corners.Values)
            {
                if (Math.Abs(position.X - existingCorner.CornerPixel.PixelPosition.X) < 10
                    && Math.Abs(position.Y - existingCorner.CornerPixel.PixelPosition.Y) < 10)
                {
                    return false;
                }
            }

            return true;
        }

        private double VectorAngle(double v1x, double v1y, double v2x, double v2y)
        {
            return Math.Acos(((v1x * v2x) + (v1y * v2y)) / (Math.Sqrt(v1x * v1x + v1y * v1y) * Math.Sqrt(v2x * v2x + v2y * v2y)));
        }


        private void SetMaxMinValues(int x, int y)
        {
            if (x < m_MinX)
            {
                m_MinX = x;
            }
            if (x > m_MaxX)
            {
                m_MaxX = x;
            }
            if (y < m_MinY)
            {
                m_MinY = y;
            }
            if (y > m_MaxY)
            {
                m_MaxY = y;
            }
        }

        private int GetCenterX()
        {
            return ((m_MaxX - m_MinX) / 2) + m_MinX;
        }

        private int GetCenterY()
        {
            return ((m_MaxY - m_MinY)) / 2 + m_MinY;
        }
    }
}
