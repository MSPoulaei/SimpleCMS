using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.DataLayer
{
    class SubCategory
    {
        public int SubCategoryId { get; set; }
        public string Name { get; set; }
        public int MainCategoryId { get; set; }
        public virtual Category MainCategory { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public SubCategory()
        {
            Posts = new List<Post>();
        }
    }
}
