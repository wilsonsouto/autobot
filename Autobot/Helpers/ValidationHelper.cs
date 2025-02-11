namespace Autobot.Helpers
{
	public static class ValidationHelper
	{
		public static bool IsStringValid(string? input) => !string.IsNullOrEmpty(input) && input.Length is >= 3 and <= 20;
	}
}