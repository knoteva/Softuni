using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MiniORM
{
    public class DbSet<TEntity> : ICollection<TEntity>
        where TEntity : class, new()
    {
        internal DbSet(IEnumerable<TEntity> entities)
        {
            Entities = entities.ToList();
            ChangeTracker = new ChangeTracker<TEntity>(entities);
        }

        internal List<TEntity> Entities { get; set; }

        internal ChangeTracker<TEntity> ChangeTracker { get; set; }

        public IEnumerator<TEntity> GetEnumerator() => this.Entities.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Add(TEntity item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item cannot be null");
            }
            Entities.Add(item);
            ChangeTracker.Add(item);
        }

        public void Clear()
        {
            while (Entities.Any())
            {
                var entity = Entities.First();
                this.Remove(entity);
            }
        }

        public bool Contains(TEntity item)
        {
            throw new System.NotImplementedException();
        }

        public void CopyTo(TEntity[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(TEntity item)
        {
            throw new System.NotImplementedException();
        }

        public int Count { get; set; }
        public bool IsReadOnly { get; set; }
    }
}