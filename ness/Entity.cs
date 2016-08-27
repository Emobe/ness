using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Ness
{
    public class Entity : ComponentCollection
    {
        string name;
        ComponentManager manager;

        public Entity(string name) : this(name, new Component[] { }) { }

        public Entity(string name, params Component[] components)
        {
            this.name = name;
            if (components.Length > 0)
            {
                foreach (Component component in components)
                {
                    Add(component);
                }
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public ComponentManager Manager
        {
            get
            {
                return manager;
            }

            set
            {
                if(manager == null)
                {
                    manager = value;
                }
            }
        }

        protected override void OnComponentAdded(ComponentEventArgs e)
        {
            Component component = e.Component as Component;
            component.Owner = this;
            base.OnComponentAdded(e);
        }
    }
}
