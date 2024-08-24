using Microsoft.AspNetCore.Mvc;
using ZapTech_Store_WebApp.Services;
using ZapTech_Store_WebApp.Models; // Add this if not already present

namespace ZapTech_Store_WebApp.Controllers
{
    public class ProductController : Controller // Corrected name here
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment environment;


        public ProductController(ApplicationDbContext context, IWebHostEnvironment environment) // Corrected name here
        {
            this.context = context;
            this.environment = environment;
        }
        public IActionResult Index()
        {
            var products = context.Products.OrderByDescending(p => p.Id).ToList();
            return View(products);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductDto productDto)
        {
            if (productDto.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "The image file is required");
            }

            if (!ModelState.IsValid)
            {
                return View(productDto);
            }

            //save the image file
            string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            newFileName += Path.GetExtension(productDto.ImageFile!.FileName);

            string imageFullPath = Path.Combine(environment.WebRootPath, "Products", newFileName);
            Console.WriteLine(imageFullPath); // Log the path to see where the file is saved

            using (var stream = System.IO.File.Create(imageFullPath)) 
            {
                productDto.ImageFile.CopyTo(stream);
            }


            Product product = new Product()
            {
                Name = productDto.Name,
                Brand = productDto.Brand,
                Category = productDto.Category,
                Price = productDto.Price,
                Description = productDto.Description,
                ImageFileName = newFileName,
                CreatedAt = DateTime.Now,
            };

            context.Products.Add(product);
            context.SaveChanges();


            return RedirectToAction("Index", "Product");
        }


        public IActionResult Edit(int id)
        {
            var product = context.Products.Find(id);
            if (product == null)
            {
                return RedirectToAction("Index", "Product");
            }

            var productDto = new ProductDto()
            {
                Name = product.Name,
                Brand = product.Brand,
                Category = product.Category,
                Price = product.Price,
                Description = product.Description,
            };

            ViewData["ProductId"] = product.Id;
            ViewData["ImageFileName"] = product.ImageFileName;
            ViewData["CreatedAt"] = product.CreatedAt.ToString("MM/dd/yyyy");

            return View(productDto);
        }


        [HttpPost]
        public IActionResult Edit(int id, ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                ViewData["ProductId"] = id;
                ViewData["ImageFileName"] = productDto.ImageFileName;
                ViewData["CreatedAt"] = productDto.CreatedAt.ToString("MM/dd/yyyy");
                return View(productDto);
            }

            var product = context.Products.Find(id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }

            // Update the product properties
            product.Name = productDto.Name;
            product.Brand = productDto.Brand;
            product.Category = productDto.Category;
            product.Price = productDto.Price;
            product.Description = productDto.Description;

            // Handle the image upload if a new image is provided
            if (productDto.ImageFile != null)
            {
                // Save the new image
                string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(productDto.ImageFile.FileName);
                string imageFullPath = Path.Combine(environment.WebRootPath, "Products", newFileName);

                using (var stream = new FileStream(imageFullPath, FileMode.Create))
                {
                    productDto.ImageFile.CopyTo(stream);
                }

                // Delete the old image
                var oldImagePath = Path.Combine(environment.WebRootPath, "Products", product.ImageFileName);
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }

                // Update product's image file name
                product.ImageFileName = newFileName;
            }

            // Save changes to the database
            context.Products.Update(product);
            context.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var product = context.Products.Find(id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }

            var productDto = new ProductDto
            {
                Name = product.Name,
                Brand = product.Brand,
                Category = product.Category,
                Price = product.Price,
                Description = product.Description,
                ImageFileName = product.ImageFileName
            };

            ViewData["ProductId"] = product.Id;
            ViewData["ImageFileName"] = product.ImageFileName;

            return View(productDto);
        }


        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = context.Products.Find(id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }

            // Delete the image file if it exists
            var imagePath = Path.Combine(environment.WebRootPath, "Products", product.ImageFileName);
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }

            // Remove the product from the database
            context.Products.Remove(product);
            context.SaveChanges();

            return RedirectToAction("Index");
        }





    }
}
