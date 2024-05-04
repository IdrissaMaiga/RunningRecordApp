using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningRecordApp
{
    public class RaceResults
    {
        public RunnerWithTime[] results;
        public RaceResults(int runnersCount, string[] inputs)
        {

            results = new RunnerWithTime[runnersCount];
            for (int i = 0; i < results.Length; i++)
            {
                results[i] = (RunnerWithTime.Parse(inputs[i]));
            }

            if (!IsSorted())
            {
                Sort();
            }
        }
        public bool IsSorted()
        {
            int isortedcount = 0;
            for (int i = 0; i < this.results.Length - 1; i++)
            {
                if (this.results[i].CompareTo(this.results[i + 1]) != 1) isortedcount++;
            }
            if (isortedcount == this.results.Length - 1) return true;
            return false;
        }
        //using the bubble sort
        public void Sort()
        {
            for (int i = this.results.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < this.results.Length - i; j++)
                {
                    if (this.results[j].CompareTo(this.results[j + 1]) == 1)
                    {
                        RunnerWithTime temp = this.results[j];
                        this.results[j] = this.results[j + 1];
                        this.results[j + 1] = temp;
                    }
                }
            }
        }

        public bool Contains(Predicate<RunnerWithTime> predicate, out RunnerWithTime runnerPerformance)
        {
            runnerPerformance = null;
            foreach (var item in results)
            {
                if (predicate(item).Equals(true)) { runnerPerformance = item; return true; };
                break;

            }

            return false;
        }
    }
}
