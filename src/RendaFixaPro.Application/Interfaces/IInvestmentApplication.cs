using RendaFixaPro.Application.Dtos;

namespace RendaFixaPro.Application.Interfaces;

public interface IInvestmentApplication
{
    decimal CalculateFinalValue(InvestmentDataDto investmentDataDto);
}