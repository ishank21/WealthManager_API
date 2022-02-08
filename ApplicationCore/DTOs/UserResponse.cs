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
    [Keyless]
    public class UserResponse
    {
        [NotMapped]
        public int ?Id { get; set; }
        public string userName { get; set; }
        public string ?UserId { get; set; }
        public string ?ClientType { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Role { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public bool isActive { get; set; }
        [Key]
        public string? AgentId { get; set; }

    }
}
