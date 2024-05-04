using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningRecordApp
{
    public class Program
    {


        static string[] ReadFile(string path)
        {
            string[] fullFile = File.ReadAllLines(path);

            string[] runnerDatafile = new string[fullFile.Length - 1];
            for (int i = 0; i < runnerDatafile.Length; i++)
            {
                runnerDatafile[i] = fullFile[i + 1];

            }
            return runnerDatafile;
        }
        static Races ReadFolder(string path)
        {
            List<RaceResults> raceResultsarray = new List<RaceResults>();
            string[] files = Directory.GetFiles(path, "*.txt");
            foreach (string file in files)
            {
                if (File.Exists(file))
                {
                    raceResultsarray.Add(new RaceResults(ReadFile(file).Length, ReadFile(file)));
                }
            }
            return new Races(raceResultsarray.ToArray());
        }
        public static void Main(string[] args)
        {

            Races races = ReadFolder("C:\\Users\\Mon PC\\Desktop\\labs\\RunningRecordApp\\RunningRecordApp\\Datafolder\\");
            Console.WriteLine(races.BestPerformance("Emma"));
            //var time1 = Time.Parse("02:22:08");
            //var time2 = Time.Parse("02:22:08");
            ////Console.WriteLine(time1.CompareTo(time2));
            //string[] inputs = new string[] { "Zljhihguuhiuh,02:02:58", "Alice,02:02:08", "Ahice,02:02:08", "Aldfdice,02:22:34" };
            //string[] inputs1 = new string[] { "Zljhihguuhiuh,02:02:28", "Alice,02:02:38", "Ahice,02:02:08", "Aldfdice,02:22:34" };
            //RaceResults raceResults = new(inputs.Length, inputs);
            //RaceResults raceResults1 = new(inputs.Length, inputs1);

            //Races races = new(new RaceResults[] { raceResults, raceResults1 });
            //Console.WriteLine(races.BestPerformance("Zljhihguuhiuh"));
            //Console.WriteLine(races.BestPerformance(" Alice"));
            //foreach (RunnerWithTime runner in raceResults.results) { Console.WriteLine(runner); }
        }
    }
}
