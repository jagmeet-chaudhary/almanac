using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almanac.Service.Storage
{
    public interface ITableStorage<T>
    {
        bool AddOrUpdate(T entity);
        bool Delete(T entity);

        List<T> Get(string query=null);

    }
}
