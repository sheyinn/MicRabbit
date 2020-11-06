using MicRabbit.Banking.Data.Context;
using MicRabbit.Banking.Domain.Interfaces;
using MicRabbit.Banking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicRabbit.Banking.Data.Repository
{
    public class BankingRepository : IBankingRepository
    {
        private BankingDbContext _ctx;

        public BankingRepository(BankingDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _ctx.Accounts;
        }
    }
}
