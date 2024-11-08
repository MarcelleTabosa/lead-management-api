using LeadManagement.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddARepository();
builder.Services.AddContext(builder.Configuration);

builder.Services.AddCorsService();

builder.Services.AddControllers();
builder.Services.AddCustomSwagger();

builder.Services.AddFluentValidation();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowAllOrigins");

app.UseAuthorization();

app.UseCustomSwagger();

app.MapControllers();

app.Run();