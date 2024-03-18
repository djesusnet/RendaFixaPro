namespace RendaFixaPro.Tests.Validators;

public class InvestmentDataValidatorTests
{
    private readonly InvestmentDataValidator _validator = new InvestmentDataValidator();

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void InitialValue_LessThanOrEqualToZero_ShouldHaveValidationError(decimal initialValue)
    {
        var model = new InvestmentDataDto { InitialValue = initialValue };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(investmentData => investmentData.InitialValue);
    }

    [Fact]
    public void InitialValue_GreaterThanZero_ShouldNotHaveValidationError()
    {
        var model = new InvestmentDataDto { InitialValue = 100 };
        var result = _validator.TestValidate(model);
        result.ShouldNotHaveValidationErrorFor(investmentData => investmentData.InitialValue);
    }

    [Theory]
    [InlineData(1)] // 1 agora é considerado fora do intervalo válido.
    [InlineData(0)]
    [InlineData(-1)]
    public void Months_LessThanOrEqualToOne_ShouldHaveValidationError(int months)
    {
        var model = new InvestmentDataDto { Months = months };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(investmentData => investmentData.Months)
              .WithErrorMessage("Months must be greater than 1");
    }

    [Theory]
    [InlineData(2)]
    [InlineData(12)]
    public void Months_GreaterThanOne_ShouldNotHaveValidationError(int months)
    {
        var model = new InvestmentDataDto { Months = months };
        var result = _validator.TestValidate(model);
        result.ShouldNotHaveValidationErrorFor(investmentData => investmentData.Months);
    }
}
