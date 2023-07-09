using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models.DTO
{
    
        public class Doctor_Password_DTO
        {
            public int Id { get; set; }
            public string Password { get; set; }
            public string HashedPassword { get; set; }
        }
    
}
