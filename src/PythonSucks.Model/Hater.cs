using PythonSucks.Repository;
using System;
using System.Collections.Generic;

namespace PythonSucks.Model
{
    public class Hater : BaseEntity
    {
        
        public string Name { get; set; }

        public string Surname { get; set; }

        public string ChildTrauma { get; set; }

        public virtual ICollection<Reason> Reasons { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
