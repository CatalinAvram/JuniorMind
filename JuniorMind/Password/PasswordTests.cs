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
    public struct PasswordParameters
    {
        public int passwordLength;
        public int nrOfSmallLetters;
        public int nrOfCapitalLetters;
        public int nrOfCiphers;
        public int nrOfSymbols;        
               
        public PasswordParameters(int passwordLength, int nrOfSmallLetters, int nrOfCapitalLetters, 
                        int nrOfCiphers, int nrOfSymbols)
        {
            this.passwordLength = passwordLength;
            this.nrOfSmallLetters = nrOfSmallLetters;
            this.nrOfCapitalLetters = nrOfCapitalLetters;
            this.nrOfCiphers = nrOfCiphers;
            this.nrOfSymbols = nrOfSymbols;           
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
            PasswordParameters passwordParameters = new PasswordParameters(3, 2, 1, 0, 0);
            string password = GeneratePassword(passwordParameters);      
            Assert.AreEqual(true, CheckPassword(password, passwordParameters));
        }
        
        [TestMethod]
        public void SmallCapitalAndCipher()
        {                        
            PasswordParameters passwordParameters = new PasswordParameters(5, 2, 1, 2, 0);
            string password = GeneratePassword(passwordParameters);
            Assert.AreEqual(true, CheckPassword(password, passwordParameters));
        }

        [TestMethod]
        public void Symbols()
        {                
            PasswordParameters passwordParameters = new PasswordParameters(3, 0, 0, 0, 2);
            string password = GeneratePassword(passwordParameters);
            Assert.AreEqual(true, CheckPassword(password, passwordParameters));
        }

        [TestMethod]
        public void SmallLettersCapitalsCiphersAndSymbols()
        {                       
            PasswordParameters passwordParameters = new PasswordParameters(8, 2, 3, 1, 2);
            string password = GeneratePassword(passwordParameters);
            Assert.AreEqual(true, CheckPassword(password, passwordParameters));
        }
        
        string GeneratePassword(PasswordParameters password)
        {
            return AddChars(CharType.SmallLetters, password.nrOfSmallLetters) + 
                   AddChars(CharType.CapitalLetters, password.nrOfCapitalLetters) + 
                   AddChars(CharType.Ciphers, password.nrOfCiphers) + GenerateSymbols(password.nrOfSymbols);          
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
       
        string AddChars(CharType charType, int nrOfChars)
        {                               
            string passwordChars = "";
            string similar = "l1Io0O";
            while (nrOfChars > 0)
            {
                if (!similar.Contains(GetRandomChar(charType).ToString()))
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

        bool CheckPassword(string password, PasswordParameters passwordParameters)
        {                     
            for(int i = 0; i < password.Length; i++)
            {             
                if (password[i] >= 'a' && password[i] <= 'z')
                    passwordParameters.nrOfSmallLetters--;                                                               
                if (password[i] >= 'A' && password[i] <= 'Z')
                    passwordParameters.nrOfCapitalLetters--;
                if (password[i] >= '0' && password[i] <= '9')
                    passwordParameters.nrOfCiphers--;
                if ("!@#$%^&*-=_+:<>?".Contains(password[i].ToString()))
                    passwordParameters.nrOfSymbols--;
            }
            if (passwordParameters.nrOfSmallLetters + passwordParameters.nrOfCapitalLetters + 
                passwordParameters.nrOfCiphers + passwordParameters.nrOfSymbols == 0)
                return true;
            return false;
        }                
    }
}
