using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
/*Pentru un număr dat dacă e multiplu de 3 rezultatul trebuie să fie Fizz iar dacă e multiplu de 5 rezultatul trebuie să
fie Buzz. Dacă e multiplu de 3 și de 5 rezultatul trebuie să fie FizzBuzz.*/
namespace FizzBuzz
{
    [TestClass]
    public class FizzBuzzTests
    {
        [TestMethod]
        public void MultipleOfThree()
        {
            Assert.AreEqual("Fizz", CheckDivisibility(9));
        }

        [TestMethod]
        public void MultipleOfFive()
        {
            Assert.AreEqual("Buzz", CheckDivisibility(10));
        }

        [TestMethod]
        public void MultipleOfThreeAndFive()
        {
            Assert.AreEqual("FizzBuzz", CheckDivisibility(15));
        }

        [TestMethod]
        public void NotAMultiple()
        {
            Assert.AreEqual("7", CheckDivisibility(7));
        }
        string CheckDivisibility(int number)
        {
            if ((number % 3 == 0) && (number % 5 == 0))
                return ("FizzBuzz");
            if (number % 3 == 0)
                return "Fizz";
            else 
                if(number % 5 == 0)
                    return "Buzz";
            return number.ToString();    
        }
    }
}
