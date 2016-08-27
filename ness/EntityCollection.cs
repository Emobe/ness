using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ness
{
    public class EntityCollection : ICollection<Entity>
    {
        public event EventHandler<EntityEventArgs> EntityAdded;

        Dictionary<string, List<Entity>> entities = new Dictionary<string, List<Entity>>();

        List<Entity> allEntities = new List<Entity>();

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

        public void Add(Entity item)
        {
            allEntities.Add(item);

            OnEntityAdded(new EntityEventArgs(item));
        }

        protected virtual void OnEntityAdded(EntityEventArgs e)
        {
            EntityAdded?.Invoke(this, e);
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public Entity Find(string name)
        {
            foreach(Entity entity in allEntities)
            {
                if(entity.Name == name)
                {
                    return entity;
                }
            }
            return null;
        }

        public List<Entity> FindAllEntity<T>() where T : Entity
        {
            List<Entity> matches = new List<Entity>();

            foreach(Entity entity in allEntities)
            {
                if(entity is T)
                {
                    matches.Add(entity);
                }
            }
            return matches;
        }

        public T Find<T>(string name) where T : Entity
        {
            foreach(Entity entity in allEntities)
            {
                if(entity is T && entity.Name == name)
                {
                    return entity as T;
                }
            }
            return null;
        }


        public List<Entity> FindAllWith<T>() where T : Component
        {
            List<Entity> match = new List<Entity>();
            foreach(Entity entity in allEntities)
            {
                if (entity.Contains<T>())
                {
                    match.Add(entity);
                }
            }
            return match;
        }

        public bool Contains(Entity item)
        {
            return allEntities.Contains(item);
        }

        public void CopyTo(Entity[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Entity> GetEnumerator()
        {
            return allEntities.GetEnumerator();
        }

        public bool Remove(Entity item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return allEntities.GetEnumerator();
        }
    }
}
