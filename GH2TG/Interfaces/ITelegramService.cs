namespace GH2TG.Interfaces
{
	public interface ITelegramService
	{
		public Task SendMessage(string message);
	}
}
