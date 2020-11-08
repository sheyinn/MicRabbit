using MediatR;
using MicRabbit.Banking.Application.Interfaces;
using MicRabbit.Banking.Application.Services;
using MicRabbit.Banking.Data.Context;
using MicRabbit.Banking.Data.Repository;
using MicRabbit.Banking.Domain.CommandHandlers;
using MicRabbit.Banking.Domain.Commands;
using MicRabbit.Banking.Domain.Interfaces;
using MicRabbit.Domain.Core.Bus;
using MicRabbit.Infra.Bus;
using MicRabbit.Transfer.Application.Interfaces;
using MicRabbit.Transfer.Application.Services;
using MicRabbit.Transfer.Data.Context;
using MicRabbit.Transfer.Data.Repository;
using MicRabbit.Transfer.Domain.EventHandlers;
using MicRabbit.Transfer.Domain.Events;
using MicRabbit.Transfer.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicRabbit.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus
            services.AddSingleton<IEventBus, RabbitMQBus>(sp => 
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);
            });

            // Subscriptions
            services.AddTransient<TransferEventHandler>();

            // Domain Events
            services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferEventHandler>();  

            // Domain Banking Commands
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            // Application Services
            services.AddTransient<IBankingService, BankingService>();
            services.AddTransient<ITransferService, TransferService>();

            // Data
            services.AddTransient<IBankingRepository, BankingRepository>();
            services.AddTransient<ITransferRepository, TransferRepository>();
            services.AddTransient<BankingDbContext>();
            services.AddTransient<TransferDbContext>();
        }
    }
}
