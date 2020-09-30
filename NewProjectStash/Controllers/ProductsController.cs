﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using NewProjectStash.Models;
using Microsoft.AspNetCore.Mvc;
using NewProjectStash.Repositories;
using NewProjectStash.ViewModel;
using Microsoft.AspNetCore.Http;

namespace NewProjectStash.Controllers
{
    public class ProductsController : Controller
    {
        private IProductRepository _productRepository = null;

        //Physical path of file and folder
        private IWebHostEnvironment _webHostEnvironment = null;

        public ProductsController(IProductRepository productRepository, IWebHostEnvironment webHostEnvironment)
        {
            _productRepository = productRepository;
            _webHostEnvironment = webHostEnvironment;
        }

     
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
       
        public ActionResult Create(ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Product prd = new Product
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ImageName = product.ImageName.FileName
            };

          int result=  _productRepository.AddNewProduct(prd);
            if (result > 0)
            {
                this.UploadImageToFolder(product.ImageName);

            }

            return RedirectToAction("Index", "Home");

        }
        [HttpGet]
        public IActionResult EditProduct(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var Product=  _productRepository.GetProductById(id.Value);

            if (Product == null)
            {
                return View("ProductNotFound");//controller specific status code error handler
                //return NotFound();
            }

            EditProductViewModel editProduct = new EditProductViewModel
            {

                Id = Product.Id,
                Name = Product.Name,
                Description = Product.Description,
                Price = Product.Price,
                ExistingImageName = Product.ImageName
            };
            return View(editProduct);
        }

        [HttpPost]
        public IActionResult EditProduct(EditProductViewModel editProduct)
        {
            Product product = new Product();
            if (editProduct.ImageName == null)
            {
                if (editProduct.ExistingImageName != null)
                {
                    product.ImageName = editProduct.ExistingImageName;
                }
            }
            else
            {
                product.ImageName = editProduct.ImageName.FileName;
            }

            product.Id = editProduct.Id;
            product.Name = editProduct.Name;
            product.Description = editProduct.Description;
            product.Price = editProduct.Price;

            int result = _productRepository.EditProduct(product);

            if (result > 0 && editProduct.ImageName != null)
            {
                string folderName = this.UploadImageToFolder(editProduct.ImageName);
                var imgPath = Path.Combine(folderName, editProduct.ExistingImageName);
                if (System.IO.File.Exists(imgPath))
                {
                    System.IO.File.Delete(imgPath);
                }
            }

            return RedirectToAction("Index", "Home");
        

    }


    private string UploadImageToFolder(IFormFile ImageFile)
        {
            string folderName = Path.Combine(_webHostEnvironment.WebRootPath, "images");//C:/DXC/MyProject/Images
            string imgFilePath = Path.Combine(folderName, ImageFile.FileName);//C:/DXC/.../MyProject/Images/Roll_Bun.jpg
            ImageFile.CopyTo(new FileStream(imgFilePath, FileMode.Create));

            return folderName;
        }

      
    }
}