using System;

namespace Jocker
{
	public class DistributionPoint
	{
		private const int TotalMultiplier = 100;
		private const int DefaultMultiplier = 50;
		private const int OverMultiplier = 10;
		private const int DarkMultiplier = 2;

		private readonly int m_maxOrder;


		public DistributionPoint(int _maxOrder)
		{
			m_maxOrder = _maxOrder;
			Order = -1;
		}

		public int Order { get; set; }

		public int Count { get; set; }

		public bool IsDark { get; set; }

		public int CalcPoint()
		{
			var result = DefaultMultiplier;
			if (Count < Order)
			{
				if (Count == 0 && Order == m_maxOrder)
					result = -Order * TotalMultiplier;
				else
					result = -((Order - Count) * DefaultMultiplier + DefaultMultiplier);
			}
			if (Count == Order)
			{
				if (Order == m_maxOrder)
					result = Order * TotalMultiplier;
				else
					result = Order * DefaultMultiplier + DefaultMultiplier;
			}
			if (Count > Order)
			{
				result = Count * OverMultiplier;
			}
			return IsDark ? DarkMultiplier * result : result;
		}
	}
}