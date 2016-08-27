using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Ness.Components;

namespace Ness.Entities
{
    public class Player : WorldObject
    {
        public Player(string name, string asset) : base(name, asset) { }
    }
}
