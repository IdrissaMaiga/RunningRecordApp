using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningRecordApp
{

    public class RunnerWithTime : IComparable<RunnerWithTime>
    {
        public string Name { get; set; }
        public Time Time { get; set; }
        public RunnerWithTime(string name, Time time)
        {
            this.Name = name;
            this.Time = time;
        }

        public static RunnerWithTime Parse(string input)
        {
            string name;
            Time time;
            string[] parts = input.Split(',');
            name = parts[0];
            time = Time.Parse(parts[1]);
            return new RunnerWithTime(name, time);
        }

        public int CompareTo(RunnerWithTime other)
        {
            if (this.Time.Equals(other.Time)) return Name.CompareTo(other.Name);
            else return Time.CompareTo(other.Time);
        }
        public override string ToString()
        {
            return $"{Name} ({Time})";
        }
        public override bool Equals(object obj)
        {
            if (obj is RunnerWithTime)
            {
                RunnerWithTime other = obj as RunnerWithTime;
                if (other.Name.Equals(Name) && other.Time.Equals(Time)) { return true; }
                return false;
            }
            else return false;
        }
    }

}
