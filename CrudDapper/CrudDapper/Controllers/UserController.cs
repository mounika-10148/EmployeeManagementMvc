using CrudDapper.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudDapper.Controllers
{
  public class UserController : Controller
{
    private readonly UserRepository _repo;

    public UserController(UserRepository repo)
    {
        _repo = repo;
    }

    public IActionResult Index()
    {
        var users = _repo.GetAll();
        return View(users);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public IActionResult Create(User user)
    {
        _repo.Add(user);
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var user = _repo.GetById(id);
        return View(user);
    }

    [HttpPost]
    public IActionResult Edit(User user)
    {
        _repo.Update(user);
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        var user = _repo.GetById(id);
        return View(user);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        _repo.Delete(id);
        return RedirectToAction("Index");
    }

  
}

    }

