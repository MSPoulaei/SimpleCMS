using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.DataLayer.Context.EntityConfigurations
{
    class CategoryConfigurations: EntityTypeConfiguration<Category>
    {
        public CategoryConfigurations()
        {
            Property(sc => sc.Name)
                .HasMaxLength(50)
                .IsRequired();
            



        }
    }
}
