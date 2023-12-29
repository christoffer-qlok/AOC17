using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2
{
    internal struct Coord
    {
        public int X;
        public int Y;

        public Coord(int y, int x)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object? obj)
        {
            return obj is Coord coord &&
                   X == coord.X &&
                   Y == coord.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public static Coord operator+(Coord c1, Coord c2)
        {
            return new Coord(c1.Y + c2.Y, c1.X + c2.X);
        }

        public static Coord operator *(int i, Coord c)
        {
            return new Coord(c.Y * i, c.X * i);
        }

        public static Coord operator *(Coord c, int i)
        {
            return new Coord(c.Y * i, c.X * i);
        }

        public static bool operator ==(Coord c1, Coord c2)
        {
            return c1.Equals(c2);
        }

        public static bool operator !=(Coord c1, Coord c2)
        {
            return !c1.Equals(c2);
        }

        public Coord TurnLeft()
        {
            return new Coord(-1 *  X, Y);
        }

        public Coord TurnRight()
        {
            return new Coord(X, -1 * Y);
        }

        public bool IsOnMap(int[][] map)
        {
            return X >= 0 && X < map[0].Length && Y >= 0 && Y < map.Length;
        }
    }
}
