using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timothy_Hsu_MVC.Models
{
    public class ScrumUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ScrumTask> ScrumTasks { get; set; }
    }
}
