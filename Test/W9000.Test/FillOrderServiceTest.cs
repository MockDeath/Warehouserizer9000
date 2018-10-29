using System;
using System.Linq;
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
		public void CreateFillOrder_Create_New_Fill_Order()
		{
			//Because I did not mock the database fully, this returns an empty object.
			//wanted to show I can mock out things however.
			var fillOrderRepo = new Mock<IFillOrderRepo>();
			fillOrderRepo.Setup(f => f.CreateFillOrder()).Returns(new FillOrder());
			var fillOrderService = new FillOrderService(fillOrderRepo.Object);
			var newOrder = fillOrderService.CreateFillOrder();
			Assert.IsType<DateTime>(newOrder.OrderCreated);
			Assert.False(newOrder.OrderClosed);
		}

		[Fact]
		public void CreateFillOrder_Create_New_Fill_Order_2()
		{
			//Because it is in memory as it is and I do not have a mocked DB, I wanted to also show the tests would catch if it generated a fill order
			var fillOrderRepo = new FillOrderRepo();
			var fillOrderService = new FillOrderService(fillOrderRepo);
			var newOrder = fillOrderService.CreateFillOrder();
			Assert.IsType<DateTime>(newOrder.OrderCreated);
			Assert.False(newOrder.OrderClosed);
			Assert.NotNull(newOrder.Id);
		}

		[Fact]
		public void ProcessFillOrder_On_Open_Order()
		{
			//Because the database is already in memory, it just calls this directly. Normally would use an in memory database to mock out the real one.
			var fillOrderRepo = new FillOrderRepo();
			fillOrderRepo.CreateFillOrder();
			FillOrderService fillOrderService = new FillOrderService(fillOrderRepo);
			var orders = fillOrderService.ViewOpenOrders();
			var singleOrder = orders.First();
			var closedOrder = fillOrderService.ProcessFillOrder(singleOrder.Id);
			Assert.True(closedOrder.OrderClosed);
		}

		[Fact]
		public void ViewOpenOrders_Shows_All_Open_Orders()
		{
			//Because the database is already in memory, it just calls this directly. Normally would use an in memory database to mock out the real one.
			var fillOrderRepo = new FillOrderRepo();
			var fillOrderService = new FillOrderService(fillOrderRepo);
			fillOrderService.CreateFillOrder();
			fillOrderService.CreateFillOrder();
			fillOrderService.CreateFillOrder();
			fillOrderService.CreateFillOrder();
			Assert.True(fillOrderService.ViewOpenOrders().Count == 4);
		}

		[Fact]
		public void ProcessFillOrder_On_Already_Closed_Order()
		{
			var fillOrderRepo = new FillOrderRepo();
			fillOrderRepo.CreateFillOrder();
			FillOrderService fillOrderService = new FillOrderService(fillOrderRepo);
			var orders = fillOrderService.ViewOpenOrders();
			var singleOrder = orders.First();
			var closedOrder = fillOrderService.ProcessFillOrder(singleOrder.Id);
			Assert.Throws<Exception>(() => fillOrderService.ProcessFillOrder(closedOrder.Id));
		}
	}
}
