using KarinShop.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarinShop.Domain.Entities.User
{
    public class User : BaseEntity
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public bool IsActive { get; set; } = true;
        public ICollection<UserInRole> UserInRoles { get; set; }

    }

}
