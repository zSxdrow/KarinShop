using KarinShop.Application.Interfaces.Context;
using KarinShop.Application.Services.Products.Commands.AddProduct;
using KarinShop.Common.Dto;
using KarinShop.Domain.Entities.Products;

namespace KarinShop.Application.Services.Products.Commands.AddFeature
{
    public interface IAddNewProductFeature
    {
        ResultDto Execute(List<AddNewProductFeatureDto> req);
    }
    public class AddNewProductFeatureServices : IAddNewProductFeature
    {
        private readonly IDataBaseContext _context;
        public AddNewProductFeatureServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(List<AddNewProductFeatureDto> req)
        {

            foreach (var item in req)
            {
                if (string.IsNullOrEmpty(item.DisplayName))
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = "نام را وارد کنید "
                    };
                }
                if (string.IsNullOrEmpty(item.Value))
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = "لطفا مقدار را وارد کنید"
                    };
                }
                var result = _context.Products.Find(item.ProductID);
                if (result == null)
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = "محصول یافت نشد"
                    };
                }
            }
            var product = req.Select(p => new ProductFeature
            {
                ProductID = p.ProductID,
                DisplayName = p.DisplayName,
                Value = p.Value,
                InsertTime = DateTime.Now,
            }).ToList();
            _context.ProductFeatures.AddRange(product);
            _context.SaveChanges();
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "ویژگی با موفقیت اضافه شد"
                };

            
            
        }
    }
    public class AddNewProductFeatureDto
    {
        public string DisplayName { get; set; }
        public string Value { get; set; }
        public int ProductID { get; set; }
    }
}
