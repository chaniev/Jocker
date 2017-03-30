
using System;
using NUnit.Framework;
using Jocker;

namespace Jocker.Tests
{
	[TestFixture]
	public class DistributionPointTests
	{
		[Test]
		public void CalcPoint_Pass_Test()
		{
			var target = new DistributionPoint(1);
			target.Order = 0;
			target.Count = 0;
			target.IsDark = false;
			var expected = 50;
			var actual = target.CalcPoint();
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void CalcPoint_PassWithDark_Test()
		{
			var target = new DistributionPoint(9);
			target.Order = 0;
			target.Count = 0;
			target.IsDark = true;
			var expected = 100;
			var actual = target.CalcPoint();
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void CalcPoint_OrderEqualCountAndNotDark_Test()
		{
			var target = new DistributionPoint(2);
			target.Order = 1;
			target.Count = 1;
			target.IsDark = false;
			var expected = 100;
			var actual = target.CalcPoint();
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void CalcPoint_OrderEqualCountAndDark_Test()
		{
			var target = new DistributionPoint(9);
			target.Order = 1;
			target.Count = 1;
			target.IsDark = true;
			var expected = 200;
			var actual = target.CalcPoint();
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void CalcPoint_OrderTotalWithDark_Test()
		{
			var target = new DistributionPoint(9);
			target.Order = 9;
			target.Count = 9;
			target.IsDark = true;
			var expected = 1800;
			var actual = target.CalcPoint();
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void CalcPoint_OrderEqualTotalNotDark_Test()
		{
			var target = new DistributionPoint(5);
			target.Order = 5;
			target.Count = 5;
			target.IsDark = false;
			var expected = 500;
			var actual = target.CalcPoint();
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void CalcPoint_OrderLessCountAndNotDark_Test()
		{
			var target = new DistributionPoint(2);
			target.Order = 1;
			target.Count = 0;
			target.IsDark = false;
			var expected = -100;
			var actual = target.CalcPoint();
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void CalcPoint_OrderLessCountAndDark_Test()
		{
			var target = new DistributionPoint(9);
			target.Order = 1;
			target.Count = 0;
			target.IsDark = true;
			var expected = -200;
			var actual = target.CalcPoint();
			Assert.AreEqual(expected, actual);
		}
	}
}
