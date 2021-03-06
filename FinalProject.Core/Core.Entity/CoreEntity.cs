﻿using FinalProject.Core.Core.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Core.Entity
{
   public class CoreEntity: IEntity<Guid>
    {

        public Guid ID { get; set; }
        public Status Status { get; set; }


        //Eklenmeler
        public string CreatedComputerName { get; set; }
        public string CreatedIp { get; set; }
       
        public DateTime CreatedDate { get; set; }
        public string CreatedADUserName { get; set; }

        //Güncellemeler
        public string ModifiedComputerName { get; set; }
        public string ModifiedIp { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedADUserName { get; set; }
    }
}
