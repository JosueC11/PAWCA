using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAWCA.Data.Repository.Interfaces;
using PAWCA.Models;

namespace PAWCA.Data.Repository
{
    public class RepositoryNews : RepositoryBase<News>, IRepositoryNews
    {
    }
}
