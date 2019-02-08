using FinalProject.Core.Core.Entity.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Dto.DTO.AppUserDTO
{
   public class AppUserRoles
    {
        [DisplayName("Roller")]
        public Role Roles { get; set; }
        public Guid ID { get; set; }
    }
}
