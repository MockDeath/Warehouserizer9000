//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using W9000.Data;
//using W9000.Entities;
//using W9000.Web.Models;

//namespace W9000.Web.Controllers
//{
//    public class FillOrdersController : Controller
//    {
//        private readonly IFillOrderRepo _context;

//        public FillOrdersController(IFillOrderRepo context)
//        {
//            _context = context;
//        }

//        // GET: FillOrders
//        public IActionResult Index()
//        {
//            return View( _context.);
//        }

//        // GET: FillOrders/Details/5
//        public async Task<IActionResult> Details(Guid? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var fillOrder = await _context.FillOrder
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (fillOrder == null)
//            {
//                return NotFound();
//            }

//            return View(fillOrder);
//        }

//        // GET: FillOrders/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: FillOrders/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,OrderCreated,OrderProcessed,OrderClosed")] FillOrder fillOrder)
//        {
//            if (ModelState.IsValid)
//            {
//                fillOrder.Id = Guid.NewGuid();
//                _context.Add(fillOrder);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(fillOrder);
//        }

//        // GET: FillOrders/Edit/5
//        public async Task<IActionResult> Edit(Guid? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var fillOrder = await _context.FillOrder.FindAsync(id);
//            if (fillOrder == null)
//            {
//                return NotFound();
//            }
//            return View(fillOrder);
//        }

//        // POST: FillOrders/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(Guid id, [Bind("Id,OrderCreated,OrderProcessed,OrderClosed")] FillOrder fillOrder)
//        {
//            if (id != fillOrder.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(fillOrder);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!FillOrderExists(fillOrder.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(fillOrder);
//        }

//        // GET: FillOrders/Delete/5
//        public async Task<IActionResult> Delete(Guid? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var fillOrder = await _context.FillOrder
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (fillOrder == null)
//            {
//                return NotFound();
//            }

//            return View(fillOrder);
//        }

//        // POST: FillOrders/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(Guid id)
//        {
//            var fillOrder = await _context.FillOrder.FindAsync(id);
//            _context.FillOrder.Remove(fillOrder);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool FillOrderExists(Guid id)
//        {
//            return _context.FillOrder.Any(e => e.Id == id);
//        }
//    }
//}
