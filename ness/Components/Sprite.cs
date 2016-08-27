using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Ness.Components
{
    [ComponentDependency(typeof(Position))]
    public class Sprite : Component, IDrawableContent
    {

        string name;
        Vector2 position;
        Texture2D texture;

        public Sprite(string name) : this(name, Vector2.Zero) { }

        public Sprite(string name, Vector2 position)
        {
            this.name = name;
        }

        public Texture2D Texture
        {
            get { return texture; }
        }

        public override void Initialise()
        {
            base.Initialise();
            position = Owner.Find<Position>().Pos;
        }

        public override void Update(GameTime gameTime)
        {
            position = Owner.Find<Position>().Pos;
            base.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        public void LoadContent(ContentManager contentManager)
        {
            texture = contentManager.Load<Texture2D>(name);
        }
    }
}
