using PythonSucks.Repository;
using System;

namespace PythonSucks.Model
{
    public class Vote : BaseEntity
    {
        public Guid HaterId { get; set; }

        public virtual Hater Hater { get; set; }

        public Guid ReasonId { get; set; }

        public virtual Reason Reason { get; set; }
    }
}
