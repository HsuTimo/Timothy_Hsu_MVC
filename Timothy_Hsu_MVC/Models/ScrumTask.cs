using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timothy_Hsu_MVC.Models
{
    public class ScrumTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ScrumStatusId { get; set; }
        public virtual ScrumStatus ScrumStatus { get; set; }
        public int? ScrumUserId { get; set; }
        public virtual ScrumUser ScrumUser { get; set; }
    }
}
