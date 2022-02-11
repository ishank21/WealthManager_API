using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTOs
{
    public class ClientResponse
    {
        //[Key]
        public int Id { get; set; }
        public string userName { get; set; }
        public string UserId { get; set; }
        public int ClientType { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string RoleType { get; set; }
        public bool hasActiveRole { get; set; }
        public string AgentId { get; set; }
    }
}
