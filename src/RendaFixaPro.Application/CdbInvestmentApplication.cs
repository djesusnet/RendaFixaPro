using RendaFixaPro.Application.Dtos;

namespace RendaFixaPro.Application;

public class CdbInvestmentApplication : IInvestmentApplication
{
    private const decimal Cdi = 0.009m; // 0.9%
    private const decimal Tb = 1.08m; // 108%

    public (decimal GrossValue, decimal NetValue) CalculateFinalValue(InvestmentDataDto investmentDataDto)
    {
        var finalValue = investmentDataDto.InitialValue;
        for (var i = 0; i < investmentDataDto.Months; i++)
        {
            finalValue *= 1 + (Cdi * Tb);
        }

        var taxRate = GetTaxRate(investmentDataDto.Months);
        var profit = finalValue - investmentDataDto.InitialValue;
        var tax = profit * taxRate;
        var netValue = finalValue - tax;

        return (finalValue, netValue);
    }

    private static decimal GetTaxRate(int months)
    {
        return months switch
        {
            <= 6 => 0.225m, // 22.5%
            <= 12 => 0.20m, // 20%
            <= 24 => 0.175m, // 17.5%
            _ => 0.15m // 15%
        };
    }
}
