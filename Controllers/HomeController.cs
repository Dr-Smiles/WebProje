using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebProje.Data;
using WebProje.Models;
using Microsoft.AspNetCore.Session;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Localization;
using System.Text;

namespace WebProje.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ProductContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IStringLocalizer<HomeController> _localizer;

    public HomeController(ILogger<HomeController> logger, ProductContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IStringLocalizer<HomeController> localizer)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
        _localizer = localizer;
    }

    [HttpPost]
    public IActionResult ChangeLanguage(string culture, string returnUrl)
    {
        Response.Cookies.Append(
        CookieRequestCultureProvider.DefaultCookieName,
        CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
            new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddDays(7)
            }
        );
 
        return LocalRedirect(returnUrl);
    }

    [Route("/api/[Controller]")]
    [HttpGet]
    public FileResult download()
    {
        //get all products
        var String = JsonSerializer.Serialize(_context.Product);
        return File(Encoding.ASCII.GetBytes(String), "text/plain", "Product.txt");
    }

    public IActionResult login()
    {
        return View();
    }


    [Authorize(Roles = "Admin")]
    public IActionResult admin()
    {
        return View();
    }

    public IActionResult Index()
    {
        //ContextSeed.SeedRolesAsync(_userManager, _roleManager).Wait();
        ViewBag.Products = _context.Product.Where(x => x.name.ToLower().Contains("çekil") == false).OrderBy(x => Guid.NewGuid()).Take(20);
        if (HttpContext.Session.GetString("cart") == null)
        {
            cart cart = new cart();
            _context.cart.Add(cart);
            HttpContext.Session.SetString("cart", cart.id.ToString());
        }
        _logger.LogInformation(HttpContext.Session.GetString("cart"));

        return View();
    }


    public ActionResult addToCart(int id)
    {
        var product = _context.Product.Find(id);
        if (product == null)
        {
            return NotFound();
        }
        var cart = HttpContext.Session.GetString("cart");
        if (cart == null)
        {
            cart = JsonSerializer.Serialize(new List<Product>());
        }
        var cartList = JsonSerializer.Deserialize<List<Product>>(cart);
        cartList.Add(product);
        HttpContext.Session.SetString("cart", JsonSerializer.Serialize(cartList));
        return RedirectToAction("Index");
    }

    public IActionResult cart()
    {

        return View();
    }

    public IActionResult checkout()
    {
        return View();
    }

    static int oldCatagoryId = -1;
    public IActionResult shop(int? catagoryId, int? pageNumber)
    {
        ViewBag.Catagories = _context.Catagory.ToList();
        if (catagoryId == null && oldCatagoryId != -1){
            catagoryId = oldCatagoryId;
        }
        else if (catagoryId != null){
            oldCatagoryId = (int)catagoryId;
        }

        if (pageNumber == null){
            pageNumber = 1;
        }

        if (catagoryId == null){
            ViewBag.Product = _context.Product.Where(x => x.name.ToLower().Contains("çekil") == false).Skip(((int)pageNumber - 1) * 20).Take(20);
            ViewBag.ProductCount = _context.Product.Count() / 20;
        }
        else if (catagoryId != null){
            ViewBag.Product = _context.Product.Where(x => x.catagory.id == catagoryId && x.name.ToLower().Contains("çekil") == false).Skip(((int)pageNumber - 1) * 20).Take(20);
            ViewBag.ProductCount = _context.Product.Where(x => x.catagory.id == catagoryId && x.name.ToLower().Contains("çekil") == false).Count() / 20;
        }

        return View();
    }

    public IActionResult productdetails(int productID)
    {
        ViewBag.Product = _context.Product.Where(x => x.id == productID).FirstOrDefault();

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
