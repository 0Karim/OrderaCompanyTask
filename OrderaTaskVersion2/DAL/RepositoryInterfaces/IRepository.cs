using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderaTaskVersion2.Models;
using System.Linq.Expressions;

namespace OrderaTaskVersion2.DAL
{
    public interface IRepository<TEntity> where TEntity : class 
    {
        //Return Entity
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);


        //Find Entity
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);



        //Add Entity
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);


        
        //Remove Entity
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void RemoveByID(int id);


        void Update(TEntity entity);
        void Save();
    }
}
