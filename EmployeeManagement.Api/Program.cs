using EmployeeManagement.Domain.Handlers;
using EmployeeManagement.Domain.Services;

namespace EmployeeManagement.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddScoped<INextEmployeeNumberGenerator, NextEmployeeNumberGenerator>();
            builder.Services.AddScoped<CreateEmployeeHandler>();
            builder.Services.AddScoped<UpdateEmployeeHandler>();


            var app = builder.Build();

            app.MapControllers();

            app.Run();
        }
    }
}
