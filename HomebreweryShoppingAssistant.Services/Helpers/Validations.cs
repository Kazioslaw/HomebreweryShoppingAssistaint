namespace HomebreweryShoppingAssistant.Services.Helpers
{
	public static class Validations<T>
	{
		public static void IsNull(T? entity, int statusCode)
		{
			if (entity is null)
			{
				throw new DataErrorException(statusCode, $"{typeof(T).Name} with this id is not exist.");
			}
		}
	}
}
