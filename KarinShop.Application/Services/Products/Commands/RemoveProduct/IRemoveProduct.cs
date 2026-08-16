using KarinShop.Application.Interfaces.Context;
using KarinShop.Common.Dto;

namespace KarinShop.Application.Services.Products.Commands.RemoveProduct
{
    public interface IRemoveProduct
    {
        ResultDto Execute(long ID);
    }
    public class RemoveProductService : IRemoveProduct
    {
        private readonly IDataBaseContext _context;
        public RemoveProductService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(long ID)
        {
            var product = _context.Products.FirstOrDefault(p => p.ID == ID);
            if (product == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "محصول یافت نشد"
                };
            }
            product.IsRemoved = true;
            product.RemoveTime = DateTime.Now;
            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
                Message = "محصول با موفقیت حذف شد"
            };
        }
    }
}
