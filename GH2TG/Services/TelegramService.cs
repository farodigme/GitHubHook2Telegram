using GH2TG.Interfaces;
using GH2TG.Models;
using Microsoft.Extensions.Options;
using System.Net;

namespace GH2TG.Services
{
	public class TelegramService : ITelegramService
	{
		private readonly TelegramCredentials _credentials;
		private readonly ILogger<TelegramService> _logger;
		private readonly HttpClient _httpClient;
		public TelegramService(IOptions<TelegramCredentials> options, ILogger<TelegramService> logger, HttpClient httpClient)
		{
			_credentials = options.Value;
			_logger = logger;
			_httpClient = httpClient;
		}
		public async Task SendMessage(string message)
		{
			try
			{
				string endpoint = $"https://api.telegram.org/{_credentials.BotToken}/sendMessage?chat_id={_credentials.ChatId}&text={message}";

				var response = await _httpClient.PostAsync(endpoint, null);

				if (response.IsSuccessStatusCode) return;
			}
			catch (Exception ex)
			{
				_logger.LogError($"Error while sending message to Telegram: {ex.Message}");
			}
		}
	}
}
