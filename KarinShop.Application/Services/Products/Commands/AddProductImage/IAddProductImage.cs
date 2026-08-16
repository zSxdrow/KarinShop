using KarinShop.Application.Interfaces.Context;
using KarinShop.Application.Services.Common.UploadFile;
using KarinShop.Common.Dto;
using KarinShop.Domain.Entities.Products;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace KarinShop.Application.Services.Products.Commands.AddProductImage
{
    public interface IAddProductImage
    {
        ResultDto Execute(RequestAddProductImage req);
    }
    public class AddProductImageServices : IAddProductImage
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;
        public AddProductImageServices(IDataBaseContext context , IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
           
        public ResultDto Execute(RequestAddProductImage req)
        {
            List<ProductImage> productImages = new();
            foreach (var item in req.Images)
            {
                var UploadResult = UploadFile(item, req.FolderName);
                productImages.Add(new ProductImage
                {
                    Src = UploadResult.FileNameAddress,
                    ProductID = req.ProductID
                });
            }
                _context.ProductImages.AddRange(productImages);
            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
                Message = "عکس با موفقیت آپلود شد"
            };

        }

        public UploadDto UploadFile(IFormFile file, string FolderName)
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
                string fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                var filePath = Path.Combine(UploadRoot, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                return new UploadDto
                {
                    Status = true,
                    FileNameAddress = folder + "/" + fileName,
                };
            }
            return null;
        }


    }



}
    public class UploadDto
    {
        public int ID { get; set; }
        public bool Status { get; set; }
        public string FileNameAddress { get; set; }

    }
    public class RequestAddProductImage
    {
        public int ProductID { get; set; }
        public List<IFormFile> Images { get; set; }
        public string FolderName { get; set; }
    }

