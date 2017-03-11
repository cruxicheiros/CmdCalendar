using System;
using System.Collections.Generic;

namespace Calendar
{
    class Event
    {
        public string Label;
        public DateTime StartTime;

        public Event(string Label, DateTime StartTime)
        {
            this.Label = Label;
            this.StartTime = StartTime;
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            Event Birthday = new Event("Happy Birthday", DateTime.Today);

            Console.WriteLine(Birthday.Label + DateTime.Today);
        }

    }
}