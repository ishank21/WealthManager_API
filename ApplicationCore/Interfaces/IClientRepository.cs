﻿using ApplicationCore.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IClientRepository
    {
        Task<List<ClientResponse>> GetClientDetailsForAgent(string agentId);
        Task<List<ClientAccountDetails>> GetAccountDetailsByClientId(string clientId);
    }
}