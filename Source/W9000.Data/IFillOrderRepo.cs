using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using W9000.Entities;

namespace W9000.Data
{
	public interface IFillOrderRepo
	{
		FillOrder CreateFillOrder();
		FillOrder ProcessFillOrder(Guid id);
		List<FillOrder> ReturnOpenOrders();
		FillOrder GeGetOrderById(Guid orderId);
	}
}