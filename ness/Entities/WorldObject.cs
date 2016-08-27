using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Ness.Components;

namespace Ness.Entities
{
    public abstract class WorldObject : Entity
    {
        bool colliding = false;

        public WorldObject(string name, string asset) : base(name, new Sprite(asset), new Velocity(), new AABB())
        {
        }

        public Vector2 Position
        {
            get
            {
                return Find<Position>().Pos;
            }

            set
            {
                Find<Position>().Pos = value;
            }
        }

        public bool Colliding
        {
            get
            {
                return colliding;
            }

            set
            {
                colliding = value;
            }
        }

        public float X
        {
            get { return Find<Position>().X; }
            set { Find<Position>().X = value; }
        }

        public float Y
        {
            get { return Find<Position>().Y; }
            set { Find<Position>().Y = value; }
        }

        public Vector2 Velocity
        {
            get
            {
                return Find<Velocity>().Vel;
            }

            set
            {
                Find<Velocity>().Vel = value;
            }
        }

        public float VelX
        {
            get
            {
                return Find<Velocity>().X;
            }

            set
            {
                Find<Velocity>().X = value;
            }
        }

        public Rectangle Bounds
        {
            get { return Find<AABB>().Bounds; }
        }

        public int Height
        {
            get { return Find<Sprite>().Texture.Height; }
        }

        public int Width
        {
            get { return Find<Sprite>().Texture.Width; }
        }

    }
}
