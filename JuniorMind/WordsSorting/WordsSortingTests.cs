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

        [TestMethod]
        public void MoreComplexCase()
        {
            var words = new string[] { "a", "b", "a", "b", "b", "c" };
            CollectionAssert.AreEqual(new Word[] { new Word("b", 3), new Word("a", 2), new Word("c", 1 )}, ShowWordsAfterAppearanceFrequency(words));

        }

        public Word[] ShowWordsAfterAppearanceFrequency(string[] textWords)
        {
            WordsAdministrator admin = new WordsAdministrator();
            for (int i = 0; i < textWords.Length; i++)
                admin.Add(textWords[i]);

            Word[] words = new Word[admin.GetNumberOfDistinctWords()];
            for(int i = 0; i < words.Length; i++)
                words[i] = admin.GetNextWord();             
            return words;
        }
    }
}
