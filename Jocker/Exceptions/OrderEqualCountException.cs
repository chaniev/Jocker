using System;

namespace Jocker.Exceptions
{
	public class OrderEqualCountException : Exception
	{
		public OrderEqualCountException()
		{
		}

		public OrderEqualCountException(string message)
			: base(message)
		{
		}

		public OrderEqualCountException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}