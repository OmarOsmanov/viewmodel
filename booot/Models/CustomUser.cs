using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace booot.Models
{
    public class CustomUser:IdentityUser
    {
     

       
        [MaxLength(250)]
        public string Name { get; set; }
        [MaxLength(250)]
        
        public List<Product> Products { get; set; }

    }
}
