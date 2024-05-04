using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RunningRecordApp
{
    public class Time : IComparable<Time>
    {
        int hour;
        private int second;
        private int minute;

        public int Hour
        {
            get => this.hour;
            set
            {

                if (value > 23 || value < 0)
                {
                    throw new TimeException("value > 23 || value < 0");
                }
                hour = value;
            }
        }
        public int Minute
        {
            get => this.minute;
            set
            {

                if (value > 60 || value < 0)
                {
                    throw new TimeException("value > 23 || value < 0");
                }
                minute = value;
            }
        }
        public int Second
        {
            get => this.second;
            set
            {

                if (value > 60 || value < 0)
                {
                    throw new TimeException("value > 60 || value < 0");
                }
                second = value;
            }
        }

        //constractor 
        public Time(int hour, int minute, int second)
        {
            this.Hour = hour;
            this.Minute = minute;
            this.Second = second;
        }
        public Time(int minute, int second)
        {
            this.Hour = 0;
            this.Minute = minute;
            this.Second = second;
        }
        //Parsing 
        public static Time Parse(string input)
        {
            var stringarray = input.Split(':');
            if (stringarray.Length == 2)
            {
                return new Time(int.Parse(stringarray[0]), int.Parse(stringarray[1]));
            }
            else if (stringarray.Length == 3)
            {
                return new Time(int.Parse(stringarray[0]), int.Parse(stringarray[1]), int.Parse(stringarray[2]));
            }
            else throw new TimeException("The string is not in correct format");

        }
        public override string ToString()
        {
            if (this.Hour > 0) { return $"{this.hour:D2}:{this.minute:D2}:{this.second:D2}"; }
            return $"{this.minute:D2}:{this.second:D2}";

        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (!(obj is Time)) return false;
            var time = (Time)obj;
            if (this.Hour == time.Hour && this.Minute == time.Minute && this.Second == time.Second) return true;
            return false;
        }

        public int CompareTo(Time time)
        {
            if (this.Hour < time.Hour) return -1;
            else
            {
                if (this.Hour > time.Hour) return 1;
                else
                {
                    if (this.Minute < time.Minute) return -1;
                    else
                    {
                        if (this.Minute > time.Minute) return 1;
                        else
                        {
                            if (this.Second < time.Second) return -1;
                            else
                            {
                                if (this.Second > time.Second) return 1;
                                else return 0;

                            }
                        }
                    }
                }
            }
        }
    }
}
