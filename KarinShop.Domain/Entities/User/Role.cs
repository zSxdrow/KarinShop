namespace KarinShop.Domain.Entities.User
{
    public class Role() : BaseEntityRole
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
       public ICollection<UserInRole> UserInRoles { get; set; }
    }
    public class BaseEntityRole
    {
        public DateTime InsertTime { get; set; } 
        public DateTime? UpdateTime { get; set; }
        public bool IsRemoved { get; set; } = false;
        public DateTime? RemoveTime { get; set; }
    }
}
