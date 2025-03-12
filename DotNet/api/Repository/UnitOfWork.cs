using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Repository.IRepository;

namespace api.Repository
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IStockRepository Stock {get ; private set;}
        public IUserRepository User { get; private set; }
        public ICommentRepository Comment { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db=db;
            Stock=new StockRepository(db);
            User=new UserRepository(db);
            Comment=new CommentRepository(db);
        }
        public void SaveChanges()
        {
            _db.SaveChanges();
        }
        public async void SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}