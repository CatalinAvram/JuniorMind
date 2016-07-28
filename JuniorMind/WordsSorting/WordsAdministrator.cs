using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Găsește și ordonează cuvintele dintr-un text în funcție de numărul de apariții.
namespace WordsSorting
{
    class WordsAdministrator
    {
        private Word[] words;

        public WordsAdministrator(Word[] words)
        {
            this.words = words;
        }

        public void SortAfterAppearances(string text)
        {
            for (int i = 0; i < words.Length - 1; i++)
            {
                int j = i + 1;
                while (j > 0)
                {
                    if (words[j - 1].CountApperances(text) <= words[j].CountApperances(text))
                    {
                        Word temp = words[i];
                        words[i] = words[j];
                        words[j] = temp;
                    }
                    j--;
                }
            }
        }

        public string GetNextWord(int index)
        {
            return words[index].WordLetters;
        }
    }
}
