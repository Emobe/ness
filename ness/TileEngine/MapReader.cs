using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Ness.TileEngine
{
    public class MapReader
    {
        int[,] map;
        string file;

        public MapReader(string file)
        {
            this.file = file;
        }

        public int[,] Load()
        {
            FileStream stream = File.OpenRead("Maps/" + @file);
            byte[] data = new byte[2];

            stream.Seek(0, SeekOrigin.Begin);
            stream.Read(data, 0, 2);

            int height = data[0];
            int width = data[1];

            map = new int[height, width];

            stream.Seek(10, SeekOrigin.Begin);

            for(int y = 0; y < height; y++)
            {
                byte[] row = new byte[width];
                stream.Read(row, 0, width);

                for(int x = 0; x < width; x++)
                {
                    map[y, x] = row[x];
                }
            }
            return map;
        }
    }
}
