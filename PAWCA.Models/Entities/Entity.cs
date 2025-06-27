using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAWCA.Models.Entities.Interfaces;

namespace PAWCA.Models.Entities
{
    public class Entity : IEntity
    {
        [NotMapped]
        public DateTime ModifiedDate { get; set; }
        [NotMapped]
        public DateTime CreatedDate { get; set; }
    }
}
