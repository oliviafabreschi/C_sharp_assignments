using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Assignment_6
{
    class FileManager
    {
        private const string fileVersionToken = "ToDoRe_21";
        private const double fileVersionNr = 1.0;

        public bool SaveTaskListToFile(List<Task> taskList, string fileName)
        {
            bool ok = true;
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(fileName);
                writer.WriteLine(fileVersionToken);
                writer.WriteLine(fileVersionNr);
                writer.WriteLine(taskList.Count);

                for (int i = 0; i< taskList.Count; i++)
                {
                    writer.WriteLine(taskList[i].Description);
                    writer.WriteLine(taskList[i].Priority.ToString());
                    writer.WriteLine(taskList[i].TaskDate.Year);
                    writer.WriteLine(taskList[i].TaskDate.Month);
                    writer.WriteLine(taskList[i].TaskDate.Day);
                    writer.WriteLine(taskList[i].TaskDate.Hour);
                    writer.WriteLine(taskList[i].TaskDate.Minute);
                    writer.WriteLine(taskList[i].TaskDate.Second);

                }
            }
            catch
            {
                //if any error occours  
                ok = false;
            }
            finally
            {
                //always executed
                if (writer != null)
                    writer.Close();
            }
            return ok;
        }
        public bool ReadTaskListFrFile(List<Task> taskList, string fileName)
        {
            bool ok = true;
            StreamReader reader = null;

            try
            {
                //clear contents
                if (taskList != null)
                    taskList.Clear();
                else
                    taskList = new List<Task>();
                reader = new StreamReader(fileName);

                //ensure correct file
                string versionTest = reader.ReadLine();
                double version = double.Parse(reader.ReadLine());

                if ((versionTest == fileVersionToken) && (version == fileVersionNr))
                {
                    int count = int.Parse(reader.ReadLine());
                    for (int i = 0; i < count; i++)
                    {
                        Task task = new Task();
                        task.Description = reader.ReadLine();
                        task.Priority = (PriorityType)Enum.Parse(typeof(PriorityType), reader.ReadLine());

                        int year = 0, month = 0, day = 0;
                        int hour = 0, minute = 0, second = 0;

                        year = int.Parse(reader.ReadLine());
                        month = int.Parse(reader.ReadLine());
                        day = int.Parse(reader.ReadLine());
                        hour = int.Parse(reader.ReadLine());
                        minute = int.Parse(reader.ReadLine());
                        second = int.Parse(reader.ReadLine());

                        task.TaskDate = new DateTime(year, month, day, hour, minute, second);
                        taskList.Add(task);
                    }

                }
                else
                    ok = false;

            }
            catch
            {
                ok = false;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
            return ok;
        }


    }
}
