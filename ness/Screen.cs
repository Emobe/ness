using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Ness
{
    public abstract class Screen
    {
        public List<GUIElement> elements;

        public Screen()
        {
            elements = new List<GUIElement>();
        }

        public abstract void Initialise();

        public void LoadContent(ContentManager contentManager)
        {
            foreach(GUIElement element in elements)
            {
                element.LoadContent(contentManager);
            }
        }

        public void Draw(Sprite)
    }
}
