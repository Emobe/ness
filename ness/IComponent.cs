using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ness
{
    public interface IComponent : IUpdateable
    {

        bool Enabled { get; }
        Entity Owner { get; }
        void Initialise();

    }
}
