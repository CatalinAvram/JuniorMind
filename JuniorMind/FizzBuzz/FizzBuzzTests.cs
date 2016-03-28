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
        string CheckDivisibility(int number)
        {
            if ((number % 3 == 0) && (number % 5 == 0))
                return ("FizzBuzz");
            if (number % 3 == 0)
                return "Fizz";
            return "Buzz";   
        }
    }
}
