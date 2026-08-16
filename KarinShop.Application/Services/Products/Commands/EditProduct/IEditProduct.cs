using Azure.Core;
using KarinShop.Application.Interfaces.Context;
using KarinShop.Common.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace KarinShop.Application.Services.Products.Commands.EditProduct
{
    public interface IEditProduct
    {
        ResultDto Execute(RequestEditProduct req);
    }

    public class EditProductServices : IEditProduct
    {
        private readonly IDataBaseContext _context;
        public EditProductServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestEditProduct req)
        {
            var product = _context.Products.Include(p => p.Category)
                .FirstOrDefault(p => p.ID == req.ID);
            if (product == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "محصول یافت نشد"
                };
            }

            if (string.IsNullOrWhiteSpace(req.Name) || string.IsNullOrEmpty(req.Description)
                || string.IsNullOrEmpty(req.Brand) || string.IsNullOrEmpty(req.Price.ToString())||
                string.IsNullOrEmpty(req.Inventory.ToString()))
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "لطفا تمامی مقادیر را پر کنید"
                };
            }
            product.Name = req.Name;
            product.Description = req.Description;
            product.Brand = req.Brand;
            product.Price = req.Price;
            product.Inventory = req.Inventory;
            product.CategoryID = req.CategoryID;
            product.Displayed = req.Displayed;
            product.UpdateTime = DateTime.Now;
            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
                Message = "محصول با موفقیت ذخیره شد"
            };
        }
    }
    public class RequestEditProduct
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }
        public int CategoryID { get; set; }
        public int Inventory { get; set; }
        public bool Displayed { get; set; }

        //public List<IFormFile> Images { get; set; }
        //public List<AddNewProduct_Feature> Features { get; set; }

    }

}
