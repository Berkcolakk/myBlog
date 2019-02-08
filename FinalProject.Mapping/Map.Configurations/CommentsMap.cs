using FinalProject.Core.Core.Map;
using FinalProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Mapping.Map.Configurations
{
   public class CommentsMap:CoreMap<Comment>
    {
        public CommentsMap()
        {
            ToTable("dbo.Comments");

            Property(x => x.Body).IsOptional();

            Property(x => x.AppUsersID).IsOptional();

            Property(x => x.BlogID).IsOptional();


            HasRequired(x => x.AppUsers)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.AppUsersID)
                .WillCascadeOnDelete(false);

            HasMany(x => x.BlogComments)
                .WithRequired(x => x.Comments)
                .HasForeignKey(x => x.CommentID)
                .WillCascadeOnDelete(false);


        }
    }
}
