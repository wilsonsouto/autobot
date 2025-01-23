namespace Autobot
{
	public static class Configuration
	{
		public static string ConsumerPath => Path.Combine(FindDirectory("rogue-consumer-cob"), "src/");

		public static string DataPath => Path.Combine(FindDirectory("Data"));

		public static string FindDirectory(string dir)
		{
			var currentDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

			while (currentDirectory.Parent != null)
			{
				if (Directory.Exists(Path.Combine(currentDirectory.FullName, dir)))
				{
					return Path.Combine(currentDirectory.FullName, dir);
				}
				currentDirectory = currentDirectory.Parent;
			}

			throw new Exception($"O diretório {dir} não foi encontrado");
		}
	}

}
