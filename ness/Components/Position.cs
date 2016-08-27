using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Ness.Components
{
    public class Position : Component
    {
        Vector2 position;

        public Position() : this(0, 0) { }

        public Position(float x, float y)
        {
            position = new Vector2(x, y);
        }

        public float X
        {
            get
            {
                return position.X;
            }

            set
            {
                position.X = value;
            }
        }

        public Vector2 Pos
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

        public float Y
        {
            get
            {
                return position.Y;
            }

            set
            {
                position.Y = value;
            }
        }
    }
}
