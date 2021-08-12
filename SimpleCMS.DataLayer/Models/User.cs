using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.DataLayer
{
    class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AvatarImageName { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime JoinedDate { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        //public bool isAuthor { get; set; }
        //public bool IsAdmin { get; set; }
        public User()
        {
            Comments = new List<Comment>();
        }
    }
}
