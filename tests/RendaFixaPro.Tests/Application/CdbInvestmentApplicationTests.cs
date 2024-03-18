

namespace RendaFixaPro.Tests.Application;

public class CdbInvestmentApplicationTests
{
    [Theory]
    [InlineData(1000, 3, 1022.819373985787200000)] 
    [InlineData(1000, 6, 1046.3106496865462988421001338)] 
    [InlineData(1000, 7, 1056.0452017563866104431951970)] 
    [InlineData(1000, 12, 1098.46567597224461054728289927)] 
    [InlineData(1000, 13, 1110.5487236659040415418588167)] 
    [InlineData(1000, 24, 1215.5835484261195599494150429)] 
    [InlineData(1000, 25, 1232.5373544718766372864301254)] 
    public void CalculateFinalValue_ShouldCalculateCorrectly(decimal initialValue, int months, decimal expectedFinalValue)
    {
        // Arrange
        var investmentDataDto = new InvestmentDataDto { InitialValue = initialValue, Months = months };
        var application = new CdbInvestmentApplication();

        // Act
        var finalValue = application.CalculateFinalValue(investmentDataDto);

        // Assert
        const decimal tolerance = 0.01m; // Uma pequena tolerância para arredondamento
        Assert.True(Math.Abs(expectedFinalValue - finalValue) < tolerance);
    }
}