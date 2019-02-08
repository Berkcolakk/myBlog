using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Dto.DTO.CommentDTO
{
   public class CommentAdd
    {
        public Guid ID { get; set; }
        public string Comments { get; set; }
        public Guid BlogID { get; set; }
        public Guid UserID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
