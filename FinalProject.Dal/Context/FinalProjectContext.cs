using FinalProject.Core.Core.Entity;
using FinalProject.Mapping.Map.Configurations;
using FinalProject.Model.Entities;
using FinalProject.Utility;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Dal.Context
{
    public class FinalProjectContext:DbContext
    {
        public FinalProjectContext() /*: base("FinalProjectContext")*/
        {
            Database.Connection.ConnectionString = @"server=.;database=FinalProject;Integrated Security = True";
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<BlogComment> BlogComments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BlogMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new LikeMap());
            modelBuilder.Configurations.Add(new AppUserMap());
            modelBuilder.Configurations.Add(new CommentsMap());
            modelBuilder.Configurations.Add(new BlogCommentsMap());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {

            var Entries = ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            string identity = WindowsIdentity.GetCurrent().Name;
            string computerName = Environment.MachineName;
            DateTime date = DateTime.Now;
            string ip = RemoteIP.IpAddress;

            foreach (var item in Entries)
            {
                //CoreEntity'e Cast ediyoruz.
                CoreEntity entity = item.Entity as CoreEntity;
                AppUser User = item.Entity as AppUser;
                if (item != null)
                {
                    if (item.State == EntityState.Added)
                    {
                        entity.Status = Core.Core.Entity.Enum.Status.Active;
                        entity.CreatedADUserName = identity;
                        entity.CreatedComputerName = computerName;
                        entity.CreatedDate = date;
                        entity.CreatedIp = ip;
                    }
                    else if (item.State == EntityState.Modified)
                    {
                        entity.ModifiedADUserName = identity;
                        entity.ModifiedComputerName = computerName;
                        entity.ModifiedDate = date;
                        entity.ModifiedIp = ip;
                    }
                }
            }
            return base.SaveChanges();
        }
    }
}
