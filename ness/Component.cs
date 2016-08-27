using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Ness
{
    public abstract class Component : IComponent
    {

        Entity owner;
        bool enabled;
        

        public bool Enabled
        {
            get
            {
                return enabled;
            }
        }

        public Entity Owner
        {
            get
            {
                return owner;
            }

            set
            {
                if (owner == null)
                {
                    owner = value;
                }
            }
        }

        public virtual void Initialise()
        {
            object[] attributes = this.GetType().GetCustomAttributes(true);

            foreach(object o in attributes)
            {
                if(o is ComponentDependency)
                {
                    ComponentDependency cd = o as ComponentDependency;

                    foreach(Type t in cd.Dependencies)
                    {
                        Type[] interfaces = t.GetInterfaces();

                        for (int j = 0; j < interfaces.Length; j++)
                        {
                            if(interfaces[j].ToString().Equals("Ness.IComponent", StringComparison.InvariantCultureIgnoreCase))
                            {
                                ComponentFactory.Create(t, owner, false);
                            }
                        }
                    }
                }
            }
        }

        public virtual void Start() { }

        public virtual void Update(GameTime gameTime) { }
    }
}
