using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalRepository.models
{
    public class User
    {
        [Key]
        public string Email { get; set; }  
        [Column]
        public string Password { get; set; }

       
    }
}
