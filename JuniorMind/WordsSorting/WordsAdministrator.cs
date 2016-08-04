using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Găsește și ordonează cuvintele dintr-un text în funcție de numărul de apariții.
namespace WordsSorting
{
    class WordsAdministrator : IEnumerator<Word>
    {
        private Word[] words = new Word[0];
        private int index = -1;


        public void Add(string word)
        {
            for(int i = 0; i < words.Length; i++)
            {
                if (words[i].CompareTo(new Word(word, 1)) == 0)
                {
                    words[i].IncreaseAppearances();
                    return;
                }
            }
            Array.Resize(ref words, words.Length + 1);
            words[words.Length - 1] = new Word(word, 1);
            SortAfterAppearances();
        }

        public void SortAfterAppearances()
        {
            for (int i = 0; i < words.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                    if (words[j - 1].CompareToByAppearances(words[j]) < 0 )
                        Swap(ref words[j - 1], ref words[j]);
            }
        }
    
        private void Swap<T>(ref T a, ref T b)
        {
            T aux = a;
            a = b;
            b = aux;
        }

        public int GetNumberOfDistinctWords()
        {
            return words.Length;
        }

        public Word Current
        {
            get
            {
                return words[index];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            index++;
            return index < words.Length;
        }

        public void Reset()
        {
            index = -1;
        }
        public Word GetNextWord()
        {

            MoveNext();
            return Current;
        }
    }
}
