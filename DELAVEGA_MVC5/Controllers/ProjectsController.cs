using Microsoft.AspNetCore.Mvc;
using DELAVEGA_MVC5.Models;
using DELAVEGA_MVC5.Services;

namespace DELAVEGA_MVC5.Controllers;

public class ProjectsController : Controller
{
    private readonly PortfolioService _portfolioService;

    public ProjectsController(PortfolioService portfolioService)
    {
        _portfolioService = portfolioService;
    }

    public IActionResult Index()
    {
        ViewData["Title"] = "Projects";
        var projects = _portfolioService.GetProjects();
        return View(projects);
    }

    public IActionResult Details(string id)
    {
        var project = _portfolioService.GetProject(id);
        if (project is null)
        {
            return NotFound();
        }

        return View(project);
    }

    public IActionResult Create()
    {
        return View(new Project());
    }

    [HttpPost]
    public IActionResult Create(Project project)
    {
        if (!ModelState.IsValid)
        {
            return View(project);
        }

        _portfolioService.AddProject(project);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(string id)
    {
        var project = _portfolioService.GetProject(id);
        if (project is null)
        {
            return NotFound();
        }

        return View(project);
    }

    [HttpPost]
    public IActionResult Edit(Project project)
    {
        if (!ModelState.IsValid)
        {
            return View(project);
        }

        if (!_portfolioService.UpdateProject(project))
        {
            return NotFound();
        }

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(string id)
    {
        var project = _portfolioService.GetProject(id);
        if (project is null)
        {
            return NotFound();
        }

        return View(project);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(string id)
    {
        _portfolioService.DeleteProject(id);
        return RedirectToAction(nameof(Index));
    }
}
