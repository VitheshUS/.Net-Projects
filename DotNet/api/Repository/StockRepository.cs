using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using api.Data;
using api.Helpers;
using api.Models;
using api.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StockRepository : Repository.Repository<Stock>, IStockRepository
    {
        private readonly ApplicationDbContext _db;
        public StockRepository(ApplicationDbContext db) : base(db)
        { 
            _db=db;
        }

        public async Task<List<Stock>> GetAllUsingQuery(QueryObject queryObj,Expression<Func<Stock, object>>exp)
        {
            var stock = _db.Stock.Include(exp).AsQueryable();

            if(!string.IsNullOrWhiteSpace(queryObj.CompanyName)){
                stock=stock.Where(s=>s.CompanyName.Contains(queryObj.CompanyName));
            }

            if(!string.IsNullOrWhiteSpace(queryObj.Symbol)){
                stock=stock.Where(s=>s.Symbol.Contains(queryObj.Symbol));
            }
            return await stock.ToListAsync();
        }

        public void Update(Stock stock)
        {
            _db.Stock.Update(stock);
        }
    }
}