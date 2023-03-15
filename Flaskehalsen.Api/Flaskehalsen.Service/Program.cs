using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using Flaskehalsen.Data;
using Flaskehalsen.Service.Configuration;
using Flaskehalsen.Service.GraphQL;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddAzureKeyVault(
    new Uri($"https://{builder.Configuration["KeyVaultName"]}.vault.azure.net/"),
    new DefaultAzureCredential());

var dbOptions = builder.Configuration.GetSection("FlaskeContext");

builder.Services.AddDbContext<FlaskeContext>(cfg => { cfg.UseSqlServer(dbOptions["ConnectionString"]); });
builder.Services.AddMediatR(options => { options.RegisterServicesFromAssemblyContaining<Program>(); });
builder.Services.AddMapster();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();

var app = builder.Build();

app.MapGraphQL();
app.Run();