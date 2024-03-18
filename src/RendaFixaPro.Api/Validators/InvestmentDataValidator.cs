namespace RendaFixaPro.Api.Validators;

public class InvestmentDataValidator : AbstractValidator<InvestmentDataDto>
{
    public InvestmentDataValidator()
    {
        RuleFor(investmentData => investmentData.InitialValue)
            .NotEmpty().WithMessage("InitialValue is required")
            .GreaterThan(0).WithMessage("InitialValue must be greater than 0");

        RuleFor(investmentData => investmentData.Months)
            .NotEmpty().WithMessage("InitialValue is required")
            .GreaterThan(1).WithMessage("Months must be greater than 1");


    }
}