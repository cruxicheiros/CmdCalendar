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

    class Cal
    {
        static void Main(string[] args)
        {
            Event OperatingEvent = new Event("", DateTime.Today);
            Console.WriteLine(args.Length);
            if (args.Length == 0)
            {
                Console.WriteLine("Please enter an argument.");
            }
            else
            {
                if (args[0] == "--add-event")
                    if (args.Length == 3) {
                        {
                            try
                            {
                                OperatingEvent.StartTime = Convert.ToDateTime(args[1]);
                                OperatingEvent.Label = args[2];

                            } catch (FormatException)
                            {
                                Console.WriteLine("Please provide your second argument in the format YYYY/MM/DD");
                            }

                        }

                        Console.WriteLine(OperatingEvent.Label);
                    } else
                    {
                        Console.WriteLine("Arguments should be provided in the form: cal --add-event [date (format: YYYY/MM/DD)] [label (in \"quotation marks\")]");
                    }


            }
            //Event Birthday = new Event("Happy Birthday", DateTime.Today);
            //Console.WriteLine(Birthday.Label + DateTime.Today);
        }
    }
}