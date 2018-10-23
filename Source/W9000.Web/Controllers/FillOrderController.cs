using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using W9000.Business;
using W9000.Entities;

namespace W9000.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FillOrderController : ControllerBase
    {
	    private readonly FillOrderService _fillOrderService;

	    public FillOrderController(FillOrderService fillOrderService)
	    {
		    _fillOrderService = fillOrderService;
	    }

	    [HttpGet]
	    public IActionResult GetOpenFillOrders()
	    {
		    return Ok(_fillOrderService.ViewOpenOrders());
	    }

	    [HttpPost("create")]
	    public IActionResult CreateFillOrder([FromBody]FillOrder fillOrder)
	    {
		    _fillOrderService.CreateFillOrder(fillOrder);
		    return Ok();
	    }

	    [HttpPost("process")]
	    public IActionResult ProccessFillOrder([FromBody]FillOrder fillOrder)
	    {
		    _fillOrderService.ProcessFillOrder(fillOrder);
		    return Ok();
	    }

	    [HttpGet("{id}")]
	    public FillOrder GetById(int id)
	    {
		    return _fillOrderService.ViewOrderById(id);
	    }
		
	}
}