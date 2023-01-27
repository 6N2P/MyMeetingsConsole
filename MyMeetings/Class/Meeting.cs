using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeetings.Class
{
    internal class Meeting
    {
        DateTime TimeStart { get; set; }
        DateTime TimeEnd { get; set; }
        string Text { get; set; }
        DateTime Reminder { get; set; }

        public Meeting() { }
        public Meeting(DateTime timeStart, DateTime timeEnd, string text, DateTime reminder)
        {
            TimeStart = timeStart;
            TimeEnd = timeEnd;
            Text = text;
            Reminder = reminder;
        }
        public override string ToString()
        {
            string result = $"Время начала встречи:{TimeStart.ToString()}; время конца встречи:{TimeEnd.ToString()};" +
                $" название встречи:{Text}; напоминание встречи в:{Reminder}";
            return result;
        }
    }
}
