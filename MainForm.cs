using System;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace ToDoReminder
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Manages the list of tasks for the application.
        /// </summary>
        private TaskManager taskManager;

        /// <summary>
        /// The file path where the task list is saved and loaded.
        /// </summary>
        private string fileName = Application.StartupPath + "\\Tasks.txt";

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// Sets up the form and initializes the GUI.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            // Set up GUI components and initial states
            InitializeGUI();

            // Attach PrintPage event handler for the PrintDocument
            printDocument1.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
        }

        /// <summary>
        /// Configures the initial state of GUI elements, sets up tooltips, and starts timers.
        /// </summary>
        private void InitializeGUI()
        {
            // Set the window title
            this.Text = "ToDo Reminder Application by André N. Lang";

            // Instantiate a new TaskManager object
            taskManager = new TaskManager();

            // Populate priority combobox with all priority types and set the default selection
            cmbPriority.Items.Clear();
            cmbPriority.Items.AddRange(Enum.GetNames(typeof(PriorityType)));
            cmbPriority.SelectedIndex = (int)PriorityType.Normal;

            // Clear task list and set label text to default
            lstTasks.Items.Clear();
            lblTime.Text = string.Empty;
            clockTimer.Start(); // Start the timer to update the clock

            txtDescription.Text = string.Empty; // Clear description input

            // Configure DateTimePicker to display custom format (date and time)
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm";

            // Configure tooltips for different controls to guide the user
            toolTip.ShowAlways = true;

            toolTip.SetToolTip(dateTimePicker, "Click to open calendar for date, write in time here");
            toolTip.SetToolTip(cmbPriority, "Select priority for the task");

            string tips = "To change: Select an item first" + Environment.NewLine +
                          "Make your changes in input controls" + Environment.NewLine +
                          "Click Change button to save changes" + Environment.NewLine;

            toolTip.SetToolTip(lstTasks, tips);
            toolTip.SetToolTip(btnChange, tips);

            string desTips = "Enter a description for the task";
            toolTip.SetToolTip(txtDescription, desTips);

            // Enable menu items for opening and saving files
            menuFileOpen.Enabled = true;
            menuFileSave.Enabled = true;
        }

        /// <summary>
        /// Updates the current time label (lblTime) to reflect the current system time.
        /// </summary>
        /// <param name="sender">The event source (clock timer).</param>
        /// <param name="e">Event arguments (empty for timer events).</param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = $"{DateTime.Now.ToLongDateString()} {DateTime.Now.ToLongTimeString()}";
        }

        /// <summary>
        /// Handles the event for the 'New' menu item to reset the GUI to its default state.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void newMenuItem_Click(object sender, EventArgs e)
        {
            InitializeGUI();
        }

        /// <summary>
        /// Opens the task list from the specified file and updates the GUI.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void menuFileOpen_click(object sender, EventArgs e)
        {
            bool ok = taskManager.ReadTaskListFromFile(fileName);
            if (!ok)
            {
                string errMessage = "Something went wrong when opening the file";
                MessageBox.Show(errMessage);
            }
            else
            {
                UpdateGUI();
            }
        }

        /// <summary>
        /// Saves the current task list to the specified file.
        /// Displays appropriate messages for success or failure.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void menuFileSave_Click(object sender, EventArgs e)
        {
            string errMessage = "Something went wrong when saving the file";
            bool ok = taskManager.SaveTaskListToFile(fileName);
            if (!ok)
                MessageBox.Show(errMessage);
            else
                MessageBox.Show("Data saved to file:" + Environment.NewLine + fileName);
        }

        /// <summary>
        /// Displays the About dialog box to provide application details.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 dlgAbout = new AboutBox1();
            dlgAbout.ShowDialog();
        }

        /// <summary>
        /// Reads the input from the user, creates a new task, and adds it to the task manager.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Task task = ReadInput();
            if (task != null && taskManager.AddNewTask(task))
            {
                UpdateGUI();
            }
        }

        /// <summary>
        /// Reads user input from the form controls to create a new <see cref="Task"/>.
        /// If the input is invalid, returns <c>null</c>.
        /// </summary>
        /// <returns>A new <see cref="Task"/> object if the input is valid; otherwise, <c>null</c>.</returns>
        private Task ReadInput()
        {
            Task task = new Task();
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageBox.Show("Please enter a description for the task", "Missing Description");
                return null;
            }

            // Set task properties based on user input
            task.Description = txtDescription.Text;
            task.TaskDate = dateTimePicker.Value;
            task.Priority = (PriorityType)cmbPriority.SelectedIndex;

            return task;
        }

        /// <summary>
        /// Deletes the selected task from the list after user confirmation.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedIndex >= 0)
            {
                var result = MessageBox.Show("Are you sure you want to delete the selected task?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    taskManager.DeleteTaskAt(lstTasks.SelectedIndex);
                    UpdateGUI();
                }
            }
        }

        /// <summary>
        /// Updates an existing task in the list based on user input.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void BtnChange_Click(object sender, EventArgs e)
        {
            int index = lstTasks.SelectedIndex;
            if (index >= 0)
            {
                Task task = ReadInput();
                if (task != null && taskManager.ChangeTaskAt(task, index))
                {
                    UpdateGUI();
                }
            }
            else
            {
                MessageBox.Show("Please select a task to change", "No Task Selected");
            }
        }

        /// <summary>
        /// Handles the event when a different item is selected in the task list.
        /// Updates the enabled state of the Change and Delete buttons.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void listBoxTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isItemSelected = lstTasks.SelectedIndex >= 0;
            btnChange.Enabled = isItemSelected;
            btnDelete.Enabled = isItemSelected;
        }

        /// <summary>
        /// Updates the task list GUI to reflect the current tasks in <see cref="taskManager"/>.
        /// </summary>
        private void UpdateGUI()
        {
            lstTasks.Items.Clear();
            string[] infoStrings = taskManager.GetInfoStringsList();
            if (infoStrings != null)
            {
                lstTasks.Items.AddRange(infoStrings);
            }
        }

        /// <summary>
        /// Prompts the user to confirm before closing the application.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = MessageBox.Show("Are you sure you want to exit?", "Think twice", MessageBoxButtons.OKCancel);
            if (dlgResult == DialogResult.OK)
            {
                Close();
            }
        }

        /// <summary>
        /// Handles the printing process by rendering each task onto the printed page.
        /// </summary>
        /// <param name="sender">The print document object.</param>
        /// <param name="e">The event data containing the graphics object used for printing.</param>
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Define the font and set the initial vertical position for printing tasks
            Font printFont = new Font("Arial", 10);
            float yPos = 10;

            // Iterate through each task and draw it on the printed page
            foreach (var item in lstTasks.Items)
            {
                string taskDetails = item.ToString();
                yPos += 20; // Line spacing between tasks
                e.Graphics.DrawString(taskDetails, printFont, Brushes.Black, 50, yPos);
            }
        }

        /// <summary>
        /// Displays the print dialog and initiates the printing process if the user confirms.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void BtnPrint_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.PrinterSettings = printDialog1.PrinterSettings;
                try
                {
                    printDocument1.Print();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while trying to print: " + ex.Message);
                }
            }
        }
    }
}
