﻿using System;

namespace DataLayer.Model
{
    public class BaseEntity
    {
        public Int64 Id { get; set; }
        public DateTime AddedDate { get;set; }
        public DateTime ModifiedDate { get; set; }
        
    }
}
