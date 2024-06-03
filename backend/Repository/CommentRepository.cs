using backend.Data;
using backend.Dtos.Comment;
using backend.Dtos.Stock;
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
        public async Task <Comment> GetByIdAsync(int id)
        {
            return _dbContext.Comments.SingleOrDefault(c => c.Id == id);    
        }
        public async Task<Comment> CreateAsync(Comment commentModel)
        {
            await _dbContext.Comments.AddAsync(commentModel);
            await _dbContext.SaveChangesAsync();
            return commentModel;
        }
        public async Task<Comment> UpdateAsync(int id,UpdateCommentDto commentModel)
        {
            var existingComment=await _dbContext.Comments.FirstOrDefaultAsync(c => c.Id == id);

            if (existingComment == null)
            {
                return null;
            }
            existingComment.Title = commentModel.Title;
            existingComment.Content = commentModel.Content;
       
            await _dbContext.SaveChangesAsync();

            return existingComment;
        }
        public async Task<Comment> DeleteAsync(int id)
        {
            var commentModel=await _dbContext.Comments.FirstOrDefaultAsync(c => c.Id == id);
            if(commentModel == null) { return null; }

             _dbContext.Comments.Remove(commentModel);
            await _dbContext.SaveChangesAsync();
            return commentModel;
        }
    }
}
