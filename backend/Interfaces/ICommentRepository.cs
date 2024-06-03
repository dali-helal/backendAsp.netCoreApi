using backend.Dtos.Comment;
using backend.Models;

namespace backend.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();
        Task<Comment?> GetByIdAsync(int id);

        Task<Comment?> CreateAsync(Comment commentModel);

        Task<Comment?> UpdateAsync(int id, UpdateCommentDto commentModel);

        Task<Comment?> DeleteAsync(int id);
    }
}
