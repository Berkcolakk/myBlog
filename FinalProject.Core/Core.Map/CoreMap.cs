using FinalProject.Core.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Core.Map
{
    public class CoreMap<T> : EntityTypeConfiguration<T> where T : CoreEntity
    {
        public CoreMap()
        {
            Property(x => x.ID).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnOrder(1);
            Property(x => x.Status).HasColumnName("Status").IsOptional();

            Property(x => x.CreatedDate).HasColumnType("datetime2").IsOptional();
            Property(x => x.CreatedADUserName).IsOptional();
          
            Property(x => x.CreatedComputerName).IsOptional();
            Property(x => x.CreatedIp).IsOptional();

            Property(x => x.ModifiedDate).HasColumnType("datetime2").IsOptional();
            Property(x => x.ModifiedADUserName).IsOptional();
         
            Property(x => x.ModifiedComputerName).IsOptional();
            Property(x => x.ModifiedIp).IsOptional();
        }
    }
}
