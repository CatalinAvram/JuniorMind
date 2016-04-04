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

        [TestMethod]
        public void TextWhichIsAPanagram()
        {
            Assert.AreEqual(true, IsAPanagram("The quick brown fox jumps over the lazy dog"));
        }
        [TestMethod]
        public void PanagramWithSomeCapitalsAndRepetions()
        {
            Assert.AreEqual(true, IsAPanagram("TH The quick brown fox jumps over the lazy dog"));
        }

        [TestMethod]
        public void EnglishCharacter()
        {
            Assert.AreEqual(true, IsEnglishCharacter('A'));
        }

        bool IsAPanagram(string phrase)
        {
            phrase = phrase.ToLower();
            string phraseLetters = GetDistinctLetters(phrase);
            if (phraseLetters.Length == 26)
                return true;
            return false;
        }

        bool IsEnglishCharacter(char c)
        {
            return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');
        }

        private string GetDistinctLetters(string phrase)
        {
            string phraseLetters = "";
            for (int i = 0; i < phrase.Length; i++)
                if (IsEnglishCharacter(phrase[i]) && !phraseLetters.Contains(phrase[i].ToString()))
                    phraseLetters = phraseLetters + phrase[i];
            return phraseLetters;
        }      
    }
}
