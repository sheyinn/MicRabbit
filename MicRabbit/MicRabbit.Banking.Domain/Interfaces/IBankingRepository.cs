using MicRabbit.Banking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicRabbit.Banking.Domain.Interfaces
{
    public interface IBankingRepository
    {
        IEnumerable<Account> GetAccounts();
    }
}
