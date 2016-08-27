using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ness.TileEngine
{
    public class Tile
    {
        int index;
        int set;

        public int Index
        {
            get
            {
                return index;
            }
        }

        public int Set
        {
            get
            {
                return set;
            }
        }

        public Tile(int index, int set)
        {
            this.index = index;
            this.set = set;
        }
    }
}
