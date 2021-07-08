using AzureStorage.Library;
using AzureStorage.Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        [HttpPost("edit")]
        public async Task<IActionResult> UpdateProduct(string rowKey,string partitionKey,Product model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var updateModel = _noSqlStorage.Get(rowKey, partitionKey);
                    await _noSqlStorage.Update(updateModel);
                    return Ok();

                }
                catch (StorageException ex)
                {
                    if (ex.RequestInformation.HttpStatusCode == (int)HttpStatusCode.PreconditionFailed)
                    { 
                        string msj = "Pls refresh page";
                        return BadRequest(msj);
                    }
                    return BadRequest(ex.Message);
                }
             
            }
            else
                return BadRequest("Update was unsuccess");
         }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteProduct(string rowKey,string partitionKey)
        {
            if (! string.IsNullOrEmpty(rowKey)&&  !string.IsNullOrEmpty(partitionKey))
            {
                 await  _noSqlStorage.Delete(rowKey,partitionKey);
                 return Ok();
            }
            else
                return BadRequest();
        }
    }
}
