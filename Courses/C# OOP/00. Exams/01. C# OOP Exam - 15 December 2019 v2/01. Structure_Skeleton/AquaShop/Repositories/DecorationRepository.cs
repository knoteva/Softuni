using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private readonly List<IDecoration> models;

        public  DecorationRepository()
        {
            models = new List<IDecoration>();
        }

        //TODO
        public IReadOnlyCollection<IDecoration> Models => this.models.AsReadOnly();


        public void Add(IDecoration model)
        {
            models.Add(model);
        }

        public IDecoration FindByType(string type)
        {
            //TODO
            var decorationType = models.FirstOrDefault(x => x.GetType().Name == type);
            return decorationType;
        }

        public bool Remove(IDecoration model)
        {
            return models.Remove(model);
        }
    }
}
