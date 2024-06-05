using backend.Interfaces;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController:ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IStockRepository _stockRepo;
        private readonly IPortfolioRepository _portfolioRepo;
        public PortfolioController(UserManager<AppUser> userManager,
        IStockRepository stockRepo,
        IPortfolioRepository portfolioRepo)
        {
            _userManager = userManager;
            _stockRepo = stockRepo;
            _portfolioRepo = portfolioRepo;

        }
        [HttpGet("{userId:guid}")]
        //[Authorize]
        public async Task<IActionResult> GetUserPortfolio(string userId)
        {
      
            if (!ModelState.IsValid)
            {
                return BadRequest("User ID is required.");
            }

            var appUser = await _userManager.FindByIdAsync(userId);

            if (appUser == null)
            {
                return NotFound("User not found.");
            }
            var userPortfolio = await _portfolioRepo.GetUserPortfolio(appUser);
            return Ok(userPortfolio);
        }
    }
}
