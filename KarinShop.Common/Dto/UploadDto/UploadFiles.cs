using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace KarinShop.Common.Dto.UploadDto;

public class UploadFiles
    {
    private readonly IHostingEnvironment _environment;
    private UploadDto UploadFile(IFormFile file , string FolderName)
    {
        if (file != null)
        {
            string folder = $@"images/{FolderName}";
            var UploadRoot = Path.Combine(_environment.WebRootPath, folder);
            if (!Directory.Exists(UploadRoot))
            {
                Directory.CreateDirectory(UploadRoot);
            }
            if (file == null || file.Length == 0)
            {
                return new UploadDto { Status = false, FileNameAddress = "" };
            }
            string fileName = DateTime.Now.Ticks.ToString() + file.FileName;
            var filePath = Path.Combine(UploadRoot, fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return new UploadDto
            {
                Status = true,
                FileNameAddress = folder + fileName,
            };
        }
        return null;
    }

}

public class UploadDto
{
    public int ID { get; set; }
    public bool Status { get; set; }
    public string FileNameAddress { get; set; }
}

