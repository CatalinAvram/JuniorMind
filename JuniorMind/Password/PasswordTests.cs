using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
/*Scrie o funcție care generează o parolă de până la X caractere.
Funcția oferă ca și opțiuni:
    litere mici
    litere mari și numărul lor
*/
namespace Password
{
    public struct Password
    {
        public int passwordLength;
        public int nrOfSmallLetters;
        public int nrOfCapitalLetters;
        public int nrOfCiphers;
        public int nrOfSymbols;
        public string passwordArray;

        public Password(int passwordLength, int nrOfSmallLetters, int nrOfCapitalLetters, int nrOfCiphers, int nrOfSymbols,string passwordArray)
        {
            this.passwordLength = passwordLength;
            this.nrOfSmallLetters = nrOfSmallLetters;
            this.nrOfCapitalLetters = nrOfCapitalLetters;
            this.nrOfCiphers = nrOfCiphers;
            this.nrOfSymbols = nrOfSymbols;
            this.passwordArray = passwordArray;
        }
    }

    [TestClass]
    public class PasswordTests
    {
        [TestMethod]
        public void RandomPassword()
        {
            Password password = new Password(3, 2, 1, 0, 0, "");
            password.passwordArray = GeneratePassword(password);      
            Assert.AreEqual(true, CheckPassword(password));
        }

        string GeneratePassword(Password password)
        {
            password.passwordArray = GenerateSmallLetters(password) + GenerateCapitalLetters(password);
            return password.passwordArray;
        }

        char GenerateRandomSmallLetter()
        {
            Random random = new Random();          
            int index = random.Next('a', 'z');
            return  (char)(index);
        }
       
        string GenerateSmallLetters(Password password)
        {
            int i = 0;  
            while(i < password.nrOfSmallLetters)
            {
                password.passwordArray += GenerateRandomSmallLetter();
                i++;
            }
            return password.passwordArray;
        }

        char GenerateRandomCapitalLetter()
        {
            Random random = new Random();
            char c = new char();
            int index = random.Next('A', 'Z');
            return c = (char)(index);
        }

        string GenerateCapitalLetters(Password password)
        {
            int i = 0;
            while (i < password.nrOfCapitalLetters)
            {
                password.passwordArray += GenerateRandomCapitalLetter();
                i++;
            }
            return password.passwordArray;
        }

        bool CheckPassword(Password password)
        {            
            int smallLetters = 0;
            int capitalLetters = 0;
            //int ciphers = 0;
            for(int i = 0; i < password.passwordArray.Length; i++)
            {
                if (password.passwordArray[i] >= 'a' && password.passwordArray[i] <= 'z')
                    smallLetters++;
                if (password.passwordArray[i] >= 'A' && password.passwordArray[i] <= 'Z')
                    capitalLetters++;
               // if (password.passwordArray[i] >= 0 && password.passwordArray[i] <= 9)
                  //  ciphers++;
            }
            if (smallLetters == password.nrOfSmallLetters && capitalLetters == password.nrOfCapitalLetters)
                return true;
            return false;
        }                
    }
}
