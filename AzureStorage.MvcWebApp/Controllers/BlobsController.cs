using AzureStorage.Library;
using AzureStorage.MvcWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureStorage.MvcWebApp.Controllers
{
    public class BlobsController : Controller
    {

        private readonly IBlobStorage _blobStorage;

        public BlobsController(IBlobStorage blobStorage)
        {
            _blobStorage = blobStorage;
        }
        public IActionResult Index()
        {
            var names = _blobStorage.GetNames(EContainerName.Picture);
            string blobUrl = $"{_blobStorage.BlobUrl}/{EContainerName.Picture.ToString()}";
            ViewBag.blobs = names.Select(x => new FileBlob { Name = x, Url = $"{blobUrl}/x" }).ToList();
           return View();
        }
    }
}
