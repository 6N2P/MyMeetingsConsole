using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMeetings.Class
{
    interface IMeetingHandler
    {
        void EditMeeting(List<Meeting> meetings, int index);
        void DeletMeeting (List<Meeting> meetings, int index);
        void CreateMeeting(List<Meeting>meetings);
    }
}
