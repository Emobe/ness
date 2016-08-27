using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Ness.TileEngine
{
    public class Engine {
        static int tileSize;

        public static int TileSize
        {
            get { return tileSize; }
        }

        public Engine(int tileSize)
        {
            Engine.tileSize = tileSize;
        }

        public static Point VectorToCell(Vector2 position)
        {
            return new Point((int)position.X / tileSize, (int)position.Y / tileSize);
        }
    }
}
