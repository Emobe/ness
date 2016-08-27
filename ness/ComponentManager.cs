using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Ness
{
    public class ComponentManager : EntityCollection
    {
        List<IUpdateable> updateables = new List<IUpdateable>();
        List<IDrawable> drawables = new List<IDrawable>();

        public void Initialise()
        {
            foreach(Entity entity in this)
            {
                foreach(Component component in entity.FindAll<Component>())
                {
                    component.Start();
                }
            }
        }

        public void LoadContent(ContentManager contentManager)
        {
            foreach(IDrawable component in drawables)
            {
                if(component is IDrawableContent)
                {
                    IDrawableContent content = component as IDrawableContent;
                    content.LoadContent(contentManager);
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            for(int i = 0; i < updateables.Count; i++)
            {
                updateables[i].Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for(int i = 0; i < drawables.Count; i++)
            {
                drawables[i].Draw(spriteBatch);
            }
        }

        protected override void OnEntityAdded(EntityEventArgs e)
        {
            Entity entity = e.Entity as Entity;

            entity.ComponentAdded += new EventHandler<ComponentEventArgs>(entity_ComponentAdded);

            foreach(Component component in entity)
            {
                Add(component);
            }
            base.OnEntityAdded(e);
        }

        void entity_ComponentAdded(object sender, ComponentEventArgs e)
        {
            Add(e.Component);
        }

        private void Add(Component component)
        {
            if(component is IDrawable)
            {
                drawables.Add(component as IDrawable);
            }
            updateables.Add(component as IUpdateable);
        }
   }
}
