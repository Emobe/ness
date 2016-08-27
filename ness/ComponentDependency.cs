using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ness
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class ComponentDependency : Attribute
    {
        Type[] dependencies;

        public ComponentDependency(params Type[] args)
        {
            dependencies = args;
        }

        public Type[] Dependencies
        {
            get
            {
                return dependencies;
            }
        }
    }
}
