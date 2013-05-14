using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Concrete;

namespace SportsStore.WebUI.Controllers
{
    public class InstrumentsController : Controller
    {
        //
        // GET: /Instruments/

        public ViewResult List()
        {
        	var instrumentRepository = new FakeInstrumentsRepository();
            return View(instrumentRepository.Instruments.ToList());
        }

    }
}
