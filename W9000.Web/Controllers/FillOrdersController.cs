using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using W9000.Business;
using W9000.Entities;
using W9000.Web.Models;

namespace W9000.Web.Controllers
{
	public class FillOrdersController : Controller
	{
		private readonly FillOrderService _service;

		public FillOrdersController(FillOrderService service)
		{
			_service = service;
		}

		// GET: FillOrders
		public IActionResult Index()
		{
			return View(_service.ViewAllOrders());
		}

		public IActionResult Open()
		{
			return View(_service.ViewOpenOrders());
		}

		// GET: FillOrders/Details/5
		public IActionResult Details(string id)
		{

			var fillOrder = _service.ViewOrderById(id);
			if (fillOrder == null)
			{
				return NotFound();
			}

			return View(fillOrder);
		}

		[HttpPost]
		public IActionResult ProcessOrder(string id)
		{
			_service.ProcessFillOrder(id);
			return RedirectToAction("Index");
		}

		//GET: FillOrders/Create
		public IActionResult Create()
		{
			return View(_service.CreateFillOrder());
		}

		//// POST: FillOrders/Create
		//// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public async Task<IActionResult> Create([Bind("Id,OrderCreated,OrderProcessed,OrderClosed")] FillOrder fillOrder)
		//{
		//	if (ModelState.IsValid)
		//	{
		//		fillOrder.Id = Guid.NewGuid();
		//		_service.Add(fillOrder);
		//		await _service.SaveChangesAsync();
		//		return RedirectToAction(nameof(Index));
		//	}
		//	return View(fillOrder);
		//}

		//// GET: FillOrders/Edit/5
		//public async Task<IActionResult> Edit(Guid? id)
		//{
		//	if (id == null)
		//	{
		//		return NotFound();
		//	}

		//	var fillOrder = await _service.FillOrder.FindAsync(id);
		//	if (fillOrder == null)
		//	{
		//		return NotFound();
		//	}
		//	return View(fillOrder);
		//}

		//// POST: FillOrders/Edit/5
		//// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public async Task<IActionResult> Edit(Guid id, [Bind("Id,OrderCreated,OrderProcessed,OrderClosed")] FillOrder fillOrder)
		//{
		//	if (id != fillOrder.Id)
		//	{
		//		return NotFound();
		//	}

		//	if (ModelState.IsValid)
		//	{
		//		try
		//		{
		//			_service.Update(fillOrder);
		//			await _service.SaveChangesAsync();
		//		}
		//		catch (DbUpdateConcurrencyException)
		//		{
		//			if (!FillOrderExists(fillOrder.Id))
		//			{
		//				return NotFound();
		//			}
		//			else
		//			{
		//				throw;
		//			}
		//		}
		//		return RedirectToAction(nameof(Index));
		//	}
		//	return View(fillOrder);
		//}

		//// GET: FillOrders/Delete/5
		//public async Task<IActionResult> Delete(Guid? id)
		//{
		//	if (id == null)
		//	{
		//		return NotFound();
		//	}

		//	var fillOrder = await _service.FillOrder
		//		.FirstOrDefaultAsync(m => m.Id == id);
		//	if (fillOrder == null)
		//	{
		//		return NotFound();
		//	}

		//	return View(fillOrder);
		//}

		//// POST: FillOrders/Delete/5
		//[HttpPost, ActionName("Delete")]
		//[ValidateAntiForgeryToken]
		//public async Task<IActionResult> DeleteConfirmed(Guid id)
		//{
		//	var fillOrder = await _service.FillOrder.FindAsync(id);
		//	_service.FillOrder.Remove(fillOrder);
		//	await _service.SaveChangesAsync();
		//	return RedirectToAction(nameof(Index));
		//}

		//private bool FillOrderExists(Guid id)
		//{
		//	return _service.FillOrder.Any(e => e.Id == id);
		//}
	}
}
