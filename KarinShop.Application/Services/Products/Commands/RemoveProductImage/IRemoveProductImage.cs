using KarinShop.Application.Interfaces.Context;
using KarinShop.Common.Dto;
using Microsoft.EntityFrameworkCore.Storage;

namespace KarinShop.Application.Services.Products.Commands.RemoveProductImage
{
    public interface IRemoveProductImage
    {
        ResultDto Execute(long ImageID);
    }
    public class RemoveProductImageServices : IRemoveProductImage
    {
        private readonly IDataBaseContext _context;
        public RemoveProductImageServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(long ImageID)
        {
            var Images = _context.ProductImages.FirstOrDefault( p => p.ID == ImageID);
            if(Images == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "عکس یافت نشد"
                };
            }
            Images.IsRemoved = true;
            Images.RemoveTime = DateTime.Now;
            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
                Message = "عکس با موفقیت حذف شد"
            };
        }
    }
}
