using DELAVEGA_MVC5.Models;

namespace DELAVEGA_MVC5.Services;

public class PortfolioService
{
    private readonly List<Project> _projects;

    public PortfolioService()
    {
        _projects = new List<Project>
        {
            new Project
            {
                Id = "web-store",
                Title = "Modern Web Store",
                Summary = "A full-stack e-commerce storefront using ASP.NET Core, Bootstrap, and a simple in-memory product catalog.",
                Role = "Frontend + Backend",
                Technologies = "ASP.NET Core, Razor, Bootstrap, C#",
                Link = "https://example.com/web-store"
            },
            new Project
            {
                Id = "team-portal",
                Title = "Team Collaboration Portal",
                Summary = "A portfolio portal with project tracking, contact forms, and cross-platform responsive design.",
                Role = "Design + Implementation",
                Technologies = "ASP.NET Core, Razor Pages, JavaScript",
                Link = "https://example.com/team-portal"
            },
            new Project
            {
                Id = "marketing-site",
                Title = "Marketing Landing Page",
                Summary = "A polished landing page showcasing services, customer testimonials, and smooth navigation.",
                Role = "UI/UX and full-stack integration",
                Technologies = "C#, MVC, Bootstrap, HTML/CSS",
                Link = "https://example.com/marketing-site"
            }
        };
    }

    public IReadOnlyList<Project> GetProjects() => _projects;

    public Project? GetProject(string id) => _projects.FirstOrDefault(p => p.Id == id);

    public void AddProject(Project project)
    {
        project.Id = Guid.NewGuid().ToString("N");
        _projects.Add(project);
    }

    public bool UpdateProject(Project project)
    {
        var existing = GetProject(project.Id);
        if (existing is null)
        {
            return false;
        }

        existing.Title = project.Title;
        existing.Summary = project.Summary;
        existing.Role = project.Role;
        existing.Technologies = project.Technologies;
        existing.Link = project.Link;

        return true;
    }

    public bool DeleteProject(string id)
    {
        var project = GetProject(id);
        return project is not null && _projects.Remove(project);
    }
}
