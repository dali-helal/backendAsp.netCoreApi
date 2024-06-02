using backend.Data;
using backend.Interfaces;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository
{
    public class CommentRepository : ICommentRepository
    {   
        private readonly ApplicationDBContext _dbContext;

        public CommentRepository(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public async Task<List<Comment>> GetAllAsync()
        {
            return await _dbContext.Comments.ToListAsync();
        }
    }
}
