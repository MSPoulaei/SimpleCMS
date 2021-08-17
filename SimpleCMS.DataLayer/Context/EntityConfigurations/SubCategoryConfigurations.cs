using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.DataLayer.Context.EntityConfigurations
{
    class SubCategoryConfigurations: EntityTypeConfiguration<SubCategory>
    {
        public SubCategoryConfigurations()
        {
            Property(sc => sc.Name)
                .HasMaxLength(50)
                .IsRequired();
            HasRequired(sc => sc.MainCategory)
                .WithMany(mc => mc.SubCategories)
                .HasForeignKey(sc=>sc.MainCategoryId)
                .WillCascadeOnDelete(false);
            



        }
    }
}
