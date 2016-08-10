using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elections
{
    class PollingStation
    {
        private Candidate[] candidates;

        public PollingStation(Candidate[] candidates)
        {
            this.candidates = candidates;
        }

        public Candidate[] Candidates
        {
            get { return candidates; }
            set { candidates = value; }
        }

        public void SortCandidatesAlphabetically()
        {
            for(int i = 0; i < candidates.Length - 1; i++)
            {
                for(int j = i + 1; j > 0; j--)
                {
                    if (candidates[j - 1].CompareTo(candidates[j]) > 0)
                        Swap(ref candidates[j - 1], ref candidates[j]);
                }
            }
        }

        public PollingStation SortCandidatesAfterNumberOfVotes()
        {
            for (int i = 0; i < candidates.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (candidates[j - 1].CompareToByVotes(candidates[j]) < 0)
                        Swap(ref candidates[j - 1], ref candidates[j]);
                }
            }
            return new PollingStation(candidates);
        }

        private void Swap<T>(ref T a, ref T b)
        {
            T aux = a;
            a = b;
            b = aux;
        }

        public void InitializeCandidatesList(Candidate[] candidates)
        {
            for (int i = 0; i < candidates.Length; i++)
                candidates[i] = new Candidate("", 0);
        }

        public override bool Equals(Object obj)
        {
            if (!(obj is PollingStation))
                return false;
            return ((PollingStation)obj).candidates.SequenceEqual(candidates);
        }
    }
}
