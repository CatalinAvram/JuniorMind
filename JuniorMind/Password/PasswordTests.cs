using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
/*Scrie o funcție care generează o parolă de până la X caractere.
Funcția oferă ca și opțiuni:
   Funcția oferă ca și opțiuni:
    litere mici
    litere mari și numărul lor
    cifre și numărul lor
    simboluri și numărul lor
    să nu includă caracterele similare: l, 1, I, o, 0, O
    să nu includă caractere ambigue: {}[]()/\'"~,;.<>

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

    public enum CharType
    {
        SmallLetters, CapitalLetters, Ciphers
    }

    [TestClass]
    public class PasswordTests
    {
        [TestMethod]
        public void SmallAndCapitalLetters()
        {
            Password password = new Password(3, 2, 1, 0, 0, "");
            password.passwordArray = GeneratePassword(password);      
            Assert.AreEqual(true, CheckPassword(password));
        }

        [TestMethod]
        public void SmallCapitalAndCipher()
        {
            Password password = new Password(5, 2, 1, 2, 0, "");
            password.passwordArray = GeneratePassword(password);
            Assert.AreEqual(true, CheckPassword(password));
        }

        [TestMethod]
        public void Symbols()
        {
            Password password = new Password(3, 0, 0, 0, 2,"");
            password.passwordArray = GeneratePassword(password);
            Assert.AreEqual(true, CheckPassword(password));
        }

        [TestMethod]
        public void SmallLettersCapitalsCiphersAndSymbols()
        {
            Password password = new Password(8, 2, 3, 1, 2, "");
            password.passwordArray = GeneratePassword(password);
            Assert.AreEqual(true, CheckPassword(password));
        }

        string GeneratePassword(Password password)
        {
            password.passwordArray = AddChars(CharType.SmallLetters, password.nrOfSmallLetters) + 
                                     AddChars(CharType.CapitalLetters, password.nrOfCapitalLetters) + 
                                     AddChars(CharType.Ciphers, password.nrOfCiphers) + GenerateSymbols(password.nrOfSymbols);
            return password.passwordArray;
        }

        char GetRandomChar(CharType charType)
        {
            Random random = new Random();
            int index = 0;
            switch (charType)
            {
                case CharType.SmallLetters:
                    index = random.Next('a', 'z');
                    break;
                case CharType.CapitalLetters:
                    index = random.Next('A', 'Z');
                    break;
                case CharType.Ciphers:
                    index = random.Next('0', '9');
                    break;
            }                   
            return  (char)(index);
        }
       
        string AddChars( CharType charType, int nrOfChars)
        {                               
            string similarChars = "l1Io0O";
            string passwordChars = "";
            while (nrOfChars > 0)
            {
                if (!similarChars.Contains(GetRandomChar(charType).ToString()))
                {                                 
                    passwordChars += GetRandomChar(charType);
                    nrOfChars--;
                }
            }
            return passwordChars;
        }

        string GenerateSymbols(int nrOfSymbols)
        {           
            string symbols = "!@#$%^&*-=_+:<>?";
            string passwordSymbols = "";                                  
            Random random = new Random();
            while (nrOfSymbols > 0)
            {               
                    passwordSymbols += symbols[random.Next(0, symbols.Length - 1)];
                    nrOfSymbols--;                
            }
            return passwordSymbols;
        }

        bool CheckPassword(Password password)
        {            
            int smallLetters = 0;
            int capitalLetters = 0;
            int ciphers = 0;
            int symbols = 0;
            for(int i = 0; i < password.passwordArray.Length; i++)
            {
                if (password.passwordArray[i] >= 'a' && password.passwordArray[i] <= 'z')
                    smallLetters++;                
                if (password.passwordArray[i] >= 'A' && password.passwordArray[i] <= 'Z')
                    capitalLetters++;
                if (password.passwordArray[i] >= '0' && password.passwordArray[i] <= '9')
                    ciphers++;
                if("!@#$%^&*-=_+:<>?".Contains(password.passwordArray[i].ToString()))
                    symbols++;
            }
            if (smallLetters == password.nrOfSmallLetters && capitalLetters == password.nrOfCapitalLetters && 
                ciphers == password.nrOfCiphers && symbols == password.nrOfSymbols)
                return true;
            return false;
        }                
    }
}
