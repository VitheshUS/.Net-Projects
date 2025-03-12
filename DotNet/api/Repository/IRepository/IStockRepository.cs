using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using api.Helpers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
namespace api.Repository.IRepository
{
    public interface IStockRepository :IRepository.IRepository<Stock>
    {
        public void Update(Stock stock);
        public Task<List<Stock>> GetAllUsingQuery(QueryObject query,Expression<Func<Stock, object>>exp);
    }
}