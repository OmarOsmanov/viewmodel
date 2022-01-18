using booot.Data;
using booot.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace booot.Areas.admin.Controllers
{
    [Area("admin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        //public IActionResult Index()
        //{
        //    return View(_context.Products.Include(u=>u.User).ToList());
        //}




        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product model)
        {

           
            
                if (model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/png")
                {
                    if (model.ImageFile.Length <= 3145728)
                    {
                        string fileName = Guid.NewGuid() + "-" + model.ImageFile.FileName;
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            model.ImageFile.CopyTo(stream);
                        }

                        model.Image = fileName;
                        //model.UserId = 1;
                        _context.Products.Add(model);
                        _context.SaveChanges();
                        return RedirectToAction("index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "hecm boyukdur!");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "format uygun deyil");
                    return View();
                }
            
           
            
        }




        public IActionResult Update(int? id)
        {
            return View(_context.Products.Find(id));
        }



        [HttpPost]
        public IActionResult Update(Product model)
        {

            if (ModelState.IsValid)
            {

                if (model.ImageFile != null)
                {
                    if (model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/png")
                    {
                        if (model.ImageFile.Length <= 3145728)
                        {
                            string oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", model.Image);

                            if (System.IO.File.Exists(oldImagePath))
                            {
                                System.IO.File.Delete(oldImagePath);
                            }

                            string fileName = Guid.NewGuid() + "-" + model.ImageFile.FileName;
                            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                model.ImageFile.CopyTo(stream);
                            }

                            model.Image = fileName;

                            _context.Products.Update(model);
                            _context.SaveChanges();
                            return RedirectToAction("index");
                        }
                        else
                        {
                            ModelState.AddModelError("", "hecm boyukdur!");
                            return View();
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "format uygun deyil");
                        return View();
                    }
                }

                else
                {
                    _context.Products.Update(model);
                    _context.SaveChanges();
                    return RedirectToAction("index");

                }

               
            }
            else
            {
                return View(model);
            }


        }




        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product product = _context.Products.Find(id);
            if(product == null)
            {
                return NotFound();
            }

            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", product.Image);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("index");


        }
    }
} 
