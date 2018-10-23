using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using W9000.Data;
using W9000.Entities;

namespace W9000.Business
{
	public class FillOrderService
	{
		private readonly IFillOrderRepo _fillOrderRepo;

		public FillOrderService(IFillOrderRepo fillOrderRepo)
		{
			_fillOrderRepo = fillOrderRepo;
		}

		public FillOrder CreateFillOrder()
		{
			return _fillOrderRepo.CreateFillOrder();
		}

		public FillOrder ProcessFillOrder(FillOrder fillOrder)
		{
			FillOrder currentOrder = _fillOrderRepo.GeGetOrderById(fillOrder.OrderId);
			if (currentOrder.OrderClosed)
			{
				//not graceful but was running low on time.
				throw new Exception("Order Already closed");
			}
			return _fillOrderRepo.ProcessFillOrder(fillOrder.OrderId);
		}

		public List<FillOrder> ViewOpenOrders()
		{
			return _fillOrderRepo.ReturnOpenOrders();
		}
	}
}
