using FinalProject.Core.Core.Map;
using FinalProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Mapping.Map.Configurations
{
   public class CategoryMap:CoreMap<Category>
    {
        public CategoryMap()
        {
            ToTable("dbo.Category");

            Property(x => x.Name).HasMaxLength(70).IsOptional();

            Property(x => x.Description).HasMaxLength(300).IsOptional();

            HasMany(x => x.Bloglar)
                .WithRequired(x => x.Category)
                .HasForeignKey(x => x.CategoryID)
                .WillCascadeOnDelete(false);


        }
    }
}
