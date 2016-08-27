using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ness
{
    public class EntityEventArgs : EventArgs
    {
        Entity entity;

        public EntityEventArgs(Entity entity)
        {
            this.entity = entity;
        }

        public Entity Entity
        {
            get
            {
                return entity;
            }
        }
    }
}
