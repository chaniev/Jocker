using System;

namespace Jocker.Exceptions
{
	public class OrderOverflowException: Exception
	{
		public OrderOverflowException()
		{
		}

		public OrderOverflowException(string message)
			: base(message)
		{
		}

		public OrderOverflowException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}