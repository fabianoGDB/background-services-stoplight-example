using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackgroundServices.Api.Services
{
    public interface IBankOperationsService
    {
        Task ExecuteAutomaticSettlementAsync();

        Task GenerateBankSlipAsync();
    }
}