using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elections
{
    class SortedCandidates : IEnumerable<Candidate>
    {
        private Candidate[] candidates;

        public SortedCandidates(Candidate[] candidates)
        {
            this.candidates = candidates;
        }

        public Candidate[] SortCandidates()
        {
            for(int i = 0; i < candidates.Length - 1; i++)
            {
                for(int j = i + 1; j > 0; j--)
                {
                    if (candidates[j - 1].CompareToByVotes(candidates[j]) < 0)
                        Swap(ref candidates[j - 1], ref candidates[j]);
                }
            }
            return candidates;
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
    }
}
