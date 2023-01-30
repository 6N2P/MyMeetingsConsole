using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MyMeetings.Class
{
    internal class MeetingHandler : IMeetingHandler
    {
        
        public List<Meeting>Meetings { get; set; }
        public MeetingHandler() { }
        public MeetingHandler (List<Meeting> meetings)
        {
            Meetings = meetings;
        }
        /// <summary>
        /// Метод добовляет в список совещание
        /// </summary>
        /// <param name="meetings">Список совещаний</param>
        public void CreateMeeting(List<Meeting> meetings)
        {
            DateTime dateStart = DateChek("Введите дату и время начала совещаяния");
            DateTime dateEnd = DateChek("Введите дату и время окончания совещания");
            Console.WriteLine("Ведите тему совещания");
            string text = Console.ReadLine();
            DateTime remainder = DateChek("Введите дату и время когда напомнить о встрече");

            bool flag = false;

            //Прверка чтоб дата ыстречи была не позднее нынешней даты
            if (dateStart >= DateTime.Now)
            {
                if (meetings.Count > 0)
                {
                    // Проверка на совподение дат встреч
                    for (int i = 0; i < meetings.Count; i++)
                    {
                        if (meetings[i].TimeStart != dateStart)
                        {
                            flag = true;
                        }
                        else
                        {
                            flag = false;
                            Console.WriteLine($"В это аремя уже есть событие: {meetings[i].Text} ");
                        }
                    }

                    if (flag)
                    {
                        ///Добавление в список встречи.
                        Meeting meeting = new Meeting(dateStart, dateEnd, text, remainder);
                        meetings.Add(meeting);
                    }
                }
                else
                {
                    Meeting meeting = new Meeting(dateStart, dateEnd, text, remainder);
                    meetings.Add(meeting);
                }
            }
            else
            {
                Console.WriteLine("Дата запланированной встречи не должна быть раньше текущей даты");
            }
            
        }
        /// <summary>
        /// Метод удоляет из списка совещание по заданному индексу
        /// </summary>
        /// <param name="meetings">Спсок совещаний</param>
        /// <param name="index">Индекс совещания</param>
        public void DeletMeeting(List<Meeting> meetings, int index)
        {
            meetings.RemoveAt(index-1);
        }
        /// <summary>
        /// Редоктирование совещания по заданному индексу
        /// </summary>
        /// <param name="meetings">Список совещания</param>
        /// <param name="index">Индекс совещания</param>
        public void EditMeeting(List<Meeting> meetings, int index)
        {
            if(meetings.Count > 0 && index <= meetings.Count)
            { 
            DateTime dateStart = DateChek("Введите дату и время начала совещаяния");
            DateTime dateEnd = DateChek("Введите дату и время окончания совещания");
            Console.WriteLine("Ведите тему совещания");
            string text = Console.ReadLine();
            DateTime remainder = DateChek("Введите дату и время когда напомнить о встрече");

            meetings[index-1]=new Meeting(dateStart, dateEnd, text, remainder);
            }
            else
            {
                Console.WriteLine("Такой строки нет в списке встреч");
            }
        }
        /// <summary>
        /// Получает и проверяет введённую дату от пользователя
        /// </summary>
        /// <param name="text">текст пользователя</param>
        /// <returns>Возвращает дату</returns>
        DateTime DateChek (string text)
        {
            DateTime date = DateTime.Now;
            string dateString = string.Empty;
            bool flag = false;
            while (!flag)
            {
                Console.WriteLine($"{text} в формате: дата месяца.месяц.год/пробел/час:минуты");
                dateString = Console.ReadLine();
                flag = DateTime.TryParse(dateString, out date);
            }

            return date;
        }
        /// <summary>
        /// Проучает и проверяет введённое число от пользователя
        /// </summary>
        /// <param name="text"></param>
        /// <returns>Возвращает int</returns>
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
       
      
    }
}
