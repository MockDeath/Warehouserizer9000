using System;
using Moq;
using W9000.Business;
using W9000.Data;
using W9000.Entities;
using Xunit;

namespace W9000.Test
{
	public class FillOrderServiceTest
	{
		[Fact]
		public void ProcessFillOrder_On_Open_Order()
		{
			Mock<IFillOrderRepo> fillOrderRepo = new Mock<IFillOrderRepo>();
			FillOrderService fillOrderService = new FillOrderService(fillOrderRepo.Object);
			var newOrder = fillOrderService.CreateFillOrder();
			Assert.IsType<DateTime>(newOrder.OrderCreated);
		}

		[Fact]
		public void ProcessFillOrder_On_Closed_Order()
		{
			Mock<IFillOrderRepo> fillOrderRepo = new Mock<IFillOrderRepo>();
			FillOrder order = fillOrderRepo.Object.CreateFillOrder();
			order.OrderCreated = DateTime.Now;
			order.OrderId = Guid.NewGuid();
			FillOrderService fillOrderService = new FillOrderService(fillOrderRepo.Object);
			var closedOrder = fillOrderService.ProcessFillOrder(order);
			Assert.True(closedOrder.OrderClosed);
		}

		[Fact]
		public void ViewOpenOrders_Shows_All_Open_Orders()
		{
			Mock<IFillOrderRepo> fillOrderRepo = new Mock<IFillOrderRepo>();
			FillOrderService fillOrderService = new FillOrderService(fillOrderRepo.Object);
			var newOrder = fillOrderService.CreateFillOrder();
		}
	}
}
