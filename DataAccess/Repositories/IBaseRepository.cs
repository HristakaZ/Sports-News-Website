using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IBaseRepository<T>
    {
        void Create();
        void Create(T entity);
        List<T> Read();
        void Update(T entity);
        T Delete(int? id);
        T Delete(int id);
        List<T> GetAll();
        T GetByID(int id);
    }
}
