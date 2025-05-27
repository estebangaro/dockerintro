using DotNet.Docker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Logging.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning);

builder.Services.AddDbContext<Models.Data.PruebasContext>(options =>
    options.UseSqlServer("Data Source=localhost,1433;Initial Catalog=pruebas;User Id=sa;Password=M45T3R3D104#;TrustServerCertificate=True"));
builder.Services.AddScoped<Entities.Interfaces.ICounterManager, Models.CounterManager>();
builder.Services.AddScoped<Entities.Interfaces.ICounterProgram, CounterProgram>();


using IHost host = builder.Build();

await Run(host.Services, args);

static async Task Run(IServiceProvider hostProvider, string[] args)
{
    using IServiceScope serviceScope = hostProvider.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;
    var counterProgram = provider.GetRequiredService<Entities.Interfaces.ICounterProgram>();

    if (args != null && args.Length > 0)
    {
        Console.WriteLine($"Argumentos recibidos: {string.Join(", ", args)}");
    }
    else
    {
        Console.WriteLine("No se recibieron argumentos, se usará el valor por defecto.");
    }

    var tag = "defaultTag"; // Default tag, can be changed as needed    
    if (args != null && args.Length > 0)
    {
        tag = args[0]; // Use the first argument as the tag
    }

    await counterProgram.Run(tag, args);
}