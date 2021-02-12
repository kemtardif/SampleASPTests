using System;
using SimpleApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace SimpleApp.Controllers
{
    public class HomeController : Controller
    {
        public IDataSource dataSource = new ProductDataSource();

        public ViewResult Index()
        {
            return View(dataSource.Products);
        }
    }
}
