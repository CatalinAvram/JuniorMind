using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
/*Găsește și ordonează cuvintele dintr-un text în funcție de numărul de apariții.*/
namespace WordsSorting
{
    [TestClass]
    public class WordsSortingTests
    {
        [TestMethod]
        public void NumberOfApperances()
        {
            Word word = new Word("the", 0);
            Assert.AreEqual(2, word.CountApperances("the frog the"));
        }

        [TestMethod]
        public void SimpleCase()
        {
            CollectionAssert.AreEqual(new string[] { "the", "the", "frog"}, ShowWordsAfterAppearanceFrequency("the frog the"));
        }

        public string[] ShowWordsAfterAppearanceFrequency(string text)
        {
            Word[] wordsToBeSorted = new Word[text.Split(' ').Length];
            for (int i = 0; i < wordsToBeSorted.Length; i++)
                wordsToBeSorted[i] = new Word(text.Split(' ')[i], 0);
          
            WordsAdministrator admin = new WordsAdministrator(wordsToBeSorted);
            admin.SortAfterAppearances(text);
            string[] sortedWords = new string[wordsToBeSorted.Length];

            for (int i = 0; i < sortedWords.Length; i++)
                sortedWords[i] = admin.GetNextWord(i);
            return sortedWords;
        }
    }
}
