using FinalProject.Core.Core.Entity;
using FinalProject.Core.Core.Entity.Enum;
using FinalProject.Core.Core.Repository;
using FinalProject.Dal.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FinalProject.Repository.Repository.Base
{
    public class BaseRepository<T> : ICoreRepository<T> where T : CoreEntity
    {
        private FinalProjectContext _context;

        public BaseRepository()
        {
            _context = new FinalProjectContext();
        }

        public void Add(T item)
        {
            _context.Set<T>().Add(item);
            try
            {
                Save();
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(ex);
            }
            
        }

        public void Add(List<T> items)
        {
            _context.Set<T>().AddRange(items);
            try
            {
                Save();
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(ex);
            }
            
        }

        public bool Any(Expression<Func<T, bool>> exp) => _context.Set<T>().Any(exp);

        public List<T> GetActive() => _context.Set<T>().Where(x => x.Status == Status.Active || x.Status == Status.Updated).ToList();

        public T GetByDefault(Expression<Func<T, bool>> exp) => _context.Set<T>().Where(exp).FirstOrDefault();


        public T GetById(Guid id) => _context.Set<T>().Find(id);


        public List<T> GetDefault(Expression<Func<T, bool>> exp) => _context.Set<T>().Where(exp).ToList();

        //Silinen Kayıtları Geri Getirme veya Silinenleri Tamamen Silmek İçin Kullanılcak..
        public List<T> GetDeleted() => _context.Set<T>().Where(x => x.Status == Status.Deleted).ToList();
        //Silinen Kayıtları Geri Getirme veya Silinenleri Tamamen Silmek İçin Kullanılcak..
        public void RealRemove(Guid id)
        {
            T item = GetById(id);
            _context.Set<T>().Remove(item);
            try
            {
                Save();
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(ex);
            }
           
        }

        public void Remove(Guid id)
        {
            T item = GetById(id);
            item.Status = Status.Deleted;
            try
            {
                Save();
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(ex);
            }
            
        }

        public void Remove(T item)
        {
            item.Status = Status.Deleted;
            try
            {
                Save();
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(ex);
            }
            
        }

        public void RemoveAll(Expression<Func<T, bool>> exp)
        {
            foreach (var item in GetDefault(exp))
            {
                item.Status = Status.Deleted;
                try
                {
                    Save();
                }
                catch (Exception ex)
                {
                    HttpContext.Current.Response.Write(ex);
                }
               
            }
        }

        public int Save() => _context.SaveChanges();


        public void Update(T item)
        {
            T updated = GetById(item.ID);
            DbEntityEntry entry = _context.Entry(updated);
            entry.CurrentValues.SetValues(item);
            try
            {
                Save();
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(ex);
            }
           
        }
    }
}
