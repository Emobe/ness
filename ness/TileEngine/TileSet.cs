using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Ness.TileEngine
{
    public class TileSet
    {
        int setHeight,
            setWidth,
            tileSize;

        Texture2D texture;

        Rectangle[] sources;

        public Texture2D Texture
        {
            get
            {
                return texture;
            }
        }

        public Rectangle[] Sources
        {
            get
            {
                return (Rectangle[])sources.Clone();
            }
        }

        public int TilesHigh
        {
            get
            {
                return setHeight / Engine.TileSize;
            }
        }

        public int TilesWide
        {
            get
            {
                return setWidth / Engine.TileSize;
            }
        }

        public TileSet(Texture2D texture)
        {
            setHeight = texture.Height;
            setWidth = texture.Width;

            this.texture = texture;

            int tile = 0;

            int tiles = TilesHigh * TilesWide;
            sources = new Rectangle[tiles];

            for(int y = 0; y < TilesHigh; y++)
            {
                for(int x = 0; x < TilesWide; x++)
                {
                    sources[tile] = new Rectangle(x * Engine.TileSize, y * Engine.TileSize, Engine.TileSize, Engine.TileSize);
                    tile++;
                }
            }
            
        }
    }
}
