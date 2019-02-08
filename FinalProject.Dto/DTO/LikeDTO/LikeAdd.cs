using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Dto.DTO.LikeDTO
{
   public class LikeAdd
    {
        public Guid ID { get; set; }

        public Guid AppUserID { get; set; }
    
        public Guid BlogID { get; set; }

        public string userMessage { get; set; }

        public int Likes { get; set; }

        public bool isSuccess { get; set; }
    }
}
