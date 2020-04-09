using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges
{
    public class BadgesContent
    {
        public int BadgeId { get; set; } //Key//
        public string DoorId { get; set; } //Value//

        public BadgesContent() { }

        public BadgesContent(int badgeId, string doorId)
        {
            BadgeId = badgeId;
            DoorId = doorId;
        }
    }
}
