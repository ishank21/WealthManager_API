using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTOs
{
    [Keyless]
    public class AgentResponse
    {
        [NotMapped]
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName{ get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string AgentId { get; set; }
    }
}
