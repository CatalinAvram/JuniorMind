using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elections
{
    class Centralizer : IEnumerable<SortedPollingStation>
    {
        SortedPollingStation[] sortedStations;

        public Centralizer(SortedPollingStation[] sortedStations)
        {
            this.sortedStations = sortedStations;
        }
       
        public SortedPollingStation CentralizePollingStations()
        {
            Candidate[] totalVotes = new Candidate[sortedStations[0].Candidates.Length];
            for (int i = 0; i < totalVotes.Length; i++)
                totalVotes[i] = new Candidate("", 0);
          
            for(int i = 0; i < totalVotes.Length; i++)
            {
                foreach (Candidate candidate in sortedStations[0].Candidates)
                {
                    totalVotes[i].CandidateName = candidate.CandidateName;
                    totalVotes[i].NumberOfVotes += candidate.GetNumberOfVotes();
                }
            }
            return new SortedPollingStation(totalVotes);
        }
        
        public IEnumerator<SortedPollingStation> GetEnumerator()
        {
            foreach(SortedPollingStation sortedStation in sortedStations)
            {
                yield return sortedStation;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
