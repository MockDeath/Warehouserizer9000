using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using W9000.Entities;

namespace W9000.Data
{
	public static class FakeDbConnect
	{
		public static List<FillOrder> Db = new List<FillOrder>();

		private static readonly FillOrder _order1 = new FillOrder
		{
			OrderId = Guid.NewGuid(),
			OrderCreated = DateTime.Now,
			OrderClosed = false,
		};

		private static readonly FillOrder _order2 = new FillOrder
		{
			OrderId = Guid.NewGuid(),
			OrderCreated = DateTime.Now,
			OrderClosed = true,
			OrderProcessed = DateTime.Now
		};

		public static void PopulateData()
		{
			Db.Add(_order1);
			Db.Add(_order2);
		}
	}
}
