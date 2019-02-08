using FinalProject.Core.Core.Map;
using FinalProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Mapping.Map.Configurations
{
   public class AppUserMap: CoreMap<AppUser>
    {
        public AppUserMap()
        {
            ToTable("dbo.Users");

            Property(x => x.UserName).HasMaxLength(50).IsOptional();

            Property(x => x.Name).HasMaxLength(50).IsOptional();

            Property(x => x.LastName).HasMaxLength(50).IsOptional();

            Property(x => x.Password).HasMaxLength(100).IsOptional();

            Property(x => x.Address).HasMaxLength(400).IsOptional();

            Property(x => x.PhoneNumber).HasMaxLength(100).IsOptional();

            Property(x => x.ImagePath).IsOptional();

            Property(x => x.Email).HasMaxLength(150).IsOptional();


            Property(x => x.CommentsID).IsOptional();

            Property(x => x.LikeID).IsOptional();

            Property(x => x.Birthdate).HasColumnType("datetime2").IsOptional();

            Property(x => x.LastLogin).HasColumnType("datetime2").IsOptional();

            HasMany(x => x.Comments)
                .WithRequired(x => x.AppUsers)
                .HasForeignKey(x => x.AppUsersID)
                .WillCascadeOnDelete(false);
           
            HasMany(x => x.Likes)
                .WithRequired(x => x.AppUsers)
                .HasForeignKey(x => x.AppUserID)
                .WillCascadeOnDelete(false);
        }
    }
}
