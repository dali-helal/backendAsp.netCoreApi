using backend.Dtos.Stock;
using backend.Helpers;
using backend.Models;

namespace backend.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllStocks(QueryObject query);
        Task<Stock> GetStockById(int stockId);
        bool IsStockExist(int stockId);
        Task<Stock> CreateAsync(Stock stockModel);
        Task<Stock?> DeleteAsync(int id);
        Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto);
    }
}
