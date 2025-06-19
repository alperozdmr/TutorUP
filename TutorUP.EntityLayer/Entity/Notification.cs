using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorUP.EntityLayer.Entity
{
    [Serializable]
    public class Notification
    {
        public int NotificationID { get; set; }
        
        public string SenderName { get; set; }
        [ForeignKey(nameof(AppUser))]
        public int ToID { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        public AppUser AppUser { get; set; }
    }
}
