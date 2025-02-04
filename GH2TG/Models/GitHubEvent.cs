namespace GH2TG.Models
{
	public class GitHubEvent
	{
		public string? action { get; set; }
		public Issue? issue { get; set; }
		public Repository? repository { get; set; }
		public Sender? sender { get; set; }
	}
	public class Issue
	{
		public string? url { get; set; }
		public int number { get; set; }
	}

	public class Owner
	{
		public string? login { get; set; }
		public int id { get; set; }
	}

	public class Repository
	{
		public int id { get; set; }
		public string? full_name { get; set; }
		public Owner? owner { get; set; }
	}

	public class Sender
	{
		public string? login { get; set; }
		public int id { get; set; }
	}
}
