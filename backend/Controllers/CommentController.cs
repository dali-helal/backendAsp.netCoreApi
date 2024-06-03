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
        public readonly IStockRepository _stockRepository;

        public CommentController(ICommentRepository commentRepository, IStockRepository stockRepository)
        {
            _commentRepository = commentRepository;
            _stockRepository = stockRepository;

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
        [HttpGet("{id}")]
        [ProducesResponseType(200,Type = typeof(CommentDto))]
        public async Task <IActionResult> GetCommentById(int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState); 

            var comment=await _commentRepository.GetByIdAsync(id);
            if(comment==null) return NotFound();

            return Ok(comment.ToCommentDto());
        }
        [HttpPost("{stockId}")]
        public async Task<IActionResult> Create(int stockId,[FromBody] CreateCommentDto commentDto)
        {
            if(!_stockRepository.IsStockExist(stockId)) return BadRequest("stock doesn't exist");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var commentModel= commentDto.ToCommentFromCreateDTO(stockId);

            await _commentRepository.CreateAsync(commentModel);

            return CreatedAtAction(nameof(GetCommentById), new { id = commentModel.Id }, commentModel.ToCommentDto());
            
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateCommentDto commentDto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var commentModel= await _commentRepository.UpdateAsync(id, commentDto);
            if (commentModel == null) return NotFound(new { message = "COMMENT NOT FOUND" });

            return Ok(commentModel.ToCommentDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            var commentModel = await _commentRepository.DeleteAsync(id);
            if(commentModel == null) return NotFound(new { message = "COMMENT NOT FOUND" });
            return NoContent(); 
        }

    }
}
