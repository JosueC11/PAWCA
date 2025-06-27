using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAWCA.Models.Entities.Interfaces
{
    public interface IEntity
    {
        DateTime ModifiedDate { get; set; }
        DateTime CreatedDate { get; set; }
    }
}
