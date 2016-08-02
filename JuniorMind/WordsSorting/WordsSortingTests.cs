using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
/*Găsește și ordonează cuvintele dintr-un text în funcție de numărul de apariții.*/
namespace WordsSorting
{
    [TestClass]
    public class WordsSortingTests
    {
        [TestMethod]
        public void SimpleCase()
        {
            var words = new string[] { "the", "frog", "the"};
            CollectionAssert.AreEqual(new Word[] { new Word("the", 2), new Word("frog", 1) }, ShowWordsAfterAppearanceFrequency(words));
        }

        public Word[] ShowWordsAfterAppearanceFrequency(string[] textWords)
        {
            WordsAdministrator admin = new WordsAdministrator();
            for (int i = 0; i < textWords.Length; i++)
                admin.AddWordAndNumberOfAppearances(textWords[i]);
            admin.SortAfterAppearances();

            Word[] words = new Word[admin.sortedWords.Length];
            for (int i = 0; i < admin.sortedWords.Length; i++)
                words[i] = admin.GetNextWord();           
            return words;
        }
    }
}
