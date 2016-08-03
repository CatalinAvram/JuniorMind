using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elections
{
    public class Candidate
    {
        private string name;
        private int numberOfVotes;

        public Candidate(string name, int numberOfVotes)
        {
            this.name = name;
            this.numberOfVotes = numberOfVotes;
        }

        public void IncreaseVotes()
        {
            numberOfVotes++;
        }

        public int CompareTo(Candidate otherCandidate)
        {
            return name.CompareTo(otherCandidate.name);
        }

        public int CompareToByVotes(Candidate otherCandidate)
        {
            return numberOfVotes.CompareTo(otherCandidate.numberOfVotes);
        }

        public override bool Equals(Object obj)
        {
            if(obj is Candidate)
            {
                var that = obj as Candidate;
                return this.name == that.name && this.numberOfVotes == that.numberOfVotes;
            }
            return false;
        }

    }
}
