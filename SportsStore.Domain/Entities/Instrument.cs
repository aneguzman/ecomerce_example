﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsStore.Domain.Entities {
	public class Instrument {
		public string Name { get; set; }
		public decimal Price { get; set; }
		public DateTime DateOfMake { get; set; }
		public string Type { get; set; }
	}
}
