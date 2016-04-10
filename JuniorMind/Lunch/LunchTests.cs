using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*Tu și prietenul tău vă întâlniți întâmplător la restaurant. În timpul mesei de prânz din discuția avută cu el, afli că el
ia prânzul la acel restaurant din 4 în 4 zile. Când te vei întâlni din nou cu el, dacă tu iei prânzul la restaurantul 
respectiv odată la 6 zile?*/

namespace Lunch
{
    [TestClass]
    public class LunchTests
    {
        [TestMethod]
        public void FirstMeeting()
        {
            Assert.AreEqual(12, ComputerNumberOfDaysBetweenTwoMeetings(4, 6));
        }
        
        int ComputerNumberOfDaysBetweenTwoMeetings(int firstPersonFrequency, int secondPersonFrequency)
        {
            int daysBetweenMeetings = secondPersonFrequency;
            while(!IsMeeting(firstPersonFrequency, secondPersonFrequency, daysBetweenMeetings))
            {
                daysBetweenMeetings++;
            }

            return daysBetweenMeetings;
        }

        private bool IsMeeting(int firstPersonFrequency, int secondPersonFrequency, int daysBetweenMeetings)
        {
            return daysBetweenMeetings % firstPersonFrequency == 0 && daysBetweenMeetings % secondPersonFrequency == 0;
        }
    }
}
