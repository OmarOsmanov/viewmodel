using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace booot.ViewModels
{
    public class VmRegister
    {

        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(30)]

        public string Phone { get; set; }
        [MaxLength(50)]

        public string Email { get; set; }
        [MaxLength(30)]

        public string Password { get; set; }
    }
}
