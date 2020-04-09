using _03_Badges;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Tests
{

    [TestClass]
    public class BadgesRepoTests
    {

        private BadgesContent _content;
        private BadgesRepo _repo;

        [TestInitialize]
        public void Arrange(int badgeId, string doorId)
        {
            _repo = new BadgesRepo();
            _content = new BadgesContent();
            _content.BadgeId = 55555;
            _content.DoorId = "A1";
            _repo.AddNewBadgeToDirectory(_content.BadgeId, _content.DoorId);
        }

        /*I couldn't get any of the TestMethods to work. Every time I tried they threw an error message of some kind.
        My biggest problem appears to be my BadgesRepo and the multiple parameters that I have for each method.
        I already rebuilt the repository three times and didn't feel like doing it again, my brain is shot.//
        I'm dreaming of this challenge and can't stop thinking about it. I've put my best foot forward and turning my
        attention to my portfolio. - Dylan */
    }
}
