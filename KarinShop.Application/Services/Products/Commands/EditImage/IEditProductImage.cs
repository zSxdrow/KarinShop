//using Azure.Core;
//using KarinShop.Application.Interfaces.Context;
//using KarinShop.Application.Services.Products.Commands.AddProduct;
//using KarinShop.Common.Dto;
//using KarinShop.Common.Dto.UploadDto;
//using KarinShop.Domain.Entities.Products;
//using Microsoft.AspNetCore.Http;
//using static System.Net.Mime.MediaTypeNames;

//namespace KarinShop.Application.Services.Products.Commands.EditProduct.EditImage
//{
//    public interface IEditProductImage
//    {
//        ResultDto Execute(List<IFormFile> Images , long parentID);
//    }
//    public class EditProductImageServices : IEditProductImage
//    {
//        private readonly IDataBaseContext _context;
//        public EditProductImageServices(IDataBaseContext context)
//        {
//            _context = context;
//        }
//        public ResultDto Execute(List<IFormFile> Images, long parentID)
//        {
//            var product = _context.ProductImages.FirstOrDefault(p => p.ProductID == parentID);
//            if (product == null)
//            {
//                return new ResultDto
//                {
//                    IsSuccess = false,
//                    Message = "محصول یافت نشد"
//                };
//            }
//            if (Images == null || !Images.Any())
//            {
//                return new ResultDto
//                {
//                    IsSuccess = false,
//                    Message = "فایل انتخاب نشده است"
//                };
//            }
//            foreach (var image in Images)
//            {
//                // ذخیره فایل
//                 var fileName = _fileUpload.Upload(image);

//                var productImage = new ProductImage
//                {
//                   ProductID = product.ProductID,
//                   Src = 
//                };

//                _context.ProductImages.Add(productImage);
//            }

//            _context.SaveChanges();

//            return new ResultDto
//            {
//                IsSuccess = true,
//                Message = "تصاویر با موفقیت ثبت شدند."
//            };
//        }
         
//    }
//}
