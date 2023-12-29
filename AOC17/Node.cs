using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC17
{
    internal class Node
    {
        public Coord Loc { get; set; }
        public Coord LastDir { get; set; }
        public int Dist { get; set; }
        public override bool Equals(object? obj)
        {
            return obj is Node node &&
                   Loc == node.Loc &&
                   LastDir == node.LastDir;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Loc, LastDir);
        }
    }
}
