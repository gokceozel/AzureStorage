using AzureStorage.Library;
using AzureStorage.MvcWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
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

        public async Task<IActionResult> Index()
        {
            var names = _blobStorage.GetNames(EContainerName.pictures);
            string blobUrl = $"{_blobStorage.BlobUrl}/{EContainerName.pictures.ToString()}";
            ViewBag.blobs = names.Select(x => new FileBlob { Name = x, Url = $"{blobUrl}/{x}" }).ToList();
            ViewBag.logs = await _blobStorage.GetLogAsync("controller.txt");
           return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile picture)
        {
            await _blobStorage.SetLogAsync("Upload metoduna giriş yapıldı","controller.txt");
            var newFileName = Guid.NewGuid().ToString() + Path.GetExtension(picture.FileName);
            await _blobStorage.UploadAsync(picture.OpenReadStream(),newFileName,EContainerName.pictures);
            await _blobStorage.SetLogAsync("Upload metodundan çıkış yapıldı", "controller.txt");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Download(string fileName)
        {
            var stream = await _blobStorage.DowloadAsync(fileName, EContainerName.pictures);
            return File(stream, "application/octet-stream", fileName);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string fileName)
        {
            await _blobStorage.DeleteAsync(fileName, EContainerName.pictures);
            return RedirectToAction("Index");
        }
    }
}
