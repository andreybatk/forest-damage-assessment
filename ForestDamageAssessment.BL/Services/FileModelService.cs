using ForestDamageAssessment.BL.Interfaces;
using ForestDamageAssessment.DB.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace ForestDamageAssessment.BL.Services
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