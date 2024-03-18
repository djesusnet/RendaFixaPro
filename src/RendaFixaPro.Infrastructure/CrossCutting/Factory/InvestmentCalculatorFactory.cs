namespace RendaFixaPro.Infrastructure.CrossCutting.Factory;

public class InvestmentCalculatorFactory(IServiceProvider serviceProvider)
{
    public IInvestmentApplication CreateCalculator(InvestmentType investmentType)
    {
        return investmentType switch
        {
            InvestmentType.Cdb => serviceProvider.GetRequiredService<CdbInvestmentApplication>(),
            InvestmentType.Lci => throw new NotImplementedException(),
            InvestmentType.Lc => throw new NotImplementedException(),
            _ => throw new ArgumentException("Invalid investment type.")
        };
    }
}