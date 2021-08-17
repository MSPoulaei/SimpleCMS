using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.DataLayer
{
    public class SubComment
    {
        public int SubCommentId { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
        //[ForeignKey("MainComment")]
        public int MainCommentId { get; set; }
        public virtual Comment MainComment { get; set; }
        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
    }
}
