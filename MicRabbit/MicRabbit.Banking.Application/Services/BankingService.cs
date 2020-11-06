using MicRabbit.Banking.Application.Interfaces;
using MicRabbit.Banking.Application.Models;
using MicRabbit.Banking.Domain.Commands;
using MicRabbit.Banking.Domain.Interfaces;
using MicRabbit.Banking.Domain.Models;
using MicRabbit.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicRabbit.Banking.Application.Services
{
    public class BankingService : IBankingService
    {
        private readonly IBankingRepository _accountRepository;
        private readonly IEventBus _bus;

        public BankingService(IBankingRepository accountRepository, IEventBus bus)
        {
            _accountRepository = accountRepository;
            _bus = bus;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }

        public void Transfer(AccountTransfer accountTransfer)
        {
            var createTransferCommand = new CreateTransferCommand(
                    accountTransfer.FromAccount,
                    accountTransfer.ToAccount,
                    accountTransfer.TransferAmount
                );

            _bus.SendCommand(createTransferCommand);
        }
    }
}
