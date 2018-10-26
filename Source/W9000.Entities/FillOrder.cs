using System;
using System.Collections.Generic;
using System.Text;

namespace W9000.Entities
{
	public class FillOrder
	{
		public string Id { get; set; }
		public DateTime OrderCreated { get; set; }
		public DateTime? OrderProcessed { get; set; }
		public bool OrderClosed { get; set; }
	}
}
