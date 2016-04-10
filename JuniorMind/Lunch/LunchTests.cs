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
            Assert.AreEqual(12, ComputerNumberOfDaysBetweenTwoMeetings(4, 6, 1));
        }

        [TestMethod]
        public void SecondMeeting()
        {
            Assert.AreEqual(24, ComputerNumberOfDaysBetweenTwoMeetings(4, 6, 2));
        }

        [TestMethod]
        public void SmallestCommonMultiple()
        {
            Assert.AreEqual(12, CalculateSmallestCommonMultiple(4, 6));
        }

        int ComputerNumberOfDaysBetweenTwoMeetings(int firstPersonFrequency, int secondPersonFrequency, int meetingNumber)
        {
            int daysBetweenMeetings = CalculateSmallestCommonMultiple(firstPersonFrequency, secondPersonFrequency);
            return daysBetweenMeetings * meetingNumber;
        }

        private int CalculateSmallestCommonMultiple(int firstNumber, int secondNumber)
        {
            int product = firstNumber * secondNumber;
            while(firstNumber != secondNumber)
            {
                if (firstNumber > secondNumber)
                    firstNumber -= secondNumber;
                else
                    secondNumber -= firstNumber;
            }
            return product / firstNumber;
        }
    }
}
