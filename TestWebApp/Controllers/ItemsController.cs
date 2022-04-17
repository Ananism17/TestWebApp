using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TestWebApp.Data.Services;
using TestWebApp.Models;

namespace TestWebApp.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IItemsService _service;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ItemsController(IItemsService service, IWebHostEnvironment hostEnvironment)
        {
            _service = service;
            this._hostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name, Price, Amount, Sell, ImageFile")] Item item) 
        {
            if (ModelState.IsValid) 
            {
                item.Stock = item.Amount - item.Sell;


                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(item.ImageFile.FileName);
                string extension = Path.GetExtension(item.ImageFile.FileName);
                item.ItemImageURL = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/images/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await item.ImageFile.CopyToAsync(fileStream);
                }


                await _service.AddAsync(item);
                return RedirectToAction(nameof(Index));
            }

            return View(item);
        }


        /*public async Task<IActionResult> Details(int id)
        {
            var itemDetails = _service.GetByIdAsync(id);

            if (itemDetails == null) return View("NotFound");

            return View(itemDetails);

        }*/



       /* public async Task<IActionResult> Edit(int id)
        {
            var itemDetails = await _service.GetByIdAsync(id);

            if (itemDetails == null) return View("NotFound");

            return View(itemDetails);
            return View(itemDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemId, Name, Price, Amount, Sell")] Item item)
        {

            if (ModelState.IsValid)
            {
                item.Stock = item.Amount - item.Sell;

                await _service.UpdateAsync(id, item);
                return RedirectToAction(nameof(Index));
            }

            return View(item);
        }*/


        public async Task<IActionResult> Stock()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        public async Task<IActionResult> Shop()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
    }
}
