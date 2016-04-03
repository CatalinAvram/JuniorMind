using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
/*
Un panagram e o frază care conține toate literele din alfabet (englezesc).
Scrie un program care determină dacă o frază e o panagram.

Exemplu: The quick brown fox jumps over the lazy dog*/

namespace Panagram
{
    [TestClass]
    public class PanagramsTests
    {
        [TestMethod]
        public void NotAPanagram()
        {
            Assert.AreEqual(false, IsAPanagram("I like IT"));
        }

        bool IsAPanagram(string phrase)
        {
            phrase.ToLower();
            string phraseLetters = "";
            for (int i = 0; i < phrase.Length; i++)
                if (!phraseLetters.Contains(phrase[i].ToString()))
                    phraseLetters = phraseLetters + phrase[i];
            if (phraseLetters.Length == 26)
                return true;
            return false;
        } 
    }
}
