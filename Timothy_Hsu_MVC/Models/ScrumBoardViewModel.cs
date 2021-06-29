using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timothy_Hsu_MVC.Models
{
    public class ScrumBoardViewModel
    {
        public IEnumerable<ScrumTask> ScrumTasks { get; set; }
        public ScrumTask NewTask { get; set; }
        public ScrumBoardViewModel()
        {
        }
    }
}
