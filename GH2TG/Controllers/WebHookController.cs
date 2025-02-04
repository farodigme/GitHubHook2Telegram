using GH2TG.Interfaces;
using GH2TG.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;

namespace GH2TG.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WebhookController : ControllerBase
	{
		private readonly ITelegramService _telegramService;

		public WebhookController(ITelegramService telegramService)
		{
			_telegramService = telegramService;
		}

		[HttpGet]
		public string Get()
		{
			return "I'm working";
		}

		[HttpPost]
		public async Task<IActionResult> ReceiveWebhook([FromBody] GitHubEvent payload)
		{
			if (payload == null) return BadRequest("Invalid payload");

			string message = $"New event on github, {payload.action} on {payload.repository?.full_name}, from {payload.sender?.login}";

			await _telegramService.SendMessage(message);

			return Ok();
		}
	}
}
