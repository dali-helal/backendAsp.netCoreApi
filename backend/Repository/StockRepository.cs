using backend.Data;
using backend.Dtos.Stock;
using backend.Interfaces;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository
{
    public class StockRepository : IStockRepository
    {   
        private readonly ApplicationDBContext _dbContext;
        public StockRepository(ApplicationDBContext dbContext)
        {

            _dbContext = dbContext;

        }
        public async Task<List<Stock>> GetAllStocks()
        {
            return await _dbContext.Stocks.Include(c=>c.Comments).ToListAsync();
        }
        public async Task<Stock> GetStockById(int stockId)
        {
            return await _dbContext.Stocks.Include(c => c.Comments).FirstOrDefaultAsync(s=>s.Id== stockId);
        }

        public async Task<Stock> CreateAsync(Stock stockModel)
        {
            await _dbContext.Stocks.AddAsync(stockModel);
            await _dbContext.SaveChangesAsync();
            return stockModel;
        }
        public async Task<Stock?> DeleteAsync(int id)
        {
            var stockModel = await _dbContext.Stocks.FirstOrDefaultAsync(x => x.Id == id);

            if (stockModel == null)
            {
                return null;
            }

            _dbContext.Stocks.Remove(stockModel);
            await _dbContext.SaveChangesAsync();
            return stockModel;
        }
        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto)
        {
            var existingStock = await _dbContext.Stocks.FirstOrDefaultAsync(x => x.Id == id);

            if (existingStock == null)
            {
                return null;
            }

            existingStock.Symbol = stockDto.Symbol;
            existingStock.CompanyName = stockDto.CompanyName;
            existingStock.Purchase = stockDto.Purchase;
            existingStock.LastDiv = stockDto.LastDiv;
            existingStock.Industry = stockDto.Industry;
            existingStock.MarketCap = stockDto.MarketCap;

            await _dbContext.SaveChangesAsync();

            return existingStock;
        }
        public bool IsStockExist(int stockId)
        {
            return _dbContext.Stocks.Any(s=>s.Id == stockId); 
        }
    }
}
