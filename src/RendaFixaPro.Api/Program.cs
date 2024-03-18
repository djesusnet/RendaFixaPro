using FluentValidation.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddValidatorsFromAssemblyContaining<InvestmentDataValidator>();
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", 
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/investments/calculate/cbd", (decimal initialValue, int months, IValidator<InvestmentDataDto> validator, InvestmentCalculatorFactory calculatorFactory) =>
{
    try
    {
        
        var investmentData = new InvestmentDataDto
        {
            InitialValue = initialValue,
            Months = months
        };

        var validationResult = validator.Validate(investmentData);

        if (!validationResult.IsValid)
            return Results.BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));

        var calculator = calculatorFactory.CreateCalculator(InvestmentType.Cdb);
        var finalValue = calculator.CalculateFinalValue(investmentData);
        return Results.Ok(new { FinalValue = finalValue });
    }
    catch (NotImplementedException)
    {
        return Results.Problem("The investment type is not supported yet.");
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
}).WithName("CalculateInvestment").WithOpenApi();

app.UseCors("AllowSpecificOrigin");

app.Run();