using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elections
{
    class SortedPollingStation : IEnumerable<Candidate>
    {
        private Candidate[] candidates;

        public SortedPollingStation(Candidate[] candidates)
        {
            this.candidates = candidates;
            SortCandidatesAlphabetically();
        }

        public Candidate[] Candidates
        {
            get { return candidates; }
            set { candidates = value; }
        }

        private void SortCandidatesAlphabetically()
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

        private void Swap<T>(ref T a, ref T b)
        {
            T aux = a;
            a = b;
            b = aux;
        }

        public IEnumerator<Candidate> GetEnumerator()
        {
            foreach(Candidate candidate in candidates)
            {
                yield return candidate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override bool Equals(Object obj)
        {
            if (!(obj is SortedPollingStation))
                return false;
            return ((SortedPollingStation)obj).candidates.SequenceEqual(candidates);
        }
    }
}
