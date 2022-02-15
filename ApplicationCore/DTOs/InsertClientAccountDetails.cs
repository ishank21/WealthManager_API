using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationCore.DTOs
{
    public class InsertClientAccountDetails
    {
        [Required]
        public string AccountId { get; set; }
        [Required]
        public string CustodainId { get; set; }
        [Required]
        public string CustodianName { get; set; }
        [Required]
        public string RegisteredName { get; set; }
        [Required]
        public string CustodianAccountNumber { get; set; }
        [Required]
        public string MarketValue { get; set; }
        [Required]
        public string ProgramId { get; set; }
        [Required]
        public string ProgramName { get; set; }
        [Required]
        public string ClientId { get; set; }
        [Required]
        public bool IsClosed { get; set; }

    }
}
