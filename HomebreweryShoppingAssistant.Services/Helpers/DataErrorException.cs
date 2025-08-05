namespace HomebreweryShoppingAssistant.Services.Helpers
{
	public class DataErrorException : Exception
	{
		public int StatusCode { get; set; }

		public DataErrorException(int statusCode, string message) : base(message)
		{
			this.StatusCode = statusCode;
		}
	}
}
