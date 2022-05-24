using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MakeTitleCase.Core;
using MakeTitleCase.Core.Configuration;

await Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddSingleton(hostContext.Configuration.Get<Config>());
        services.AddSingleton<TitleCaseMaker>();
        services.AddHostedService<Program>();
    })
    .Build()
    .RunAsync();
