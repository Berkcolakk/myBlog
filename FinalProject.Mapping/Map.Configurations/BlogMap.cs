using FinalProject.Core.Core.Map;
using FinalProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Mapping.Map.Configurations
{
   public class BlogMap:CoreMap<Blog>
    {
        public BlogMap()
        {
            ToTable("dbo.Blog");

            Property(x => x.Header).IsOptional();

            Property(x => x.Homepage).IsOptional();

            Property(x => x.Description).IsOptional();

            Property(x => x.Content).IsOptional();

            Property(x => x.Image).IsOptional();

            Property(x => x.Confirmation).IsOptional();



            HasRequired(x => x.Category)
                .WithMany(x => x.Bloglar)
                .HasForeignKey(x => x.CategoryID)
                .WillCascadeOnDelete(false);


            HasMany(x => x.BlogComments)
                .WithRequired(x => x.Blogs)
                .HasForeignKey(x => x.BlogID)
                .WillCascadeOnDelete(false);

            HasMany(x => x.Likes)
                .WithRequired(x => x.Blogs)
                .HasForeignKey(x => x.BlogID)
                .WillCascadeOnDelete(false);
        }
    }
}
