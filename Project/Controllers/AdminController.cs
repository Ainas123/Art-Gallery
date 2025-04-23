using Art_Gallery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Art_Gallery.Controllers
{
    public class AdminController : Controller
    {
        
        private artGallery _context;
        private readonly IWebHostEnvironment _env;
        public AdminController(artGallery context, IWebHostEnvironment env)
        {
            _env = env;
            _context = context;
        }
        public IActionResult Index()
        {
            string admin_session = HttpContext.Session.GetString("admin_session");
            if (admin_session != null)
            {
                // total user count
                int userCount = _context.userTb.Count();
                ViewBag.UserCount = userCount;

                // total category count
                int catCount = _context.categoryTb.Count();
                ViewBag.CatCount = catCount;

                // total art count
                int artCount = _context.productTbs.Count();
                ViewBag.ArtCount = artCount;

                // total category count
                /*int artCount = _context..Count();
                ViewBag.ArtCount = artCount;*/

                // total feedback count
                int feedCount = _context.feedbackTbs.Count();
                ViewBag.FeedCount = feedCount;

               /* // total feedback count
                int paymentCount = _context.feedbackTbs.Count();
                ViewBag.PaymentCount = feedCount;*/

                return View();
            }
            else
            {
                return RedirectToAction("login");
            }

        }
       
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string adminName, string adminPassword)
        {
            var row = _context.adminTb.FirstOrDefault(a => a.admin_name == adminName);
            if (row != null && row.admin_password == adminPassword)
            {
                HttpContext.Session.SetString("admin_session", row.admin_id.ToString());
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.message = "Incorrect Username or Password";
                return View();
            }

        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("admin_session");
            return RedirectToAction("login");
        }
        // Admin Profile //
        public IActionResult Profile()
        {
            var adminId = HttpContext.Session.GetString("admin_session");
            var row = _context.adminTb.Where(a => a.admin_id == int.Parse(adminId)).ToList();
            return View(row);
        }
        [HttpPost]
        public IActionResult Profile(AdminTb admin)
        {
            _context.adminTb.Update(admin);
            _context.SaveChanges();
            return RedirectToAction("Profile");
        }
        [HttpPost]
        public IActionResult ChangeProfileImage(IFormFile admin_image, AdminTb admin)
        {
            string ImagePath = Path.Combine(_env.WebRootPath, "admin-image", admin_image.FileName);
            FileStream fs = new FileStream(ImagePath, FileMode.Create);
            admin_image.CopyTo(fs);
            admin.admin_image = admin_image.FileName;
            _context.adminTb.Update(admin);
            _context.SaveChanges();
            return RedirectToAction("Profile");
        }
        // Manage User //
        public IActionResult fetchUser()
        {
            return View(_context.userTb.ToList());
        }
        public IActionResult userDetails(int id)
        {
            return View(_context.userTb.FirstOrDefault(c => c.user_id == id));
        }
        public IActionResult userUpdate(int id)
        {
            return View(_context.userTb.Find(id));
        }
        [HttpPost]
        public IActionResult userUpdate(UserTb user,IFormFile user_image)
        {
            string fileName = Path.GetFileName(user_image.FileName);
            string filePath = Path.Combine(_env.WebRootPath, "user_image", fileName);
            FileStream fs = new FileStream(filePath, FileMode.Create);
            user_image.CopyTo(fs);

            user.user_image = fileName;
            _context.userTb.Update(user);
            _context.SaveChanges();
            return RedirectToAction("fetchuser");
        }
        public IActionResult deletePermission(int id)
        {
            return View(_context.userTb.FirstOrDefault(c => c.user_id == id));
        }
        public IActionResult userDelete(int id)
        {
            var user = _context.userTb.Find(id);
            _context.userTb.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("fetchuser");
        }
        public IActionResult fetchCategory()
        {
            return View(_context.categoryTb.ToList());
        }
        // Category Section //
        public IActionResult addCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult addCategory(CategoryTb cat)
        {
            _context.categoryTb.Add(cat);
            _context.SaveChanges();
            return RedirectToAction("fetchCategory");
        }
        public IActionResult updateCategory(int id)
        {
            var category = _context.categoryTb.Find(id);
            return View(category);
        }
        [HttpPost]
        public IActionResult updateCategory(CategoryTb cat)
        {
            _context.categoryTb.Update(cat);
            _context.SaveChanges();
            return RedirectToAction("fetchCategory");
        }
        public IActionResult deletePermissionCategory(int id)
        {
            return View(_context.categoryTb.FirstOrDefault(c => c.category_id == id));
        }
        public IActionResult deleteCategory(int id)
        {
            var category = _context.categoryTb.Find(id);
            _context.categoryTb.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("fetchCategory");
        }
        // Manage Product
        public IActionResult fetchProduct()
        {
            return View(_context.productTbs.ToList());
        }
        public IActionResult addProduct()
        {
            List<CategoryTb> categories = _context.categoryTb.ToList();
            ViewData["category"] = categories;
            return View();
        }
        [HttpPost]
        public IActionResult addProduct(IFormFile product_image,ProductTb prod)
        {
            string fileName = Path.GetFileName(product_image.FileName);
            string filePath = Path.Combine(_env.WebRootPath, "product_images", fileName);
            FileStream fs = new FileStream(filePath, FileMode.Create);
            product_image.CopyTo(fs);

            prod.product_image = fileName;
            _context.productTbs.Add(prod);
            _context.SaveChanges();
            return View();
        }
        public IActionResult productDetails(int id)
        {
            return View(_context.productTbs.Include(p=>p.Category).FirstOrDefault(p=>p.product_id==id));
        }
        public IActionResult deletePermissionProduct(int id)
        {
            return View(_context.productTbs.FirstOrDefault(c => c.product_id == id));
        }
        public IActionResult deleteProduct(int id)
        {
            var product = _context.productTbs.Find(id);
            _context.productTbs.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("fetchProduct");
        }
        public IActionResult updateProduct(int id)
        {
            List<CategoryTb> categories = _context.categoryTb.ToList();
            ViewData["category"] = categories;

            var product = _context.productTbs.Find(id);

            ViewBag.selectedCategoryId = product.cat_id;

            return View(product);
        }
        [HttpPost]
        public IActionResult updateProduct(ProductTb product)
        {
            _context.productTbs.Update(product);
            _context.SaveChanges();
            return RedirectToAction("fetchProduct");
        }
        [HttpPost]
        public IActionResult ChangeProductImage(IFormFile product_image, ProductTb product)
        {
            string ImagePath = Path.Combine(_env.WebRootPath, "product_images", product_image.FileName);
            FileStream fs = new FileStream(ImagePath, FileMode.Create);
            product_image.CopyTo(fs);
            product.product_image = product_image.FileName;
            _context.productTbs.Update(product);
            _context.SaveChanges();
            return RedirectToAction("fetchProduct");
        }
        // Contact Page //
        public IActionResult fetchContact()
        {
            return View(_context.feedbackTbs.ToList());
        }
        public IActionResult deletePermissionContact(int id)
        {
            return View(_context.feedbackTbs.FirstOrDefault(f => f.feedback_id == id));
        }
        public IActionResult deleteContact(int id)
        {
            var feedback = _context.feedbackTbs.Find(id);
            _context.feedbackTbs.Remove(feedback);
            _context.SaveChanges();
            return RedirectToAction("fetchContact");
        }
        // Add to cart //
        public IActionResult fetchCart()
        {
            var cart = _context.cartTb.Include(c=>c.products).Include(c => c.user).ToList();
            return View(cart);
        }
        public IActionResult deletePermissionCart(int id)
        {
            return View(_context.cartTb.FirstOrDefault(c => c.cart_id == id));
        }
        public IActionResult deleteCart(int id)
        {
                var cart = _context.cartTb.Find(id);
                _context.cartTb.Remove(cart);
                _context.SaveChanges();
                return RedirectToAction("fetchCart");
        }


























    }
}
    
