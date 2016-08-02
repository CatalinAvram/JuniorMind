using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Găsește și ordonează cuvintele dintr-un text în funcție de numărul de apariții.
namespace WordsSorting
{
    class WordsAdministrator : IEnumerable<Word>
    {
        private Word[] words = new Word[0];
        private int index = -1;

        public Word[] sortedWords
        {
            get { return words; }
            set { words = value; }
        }

        public void AddWordAndNumberOfAppearances(string word)
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

        public IEnumerator<Word> GetEnumerator()
        {
            foreach(Word word in words)
            {
                yield return word;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        bool MoveNext()
        {
            index++;
            return index < words.Length;
        }

        Word Current
        {
            get
            {
                return words[index];
            }
        }

        void Reset()
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
