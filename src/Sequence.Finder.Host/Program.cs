using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Sequence.Finder.Host.Injection;

var builder = 
    WebApplication
        .CreateBuilder(args);

var services =
    builder
        .Services;

services
    .AddControllers();

services
    .AddPlatformServices();

var app = 
    builder
        .Build();

app
    .UseAuthorization();

app
    .MapControllers();

app
    .Run();
