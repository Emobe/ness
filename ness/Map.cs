using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Ness.TileEngine;

namespace Ness
{
    public class Map
    {

        List<TileSet> tileSets;
        List<MapLayer> layers;
        int[,] map;

        List<string> assets = new List<string>()
        {
            "tiles"
        };

        public Map(int[,] map)
        {
            tileSets = new List<TileSet>();
            layers = new List<MapLayer>();
            this.map = map;
        }

        public List<MapLayer> Layers
        {
            get { return layers; }
        }

        public List<TileSet> TileSets
        {
            get { return tileSets; }
        }

        public void Initialise()
        {
        }

        public bool IsColliding(int x, int y)
        {
            return true;
        }

        public void LoadContent(ContentManager contentManager)
        {
            Texture2D texture = contentManager.Load<Texture2D>(assets[0]);
            tileSets.Add(new TileSet(texture));
            layers.Add(new MapLayer(map));
        }

    }
}
