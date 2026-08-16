using KarinShop.Application.Interfaces.Context;
using KarinShop.Common.Dto;

namespace KarinShop.Application.Services.Users.Commands.RemoveUsers
{
    public class RemoveUserServices : IRemoveUsers
    {
        private readonly IDataBaseContext _context;
        public RemoveUserServices(IDataBaseContext context)
        {
            _context = context;
        }


        public ResultDto Execute(int UserID)
        {
           var user = _context.Users.Find(UserID);
            if (user == null)
            {
                return new ResultDto()
                { IsSuccess = false , Message = "کاربر یافت نشد"};

            }
            user.IsRemoved = true;
            user.RemoveTime = DateTime.Now;
            _context.SaveChanges();
            return new ResultDto()
            { IsSuccess = true, Message = "کاربر با موفقیت حذف شد" };
        }
    }
}
