namespace RendaFixaPro.Infrastructure.CrossCutting.Ioc;

public static class ServicesCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection servicesCollection)
    {
        servicesCollection.TryAddTransient<CdbInvestmentApplication>();
        servicesCollection.TryAddTransient<InvestmentCalculatorFactory>();
            
        return servicesCollection;
    }
}