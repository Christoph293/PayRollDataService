using PayrollDataService.Business;
using PayrollDataService.Interface;
using PayrollDataService.Repository;
using PayrollDataService.RepositoryMock;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependencies
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepositoryMock>();
builder.Services.AddScoped<ILocationRepository, LocationRepositoryMock>();
builder.Services.AddScoped<IBusinessAssociateRepository, BusinessAssociateRepositoryMock>();
builder.Services.AddScoped<IBusinessAssociateService, BusinessAssociateService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IRepositoryMockBase, RepositoryMockBase>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
