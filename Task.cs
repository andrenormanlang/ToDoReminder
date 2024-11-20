using System;

namespace ToDoReminder
{
    /// <summary>
    /// Represents a task with a date, description, and priority level.
    /// </summary>
    public class Task
    {
        // Fields
        private DateTime date;          // Stores the date and time of the task.
        private string description;     // Stores a description of the task.
        private PriorityType priority;  // Stores the priority level of the task.

        /// <summary>
        /// Initializes a new instance of the <see cref="Task"/> class with default values.
        /// The default priority is set to Normal.
        /// </summary>
        public Task()
        {
            // Set the default priority type to Normal.
            priority = PriorityType.Normal;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Task"/> class with the specified values.
        /// </summary>
        /// <param name="taskDate">The date and time of the task.</param>
        /// <param name="description">The description of the task.</param>
        /// <param name="priority">The priority level of the task.</param>
        public Task(DateTime taskDate, string description, PriorityType priority)
        {
            this.date = taskDate;
            this.description = description;
            this.priority = priority;
        }

        /// <summary>
        /// Gets or sets the priority level of the task.
        /// </summary>
        public PriorityType Priority
        {
            get { return priority; }
            set { priority = value; }
        }

        /// <summary>
        /// Gets or sets the description of the task.
        /// </summary>
        /// <remarks>
        /// The description cannot be null or empty. If an invalid value is provided,
        /// the existing description remains unchanged.
        /// </remarks>
        public string Description
        {
            get { return description; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    description = value;
            }
        }

        /// <summary>
        /// Gets or sets the date and time of the task.
        /// </summary>
        public DateTime TaskDate
        {
            get { return date; }
            set { date = value; }
        }

        /// <summary>
        /// Generates a formatted time string based on the task's date.
        /// </summary>
        /// <returns>A string representing the task's time in "HH:mm" format.</returns>
        private string GetTimeString()
        {
            string time = string.Format("{0}:{1}", date.Hour.ToString("00"), date.Minute.ToString("00"));
            return time;
        }

        /// <summary>
        /// Generates a formatted priority string for the task.
        /// </summary>
        /// <remarks>
        /// The underscore character in the priority enum name is replaced with a space.
        /// </remarks>
        /// <returns>A string representing the priority of the task.</returns>
        private string GetPriorityString()
        {
            string txtOut = Enum.GetName(typeof(PriorityType), priority);
            txtOut = txtOut.Replace("_", " ");
            return txtOut;
        }

        /// <summary>
        /// Returns a formatted string representation of the task.
        /// </summary>
        /// <remarks>
        /// The string representation includes the date, time, priority, and description.
        /// </remarks>
        /// <returns>
        /// A formatted string containing the task details:
        /// Date (in a long format), time (HH:mm), priority (formatted), and the task description.
        /// </returns>
        public override string ToString()
        {
            string textOut = $"{date.ToLongDateString(),-30} {GetTimeString(),10} {"",5}" +
                             $"{GetPriorityString(),-20} {description,-20}";
            return textOut;
        }
    }
}


