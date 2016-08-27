using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Ness.TileEngine
{
    public class MapLayer
    {
        Tile[,] map;

        public int Width
        {
            get { return map.GetLength(1); }
        }

        public int Height
        {
            get { return map.GetLength(0); }
        }

        public MapLayer(int height, int width)
        {
            map = new Tile[height, width];

            for(int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    map[y, x] = new Tile(0, 0);
                }
            }
        }

        public MapLayer(int[,] map)
        {
            int width = map.GetLength(1);
            int height = map.GetLength(0);

            this.map = new Tile[height, width];
                        
            for(int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    this.map[y, x] = new Tile(map[y, x], 0);
                }
            }
        }

        public Tile GetTile(int x, int y) 
        {
            return map[y, x];
        }


        public void SetTile(int x, int y, Tile tile)
        {
            map[y, x] = tile;
        }
    }
}
