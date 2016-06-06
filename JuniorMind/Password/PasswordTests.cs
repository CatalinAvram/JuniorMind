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
        public bool similar;
        public bool ambiguous;
                         
        public PasswordParameters(int passwordLength, int nrOfSmallLetters, int nrOfCapitalLetters, 
                        int nrOfCiphers, int nrOfSymbols, bool similar, bool ambiguous)
        {
            this.passwordLength = passwordLength;
            this.nrOfSmallLetters = nrOfSmallLetters;
            this.nrOfCapitalLetters = nrOfCapitalLetters;
            this.nrOfCiphers = nrOfCiphers;
            this.nrOfSymbols = nrOfSymbols;
            this.similar = similar;
            this.ambiguous = ambiguous;         
        }
    }

    [TestClass]
    public class PasswordTests
    {
        [TestMethod]
        public void SmallAndCapitalLetters()
        {
            PasswordParameters passwordParameters = new PasswordParameters(3, 2, 1, 0, 0, true, false);
            string password = GeneratePassword(passwordParameters);
            Assert.AreEqual(2, CountCharacters(password, 'a', 'z'));
            Assert.AreEqual(1, CountCharacters(password, 'A', 'Z'));                     
        }
               
       /* [TestMethod]
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
        }*/
               
        Random random = new Random();

        string GeneratePassword(PasswordParameters password)
        {
            return AddChars(password.nrOfSmallLetters, 'a', 'z', password.similar) + 
                   AddChars(password.nrOfCapitalLetters, 'A', 'Z', password.similar) + 
                   AddChars(password.nrOfCiphers, '0', '9', password.similar) + GenerateSymbols(password.nrOfSymbols);          
        }

        char GetRandomChar(char start, char end)
        {                    
            return (char)(random.Next(start, end + 1));          
        }
       
        string AddChars(int nrOfChars, char start, char end, bool similarAccepted)
        {
            string similarChars = "l1Io0O";
            //char[] similarChars = { 'l', '1', 'I', 'o', '0', 'O' };
            string passwordChars = "";
            if(similarAccepted)
                while (nrOfChars > 0)
                {
                    passwordChars += GetRandomChar(start, end);
                    nrOfChars--;                                   
                }
            else
            while (nrOfChars > 0)
            {                              
                if (!similarChars.Contains(GetRandomChar(start, end).ToString()))                    
                    {
                        passwordChars += GetRandomChar(start, end);
                        nrOfChars--;
                    }
            }
            return passwordChars;
        }

        string GenerateSymbols(int nrOfSymbols)
        {           
            string symbols = "!@#$%^&*-=_+:<>?";
            string passwordSymbols = "";                                  
            while (nrOfSymbols > 0)
            {               
                    passwordSymbols += symbols[random.Next(0, symbols.Length - 1)];
                    nrOfSymbols--;                
            }
            return passwordSymbols;
        }

        int CountCharacters(string word, char start, char end)
        {
            int counter = 0;
            foreach (char c in word)
                if (start <= c && c <= end)
                    counter++;
            return counter;
        }

        /*bool CheckPassword(string password, PasswordParameters passwordParameters)
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
            if(passwordParameters.nrOfSmallLetters == CountCharacters(password, 'a', 'z'))
                return true;
            return false;
        }       */         
    }
}
