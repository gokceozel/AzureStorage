using AzureStorage.Library;
using AzureStorage.Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureStorage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly INoSqlStorage<Product> _noSqlStorage;
        public HomeController(INoSqlStorage<Product> noSqlStorage)
        {
            _noSqlStorage = noSqlStorage;
        }

        [HttpGet("get")]
        public IActionResult Get()
        {
            var model = _noSqlStorage.GetAll().ToList();
            if (model == null)
               return NoContent();
            else
               return Ok(model);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddProduct(Product model)
        {
            if (ModelState.IsValid)
            {
                model.RowKey = Guid.NewGuid().ToString();
                model.PartitionKey = "The products to order";
                await _noSqlStorage.Add(model);
                return Ok();
            }
            else
            {
                return BadRequest("model error");
            }
            
        }

    }
}
