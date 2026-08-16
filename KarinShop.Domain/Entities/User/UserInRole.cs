using KarinShop.Domain.Entities.Commons;

namespace KarinShop.Domain.Entities.User
{
    public class UserInRole() : BaseEntity
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int RoleID { get; set; }

        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }

}
