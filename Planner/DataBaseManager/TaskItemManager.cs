using Planner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;

namespace Planner.DataBaseManager
{
    public class TaskItemManager
    {
        // получение всех пунктов
        public static async Task<List<TaskItem>> GetItemsAsync()
        {
            var result = new List<TaskItem>();
            using (DataBaseContext db = new DataBaseContext())
            {
                try
                {
                    result = await db.Items.ToListAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка валидации" + ex.Message.ToString());
                    Console.ReadLine();
                    result = null;
                }
            }
            return result;
        }
        // получение одного пункта
        public static async Task<TaskItem> GetAsync(Guid id)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var res = await db.Items.ToListAsync();

                foreach (var item in db.Items)
                {
                    if (item.Id == id)
                        return item;
                }
                return null;
            }
        }
        //добавление нового пункта
        public static async Task<bool> AddItemAsync(TaskItem item)
        {
            if (item != null)
            {
                item.Id = Guid.NewGuid();
                item.Datetime = DateTime.Now;
                using (DataBaseContext db = new DataBaseContext())
                {
                    db.Items.Add(item);
                    await db.SaveChangesAsync();
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        //удаление пункта
        public static async Task<bool> DeleteItemAsync(Guid id)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var temp = new TaskItem();
                foreach (var item in db.Items)
                {
                    if (item.Id == id)
                    {
                        temp = item;
                    }
                }
                db.Items.Remove(temp);
                await db.SaveChangesAsync();
                return true;
            }
        }
        //редактирование пункта
        public static async Task<bool> EditItemAsync(TaskItem item)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var item2 = await db.Items.SingleOrDefaultAsync(x => x.Id == item.Id);
                if (item2 != null)
                {
                    item2.ItemContent = item.ItemContent;
                    item2.Datetime = DateTime.Now;
                    await db.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}