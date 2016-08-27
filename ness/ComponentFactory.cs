using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Ness
{
    public sealed class ComponentFactory : Factory
    {

        public static Component Create(Type type, Entity owner, bool overwrite, params object[] parameters)
        {
            ConstructorInfo match = getConstructor(type, parameters);

            object o = null;

            try
            {
                o = match.Invoke(parameters);
            }
            catch (TargetParameterCountException tcpe)
            {
                throw tcpe;
            }

            Component component = o as Component;

            component.Owner = owner;
            owner.Add(component);

            return o as Component;
        }

        public T Create<T>(Entity owner) where T : Component
        {
            return Create<T>(owner, false, new object[] { });
        }

        public T Create<T>(Entity owner, params object[] parameters) where T : Component
        {
            return Create<T>(owner, false, parameters);
        }

        public T Create<T>(Entity Owner, bool overwrite, params object[] parameters) where T : Component
        {
            ConstructorInfo best = getConstructor(typeof(T), parameters);

            object o = null;

            try
            {
                o = best.Invoke(parameters);
            }
            catch (TargetParameterCountException tpce)
            {
                throw tpce;
            }

            Component component = o as Component;

            component.Owner = Owner;
            component.Owner.Add(component);

            return o as T;
        }
    }
}
