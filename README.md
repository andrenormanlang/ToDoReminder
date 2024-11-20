# ToDoReminder Application 📝

## Overview

ToDoReminder is a Windows Forms desktop application that helps users manage their tasks efficiently. It allows users to add, edit, delete, and print tasks with a user-friendly interface while providing various priority levels for better task organization.

## Features 🚀

- **Add New Tasks** ➕: Add tasks with a title, date, time, and priority level.
- **Edit Existing Tasks** ✏️: Modify details of an existing task.
- **Delete Tasks** ❌: Remove tasks when they're no longer needed.
- **Prioritize Tasks** ⭐: Choose from multiple priority levels (Very Important, Important, Normal, Less Important, Not Important) for each task.
- **Print Task List** 🖨️: Print out the list of tasks with all details using the Print Dialog functionality.
- **Real-Time Clock** ⏰: Displays the current date and time for reference.

## Screenshots 📸
![image](https://github.com/user-attachments/assets/429ce3f3-b985-4f68-a83b-ae3fe3489fa9)

## Installation 💻

### Prerequisites

- **.NET Framework 4.8 or above**: Required to run the application.
- **Visual Studio (Optional for modification)**: If you wish to modify the source code.

### Steps

1. **Download the Project** 📥: Clone the repository or download the ZIP file.
   
   ```sh
   git clone https://github.com/andrenormanlang/ToDoReminder.git
   ```

2. **Open Solution** 🗂️: Open the `.sln` file in Visual Studio.
3. **Restore NuGet Packages** 🔄: Restore any required NuGet packages.
4. **Run the Application** ▶️: Press `F5` to build and run the application.

## Usage 🛠️

### Adding a New Task ➕

1. Set the Date and Time using the DateTime picker.
2. Enter a Description for the task.
3. Select a Priority from the dropdown.
4. Click the **Add** button to add the task to the list.

### Editing an Existing Task ✏️

1. Select the task to be modified from the task list.
2. Change the Date, Time, Priority, or Description.
3. Click **Change** to save modifications.

### Deleting a Task ❌

1. Select the task to be deleted.
2. Click the **Delete** button.

### Printing the Task List 🖨️

1. Click the **Print** button.
2. Choose the printer from the Print Dialog.
3. Confirm to print the task list.

### Exiting the Application 🚪

Use the **Exit** option from the File menu to close the application.

## Project Structure 📁

```
ToDoReminder
│   README.md
│   ToDoReminder.sln
│
└───ToDoReminder
    │   MainForm.cs
    │   MainForm.Designer.cs
    │   AboutBox1.cs
    │   Task.cs
    │   TaskManager.cs
    │   FileManager.cs
    │   Program.cs
    │
    ├───Properties
    │       AssemblyInfo.cs
    │       Resources.resx
    │       Settings.settings
    │
    ├───Resources
    │       app-icon.png       // Application icon
    │       reminder-screenshot.png
```

## Key Files 🗝️

- **MainForm.cs**: The main form containing logic for adding, deleting, editing, and managing tasks.
- **Task.cs**: Represents a task, including properties like Date, Description, and Priority.
- **TaskManager.cs**: Handles operations such as adding, deleting, and changing tasks.
- **FileManager.cs**: Responsible for saving and loading tasks to/from a file.

## Troubleshooting 🛠️

### Common Issues

- **File Access Errors** ⚠️:
  - Ensure the application has permission to read/write to the directory.
- **Misaligned Task List Items** 📋:
  - The application displays task details in a ListBox, and text alignment issues may arise. Adjust the column width or modify the `ToString()` representation in `Task.cs` to ensure consistency.
- **Printing Issues** 🖨️:
  - Ensure a printer is properly configured on your system.

## Contributing 🤝

Contributions are welcome! If you would like to contribute:

1. **Fork** the repository.
2. Create a new branch (`git checkout -b feature/my-feature`).
3. Commit your changes (`git commit -m 'Add new feature'`).
4. Push to the branch (`git push origin feature/my-feature`).
5. Open a **Pull Request**.

## License 📄

This project is licensed under the MIT License. See the LICENSE file for more details.



