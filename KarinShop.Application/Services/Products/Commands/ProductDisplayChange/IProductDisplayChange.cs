using KarinShop.Application.Interfaces.Context;
using KarinShop.Common.Dto;

namespace KarinShop.Application.Services.Products.Commands.ProductDisplayChange
{
    public interface IProductDisplayChange
    {
        ResultDto Execute(long ID);
    }
    public class ProductDisplayChangeServices : IProductDisplayChange
    {
        private readonly IDataBaseContext _context;
        public ProductDisplayChangeServices(IDataBaseContext context)
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
                    Message = "کالای مورد نظر یافت نشد!!"
                };
            }
            string txt = product.Displayed == true ? ".نمایش داده خواهد شد" : "نمایش داده نخواهد شد.";
            product.Displayed = !product.Displayed;
            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
                Message = $"کالا با موفقیت در سایت {txt}"
            };
        }
    }
}
