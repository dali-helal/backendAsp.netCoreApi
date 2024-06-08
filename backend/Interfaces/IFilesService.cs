namespace backend.Interfaces
{
    public interface IFilesService
    {
        Task<string> saveFileAsync(IFormFile file, string subDirectory);
    }
}
