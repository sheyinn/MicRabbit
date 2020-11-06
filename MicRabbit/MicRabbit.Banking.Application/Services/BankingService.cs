using MicRabbit.Banking.Application.Interfaces;
using MicRabbit.Banking.Domain.Interfaces;
using MicRabbit.Banking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicRabbit.Banking.Application.Services
{
    public class BankingService : IBankingService
    {
        private readonly IBankingRepository _accountRepository;

        public BankingService(IBankingRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }
    }
}
