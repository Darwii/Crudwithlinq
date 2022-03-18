using DomainLayer;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UIlayer.Controllers
{
    public class CatalogController : Controller
    {
        ProductDbContext _context;
        IRepositoryOperations<Product> _repo;

        public CatalogController(ProductDbContext context,IRepositoryOperations<Product> repo)
        {
            _context = context;
            _repo = repo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index()
        {

        }
    }
}
