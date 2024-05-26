using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuizMaster.DataAccess.Contexts;
using QuizMaster.DataAccess.Repositories;
using QuizMaster.Service.Mappers;
using QuizMaster.Service.Services.Users;
using QuizMaster.TelegramBot.Extensions;
using QuizMaster.TelegramBot.Models;
using QuizMaster.TelegramBot.Services;
using System.Net.Http;
using Telegram.Bot;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options
    => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IHostedService, WebhookConfiguration>();
builder.Services.AddHttpClient("tgwebhook")
    .AddTypedClient<ITelegramBotClient>(httpClient 
        => new TelegramBotClient(builder.Configuration.GetSection("BotConfiguration").Get<BotConfiguration>().Token, httpClient));
builder.Services.AddScoped<HandleUpdateService>();

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

app.UseRouting();

app.UseCors();

app.UseAuthorization();

app.MapControllerRoute(name: "tgwebhook",
                       pattern: $"bot/{builder.Configuration
                            .GetSection("BotConfiguration")
                            .Get<BotConfiguration>().Token}",
                       new { controller = "Webhook", action = "Post" });

app.MapControllers();

app.Run();
