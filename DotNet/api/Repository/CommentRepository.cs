using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CommentRepository : IRepository.ICommentRepository
    {
        private readonly ApplicationDbContext _db;
        public CommentRepository(ApplicationDbContext db)
        {
            _db=db;
        }

        public async void DeleteAsync(int? id)
        {
            var comment=await GetAsync(id);
            _db.Comment.Remove(comment);
        }

        public async Task<Comment> GetAsync(int? id)
        {
            return await _db.Comment.FindAsync(id);
        }

        public async Task<List<Comment>> GetAllAsync()
        {
           return await _db.Comment.ToListAsync();
        }

        public void Update(Comment? comment)
        {
            if(comment!=null)
                _db.Comment.Update(comment);
        }

        public async void AddAsync(Comment? comment)
        {
            if(comment!=null)
                await _db.Comment.AddAsync(comment);
        }
    }
}