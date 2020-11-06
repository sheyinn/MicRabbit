using MicRabbit.Banking.Application.Interfaces;
using MicRabbit.Banking.Application.Services;
using MicRabbit.Banking.Data.Context;
using MicRabbit.Banking.Data.Repository;
using MicRabbit.Banking.Domain.Interfaces;
using MicRabbit.Domain.Core.Bus;
using MicRabbit.Infra.Bus;
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
            services.AddTransient<IEventBus, RabbitMQBus>();

            // Application Services
            services.AddTransient<IBankingService, BankingService>();

            // Data
            services.AddTransient<IBankingRepository, BankingRepository>();
            services.AddTransient<BankingDbContext>();
        }
    }
}
