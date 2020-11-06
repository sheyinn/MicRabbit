using MicRabbit.Banking.Application.Models;
using MicRabbit.Banking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicRabbit.Banking.Application.Interfaces
{
    public interface IBankingService
    {
        IEnumerable<Account> GetAccounts();
        void Transfer(AccountTransfer accountTransfer);
    }
}
