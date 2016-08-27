using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Ness
{
    public abstract class GUIElement
    {
        public Texture2D texture;
        public SpriteFont font;

        string asset;
        string fontAsset;

        Vector2 position;

        public Vector2 Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
            }
        }

        public GUIElement(string asset) : this(asset, "") { }
        public GUIElement(string asset, string font)
        {
            this.asset = asset;
            fontAsset = font;
        }

        public void LoadContent(ContentManager contentManager)
        {
            texture = contentManager.Load<Texture2D>(asset);
            if (fontAsset.Length > 0)
            {
                font = contentManager.Load<SpriteFont>(fontAsset);
            }
        }
    }
}
