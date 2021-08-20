using DemoApplication.DBContexts;
using DemoApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApplication.Controllers
{
    public class PartyContactController : Controller
    {
        private MyDBContext myDbContext;

        public PartyContactController(MyDBContext context)
        {
            myDbContext = context;
        }

        [HttpGet]
        public IList<PartyContact> Get()
        {
            return (this.myDbContext.PartyContact.ToList());
        }
        [HttpPost]
        public ActionResult Post([FromBody] PartyContact request)
        {
            this.myDbContext.Add(request);
            this.myDbContext.SaveChanges();


            return Ok();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
