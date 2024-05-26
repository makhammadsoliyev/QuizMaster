using Npgsql.PostgresTypes;
using QuizMaster.Service.Services.Users;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace QuizMaster.TelegramBot.Services;

public class HandleUpdateService(ILogger<HandleUpdateService> logger,
                                 ITelegramBotClient botClient,
                                 IUserService userService)
{
    public async Task EchoAsync(Update update)
    {
        var handler = update.Type switch
        {
            UpdateType.Message => BotOnMessageRecieved(update.Message),
            UpdateType.CallbackQuery => BotOnCollBackQueryrecieved(update.CallbackQuery),
            _ => UnknownUpdateTypeHandler(update)
        };

        try
        {
            await handler;
        }
        catch (Exception ex)
        {
            await HandlerErrorAsync(ex);
        }
    }

    public Task HandlerErrorAsync(Exception ex)
    {
        var errorMessage = ex switch
        {
            ApiRequestException apiRequestException => $"Telegram API Error:\n{apiRequestException.ErrorCode}",
            _ => ex.ToString()
        };
        logger.LogInformation($"Uknown update type: {errorMessage}");

        return Task.CompletedTask;
    }

    private Task UnknownUpdateTypeHandler(Update update)
    {
        logger.LogInformation($"Uknown update type: {update.Type}");

        return Task.CompletedTask;
    }

    private async Task BotOnCollBackQueryrecieved(CallbackQuery callbackQuery)
    {
        await botClient.SendTextMessageAsync(chatId: callbackQuery.Message.Chat.Id,
                                             text: $"CallBack: {callbackQuery.Data}");
    }

    private async Task BotOnMessageRecieved(Message message)
    {
        logger.LogInformation($"Message recivied: {message.Type}");
        await botClient.SendTextMessageAsync(chatId: message.Chat.Id,
                                             text: "Bot reciveid message");
    }

}
