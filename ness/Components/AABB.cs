using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Ness.Components
{
    public class AABB : Component
    {

        Rectangle bounds;

        public AABB() : this(0, 0) { }

        public AABB(int height, int width)
        {
            bounds = new Rectangle();
        }

        public Rectangle Bounds
        {
            get { return bounds; }
        }

        public void SetBounds(int x, int y, int height, int width)
        {
            bounds.X = x;
            bounds.Y = y;
            bounds.Height = height;
            bounds.Width = width;
        }
    }
}
