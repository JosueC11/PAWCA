using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAWCA.Manager.Factory.Interfaces;
using PAWCA.Models.Entities.Interfaces;

namespace PAWCA.Manager.Factory
{
    public abstract class NewsFactory : INewsFactory
    {
        public virtual IEntity CreateEntity<T>() where T : class, new()
        {
            var entity = Activator.CreateInstance(typeof(T));
            return entity as IEntity;
        }

        public virtual void ApplyAuditing(IEntity entity)
        {
            Action<IEntity> funcWhenInserting = new(entity =>
            {
                entity.CreatedDate = DateTime.Now;
            });

            Action<IEntity> funcWhenUpdating = new(entity =>
            {
                entity.ModifiedDate = DateTime.Now;
            });
        }
    }
}
