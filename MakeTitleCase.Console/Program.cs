using Microsoft.Extensions.Hosting;
using System.Text.Json;
using MakeTitleCase.Core;
using MakeTitleCase.Core.Configuration;

partial class Program
    : IHostedService
{
    private readonly TitleCaseMaker _titleCaseMaker;

    public Program(TitleCaseMaker titleCaseMaker)
    {
        _titleCaseMaker = titleCaseMaker;
    }

    Task IHostedService.StartAsync(CancellationToken cancellationToken)
    {
        List<string> output = new();
        while (true)
        {
            Console.Write("Line (ENTER to exit): ");
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                break;
            }
            output.Add(_titleCaseMaker.MakeTitleCase(input));
        }

        foreach (string s in output)
        {
            Console.WriteLine(s);
        }

        Environment.Exit(0);
        return Task.CompletedTask;
    }

    Task IHostedService.StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
