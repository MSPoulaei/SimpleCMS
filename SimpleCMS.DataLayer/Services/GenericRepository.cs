using SimpleCMS.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.DataLayer
{
   public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        SimpleCMSContext _context=null;
        public GenericRepository(SimpleCMSContext context)
        {
            _context = context;
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }
        public T GetById(int Id)
        {
            return _context.Set<T>().Find(Id);
        }

        public bool Insert(T item)
        {
            try
            {
                _context.Set<T>().Add(item);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(T item)
        {
            try
            {
                _context.Set<T>().Attach(item);
                _context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool Delete(T item)
        {
            try
            {
                _context.Set<T>().Attach(item);
                _context.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false; 
            }
        }

        public bool Delete(int Id)
        {
            try
            {
                Delete(GetById(Id));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
