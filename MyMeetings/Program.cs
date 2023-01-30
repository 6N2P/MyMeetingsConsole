using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Timers;

using MyMeetings.Class;
using System.Timers;

namespace MyMeetings
{
    internal class Program
    {
        static  void Main(string[] args)
        {
            List<Meeting> meetings = new List<Meeting>();
            MeetingHandler meetingHandler = new MeetingHandler();
            string pathFail = @".\Meetings.txt";
            string[] saveMeeting;

            bool endProgram = false;
            int selection=0;
            int index=0;

            while (!endProgram)
            {
                selection = SelectionCheck();
                switch (selection)
                {
                    case 1: meetingHandler.CreateMeeting(meetings); break;
                    case 2:
                        if (meetings.Count > 0)
                        {
                            int ind = 1;
                            foreach (var m in meetings)
                            {
                                Console.WriteLine($"{ind}. {m.ToString()}");
                                ind++;
                            };
                        }
                        else Console.WriteLine("Список пуст");
                        break;
                    case 3:
                        index = IntCheck("Какое совещанин вы хотите удалить? Введите цифру");
                        meetingHandler.DeletMeeting(meetings, index);
                        break;
                    case 4:
                        index = IntCheck("Какое совещанин вы хотите отредактировать? Введите цифру");
                        meetingHandler.EditMeeting(meetings, index);
                        break;
                    case 5:
                        saveMeeting=new string[meetings.Count];
                        for (int i = 0; i < meetings.Count; i++)
                        {
                            saveMeeting[i] = meetings[i].ToString();
                        }
                        File.WriteAllLines(pathFail, saveMeeting);
                        break;
                    case 6: endProgram = true; break;
                }
                SetTimer();
            }

            

            ///Метод получает какое действие хочет сделать пользователь
            int  SelectionCheck()
            {
                int selectionInt = 0;
                bool isTrueInt = false;
                string check = string.Empty;


                while (!isTrueInt)
                {
                    Console.WriteLine("Что бы создать встречу нажмите 1\n" +
                        "Чтобы посмотреть встречи нажмите 2\n" +
                        "Что бы удолить встречу нажмите 3\n" +
                        "Что бы отредактировать встречу 4\n" +
                        "Что бы сохранить встречи 5\n" +
                        "Что бы выйти из программы нажмите 6");

                    check = Console.ReadLine();

                    if (check == "1" || check == "2" || check == "3" || check == "4" || check == "5")
                    {
                        selectionInt = int.Parse(check);
                        isTrueInt = true;
                    }
                    else
                    {
                        Console.WriteLine("такого варианта нет");
                    }
                }

                return selectionInt;
            }

            ///Метод проверяет и получает цифру 
            ///text-для отоброжения вопроса пользователю.
            int IntCheck(string text)
            {
                int result = 0;
                bool isTrueInt = false;
                string intString;
                while (!isTrueInt)
                {
                    Console.WriteLine(text);
                    intString = Console.ReadLine();
                    isTrueInt = int.TryParse(intString, out result);
                }
                return result;
            }

            void SetTimer()
            {
              Timer  aTimer = new Timer(30000);

                aTimer.Elapsed += OnTimedEvent;
                aTimer.AutoReset = true;
                aTimer.Enabled = true;
            }

            void OnTimedEvent(Object sourse, ElapsedEventArgs e)
            {
                DateTime dateTimeNow = DateTime.Now;

                for (int i = 0; i < meetings.Count; i++)
                {
                    if (meetings[i].Reminder.Date == dateTimeNow.Date && 
                        meetings[i].Reminder.Hour == dateTimeNow.Hour && 
                        meetings[i].Reminder.Minute == dateTimeNow.Minute)
                    {
                        Console.Beep(700, 10000);
                        Console.WriteLine($"Предстоит встреча {meetings[i].Text}");
                    }
                }
            }
        }
    }
}
