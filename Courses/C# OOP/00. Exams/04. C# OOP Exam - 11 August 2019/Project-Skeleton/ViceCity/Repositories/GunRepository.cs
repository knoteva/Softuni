using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Repositories
{
    public class GunRepository : IRepository<IGun>
    {

        private List<IGun> models;

        public GunRepository()
        {
            this.models = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models => models.AsReadOnly();

        public void Add(IGun model)
        {
            if (!models.Contains(model))
            {
                models.Add(model);
            }
        }

        public IGun Find(string name)
        {
            var gun = models.Find(x => x.Name == name);
            return gun;
        }
        
        public bool Remove(IGun model)
        {
            return models.Remove(model);
        }
    }
}
