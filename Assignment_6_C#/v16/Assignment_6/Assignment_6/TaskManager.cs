using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_6
{
    class TaskManager
    {
        //declare list where T is task type
        List<Task> taskList;
        
        //create tasklist in the constructor
        public TaskManager()
        {
            taskList = new List<Task> ();

        }

        public Task GetTask(int index)
        {
            if (CheckIndex(index))
                return taskList[index];
            else
                return null;
        }

        //to add new task
        public bool AddNewTask ( Task newTask)
        {
            bool ok = true;
                if (newTask != null)
                taskList.Add(newTask);
            else
                ok = false;

            return ok;
        }



        public bool AddNewTask (DateTime newTime, string description, PriorityType priority)
        {
            bool ok = true;
            //create new object with the above
            Task newTask = new Task(newTime, description, priority);
            if (newTask != null)
                taskList.Add(newTask);
            else
                ok = false;

            return ok;

        }

        public bool ChangeTaskAt (Task task, int index)
        {
            bool ok = true;
            //check for null and index in range
            if ((task!=null) && CheckIndex(index))
               taskList[index] = task;
            else
                ok = false;
            return ok;
        }

        //checking for index
        public bool CheckIndex(int index)
        {
            bool ok = false;
            if ((index >= 0) && (index < taskList.Count))
            {
                ok = true;
            }
            return ok;
        }

        //to delete the task at the index
        public bool DeleteTaskAt (int index)
        {
            bool ok = false;

            if ((index >=0) && (index < taskList.Count))
            {
                taskList.RemoveAt(index);
                ok = true;
            }
            return ok; 
        }

        public string[] GetInfoStringsList()
        {

            //local array of string element
            string[] infoStrings = new string[taskList.Count];
            for (int i = 0; i< infoStrings.Length; i++)
            {
                infoStrings[i] = taskList[i].ToString();

            }
            return infoStrings;
        }
        //filemanager is a class that handles saving and reading data
        //to and from text file
        //the below sends the tasklist to the filename
        public bool WriteDataToFile(string fileName)
        {
            FileManager fileManager = new FileManager();
            return fileManager.SaveTaskListToFile(taskList, fileName);
         }

        //send the object declared above. taskList is an object,
        //so will have the changes made in the FileManger when
        //the method returns
        public bool ReadDataFromFile(string fileName)
        {
            FileManager fileManager = new FileManager();
            //objects pass by ref so taskList can be updated
            
            return fileManager.ReadTaskListFrFile(taskList, fileName);
        }
    }
}
