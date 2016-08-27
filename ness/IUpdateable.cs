using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Ness
{
    public interface IUpdateable
    {
        void Update(GameTime gameTime);
    }
}
