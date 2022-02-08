using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTOs
{
    [Keyless]
    public class UserAuthRole
    {
        public int isvalid { get; set; }
        public string roletype { get; set; }
    }
}
