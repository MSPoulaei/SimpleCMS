using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.DataLayer.Context.EntityConfigurations
{
    class UserConfigurations : EntityTypeConfiguration<User>
    {
        public UserConfigurations()
        {
            Property(u => u.FirstName)
                .HasMaxLength(75)
                .IsRequired();
            Property(u => u.LastName)
                .HasMaxLength(75);
            Property(u => u.UserName)
                .HasMaxLength(75)
                .IsRequired();
            Property(u => u.Email)
                .HasMaxLength(75)
                .IsRequired();
            Property(u => u.Password)
                .HasMaxLength(100)
                .IsRequired();
            Property(u => u.AvatarImageName)
                .HasMaxLength(100);
            Property(u => u.JoinedDate)
                .IsRequired();



        }
    }
}
