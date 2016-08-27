using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Ness.TileEngine;
using Ness.Entities;
using Ness.Components;

namespace Ness
{
    public class PhysicsSystem
    {
        int gravity, speed;

        public PhysicsSystem(int gravity)
        {
            this.gravity = gravity;
            speed = 5;
        }

        public void Update(ComponentManager manager, Map map)
        {
            List<Entity> matches = manager.FindAllWith<AABB>();
            foreach(Entity entity in matches)
            {
                WorldObject worldObject = entity as WorldObject;

                worldObject.Find<AABB>().SetBounds((int)worldObject.X, (int)worldObject.Y, worldObject.Height, worldObject.Width);

                int left = worldObject.Bounds.Left / Engine.TileSize;
                int top = worldObject.Bounds.Top / Engine.TileSize;
                int right = (int)Math.Ceiling((float)worldObject.Bounds.Right / Engine.TileSize) - 1;
                int bottom = (int)Math.Ceiling((float)worldObject.Bounds.Bottom / Engine.TileSize) - 1;

                for(int y = top; y <= bottom; y++)
                {
                    for(int x = left; x <= right; x++)
                    {
                        worldObject.Colliding = map.IsColliding(x, y);
                    }
                }
            }
        }
    }
}