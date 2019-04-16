using System.Linq;
using LoginRegistration.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoginRegistration.Controllers
{
  public class VillainController : Controller
  {
    private DemoContext dbContext;
    public VillainController(DemoContext context)
    {
      dbContext = context;
    }


    [HttpGet("home")]
    public IActionResult Home()
    {
      int? villainId = HttpContext.Session.GetInt32("VillainId");
      if (villainId is null) return RedirectToAction("Index", "Login");

      Home model = CreateHomeModel((int)villainId);
      return View(model);
    }

    [HttpPost("newplan")]
    public IActionResult NewPlan(NewPlan form)
    {
      int? villainId = HttpContext.Session.GetInt32("VillainId");
      if (villainId is null) return RedirectToAction("Index", "Login");

      if (ModelState.IsValid)
      {
        Plan planB = new Plan()
        {
          Content = form.Content,
          Duration = form.Duration,
          Cost = form.Cost,
          VillainId = (int)villainId
        };

        dbContext.Plans.Add(planB);
        dbContext.SaveChanges();
        return RedirectToAction("Home", "Villain");
      }
      return View("Home", CreateHomeModel((int)villainId)); 
    }

    [HttpGet("create-group")]
    public IActionResult CreateGroup()
    {
      int? villainId = HttpContext.Session.GetInt32("VillainId");
      if (villainId is null) return RedirectToAction("Index", "Login");

      return View();
    }

    [HttpPost("newgroup")]
    public IActionResult NewGroup(NewGroup form)
    {
      int? villainId = HttpContext.Session.GetInt32("VillainId");
      if (villainId is null) return RedirectToAction("Index", "Login");

      if (ModelState.IsValid)
      {
        EvilGroup groupB = new EvilGroup()
        {
          Name = form.Name
        };
        dbContext.EvilGroups.Add(groupB);
        dbContext.SaveChanges();

        return RedirectToAction("Home", "Villain");
      }

      return View("CreateGroup");

    }

    [HttpGet("add/{groupId}")]
    public IActionResult AddGroup(int groupId)
    {
      int? villainId = HttpContext.Session.GetInt32("VillainId");
      if (villainId is null) return RedirectToAction("Index", "Login");

      VillainEvilGroup villainevilgroupB = new VillainEvilGroup()
      {
        VillainId = (int)villainId,
        EvilGroupId = groupId
      };
      dbContext.VillainEvilGroups.Add(villainevilgroupB);
      dbContext.SaveChanges();

      return RedirectToAction("Home", "Villain");
    }

    public Home CreateHomeModel(int villainId)
    {
      Home model = new Home();
      model.AllPlans = dbContext.Plans.Where(p => p.VillainId == villainId).ToList();
      model.AllGroups = dbContext.EvilGroups.ToList();
      model.Villain = dbContext.Villains
        .Include(v => v.VillainEvilGroups)
        .ThenInclude(veg => veg.EvilGroup)
        .FirstOrDefault(x => x.VillainId == villainId);

      return model;
    }

  }
}
