using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Ness.Entities;

namespace Ness.Components
{
    [ComponentDependency(typeof(Position))]
    public class Velocity : Component
    {
        Vector2 velocity = Vector2.Zero;
        int speed = 5;

        public float Y
        {
            get
            {
                return velocity.Y;
            }

            set
            {
                velocity.Y = value;
            }
        }
        
        public float X
        {
            get
            {
                return velocity.X;
            }

            set
            {
                velocity.X = value;
            }
        }

        public Vector2 Vel
        {
            get
            {
                return velocity;
            }

            set
            {
                velocity = value;
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Player player = Owner as Player;

            if (!player.Colliding){
                Owner.Find<Position>().X += X * speed;
                Owner.Find<Position>().Y += Y * speed;
            }
        }

    }
}
