using ForestDamageAssessment.DB.Models;
using ForestDamageAssessment.Infrastructure;

namespace ForestDamageAssessment.Services
{
    public class FileModelService : IFileModelService
    {
        private readonly IWebHostEnvironment _appEnvironment;

        public FileModelService(IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }

        public async Task<FileModel> CreateFileModelAsync(IFormFile uploadedFile)
        {
            var fileModel = new FileModel();

            if (uploadedFile == null)
            {
                return fileModel;
            }

            if (!uploadedFile.FileName.ToLower().EndsWith(".txt") && !uploadedFile.FileName.ToLower().EndsWith(".csv"))
            {
                return fileModel;
            }

            string path = _appEnvironment.WebRootPath + "/Files/" + uploadedFile.FileName;
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await uploadedFile.CopyToAsync(fileStream);
            }

            fileModel.Name = uploadedFile.FileName;
            fileModel.Path = path;
            return fileModel;
        }
    }
}