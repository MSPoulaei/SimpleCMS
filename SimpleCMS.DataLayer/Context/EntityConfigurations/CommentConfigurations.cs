using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.DataLayer.Context.EntityConfigurations
{
    class CommentConfigurations: EntityTypeConfiguration<Comment>
    {
        public CommentConfigurations()
        {
            Property(cm => cm.Title)
                .HasMaxLength(50)
                .IsRequired();
            Property(cm => cm.Text)
                .HasMaxLength(250)
                .IsRequired();

        }
    }
}
