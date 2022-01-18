using booot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace booot.ViewModels
{
    public class VmHome
    {
        public Setting setting { get; set; }
        public List<Product> products { get; set; }
    }
}
