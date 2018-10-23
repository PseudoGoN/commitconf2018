using PythonSucks.Repository;
using System;
using System.Collections.Generic;

namespace PythonSucks.Model
{
    public class Reason : BaseEntity
    {

        public Guid HaterId { get; set; }

        public virtual Hater Hater { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int RageLevel { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
