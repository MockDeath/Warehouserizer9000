using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using W9000.Entities;

namespace W9000.Data
{
	public class FillOrderRepo : IFillOrderRepo
	{
		//I know this is not how you deal with a database, but I am faking it due to lack of time.
		//private readonly IDbConnection _db;

		public FillOrder CreateFillOrder()
		{
			FillOrder newOrder = new FillOrder
			{
				Id = Guid.NewGuid().ToString(),
				OrderCreated = DateTime.Now,
				OrderClosed = false,
			};
			FakeDbConnect.Db.Add(newOrder);
			return newOrder;
		}

		public FillOrder ProcessFillOrder(string id)
		{
			FillOrder order = FakeDbConnect.Db.Find(o => o.Id == id);
			order.OrderClosed = true;
			order.OrderProcessed = DateTime.Now;

			return order;
		}

		public List<FillOrder> ReturnAllOrders()
		{
			return FakeDbConnect.Db;
		}

		public FillOrder GetOrderById(string orderId)
		{
			FillOrder order = FakeDbConnect.Db.Find(o => o.Id == orderId);
			return order;
		}

		public List<FillOrder> ReturnOpenOrders()
		{
			List<FillOrder> order = FakeDbConnect.Db.FindAll(o => o.OrderClosed != true);
			return order;
		}
	}
}
