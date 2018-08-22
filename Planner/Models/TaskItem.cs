using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Planner.Models
{
    public class TaskItem
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Заголовок")]
        public string ItemContent { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Дата создания пункта")]
        public DateTime Datetime { get; set; }
    }
}