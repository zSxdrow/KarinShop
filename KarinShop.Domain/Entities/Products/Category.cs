using KarinShop.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarinShop.Domain.Entities.Products
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }

        public virtual Category ParentCategory { get; set; }
        public int? ParentCategoryID { get; set; }


        //برای نمایش زیر دسته های هر گروه
        public virtual ICollection<Category> ChildCategories { get; set; }



    }
}
