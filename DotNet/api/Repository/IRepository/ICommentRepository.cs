using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Repository.IRepository
{
    public interface ICommentRepository
    {
        public void AddAsync(Comment? comment); //Add comment to a stock based on Stock ID
        public void DeleteAsync(int?id); //Delete Comment from a stock based on Stock ID
        public Task<List<Comment>> GetAllAsync();//Get all the comments of a stock based on Stock ID
        public Task<Comment> GetAsync(int?id); //Get comment based on comment Id
        public void Update(Comment? comment); //Edit Comment based on comment Id
    }
}