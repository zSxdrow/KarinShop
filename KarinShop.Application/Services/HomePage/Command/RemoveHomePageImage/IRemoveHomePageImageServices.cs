using KarinShop.Application.Interfaces.Context;
using KarinShop.Common.Dto;
using KarinShop.Domain.Entities.HomePage;

namespace KarinShop.Application.Services.HomePage.Command.RemoveHomePageImage
{
    public interface IRemoveHomePageImageServices
    {
        ResultDto Execute(long? ID);
    }

    public class RemoveHomePageImageServices : IRemoveHomePageImageServices
    {
        private readonly IDataBaseContext _context;
        public RemoveHomePageImageServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(long? ID)
        {
            var result = _context.HomePageImages.Where(p => p.ID == ID).FirstOrDefault();
            if (result == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "اسلاید پیدا نشد لطفا دوباره تلاش کنید"
                };
            }
            result.IsRemoved = true;
            result.RemoveTime = DateTime.Now;
            _context.SaveChanges();
            return new ResultDto
            { 
                IsSuccess = true,
                Message = "اسلاید با موفقیت حذف شد"
            };
        }
    }
}
