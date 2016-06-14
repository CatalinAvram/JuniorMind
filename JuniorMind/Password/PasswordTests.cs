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
            Assert.AreEqual(0, CountCharacters(password, '0', '9'));
        }
               
       [TestMethod]
        public void SmallCapitalAndCipher()
        {                        
            PasswordParameters passwordParameters = new PasswordParameters(5, 2, 1, 2, 0, false, false);
            string password = GeneratePassword(passwordParameters);
            Assert.AreEqual(2, CountCharacters(password, 'a', 'z'));
            Assert.AreEqual(1, CountCharacters(password, 'A', 'Z'));
            Assert.AreEqual(2, CountCharacters(password, '0', '9'));            
        }

        [TestMethod]
        public void Symbols()
        {                
            PasswordParameters passwordParameters = new PasswordParameters(3, 0, 0, 0, 2, false, false);
            string password = GeneratePassword(passwordParameters);
            Assert.AreEqual(0, CountCharacters(password, 'a', 'z'));
            Assert.AreEqual(0, CountCharacters(password, 'A', 'Z'));
            Assert.AreEqual(0, CountCharacters(password, '0', '9'));
        }

        [TestMethod]
        public void SmallLettersCapitalsCiphersAndSymbols()
        {                       
            PasswordParameters passwordParameters = new PasswordParameters(8, 2, 3, 1, 2, false, false);
            string password = GeneratePassword(passwordParameters);
            Assert.AreEqual(2, CountCharacters(password, 'a', 'z'));
            Assert.AreEqual(3, CountCharacters(password, 'A', 'Z'));
            Assert.AreEqual(1, CountCharacters(password, '0', '9'));
        }

        [TestMethod]
        public void PasswordWithAmbiguousSymbols()
        {
            PasswordParameters passwordParameters = new PasswordParameters(8, 2, 3, 1, 2, false, true);
            string password = GeneratePassword(passwordParameters);
            Assert.AreEqual(2, CountSymbols(password));
        }
               
        Random random = new Random();

        string GeneratePassword(PasswordParameters password)
        {
            return AddChars(password.nrOfSmallLetters, 'a', 'z', password.similar) + 
                   AddChars(password.nrOfCapitalLetters, 'A', 'Z', password.similar) + 
                   AddChars(password.nrOfCiphers, '0', '9', password.similar) + GenerateSymbols(password.nrOfSymbols, password.ambiguous);          
        }

        char GetRandomChar(char start, char end)
        {                    
            return (char)(random.Next(start, end + 1));          
        }
       
        string AddChars(int nrOfChars, char start, char end, bool similarAccepted)
        {
            string similarChars = "l1Io0O";
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

        string GenerateSymbols(int nrOfSymbols, bool ambiguousAccepted)
        {

            string ambiguousIncluded = "!@#$%^&*-=_+:<>?{}[]()/\'~,;.<>";
            string symbols = "!@#$%^&*-=_+:<>?";
            string passwordSymbols = "";     

            if(ambiguousAccepted)                            
                while (nrOfSymbols > 0)
                {               
                        passwordSymbols += symbols[random.Next(0, symbols.Length - 1)];
                        nrOfSymbols--;                
                }
            else
                while (nrOfSymbols > 0)
                {
                    passwordSymbols += ambiguousIncluded[random.Next(0, symbols.Length - 1)];
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

        int CountSymbols(string word)
        {
            int counter = 0;
            string ambiguous = "!@#$%^&*-=_+:<>?{}[]()/\'~,;.<>";
            for (int i = 0; i < word.Length; i++)
                if (ambiguous.Contains(word[i].ToString()))
                    counter++;
            return counter;
        }
    }
}
