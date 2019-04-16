using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoginRegistration.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace LoginRegistration.Controllers
{
  public class LoginController : Controller
  {
    private DemoContext dbContext;

    public LoginController(DemoContext context)
    {
      dbContext = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
      return View();
    }

    [HttpPost("register")]
    public IActionResult Register(Registration form)
    {
      if (ModelState.IsValid)
      {
        Villain newVillain = new Villain()
        {
          FirstName = form.FirstName,
          LastName = form.LastName,
          Email = form.Email,
          Password = form.Password
        };
        PasswordHasher<Villain> Hasher = new PasswordHasher<Villain>();
        newVillain.Password = Hasher.HashPassword(newVillain, newVillain.Password);

        dbContext.Villains.Add(newVillain);
        dbContext.SaveChanges();

        HttpContext.Session.SetInt32("VillainId", newVillain.VillainId);

        return RedirectToAction("Home", "Villain");
      }
      else
      {
        return View("Index");
      }
    }


    [HttpPost("login")]
    public IActionResult Login(Login form)
    {
      if (ModelState.IsValid)
      {
        Villain villainInDb = dbContext.Villains.FirstOrDefault(u => u.Email == form.LoginEmail);

        if (villainInDb is null)
        {
          ModelState.AddModelError("Email", "Invalid Email/Password");
          return View("Index");
        }

        else
        {
          var hasher = new PasswordHasher<Login>();
          var result = hasher.VerifyHashedPassword(form, villainInDb.Password, form.LoginPassword);
          if (result == 0)
          {
            ModelState.AddModelError("Email", "Invalid Email/Password");
            return View("Index");
          }
          HttpContext.Session.SetInt32("VillainId", villainInDb.VillainId);
          return RedirectToAction("Home", "Villain");
        }
      }
      return View("Index");
    }

    [HttpGet("logout")]
    public IActionResult Logout()
    {
      HttpContext.Session.Clear();
      return RedirectToAction("Index");
    }

  }
}
