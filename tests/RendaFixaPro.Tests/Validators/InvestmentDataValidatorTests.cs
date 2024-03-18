namespace RendaFixaPro.Tests.Validators;

public class InvestmentDataValidatorTests
{
    private readonly InvestmentDataValidator _validator;

    public InvestmentDataValidatorTests()
    {
        var mocker = new AutoMoqer();
        _validator = mocker.Create<InvestmentDataValidator>();
    }

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
    [InlineData(0)]
    [InlineData(13)]
    public void Months_OutOfRange_ShouldHaveValidationError(int months)
    {
        var model = new InvestmentDataDto { Months = months };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(investmentData => investmentData.Months);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(12)]
    public void Months_WithinRange_ShouldNotHaveValidationError(int months)
    {
        var model = new InvestmentDataDto { Months = months };
        var result = _validator.TestValidate(model);
        result.ShouldNotHaveValidationErrorFor(investmentData => investmentData.Months);
    }
}