using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_6
{
    public class Task
    {
        private DateTime date; //date and time
        private string description; //tasks notes
        private PriorityType priority; //priority

        public Task()
        {

            //default
            priority = PriorityType.Normal;
        }

        public Task(DateTime taskDate) : this(taskDate, string.Empty, PriorityType.Normal)
        {
            //no code needed
        }

        public Task(DateTime taskDate, string description, PriorityType priority)
        
        {
            this.date = taskDate;
            this.description = description;
            this.priority = priority;
        }

        public DateTime DateAndTime
        {
            get { return date; }

            set { date = value; }
        }
        public PriorityType Priority
        {
            get { return priority; }

            set { priority = value; }
        }

        public string Description
        {
            get { return description; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    description = value;
            }

        }

        public DateTime TaskDate
        {
            get { return date; }

            set { date = value; }
        }

        private string GetTimeString()
        {
            string time = string.Format("{0}:{1}", date.Hour.ToString("00"),
                date.Minute.ToString("00"));
           
            return time;
        }

        public string GetPriorityString()
        {
            string txtOut = Enum.GetName(typeof(PriorityType), priority);
             txtOut = txtOut.Replace("_", " ");
            return txtOut;
        }

        public override string ToString()
        {//dollar sign saame as string.format
            string textOut = $"{date.ToLongDateString(),-25} {GetTimeString(),12}{" ",6}"+
            $"{GetPriorityString(),-16} {description, -20}";
            return textOut;
        }


    }
}
