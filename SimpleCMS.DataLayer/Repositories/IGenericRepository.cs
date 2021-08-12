using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.DataLayer
{
   public interface IGenericRepository<T>:IDisposable where T:class
    {
        IEnumerable<T> GetAll();
        T GetById(int Id);
        bool Insert(T item);
        bool Update(T item);
        bool Delete(T item);
        bool Delete(int Id);
        void save();

    }
}
