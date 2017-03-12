using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Calendar
{
    public class Event
    {
        public string Label;
        public DateTime StartTime;

        public Event(string Label, DateTime StartTime)
        {
            this.Label = Label;
            this.StartTime = StartTime;
        }
        private Event() : this(null, DateTime.MinValue) { }
    }

    class Cal
    {
        static void Serialize(List<Event> events)
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<Event>));
            StreamWriter OutputFile = new StreamWriter(File.OpenWrite("cal_events.xml"));
            ser.Serialize(OutputFile, events);
            OutputFile.Dispose();

        }

        static List<Event> Deserialize()
        {
            List<Event> CalEvents;

            XmlSerializer ser = new XmlSerializer(typeof(List<Event>));
            StreamReader InputFile = new StreamReader(File.OpenRead("cal_events.xml"));
            CalEvents = (List<Event>)ser.Deserialize(InputFile);
            InputFile.Dispose();

            return CalEvents;
        }

        static void Main(string[] args)
        {
            Event OperatingEvent = new Event("", DateTime.Today);
            List<Event> CalendarEvents = Deserialize();
            
            if (args.Length == 0)
            {
                Console.WriteLine("Please enter an argument.");
            }
            else
            {
                if (args[0] == "--add-event")
                    if (args.Length == 3)
                    {
                        {
                            try
                            {
                                OperatingEvent.StartTime = Convert.ToDateTime(args[1]);
                                OperatingEvent.Label = args[2];

                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Please provide your second argument in the format YYYY/MM/DD");
                            }

                        }

                        if (OperatingEvent.Label == "")
                        {
                            Console.WriteLine("Can't have an event with an empty label.");
                        }
                        else
                        {
                            CalendarEvents.Add(OperatingEvent);
                            Console.WriteLine("Event \"{0}\" added on day {1}", OperatingEvent.Label, OperatingEvent.StartTime);

                            Serialize(CalendarEvents);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Arguments should be provided in the form: cal --add-event [date (format: YYYY/MM/DD)] [label (in \"quotation marks\")]");
                    }

            }
            //Event Birthday = new Event("Happy Birthday", DateTime.Today);
            //Console.WriteLine(Birthday.Label + DateTime.Today);
        }
    }
}