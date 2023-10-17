using Application.Command.CoommandHandler;
using Application.Command.CoommandHandler.Interfaces;
using Application.Query.QueryService.Account;
using Application.Query.QueryService.Currency;
using Application.Query.QueryService.CurrencySetting;
using Application.Query.QueryService.Gateway;
using Application.Query.QueryService.Interfaces;
using Application.Query.QueryService.Members;
using Application.Query.QueryService.Transaction;

namespace Presentation.Extensions
{
    public static class AddServicesExtension
    {
        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ICurrencyCommandHandler, CurrencyCommandHandler>();
            builder.Services.AddScoped<ICurrencyQueryService, CurrencyQueryService>();
            builder.Services.AddScoped<ICurrencySettingQueryService, CurrencySettingQueryService>();
            builder.Services.AddScoped<ICurrencySettingCommandHandler, CurrencySettingCommandHandler>();
            builder.Services.AddScoped<IGatewayQueryService, GatewayQueryService>();
            builder.Services.AddScoped<IGatewayCommandHandler, GatewayCommandHandler>();
            builder.Services.AddScoped<IUserQueryService, UserQueryService>();
            builder.Services.AddScoped<IUserCommandHandler, UserCommandHandler>();
            builder.Services.AddScoped<ITransactionQueryService, TransactionQueryService>();
            builder.Services.AddScoped<ITransactionCommandHandler, TransactionCommandHandler>();
            builder.Services.AddScoped<IAccountQueryService, AccountQueryService>();
            builder.Services.AddScoped<IAccountCommandHandler, AccountCommandHandler>();
        }
    }
}
