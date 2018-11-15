using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PythonSucks.ViewModels
{
    public class Reason
    {
        public Guid? Id { get; set; }

        [Required]
        public Guid HaterId { get; set; }

        public Hater Hater { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(600)]
        public string Description { get; set; }

        [Required]
        [Range(0,5)]
        public int RageLevel { get; set; }

        public int Votes { get; set; }  
    }
}
