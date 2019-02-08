using FinalProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Dto.DTO.CommentDTO
{
   public class CommentList
    {
        public Guid ID { get; set; }
        public string Comments { get; set; }
        public Guid BlogID { get; set; }
        public Guid AppUsersID { get; set; }
        public string AppUserName { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
