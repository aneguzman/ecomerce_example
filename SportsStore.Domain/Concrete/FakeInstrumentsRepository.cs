using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Concrete {
	public class FakeInstrumentsRepository: IInstrumentRepository
	{
		private IQueryable<Instrument> instruments = new List<Instrument>
		                                          	{
		                                          		new Instrument {Name = "Guitar", Price = 1200, Type = "Chord"},
		                                          		new Instrument {Name = "Piano", Price = 10000, Type = "Cola"}
		                                          	}.AsQueryable(); 

		public IQueryable<Instrument> Instruments
		{
			get { return instruments; }
		}
	}
}
