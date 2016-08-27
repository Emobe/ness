using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Ness.TileEngine;
using Ness.Entities;

namespace Ness
{
    public class SceneManager
    {
        ComponentManager manager;
        EntityFactory factory;
        Engine engine;
        PhysicsSystem physics;
        InputHandler input;
        MapManager mapManager;
        Stack<Screen> screens;

        public SceneManager(){
            manager = new ComponentManager();
            factory = new EntityFactory(manager);
            engine = new Engine(32);
            physics = new PhysicsSystem(40);
            input = new InputHandler();
            mapManager = new MapManager("1.map");
            screens = new Stack<Screen>();
        }
        
        public ComponentManager Manager
        {
            get
            {
                return manager;
            }
        }

        public EntityFactory Factory
        {
            get
            {
                return factory;
            }
        }

        public void Initialise()
        {
            manager.Initialise();
        }

        public void LoadContent(ContentManager contentManager)
        {
            mapManager.LoadContent(contentManager);
            manager.LoadContent(contentManager);
        }

        public void Update(GameTime gameTime)
        {
            input.Update();
            if (screens.Count == 0)
            {
                if (InputHandler.isDown(Keys.D))
                {
                    manager.Find<Player>("player").VelX = 1;
                }
                else
                {
                    manager.Find<Player>("player").Velocity = Vector2.Zero;
                }
            }

            manager.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            mapManager.Draw(spriteBatch);
            manager.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
