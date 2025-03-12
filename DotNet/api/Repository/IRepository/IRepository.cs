using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace api.Repository.IRepository
{
    public interface IRepository<T> where T :class
    {
        public T? Get(int? id);
        public IEnumerable<T> GetAll();
        public void Add(T obj);
        public void Remove(T obj);
        public ValueTask<T?> GetAsync(int? id);
        public Task<List<T>> GetAllAsync();
        public Task<List<T>> GetAllAsync(Expression<Func<T,object>>exp);
    }
}