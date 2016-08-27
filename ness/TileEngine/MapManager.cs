using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Ness.TileEngine
{
    public class MapManager
    {
        Map map;
        MapReader mapReader;
        string mapFile;

        public MapManager(string map)
        {
            mapFile = map;
            mapReader = new MapReader(mapFile);
        }

        public void LoadContent(ContentManager contentManager)
        {
            map = new Map(mapReader.Load());
            map.LoadContent(contentManager);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destination = new Rectangle(0, 0, Engine.TileSize, Engine.TileSize);
            Tile tile;

            foreach (MapLayer layer in map.Layers)
            {
                for (int y = 0; y < layer.Height; y++)
                {
                    destination.Y = y * Engine.TileSize;

                    for (int x = 0; x < layer.Width; x++)
                    {
                        destination.X = x * Engine.TileSize;

                        tile = layer.GetTile(x, y);

                        spriteBatch.Draw(map.TileSets[tile.Set].Texture, destination, map.TileSets[tile.Set].Sources[tile.Index], Color.White);
                    }
                }
            }
        }
    }
}