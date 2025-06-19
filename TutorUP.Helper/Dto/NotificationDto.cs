using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorUP.Helper.Dto
{
    public class NotificationDto
    {
        public int NotificationID { get; set; }
        public string SenderName { get; set; }
        public int ToID { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

    }
}
