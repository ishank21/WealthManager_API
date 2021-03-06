using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entitites
{
    public class ClientDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public ClientType ClientType { get; set; }
        public string PhoneNo { get; set; }
        public string AgentId { get; set; }
    }
    public enum ClientType
    {
        Corporate = 1,
        DonorAdvisedFund = 2,
        JointFamily = 3,
        Personal = 4
    }
}
