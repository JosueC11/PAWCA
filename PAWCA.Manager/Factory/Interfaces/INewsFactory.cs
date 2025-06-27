using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using PAWCA.Models.Entities.Interfaces;

namespace PAWCA.Manager.Factory.Interfaces
{
    public interface INewsFactory
    {
        void ApplyAuditing(IEntity entity);
        IEntity CreateEntity<T>() where T : class, new();
    }
}
