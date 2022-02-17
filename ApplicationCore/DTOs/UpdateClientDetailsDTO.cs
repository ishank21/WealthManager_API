﻿using ApplicationCore.Entitites;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.DTOs
{
    public class UpdateClientDetailsDTO
    {
        public string ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public ClientType ClientType { get; set; }
        public string PhoneNo { get; set; }
        public string AgentId { get; set; }
    }
}
