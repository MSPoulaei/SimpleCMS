using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.DataLayer
{
    class Post
    {
        public int PostId { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public int VisitsCount { get; set; }
        public string ImageName { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual Author Author { get; set; }
        public virtual ICollection<SubCategory> SubCategories { get; set; }
        public Post()
        {
            Comments = new List<Comment>();
            SubCategories = new List<SubCategory>();
        }
    }
}
