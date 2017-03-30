using System;
using System.Linq;
using Jocker.Exceptions;

namespace Jocker
{
	public class Distribution
	{
		private readonly DistributionPoint[] m_distPoints;
		private readonly bool m_canDark;
		private readonly int m_playerIndex;
		private readonly int m_order;

		public Distribution(int _playerCount, int _order, bool _canDark, int _playerIndex)
		{
			m_order = _order;
			m_playerIndex = _playerIndex;
			m_canDark = _canDark;
			m_distPoints = new DistributionPoint[_playerCount];
		}Í

		public DistributionPoint[] DistPoints
		{
			get
			{
				return m_distPoints;
			}
		}

		public void SetOrder(int _player, int _order, bool _dark)
		{
			if (_order > m_order)
				throw new OrderOverflowException("can not order more max order!");
			if (_player == m_playerIndex)
			{
				if (m_distPoints.Any(x => x == null) || m_distPoints.Any(x => x != null && x.Order == -1))
					throw new OrderLastException("can not order last player!");
				var playerorder = m_distPoints.Sum(x => x.Order);
				if (playerorder + _order == m_order)
					throw new OrderEqualCountException("can not set order!");
			}
			m_distPoints[_player] = new DistributionPoint(m_order);
			m_distPoints[_player].Order = _order;
			m_distPoints[_player].IsDark = m_canDark && _dark;
		}

		public void CalcPoint()
		{
			foreach (var distPoint in m_distPoints)
				distPoint.CalcPoint();
		}
	}
}