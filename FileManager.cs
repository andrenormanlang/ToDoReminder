using System;
using System.Collections.Generic;
using System.IO;

namespace ToDoReminder
{
    /// <summary>
    /// Handles file management for saving and loading task lists.
    /// </summary>
    class FileManager
    {
        /// <summary>
        /// A token used to identify the file version.
        /// </summary>
        private const string fileVersionToken = "ToDoReminder_ANL";

        /// <summary>
        /// The version number of the file format used to save and load tasks.
        /// </summary>
        private const double fileVersionNr = 1.0;

        /// <summary>
        /// Saves the task list to a file in a specific format.
        /// </summary>
        /// <param name="taskList">The list of tasks to save.</param>
        /// <param name="fileName">The name of the file to save to.</param>
        /// <returns>True if the tasks were saved successfully, otherwise false.</returns>
        public bool SaveTaskListToFile(List<Task> taskList, string fileName)
        {
            bool ok = true;
            StreamWriter writer = null;

            try
            {
                writer = new StreamWriter(fileName);

                // Write version information and task count
                writer.WriteLine(fileVersionToken);
                writer.WriteLine(fileVersionNr);
                writer.WriteLine(taskList.Count);

                // Write task details to the file
                for (int i = 0; i < taskList.Count; i++)
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
                ok = false;
            }
            finally
            {
                // Close the writer if it was successfully created
                if (writer != null)
                    writer.Close();
            }

            return ok;
        }

        /// <summary>
        /// Reads a list of tasks from a file and loads them into the provided task list.
        /// </summary>
        /// <param name="taskList">A reference to the list of tasks to populate with data from the file.</param>
        /// <param name="fileName">The name of the file to read from.</param>
        /// <returns>True if the tasks were loaded successfully, otherwise false.</returns>
        public bool ReadTaskListFromFile(ref List<Task> taskList, string fileName)
        {
            bool ok = true;
            StreamReader reader = null;

            try
            {
                // Clear or create the task list to prepare it for loading new data
                if (taskList != null)
                    taskList.Clear();
                else
                    taskList = new List<Task>();

                reader = new StreamReader(fileName);

                // Read version information and verify file integrity
                string fileVersionTest = reader.ReadLine();
                double version = double.Parse(reader.ReadLine());

                if ((fileVersionTest == fileVersionToken) && (version == fileVersionNr))
                {
                    int count = int.Parse(reader.ReadLine());

                    // Read each task's details and populate the list
                    for (int i = 0; i < count; i++)
                    {
                        Task task = new Task
                        {
                            Description = reader.ReadLine(),
                            Priority = (PriorityType)Enum.Parse(typeof(PriorityType), reader.ReadLine())
                        };

                        // Read and parse task date components
                        int year = int.Parse(reader.ReadLine());
                        int month = int.Parse(reader.ReadLine());
                        int day = int.Parse(reader.ReadLine());
                        int hour = int.Parse(reader.ReadLine());
                        int minute = int.Parse(reader.ReadLine());
                        int second = int.Parse(reader.ReadLine());

                        task.TaskDate = new DateTime(year, month, day, hour, minute, second);

                        // Add task to the list
                        taskList.Add(task);
                    }
                }
                else
                {
                    ok = false; // Version mismatch or invalid file
                }
            }
            catch
            {
                ok = false; // General error occurred
            }
            finally
            {
                // Close the reader if it was successfully created
                if (reader != null)
                    reader.Close();
            }

            return ok;
        }
    }
}


