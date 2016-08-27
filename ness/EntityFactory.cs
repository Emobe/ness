using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Ness
{
    public sealed class EntityFactory : Factory
    {
        ComponentManager manager;

        public EntityFactory(ComponentManager manager)
        {
            this.manager = manager;
        }
        public Entity Create(string name)
        {
            return Create(name, new Component[] { });
        }

        public Entity Create(string name, params Component[] components)
        {
            Entity entity = new Entity(name, components);
            entity.Manager = manager;
            manager.Add(entity);
            return entity;
        }

        public T Create<T>(string name) where T : Entity
        {
            return Create<T>(new object[] { name });
        }

        public T Create<T>(string name, params Component[] components) where T : Entity
        {
            return Create<T>(new object[] { name, components });
        }

        public T Create<T>(params object[] parameters) where T : Entity
        {
            ConstructorInfo match = getConstructor(typeof(T), parameters);

            object o = null;

            try
            {
                o = match.Invoke(parameters);
            }
            catch (TargetInvocationException)
            {
                throw;
            }
            catch(TargetParameterCountException)
            {
                throw;
            }

            Entity entity = o as Entity;

            entity.Manager = manager;

            manager.Add(entity);

            return o as T;
        }
    }
}
