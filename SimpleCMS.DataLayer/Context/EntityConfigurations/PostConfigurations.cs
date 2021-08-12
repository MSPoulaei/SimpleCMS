using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.DataLayer.Context.EntityConfigurations
{
    class PostConfigurations:EntityTypeConfiguration<Post>
    {
        public PostConfigurations()
        {
            Property(p => p.Title)
                .HasMaxLength(100)
                .IsRequired();
            Property(p => p.Text)
                .IsMaxLength()
                .IsRequired();
        }
    }
}
