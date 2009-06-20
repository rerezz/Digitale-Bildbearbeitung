using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColorFilter
{
    internal class Coordinate : IComparable<Coordinate>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int TransformedX { get; set; }
        public int TransformedY { get; set; }

        public Coordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int CompareTo(Coordinate other)
        {
            if (this.X == other.X)
            {
                return this.Y - other.Y;
            }
            else
            {
                return this.X - other.X;
            }
        }

        public override string ToString()
        {
            return X.ToString() + " / " + Y.ToString();
        }
    }
}
