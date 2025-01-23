namespace Autobot
{
	public static class Configuration
	{
		public static string ConsumerPath => Path.Combine(FindConsumerDirectory(), "src/");

		public static string FindConsumerDirectory()
		{
			var currentDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

			while (currentDirectory.Parent != null)
			{
				if (Directory.Exists(Path.Combine(currentDirectory.FullName, "rogue-consumer-cob")))
				{
					return Path.Combine(currentDirectory.FullName, "rogue-consumer-cob");
				}
				currentDirectory = currentDirectory.Parent;
			}

			throw new Exception("The directory 'rogue-consumer-cob' was not found");
		}
	}

}
