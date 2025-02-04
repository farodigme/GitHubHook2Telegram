using System.ComponentModel.DataAnnotations;

namespace GH2TG.Models
{
	public class TelegramCredentials
	{
		[Required(ErrorMessage = "BotToken is required")]
		public string? BotToken { get; set; }

		[Required(ErrorMessage = "ChatId is required")]
		public string? ChatId { get; set; }
	}
}
