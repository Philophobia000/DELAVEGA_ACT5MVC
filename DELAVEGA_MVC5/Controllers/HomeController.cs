using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DELAVEGA_MVC5.Models;

namespace DELAVEGA_MVC5.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewData["Title"] = "Home";
        return View();
    }

    public IActionResult Contact()
    {
        ViewData["Title"] = "Contact";
        return View(new ContactForm());
    }

    [HttpPost]
    public IActionResult Contact(ContactForm form)
    {
        if (!ModelState.IsValid)
        {
            ViewData["Title"] = "Contact";
            return View(form);
        }

        ViewData["Title"] = "Contact";
        ViewBag.Message = "Thanks for reaching out! Your message was received successfully.";
        return View(new ContactForm());
    }

    public IActionResult Privacy()
    {
        ViewData["Title"] = "Privacy Policy";
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
