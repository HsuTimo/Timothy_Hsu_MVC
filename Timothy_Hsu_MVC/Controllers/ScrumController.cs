using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Timothy_Hsu_MVC.Interfaces;
using Timothy_Hsu_MVC.Models;

namespace Timothy_Hsu_MVC.Controllers
{
    public class ScrumController : Controller
    {
        private readonly IRepository _repository;
        public ScrumController(IRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.UserList = new SelectList(await _repository.SelectAllAsync<ScrumUser>(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(ScrumUser user)
        {
            var selectedUser = await _repository.SelectByIdAsync<ScrumUser>(user.Id);
            TempData["SelectedUserName"] = selectedUser.Name;
            TempData["SelectedUserId"] = selectedUser.Id;
            return RedirectToAction(nameof(ScrumBoard));
        }
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(ScrumUser newUser)
        {
            await _repository.CreateAsync(newUser);
            TempData["SelectedUserName"] = newUser.Name;
            TempData["SelectedUserId"] = newUser.Id;
            return RedirectToAction(nameof(ScrumBoard));
        }
        public async Task<IActionResult> ScrumBoard()
        {
            var list = await _repository.SelectAllAsync<ScrumTask>();
            return View(list);
        }
        public async Task<IActionResult> CheckOutTask(int id)
        {
            var toCheckOut = await _repository.SelectByIdAsync<ScrumTask>(id);
            toCheckOut.ScrumStatusId = 2;
            toCheckOut.ScrumUserId = (int)TempData.Peek("SelectedUserId");
            await _repository.UpdateAsync(toCheckOut);
            return RedirectToAction(nameof(ScrumBoard));
        }
        public async Task<IActionResult> UndoCheckoutTask(int id)
        {
            var toUndo = await _repository.SelectByIdAsync<ScrumTask>(id);
            toUndo.ScrumStatusId = 1;
            toUndo.ScrumUserId = null;
            await _repository.UpdateAsync(toUndo);
            return RedirectToAction(nameof(ScrumBoard));
        }
        public async Task<IActionResult> CompleteTask(int id)
        {
            var toComplete = await _repository.SelectByIdAsync<ScrumTask>(id);
            toComplete.ScrumStatusId = 3;
            await _repository.UpdateAsync(toComplete);
            return RedirectToAction(nameof(ScrumBoard));
        }
        public async Task<IActionResult> UndoCompleteTask(int id)
        {
            var toUndo = await _repository.SelectByIdAsync<ScrumTask>(id);
            toUndo.ScrumStatusId = 2;
            await _repository.UpdateAsync(toUndo);
            return RedirectToAction(nameof(ScrumBoard));
        }
        public IActionResult CreateTask()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTask(ScrumTask task)
        {
            task.ScrumStatusId = 1;
            await _repository.CreateAsync(task);
            return RedirectToAction(nameof(ScrumBoard));
        }
        [HttpGet]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var toDelete = await _repository.SelectByIdAsync<ScrumTask>(id);
            return View(toDelete);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteTask(ScrumTask scrumTask)
        {
            await _repository.DeleteAsync(scrumTask);
            return RedirectToAction(nameof(ScrumBoard)); 
        }
        [HttpGet]
        public async Task<IActionResult> EditTask(int id)
        {
            var toEdit = await _repository.SelectByIdAsync<ScrumTask>(id);
            return View(toEdit);
        }
        [HttpPost]
        public async Task<IActionResult> EditTask(ScrumTask newScrumTask)
        {
            var toEdit = await _repository.SelectByIdAsync<ScrumTask>(newScrumTask.Id);
            toEdit.Title = newScrumTask.Title;
            toEdit.Description = newScrumTask.Description;
            await _repository.UpdateAsync(toEdit);
            return RedirectToAction(nameof(ScrumBoard));
        }

    }
}
