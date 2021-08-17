using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.DataLayer.Context.EntityConfigurations
{
    class SubCommentConfigurations: EntityTypeConfiguration<SubComment>
    {
        public SubCommentConfigurations()
        {
            Property(cm => cm.Title)
                .HasMaxLength(50)
                .IsRequired();
            Property(cm => cm.Text)
                .HasMaxLength(250)
                .IsRequired();
            HasRequired(sc => sc.MainComment)
                .WithMany(mc => mc.SubComments)
                .HasForeignKey(sc => sc.MainCommentId)
                .WillCascadeOnDelete(false);

        }
    }
}
