using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.DataLayer
{
    class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<SubCategory> SubCategories { get; set; }
        public Category()
        {
            SubCategories = new List<SubCategory>();
        }
    }
}
