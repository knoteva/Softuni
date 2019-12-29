using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        public DecorationRepository()
        {
            Models = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models { get; }

        public void Add(IDecoration model)
        {
            Models.ToList().Add(model);
        }

        public IDecoration FindByType(string type)
        {
            var result = Models.FirstOrDefault(x => x.GetType().Name == type);

            return result;
        }

        public bool Remove(IDecoration model)
        {
            return true;
        }
    }
}
