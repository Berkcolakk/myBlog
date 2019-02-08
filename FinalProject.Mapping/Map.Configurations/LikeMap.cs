using FinalProject.Core.Core.Map;
using FinalProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Mapping.Map.Configurations
{
   public class LikeMap:CoreMap<Like>
    {
        public LikeMap()
        {
            ToTable("dbo.Like");

            Property(x => x.BlogID).IsOptional();

            Property(x => x.AppUserID).IsOptional();

            HasRequired(x => x.AppUsers)
              .WithMany(x => x.Likes)
              .HasForeignKey(x => x.AppUserID)
              .WillCascadeOnDelete(false);

            HasRequired(x => x.Blogs)
                .WithMany(x => x.Likes)
                .HasForeignKey(x => x.BlogID)
                .WillCascadeOnDelete(false);
            
        }
    }
}
