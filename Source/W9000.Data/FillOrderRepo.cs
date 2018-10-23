﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using W9000.Entities;

namespace W9000.Data
{
	public class FillOrderRepo : IFillOrderRepo
	{
		//I know this is not how you deal with a database, but I as faking it due to lack of time.

		public FillOrder CreateFillOrder()
		{
			FillOrder newOrder = new FillOrder
			{
				OrderId = Guid.NewGuid(),
				OrderCreated = DateTime.Now,
				OrderClosed = false,
			};
			FakeDbConnect.Db.Add(newOrder);
			return newOrder;
		}

		public FillOrder ProcessFillOrder(Guid id)
		{
			FillOrder order = FakeDbConnect.Db.Find(o => o.OrderId == id);
			order.OrderClosed = true;
			order.OrderProcessed = DateTime.Now;

			return order;
		}

		public List<FillOrder> ReturnOpenOrders()
		{
			return FakeDbConnect.Db;
		}

		public FillOrder GeGetOrderById(Guid orderId)
		{
			FillOrder order = FakeDbConnect.Db.Find(o => o.OrderId == orderId);
			return order;
		}
	}
}