using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PythonSucks.ViewModels
{
    public class Hater
    {
        public Guid? Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Surname { get; set; }
        [Required]
        public string ChildTrauma { get; set; }
    }
}
