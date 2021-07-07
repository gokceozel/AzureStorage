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
        private readonly INoSqlStorage<Product> _noSqlStorage;
        public TableStoragesController(INoSqlStorage<Product> noSqlStorage)
        {
            _noSqlStorage = noSqlStorage;
        }
        public IActionResult Index()
        {
            var test = _noSqlStorage.GetAll().ToList();
            return View();
        }
    }
}
