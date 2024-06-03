using backend.Dtos.Stock;
using backend.Helpers;
using backend.Interfaces;
using backend.Mapper;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController:ControllerBase
    {  
        private readonly IStockRepository _stockRepository;
        public StockController(IStockRepository stockRepository)
        {
            _stockRepository=stockRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<StockDto>))]
        public async Task<IActionResult> GetStocks([FromQuery] QueryObject queryObejct)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stocks = await _stockRepository.GetAllStocks(queryObejct);

            if (stocks == null)
                return NotFound();

            var stockDto = stocks.Select(s => s.ToStockDto()).ToList();
            return Ok(stockDto);
        }

        [HttpGet("{stockId:int}")]
        [ProducesResponseType(200, Type = typeof(StockDto))]
        public async Task<IActionResult> GetStockById(int stockId)
        {
            if (!_stockRepository.IsStockExist(stockId))
                return NotFound();

            var stock = await _stockRepository.GetStockById(stockId);
        
            var stockDto = stock.ToStockDto();
            return Ok(stockDto);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(StockDto))]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
        {
            // Check if the incoming data is valid
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // If not valid, return a Bad Request response with the validation errors

            // Convert the CreateStockRequestDto to a Stock model
            var stockModel = stockDto.ToStockFromCreateDTO();

            // Call the repository method to create the new stock asynchronously
            await _stockRepository.CreateAsync(stockModel);

            // Return a response indicating that the stock was successfully created
            // Include the newly created stock in the response body and provide the URL to retrieve it
            return CreatedAtAction(nameof(GetStockById), new { stockId = stockModel.Id }, stockModel.ToStockDto());
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stockModel = await _stockRepository.UpdateAsync(id, updateDto);

            if (stockModel == null)
            {
                return NotFound();
            }

            return Ok(stockModel.ToStockDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var stock=await _stockRepository.DeleteAsync(id);
            if (stock == null) return NotFound();

            return NoContent();
        }
    }
}
