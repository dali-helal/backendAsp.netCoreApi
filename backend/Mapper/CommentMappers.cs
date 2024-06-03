using backend.Dtos.Comment;
using backend.Models;

namespace backend.Mapper
{
    public static class CommentMappers
    {
        public static CommentDto ToCommentDto(this Comment comment)
        {

            return new CommentDto
            {
               Id = comment.Id,
               Title = comment.Title,
               Content = comment.Content,
               CreatedOn = comment.CreatedOn,
               StockId = comment.StockId,
            } ;
        }
        public static Comment ToCommentFromCreateDTO(this CreateCommentDto modelDto,int stockId)
        {
            return new Comment
            {
                Title = modelDto.Title,
                Content = modelDto.Content,
                StockId=stockId,
            };
        }
    }
}
