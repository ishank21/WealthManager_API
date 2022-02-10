using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTOs
{
    public class UserAuthRole
    {
        //[Key]
        public int Isvalid { get; set; }
        public string roletype { get; set; }
    }
}
