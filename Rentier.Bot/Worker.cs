using Rentier.Bot.Model;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Rentier.Bot
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        private readonly IConfiguration _configuration;
        private readonly TelegramBotClient _botClient;

        public Worker(ILogger<Worker> logger, IConfiguration config)
        {
            _logger = logger;
            _configuration = config;
            var accessToken = config.GetValue<string>("AccessToken");
            if (accessToken == null) throw new ArgumentNullException("Внесите в конфигурацию токен доступа");
            _botClient = new TelegramBotClient(accessToken);
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = Array.Empty<UpdateType>()
            };
            _botClient.StartReceiving(
                updateHandler: HandleUpdateAsync,
                pollingErrorHandler: HandlePollingErrorAsync,
                receiverOptions: receiverOptions
                );
        }

        private async Task HandlePollingErrorAsync(ITelegramBotClient client, Exception exception, CancellationToken token)
        {
            _logger.LogInformation("Возникло исключение: {msg}", exception.Message);
        }

        private async Task HandleUpdateAsync(ITelegramBotClient client, Update update, CancellationToken token)
        {
            if (update == null) {
                _logger.LogInformation("{time} update == null", DateTimeOffset.Now);
                return;
            }
            if (update.Message == null)
            {
                _logger.LogInformation("{time} update.Message == null", DateTimeOffset.Now);
                return;
            }
            if (update.Message.Text == null)
            {
                _logger.LogInformation("{time} update.Message.Text == null", DateTimeOffset.Now);
                return;
            }

            switch (update.Message.Text)
            {
                case Commands.start:
                    Message sentMessage = await client.SendTextMessageAsync(
                    chatId: update.Message.Chat.Id,
                    text: "Отлично! Теперь мы плодотворно поработаем.",
                    cancellationToken: token); break;
            }
            return;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}