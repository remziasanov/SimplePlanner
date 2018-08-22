using Planner.DataBaseManager;
using Planner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Planner.Controllers
{
    public class PlannerController : Controller
    {
        // GET: Planner
        public async Task<ActionResult> Index()
        {
            var resultlist = await TaskItemManager.GetItemsAsync();
            return View(resultlist);
        }
        [HttpGet]
        public ActionResult AddItem()
        {
            return View();

        }
        [HttpPost]
        public async Task<ActionResult> AddItem(TaskItem item)
        {
            await TaskItemManager.AddItemAsync(item);
            return RedirectToRoute(new { controller = "Planner", action = "Index" });
        }
        [HttpGet]
        public async Task<ActionResult> Delete(Guid id)
        {
            var item = await TaskItemManager.GetAsync(id);
            if (item != null)
            {
                return View(item);
            }
            else
            {
                var resultlist = await TaskItemManager.GetItemsAsync();
                return View(resultlist);
            }
        }
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            var item = await TaskItemManager.GetAsync(id);
            if (item == null)
            {
                return RedirectToRoute(new { controller = "Planner", action = "Index" });
            }
            else
            {
                await TaskItemManager.DeleteItemAsync(id);
                return RedirectToRoute(new { controller = "Planner", action = "Index" });
            }
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            var result =  await TaskItemManager.GetAsync(id);
            if (result == null)
            {
                return RedirectToAction("Index", "Planner");
            }
            else
            {
                return View(result);
            }
        }
        [HttpPost]
        public async Task<ActionResult> Edit(TaskItem item)
        {
            await TaskItemManager.EditItemAsync(item);
            //var result = TaskItemManager.GetItemsAsync();
            return RedirectToAction("../Planner/Index");
        }

    }
}