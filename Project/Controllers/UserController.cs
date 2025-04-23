using Art_Gallery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Art_Gallery.Controllers
{
    public class UserController : Controller
    {
        private artGallery _context;
        private readonly IWebHostEnvironment _env;
        public UserController(artGallery context, IWebHostEnvironment env)
        {
            _env = env;
            _context = context;
            
        }
        public IActionResult Index()
        {
            ViewBag.checkSession = HttpContext.Session.GetString("userSession");
            return View();
        }
        // User Login //
        public IActionResult userLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult userLogin(string userEmail, string userPassword)
        {
            var user = _context.userTb.FirstOrDefault(c=>c.user_email == userEmail);
            if(user!=null && user.user_password== userPassword)
            {
                HttpContext.Session.SetString("userSession", user.user_id.ToString());
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.message = "Incorrect Name or Password";
                return View();
            }
        }
        public IActionResult userRegistration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult userRegistration(UserTb user)
        {
            _context.userTb.Add(user);
            _context.SaveChanges();
            return RedirectToAction("userLogin");
        }
        public IActionResult userLogout()
        {
            HttpContext.Session.Remove("userSession");
            return RedirectToAction("index");
        }
        // User Profile //

        public IActionResult userProfile()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("userSession")))
            {
                return RedirectToAction("userLogin");
            }
            else
            {
                var userId = HttpContext.Session.GetString("userSession");
                var row = _context.userTb.Where(c => c.user_id == int.Parse(userId)).ToList();
                return View(row);
            }
        }
        [HttpPost]
        public IActionResult userProfile(UserTb user, IFormFile user_image)
        {
            string fileName = Path.GetFileName(user_image.FileName);
            string filePath = Path.Combine(_env.WebRootPath, "user_image", user_image.FileName);
            FileStream fs = new FileStream(filePath, FileMode.Create);
            user_image.CopyTo(fs);
            user.user_image = fileName;
            _context.userTb.Update(user);
            _context.SaveChanges();
            return RedirectToAction("userProfile");
        }

        // Contact Page //
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(FeedbackTb contact)
        {
            TempData["message"] = "Thank You For Your Feedback";
            _context.feedbackTbs.Add(contact);
            _context.SaveChanges();
            return RedirectToAction("contact");
        }
        // Product Details //
        public IActionResult productDetails(int id)
        {
            var products = _context.productTbs.Where(p => p.product_id == id).ToList();
            return View(products);
        }
        // AddtoCart//
        public IActionResult AddtoCart(int prod_id, CartTb cart)
        {
            string isLogin = HttpContext.Session.GetString("userSession");
            if (isLogin != null)
            {
                cart.prod_id = prod_id;
                cart.cust_id = int.Parse(isLogin);
                cart.product_quantity = 1;
                cart.cart_status = 0;
                _context.cartTb.Add(cart);
                _context.SaveChanges();
                TempData["message"] = "Product Succesfully added in Cart";
                return RedirectToAction("Arts");
                
            }
            else
            {
                return RedirectToAction("userLogin");

            }
        }
        // Add product
       /* public IActionResult fetchuserProduct()
        {
            return View(_context.productTbs.ToList());
        }
        public IActionResult adduserProduct()
        {
            List<CategoryTb> categories = _context.categoryTb.ToList();
            ViewData["category"] = categories;
            return View();
        }
        [HttpPost]
        public IActionResult adduserProduct(IFormFile uproduct_image, User_ProductTb prod)
        {
            string fileName = Path.GetFileName(uproduct_image.FileName);
            string filePath = Path.Combine(_env.WebRootPath, "uproduct_image", fileName);
            FileStream fs = new FileStream(filePath, FileMode.Create);
            uproduct_image.CopyTo(fs);

            prod.uproduct_image = fileName;
            _context.user_productTb.Add(prod);
            _context.SaveChanges();
            return View();
        }
*/

        // Product //
        public IActionResult Arts()
        {
            List<CategoryTb> category = _context.categoryTb.ToList();
            ViewData["category"] = category;

            List<ProductTb> products = _context.productTbs.ToList();
            ViewData["product"] = products;
            return View();
        }
        // About Page //
        public IActionResult About()
        {
            return View();
        }
       

    }
}
