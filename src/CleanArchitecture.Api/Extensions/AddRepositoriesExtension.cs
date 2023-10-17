using Domain.IRepository;
using Domain;
using Persistence;

namespace Presentation.Extensions
{
    public static class AddRepositoriesExtension
    {
        public static void AddRepositories(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            builder.Services.AddScoped<ICurrencySettingRepository, CurrencySettingRepository>();
            builder.Services.AddScoped<IGatewayRepository, GatewayRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
            builder.Services.AddScoped<IAccountRepository, AccountRepository>();
        }
    }
}
