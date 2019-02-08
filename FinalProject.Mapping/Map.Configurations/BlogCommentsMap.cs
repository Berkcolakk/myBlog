using FinalProject.Core.Core.Map;
using FinalProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Mapping.Map.Configurations
{
    public class BlogCommentsMap:CoreMap<BlogComment>
    {
        public BlogCommentsMap()
        {
            Property(x => x.CommentID).IsOptional();

            Property(x => x.BlogID).IsOptional();

            HasRequired(x => x.Blogs)
                .WithMany(x => x.BlogComments)
                .HasForeignKey(x => x.BlogID)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Comments)
                .WithMany(x => x.BlogComments)
                .HasForeignKey(x => x.CommentID)
                .WillCascadeOnDelete(false);
        }
    }
}
