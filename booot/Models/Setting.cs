using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace booot.Models
{
    public class Setting
    {

        [Key]

        public int Id { get; set; }
        [MaxLength(250)]
        public string Logo { get; set; }
        [MaxLength(500)]
        public string Tittle { get; set; }
        [MaxLength(1000)]
        public string Subtitle { get; set; }


    }
}
