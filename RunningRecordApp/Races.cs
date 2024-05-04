using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningRecordApp
{
    public class Races
    {
        public RaceResults[] raceResults { get; private set; }
        public Races(RaceResults[] raceResults)
        {
            this.raceResults = raceResults;
        }
        public Time BestPerformance(string name)
        {
            List<RunnerWithTime> runs = new List<RunnerWithTime>();
            foreach (var item in raceResults)
            {
                foreach (var item1 in item.results)
                {
                    if (name == item1.Name) runs.Add(item1);
                }

            }
            RunnerWithTime min = null;
            for (int i = 0; i < runs.Count - 1; i++)
            {
                min = runs[i];
                if (runs[i].CompareTo(runs[i + 1]) != 1)
                {
                    min = runs[i];
                }
                else { min = runs[i + 1]; }
            }
            if (min as RunnerWithTime == null) { return null; }
            return min.Time;
        }


        RunnerWithTime[] Union(RunnerWithTime[] first, RunnerWithTime[] second)
        {
            RunnerWithTime[] Union = new RunnerWithTime[first.Length + second.Length];
            for (int i = 0; i < Union.Length; i++)
            {
                int j = 0;
                if (i < first.Length)
                {
                    Union[i] = first[i];

                }
                else
                {
                    Union[i] = second[j];
                    j++;
                }
            }

            for (int i = Union.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < Union.Length - i; j++)
                {
                    if (Union[j].CompareTo(Union[j + 1]) == 1)
                    {
                        RunnerWithTime temp = Union[j];
                        Union[j] = Union[j + 1];
                        Union[j + 1] = temp;
                    }
                }
            }
            return Union;





        }
    }
}
