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
    public class ClientAccountDetails
    {
        //[Key]
        public int Id { get; set; }
        public string AccountId { get; set; }
        public string ClientId { get; set; }
        public string CustodianId { get; set; }
        public string CustodianName { get; set; }
        public string RegisteredName { get; set; }
        public string CustodianAccountNumber { get; set; }
        public string MarketValue { get; set; }
        public string ProgramId { get; set; }
        public string ProgramName { get; set; }
        public bool isClosed { get; set; }
    }
}
