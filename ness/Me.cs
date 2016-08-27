using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ness.Components;

namespace Ness
{
    public class Me : Entity
    {
        public Me(string name) : base(name, new Component[] { new Sprite("5")})
        {

        }
    }
}
