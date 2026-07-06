using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Code.Models;
using Code.Data;

namespace Code.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly AppDbContext _context;

    public HomeController(ILogger<HomeController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    public IActionResult Index()
    {
        var allJournals = _context.Journals.ToList();

        ViewData["JournalCount"] = _context.Journals.Count();
        return View(allJournals);
    }

    public IActionResult NewJournal()
    {
        return View();
    }

    public IActionResult NewJournalForm( JournalDb model)
    {
        _context.Journals.Add(model);
        _context.SaveChanges();
        _logger.LogInformation("New journal created.");

        return RedirectToAction("Index");
    }

    public IActionResult EditJournal(JournalDb model)
    {
        //editing ->loading the journal to edit
        _context.Journals.Update(model);
        _context.SaveChanges();
        _logger.LogInformation("Journal edited.");

        var journalinDb = _context.Journals.SingleOrDefault(entry => entry.Id == model.Id);
        return RedirectToAction("Index");
    }

    public IActionResult DeleteJournal(JournalDb model)
    {
        var journalinDb = _context.Journals.SingleOrDefault(entry => entry.Id == model.Id);
        _context.Journals.Remove(journalinDb);
        _context.SaveChanges();

        _logger.LogInformation("Journal deleted.");

        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
