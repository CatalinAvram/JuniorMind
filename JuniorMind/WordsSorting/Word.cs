using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsSorting
{
    class Word
    {
        private string word;
        private int numberOfAppearances;       

        public Word(string word, int numberOfApperances)
        {
            this.word = word;
            this.numberOfAppearances = numberOfApperances;         
        }

        public string WordLetters
        {
            get { return word; }
            set { word = value; }
        }

        public int CountApperances(string text)
        {
            string[] textWords = text.Split(' ');
            for(int i = 0; i < textWords.Length; i++)           
                if(word.Equals(textWords[i]))
                    numberOfAppearances++;
            return numberOfAppearances;            
        }          
    }
}
