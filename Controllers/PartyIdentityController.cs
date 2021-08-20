using DemoApplication.DBContexts;
using DemoApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApplication.Controllers
{
    public class PartyIdentityController : Controller
    {
        private MyDBContext myDbContext;

        public PartyIdentityController(MyDBContext context)
        {
            myDbContext = context;
        }

        [HttpGet]
        public IList<PartyIdentity> Get()
        {
            return (this.myDbContext.PartyIdentity.ToList());
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
