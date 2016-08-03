using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elections
{
    class PollingStation : IEnumerable<Candidate>
    {
        private Candidate[] candidates;

        public PollingStation(Candidate[] candidates)
        {
            this.candidates = candidates;
        }

        public void AddCandidates()
        {
            for (int i = 0; i < candidates.Length; i++)
                candidates[i] = new Candidate("", 0);
        }

        public IEnumerator<Candidate> GetEnumerator()
        {
            foreach (Candidate candidate in candidates)
                yield return candidate;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
