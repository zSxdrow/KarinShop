using KarinShop.Application.Interfaces.Context;
using KarinShop.Common.Dto;

namespace KarinShop.Application.Services.Products.Commands.RemoveProductFeature
{
    public interface IRemoveProductFeature
    {
        ResultDto Execute(int ID);
    }
    public class RemoveProductFeatureServices : IRemoveProductFeature
    {
        private readonly IDataBaseContext _context;
        public RemoveProductFeatureServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(int ID)
        {
            var result = _context.ProductFeatures.Find(ID);
            if (result == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "آیتم یافت نشد!"
                };
            }
            result.IsRemoved = true;
            result.RemoveTime = DateTime.Now;
            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
                Message = "آیتم با موفقیت حذف شد"
            };
        }
    }
}
