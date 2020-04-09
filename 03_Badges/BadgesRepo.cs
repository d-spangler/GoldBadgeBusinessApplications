using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges
{
    public class BadgesRepo
    {
        protected readonly Dictionary<int, string> badgeDirectory = new Dictionary<int, string>();

        public bool AddNewBadgeToDirectory(int badgeId, string doorId)
        {
            int startingCount = badgeDirectory.Count;

            if (!badgeDirectory.ContainsKey(badgeId))
            {
                badgeDirectory.Add(badgeId, doorId);
                startingCount++;
            }
            else
            {
                badgeDirectory[badgeId] = doorId;
            }

            bool wasAdded = (badgeDirectory.Count < startingCount) ? true : false;
            return wasAdded;

        }

        public Dictionary<int, string> GetBadges()
        {
            return badgeDirectory;
        }

        //Found a video on YouTube trying to explain this, doesn't work for my application...//
        /*public T GetAnyValue<T>(int badgeId)
        {
            object obj;
            T retType;

            badgeDirectory.TryGetValue(badgeId, out obj);

            try
            {
                retType = (T)obj;
            }
            catch
            {
                retType = default(T);
            }
            return retType;
        }*/

        public BadgesContent GetBadgeById(int badgeId)
        {
            var badge = new BadgesContent(badgeId, badgeDirectory[badgeId]);
            
            if (badge.BadgeId == badgeId)
            {
                return badge;
            }


            return null;
        }

        public BadgesContent AddDoorAccessToId(int badgeId, string updatedDoorId, BadgesContent newDoorAccess)
        {
            BadgesContent idToAlterAccess = GetBadgeById(badgeId);

            if(idToAlterAccess != null)
            {
                newDoorAccess.DoorId = badgeDirectory[badgeId] + "," + updatedDoorId;
                var badge = new BadgesContent(badgeId, newDoorAccess.DoorId);
            }
            return null;
        }

        public BadgesContent RemoveDoorAccessToId(int badgeId, string doorToBeRemoved, BadgesContent newDoorAccess)
        {
            BadgesContent idToAlterAccess = GetBadgeById(badgeId);

            if (idToAlterAccess != null)
            {
                newDoorAccess.DoorId = badgeDirectory[badgeId].Replace(doorToBeRemoved, " ");
                var badge = new BadgesContent(badgeId, newDoorAccess.DoorId);
            }
            return null;


        }

        public bool UpdateBadge(int badgeId, BadgesContent newDoorAccess)
        {
            BadgesContent oldBadge = GetBadgeById(badgeId);
            if(oldBadge != null)
            {
                oldBadge.BadgeId = newDoorAccess.BadgeId;
                oldBadge.DoorId = newDoorAccess.DoorId;

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteBadgeById(BadgesContent badgesContent, int badgeId)
        {
            bool deleteBadge = badgeDirectory.Remove(badgeId);
            return deleteBadge;
        }
    }
}
