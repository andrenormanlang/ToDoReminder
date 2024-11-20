using System;
using System.Collections.Generic;
using System.IO;

namespace ToDoReminder
{
    /// <summary>
    /// Manages a list of tasks, including adding, deleting, and updating tasks.
    /// Also supports saving to and reading from a file.
    /// </summary>
    public class TaskManager
    {
        // List to store tasks
        private List<Task> taskList;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskManager"/> class.
        /// Creates an empty task list.
        /// </summary>
        public TaskManager()
        {
            taskList = new List<Task>();
        }

        /// <summary>
        /// Adds a new task to the task list.
        /// </summary>
        /// <param name="newTask">The task to add to the list.</param>
        /// <returns>True if the task was added successfully, otherwise false.</returns>
        public bool AddNewTask(Task newTask)
        {
            bool ok = true;

            if (newTask != null)
                taskList.Add(newTask);
            else
                ok = false;

            return ok;
        }

        /// <summary>
        /// Deletes a task from the task list at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the task to delete.</param>
        /// <returns>True if the task was deleted successfully, otherwise false.</returns>
        public bool DeleteTaskAt(int index)
        {
            bool ok = false;
            if ((index >= 0) && (index < taskList.Count))
            {
                taskList.RemoveAt(index);
                ok = true;
            }
            return ok;
        }

        /// <summary>
        /// Gets an array of task details formatted as strings for all tasks in the task list.
        /// </summary>
        /// <returns>An array of strings, each representing a task in the list.</returns>
        public string[] GetInfoStringsList()
        {
            string[] infoStrings = new string[taskList.Count];
            for (int i = 0; i < taskList.Count; i++)
            {
                infoStrings[i] = taskList[i].ToString();
            }
            return infoStrings;
        }

        /// <summary>
        /// Changes the details of a task at the specified index.
        /// </summary>
        /// <param name="task">The updated task to replace the existing task.</param>
        /// <param name="index">The zero-based index of the task to change.</param>
        /// <returns>True if the task was successfully updated, otherwise false.</returns>
        public bool ChangeTaskAt(Task task, int index)
        {
            bool ok = true;
            if ((task != null) && CheckIndex(index))
                taskList[index] = task;
            else
                ok = false;

            return ok;
        }

        /// <summary>
        /// Checks if the provided index is within the bounds of the task list.
        /// </summary>
        /// <param name="index">The zero-based index to check.</param>
        /// <returns>True if the index is valid, otherwise false.</returns>
        public bool CheckIndex(int index)
        {
            bool ok = false;

            if ((index >= 0) && (index < taskList.Count))
            {
                ok = true;
            }
            return ok;
        }

        /// <summary>
        /// Saves the current task list to a file.
        /// </summary>
        /// <param name="fileName">The name of the file to save the tasks to.</param>
        /// <returns>True if the tasks were saved successfully, otherwise false.</returns>
        public bool SaveTaskListToFile(string fileName)
        {
            FileManager fileManager = new FileManager();
            return fileManager.SaveTaskListToFile(taskList, fileName);
        }

        /// <summary>
        /// Reads a list of tasks from a file and replaces the current task list.
        /// </summary>
        /// <param name="fileName">The name of the file to read tasks from.</param>
        /// <returns>True if the tasks were read successfully, otherwise false.</returns>
        public bool ReadTaskListFromFile(string fileName)
        {
            FileManager fileManager = new FileManager();
            return fileManager.ReadTaskListFromFile(ref taskList, fileName);
        }
    }
}


