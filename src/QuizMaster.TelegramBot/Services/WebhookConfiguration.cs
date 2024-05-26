using QuizMaster.TelegramBot.Models;
using Telegram.Bot;

namespace QuizMaster.TelegramBot.Services;

public class WebhookConfiguration(ILogger<WebhookConfiguration> logger,
                            IServiceProvider serviceProvider,
                            IConfiguration configuration) : IHostedService
{
    private readonly BotConfiguration botConfiguration = configuration
        .GetSection("BotConfiguration")
        .Get<BotConfiguration>();

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = serviceProvider.CreateScope();
        var botClient = scope.ServiceProvider.GetRequiredService<ITelegramBotClient>();
        var webhookAdddress = $@"{botConfiguration.HostAddress}/bot/{botConfiguration.Token}";

        logger.LogInformation("Setting webhook");

        await botClient.SendTextMessageAsync(chatId: 1634251726,
                                             text: "Webhook is setting up",
                                             cancellationToken: cancellationToken);

        await botClient.SetWebhookAsync(url: webhookAdddress,
                                        allowedUpdates: [],
                                        cancellationToken: cancellationToken);
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        using var scope = serviceProvider.CreateScope();
        var botClient = scope.ServiceProvider.GetRequiredService<ITelegramBotClient>();

        logger.LogInformation("Webhook is removing");

        await botClient.SendTextMessageAsync(chatId: 1634251726,
                                             text: "Bot is slepping",
                                             cancellationToken: cancellationToken);
    }
}
