using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP_LW5.Data;
using TP_LW5.Models;

namespace TP_LW5.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _dbContext;

    public HomeController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        return View(await _dbContext.Users.ToListAsync(cancellationToken: cancellationToken));
    }

    [HttpGet]
    public IActionResult Add()
    {
        var model = new User();
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromForm] User user, CancellationToken cancellationToken)
    {
        if (ModelState.IsValid)
        {
            await _dbContext.Users.AddAsync(user, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        return View(user);
    }

    [HttpGet("Update/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.FindAsync(new object[] { id }, cancellationToken);
        if (user is null)
        {
            return NotFound(id);
        }

        return View(user);
    }

    [HttpPost("Update/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromForm] User user, CancellationToken cancellationToken)
    {
        if (id != user.Id)
        {
            ModelState.AddModelError("Id", "Id doesn't equal.");
        }
        if (ModelState.IsValid)
        {
            _dbContext.Update(user);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        return View(user);
    }

    [HttpGet("Get/{id:int}")]
    public async Task<IActionResult> Get([FromRoute] int id, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.FindAsync(new object[] { id }, cancellationToken);
        if (user is null)
        {
            return NotFound(id);
        }

        return View(user);
    }

    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.FindAsync(new object[] { id }, cancellationToken);
        if (user is null)
        {
            return NotFound(id);
        }

        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return RedirectToAction(nameof(Index));
    }
}