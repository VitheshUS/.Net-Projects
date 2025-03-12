using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using api.Data;
using api.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class Repository<T> : IRepository.IRepository<T> where T:class
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db=db;
            dbSet=_db.Set<T>();
        }
        public void Add(T obj)
        {
            dbSet.Add(obj);
        }

        public T? Get(int? id)
        {
             T? obj=dbSet.Find(id);
            return obj;
        }

        public IEnumerable<T> GetAll()
        {
           return dbSet.ToList();
        }

        public Task<List<T>> GetAllAsync()
        {
            return dbSet.ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, object>> exp)
        {
            Console.WriteLine(exp);
            IQueryable<T> query=dbSet;
            if(exp!=null){
                query=query.Include(exp);
            }
            return await query.ToListAsync();
        }

        public async ValueTask<T?> GetAsync(int? id)
        {
           Console.WriteLine(id);
           var obj= await dbSet.FindAsync(id);
           return obj;
        }

        public void Remove(T obj)
        {
            dbSet.Remove(obj);
        }
    }
}