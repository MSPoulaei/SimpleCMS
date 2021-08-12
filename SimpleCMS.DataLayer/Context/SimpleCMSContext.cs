using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCMS.DataLayer.Context.EntityConfigurations;

namespace SimpleCMS.DataLayer.Context
{
    class SimpleCMSContext:DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PostConfigurations());
            modelBuilder.Configurations.Add(new SubCategoryConfigurations());
            modelBuilder.Configurations.Add(new UserConfigurations());
            base.OnModelCreating(modelBuilder);
        }
        public SimpleCMSContext()
            : base("name=SimpleCMSContext")
        {

        }
    }
}
