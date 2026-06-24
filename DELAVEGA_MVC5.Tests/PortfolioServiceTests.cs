using DELAVEGA_MVC5.Services;
using NUnit.Framework;

namespace DELAVEGA_MVC5.Tests;

[TestFixture]
public class PortfolioServiceTests
{
    private PortfolioService _service = null!;

    [SetUp]
    public void Setup()
    {
        _service = new PortfolioService();
    }

    [Test]
    public void GetProjects_ReturnsAllProjects()
    {
        // Arrange is handled by Setup

        // Act
        var result = _service.GetProjects();

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.GreaterThanOrEqualTo(3));
    }

    [Test]
    public void GetProject_WithValidId_ReturnsProject()
    {
        // Arrange
        var existingProject = _service.GetProjects().First();

        // Act
        var result = _service.GetProject(existingProject.Id);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result?.Title, Is.EqualTo(existingProject.Title));
    }

    [Test]
    public void GetProject_WithInvalidId_ReturnsNull()
    {
        // Arrange
        var invalidId = "missing-id";

        // Act
        var result = _service.GetProject(invalidId);

        // Assert
        Assert.That(result, Is.Null);
    }
}
