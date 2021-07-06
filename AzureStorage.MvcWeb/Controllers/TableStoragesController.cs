using AzureStorage.Library;
using AzureStorage.Library.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureStorage.MvcWeb.Controllers
{
    public class TableStoragesController : Controller
    {
        private readonly INoSqlStorage<Product> _product;
        public IActionResult Index()
        {
            return View();
        }
    }
}
