

namespace RendaFixaPro.Tests.Application;

public class CdbInvestmentApplicationTests
{
   
    private readonly CdbInvestmentApplication _application = new CdbInvestmentApplication();

    [Theory]
    [InlineData(1000, 3, 1029.444353530048000, 1022.819373985787200000)] 
    [InlineData(1000, 6, 1059.7556770148984501188388823, 1046.3106496865462988421001338)] 
    [InlineData(1000, 12, 1123.0820949653057631841036240, 1098.4656759722446105472828992)] 
    [InlineData(1000, 24, 1261.3133920316600726659576277, 1215.5835484261195599494150429)] 
    [InlineData(1000, 30, 1336.6840277004699403973882803, 1286.1814235453994493377800383)] 
    public void CalculateFinalValue_ShouldCalculateCorrectly(decimal initialValue, int months, decimal expectedGrossValue, decimal expectedNetValue)
    {
        // Arrange
        var investmentDataDto = new InvestmentDataDto { InitialValue = initialValue, Months = months };

        // Act
        var (GrossValue, NetValue) = _application.CalculateFinalValue(investmentDataDto);

        // Assert
        Assert.Equal(expectedGrossValue, GrossValue, 2);
        Assert.Equal(expectedNetValue, NetValue, 2);
    }
}