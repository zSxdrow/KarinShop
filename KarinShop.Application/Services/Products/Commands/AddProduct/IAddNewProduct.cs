using KarinShop.Application.Interfaces.Context;
using KarinShop.Common.Dto;
using KarinShop.Domain.Entities.Products;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace KarinShop.Application.Services.Products.Commands.AddProduct
{
    public interface IAddNewProduct
    {
        ResultDto Execute(RequestAddProduct request);
    }
    public class AddNewProductServices : IAddNewProduct
    {
       private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;
        public AddNewProductServices(IDataBaseContext context , IHostingEnvironment environment)
        {
        _context = context;
            _environment= environment;
        }
        //using flurent validation

        public ResultDto Execute(RequestAddProduct request)
        {
            try
            {
                var category = _context.Categories.Find(request.CategoryID);
                if (string.IsNullOrWhiteSpace(request.Name) ||
                    string.IsNullOrWhiteSpace(request.Brand) ||
                    string.IsNullOrWhiteSpace(request.Description) ||
                    request.Price == null ||
                    request.Inventory == null)
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = "لطفا تمامی موارد را وارد کنید"
                    };
                }
                Product product = new Product()
                {
                    Name = request.Name,
                    Brand = request.Brand,
                    Description = request.Description,
                    Inventory = request.Inventory,
                    Price = request.Price,
                    Category = category,
                    Displayed = request.Displayed,
                };
                _context.Products.Add(product);

                List<ProductImage> ProductImages = new();
                foreach (var item in request.Images)
                {
                    var uploadResult = UploadFile(item);
                    ProductImages.Add(new ProductImage
                    {
                        Product = product,
                        Src = uploadResult.FileNameAddress,
                    });
                }
                _context.ProductImages.AddRange(ProductImages);

                List<ProductFeature> productFeatures = new();
                foreach(var item in request.Features)
                {
                    productFeatures.Add(new ProductFeature
                    {
                        DisplayName = item.DisplayName,
                        Value = item.Value,
                        Product = product,
                    });
                }
                _context.ProductFeatures.AddRange(productFeatures);

                _context.SaveChanges();
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "محصول با موفقیت به سایت اضافه شد"
                };
            }
            catch (Exception ex)
            {
                return new ResultDto { IsSuccess = false, Message = "خطایی رخ داد" };
            }
        }

        private UploadDto UploadFile(IFormFile file)
        {
            if(file != null)
            {
                string folder = $@"images/ProductImages";
                var UploadRoot = Path.Combine(_environment.WebRootPath, folder);
                if (!Directory.Exists(UploadRoot))
                {
                    Directory.CreateDirectory(UploadRoot);
                }
                if(file == null || file.Length == 0)
                {
                    return new UploadDto { Status = false , FileNameAddress = ""};
                }
                string fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                var filePath = Path.Combine(UploadRoot, fileName);
                using (var fileStream = new FileStream(filePath , FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                return new UploadDto
                {
                    Status = true,
                    FileNameAddress = folder+ "/" + fileName,
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

    public class RequestAddProduct
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }
        public int CategoryID { get; set; }
        public int Inventory { get; set; }
        public bool Displayed { get; set; }

        public List<IFormFile> Images { get; set; }
        public List<AddNewProduct_Feature> Features { get; set; }
    }
    public class AddNewProduct_Feature
    {

        public string DisplayName { get; set; }
        public string Value { get; set; }

    }
}
