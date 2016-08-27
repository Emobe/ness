using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ness
{
    public class ComponentEventArgs : EventArgs
    {
        Component component;

        public ComponentEventArgs(Component component)
        {
            this.component = component;
        }

        public Component Component
        {
            get
            {
                return component;
            }
        }

    }
}
