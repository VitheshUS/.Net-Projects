using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repository.IRepository
{
    public interface IUnitOfWork
    {
        public IStockRepository Stock {get ; }
        public IUserRepository User { get; }
        public ICommentRepository Comment { get; }
        public void SaveChanges();
        public void SaveChangesAsync();
    }
}