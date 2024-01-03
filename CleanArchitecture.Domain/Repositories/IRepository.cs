using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Repositories
{
    public interface IRepository<in TDomain>
    {
        void Add(TDomain entity);
        void Update(TDomain entity);
        void Remove(TDomain entity);
    }
}
