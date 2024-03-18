using RendaFixaPro.Application.Dtos;

namespace RendaFixaPro.Application.Interfaces;

public interface IInvestmentApplication
{
    (decimal GrossValue, decimal NetValue) CalculateFinalValue(InvestmentDataDto investmentDataDto);
}