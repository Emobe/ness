using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace Ness
{
    public interface IDrawableContent : IDrawable
    {
        void LoadContent(ContentManager contentManager);
    }
}
