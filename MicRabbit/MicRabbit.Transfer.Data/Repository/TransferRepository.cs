using MicRabbit.Transfer.Data.Context;
using MicRabbit.Transfer.Domain.Interfaces;
using MicRabbit.Transfer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicRabbit.Transfer.Data.Repository
{
    public class TransferRepository : ITransferRepository
    {
        private TransferDbContext _ctx;

        public TransferRepository(TransferDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Add(TransferLog transferLog)
        {
            _ctx.TransferLogs.Add(transferLog);
            _ctx.SaveChanges();
        }

        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _ctx.TransferLogs;
        }
    }
}
