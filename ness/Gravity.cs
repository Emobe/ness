using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ness
{
    public class Gravity : Component
    {
        int gravity;

        public int Speed
        {
            get
            {
                return gravity;
            }
        }

        public override void Initialise()
        {
            gravity = 1;
            base.Initialise();
        }

    }
}
