using System;
using System.Collections.Generic;

namespace Results.Operations.Data.Entities
{
    public class Exam : IEntity
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Data { get; set; }
        
    }
}