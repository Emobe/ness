using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ness
{
    public class ComponentCollection : ICollection<Component>
    {
        Dictionary<Type, Component> components = new Dictionary<Type, Component>();

        public event EventHandler<ComponentEventArgs> ComponentAdded;

        public int Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Add(Component item)
        {
            Add(item, false);
        }

        public void Add(Component item, bool overwrite)
        {
            if (components.ContainsKey(item.GetType()) && overwrite)
            {
            }
            
            if(!components.ContainsKey(item.GetType()))
            {
                components.Add(item.GetType(), item);
                OnComponentAdded(new ComponentEventArgs(item));
            }

            item.Initialise();
        }

        public T Find<T>() where T : Component
        {
            Component[] tmpComponents = new Component[components.Values.Count];
            components.Values.CopyTo(tmpComponents, 0);

            for (int i = 0; i < tmpComponents.Length; i++)
            {
                if (tmpComponents[i] is T)
                {
                    return (T)tmpComponents[i];
                }
            }
            return default(T);
        }

        public List<T> FindAll<T>() where T : Component
        {
            List<T> matches = new List<T>();
            foreach (Component component in this)
            {

                if (component is T)
                {
                    matches.Add((T)component);
                }
            }

            return matches;
        }

        protected virtual void OnComponentAdded(ComponentEventArgs e)
        {
            ComponentAdded?.Invoke(this, e);
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(Component item)
        {
            return components.ContainsKey(item.GetType());
        }

        public bool Contains<T>() where T : Component
        {
            Component[] tmp = new Component[components.Values.Count];
            components.Values.CopyTo(tmp, 0);

            for (int i = 0; i < tmp.Length; i++)
            {
                if (tmp[i] is T)
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(Component[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Component> GetEnumerator()
        {
            return components.Values.GetEnumerator();
        }

        public bool Remove(Component item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return components.GetEnumerator();
        }
    }
}
