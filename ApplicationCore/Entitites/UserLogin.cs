using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entitites
{
    public class UserLogin
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string userName { get; set; }
        public string guidId { get; set; }
        public int RoleId { get; set; }
        public bool hasActiveRole { get; set; }
        public string UserId { get; set; }
    }
}
