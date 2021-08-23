using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.DataLayer
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsAnonymous { get; set; }
        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
        public virtual IList<SubComment> SubComments { get; set; }
        public Comment()
        {
            SubComments = new List<SubComment>();
        }
    }
}
