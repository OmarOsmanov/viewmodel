using booot.Data;
using booot.Models;
using booot.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace booot.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            VmHome model = new VmHome()
            {
                setting = _context.Settings.FirstOrDefault(),
                products = _context.Products.ToList()
            };
            return View(model);


        }


     
    }
}
