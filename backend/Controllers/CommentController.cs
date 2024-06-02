using backend.Dtos.Comment;
using backend.Interfaces;
using backend.Mapper;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController:ControllerBase
    {
        public readonly ICommentRepository _commentRepository;

        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository= commentRepository;
        }
        [HttpGet]
        [ProducesResponseType(200,Type= typeof(ICollection<CommentDto>))]
        public async Task<IActionResult> GetAll()
        {
            if(!ModelState.IsValid) return BadRequest(ModelState); 
            var commentes=await _commentRepository.GetAllAsync();
            
            var commentesDtos= commentes.Select(s=>s.ToCommentDto()).ToList();  
            return Ok(commentesDtos);
        }
    }
}
