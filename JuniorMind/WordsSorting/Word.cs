using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsSorting
{
    public class Word 
    {
        private string word;
        private int numberOfAppearances;       

        public Word(string word, int numberOfAppearances)
        {
            this.word = word;
            this.numberOfAppearances = numberOfAppearances;   
        }

        public void IncreaseAppearances()
        {
            numberOfAppearances++;
        }

        public int CompareTo(Word otherWord)
        {
            return word.CompareTo(otherWord.word);
        }

        public int CompareToByAppearances(Word otherWord)
        {
            return numberOfAppearances.CompareTo(otherWord.numberOfAppearances);   
        }

        public override bool Equals(Object obj)
        {
            if (obj is Word)
            {
                var that = obj as Word;
                return this.word == that.word && this.numberOfAppearances == that.numberOfAppearances;
            }
            return false;
        }
    }
}
