using System;
using System.Linq;
using Jocker.Exceptions;

namespace Jocker
{
	public class Distribution
	{
		private readonly DistributionPoint[] _distPoints;
		private readonly bool _canDark;
		private readonly int _playerIndex;
		private readonly int _order;

		public Distribution(int playerCount, int order, bool canDark, int playerIndex)
		{
			_order = order;
			_playerIndex = playerIndex;
			_canDark = canDark;
			_distPoints = new DistributionPoint[playerCount];
		}

		public DistributionPoint[] DistPoints
		{
			get
			{
				return _distPoints;
			}
		}

		public void SetOrder(int player, int order, bool dark)
		{
			if (order > _order)
				throw new OrderOverflowException("can not order more max order!");
			if (player == _playerIndex)
			{
				if (_distPoints.Any(x => x == null) || _distPoints.Any(x => x != null && x.Order == -1))
					throw new OrderLastException("can not order last player!");
				var playerorder = _distPoints.Sum(x => x.Order);
				if (playerorder + order == _order)
					throw new OrderEqualCountException("can not set order!");
			}
			_distPoints[player] = new DistributionPoint(_order);
			_distPoints[player].Order = order;
			_distPoints[player].IsDark = _canDark && dark;
		}

        public void SetCout(int player, int count)
        {
            _distPoints[player].Count = count;
        }

		public void CalcPoint()
		{
			foreach (var distPoint in _distPoints)
				distPoint.CalcPoint();
		}
	}
}