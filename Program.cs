using Microsoft.Extensions.DependencyInjection;
using W10_assignment_template.Data;
using W10_assignment_template.Services;

namespace W10_assignment_template;

public static class Program
{
    private static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();
        Startup.ConfigureServices(serviceCollection);

        var serviceProvider = serviceCollection.BuildServiceProvider();

        var gameEngine = serviceProvider.GetService<GameEngine>();

        gameEngine?.Run();
    }
}