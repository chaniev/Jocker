using System;

namespace Jocker.Exceptions
{
	public class OrderLastException : Exception
	{
		public OrderLastException()
		{
		}

		public OrderLastException(string message)
			: base(message)
		{
		}

		public OrderLastException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
