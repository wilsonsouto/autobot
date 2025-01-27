namespace Autobot.Helpers
{
	public class ValidationHelper
	{
		public static bool IsStringValid(string? input) =>
			!string.IsNullOrEmpty(input) && input.Length >= 3 && input.Length <= 20;
	}
}
