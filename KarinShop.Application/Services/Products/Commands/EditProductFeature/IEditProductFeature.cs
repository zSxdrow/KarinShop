using KarinShop.Application.Interfaces.Context;
using KarinShop.Common.Dto;

namespace KarinShop.Application.Services.Products.Commands.EditProductFeature
{
    public interface IEditProductFeature
    {
        ResultDto Execute(long ID, string Name, string Value);
    }
    public class EditProductFeatureServices : IEditProductFeature
    {
        private readonly IDataBaseContext _context;
        public EditProductFeatureServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(long ID, string Name, string Value)
        {
            var result = _context.ProductFeatures.FirstOrDefault(p => p.ID == ID);
            if (result == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "آیتم مورد نظر پیدا نشد!"
                };
            }
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Value))
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "لطفا تمامی مقادیر را وارد کنید"
                };
            }
            result.DisplayName = Name;
            result.Value = Value;
            result.UpdateTime = DateTime.Now;
            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
                Message = "آیتم با موفقیت تغیر یافت"
            };
        }
    }
}
