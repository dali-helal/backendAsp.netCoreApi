using backend.Interfaces;

namespace backend.Services
{
    public class FileService : IFilesService
    {
        public readonly string _baseDirectory;
        public FileService()
        {
            _baseDirectory = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
            if(Directory.Exists(_baseDirectory)) {

                Directory.CreateDirectory(_baseDirectory);
             }
        }
        public async Task<string> saveFileAsync(IFormFile file, string subDirectory)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("No file uploaded");
            }

            var directoryPath = Path.Combine(_baseDirectory, subDirectory ?? string.Empty);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var filePath = Path.Combine(directoryPath, file.FileName);


            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Return the relative path
            var relativePath = Path.Combine("uploads", subDirectory ?? string.Empty, file.FileName).Replace("\\", "/");
            return relativePath;
        }   
    }
}
