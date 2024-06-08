using backend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController:ControllerBase
    {   
        private readonly IFilesService _filesService;
        public FilesController(IFilesService fileService)
        {
            _filesService = fileService;
        } 
        

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UploadFile(IFormFile file, [FromQuery] string subDirectory)
        {
            try
            {
                var filePath=await _filesService.saveFileAsync(file,subDirectory);

                return Ok(filePath);

            }catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
            }
       
        }
    }
}
