using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace ToDoReminder
{
    partial class MainForm : Form
    {
        private IContainer components = null;

        // Explicit control declarations to ensure they exist in the current context
        private MenuStrip menuMain;
        private ToolStripMenuItem fileMenuItem;
        private ToolStripMenuItem newMenuItem;
        private ToolStripMenuItem menuFileOpen;
        private ToolStripMenuItem menuFileSave;
        private ToolStripMenuItem exitMenuItem;
        private ToolStripMenuItem helpMenuItem;
        private ToolStripMenuItem aboutMenuItem;
        private DateTimePicker dateTimePicker;
        private ComboBox cmbPriority;
        private TextBox txtDescription;
        private ListBox lstTasks;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnChange;
        private Button btnPrint;
        private Label lblTime;
        private System.Windows.Forms.Timer clockTimer;
        private ToolTip toolTip;
        private PrintDocument printDocument1 = new PrintDocument();
        private PrintDialog printDialog1 = new PrintDialog();

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
            menuMain = new MenuStrip();
            fileMenuItem = new ToolStripMenuItem();
            newMenuItem = new ToolStripMenuItem();
            menuFileOpen = new ToolStripMenuItem();
            menuFileSave = new ToolStripMenuItem();
            exitMenuItem = new ToolStripMenuItem();
            helpMenuItem = new ToolStripMenuItem();
            aboutMenuItem = new ToolStripMenuItem();
            dateTimePicker = new DateTimePicker();
            cmbPriority = new ComboBox();
            txtDescription = new TextBox();
            lstTasks = new ListBox();
            btnAdd = new Button();
            btnDelete = new Button();
            btnChange = new Button();
            lblTime = new Label();
            clockTimer = new System.Windows.Forms.Timer(components);
            toolTip = new ToolTip(components);
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            groupBox1 = new GroupBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label4 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            btnPrint = new Button();
            menuMain.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // menuMain
            // 
            menuMain.ImageScalingSize = new Size(20, 20);
            menuMain.Items.AddRange(new ToolStripItem[] { fileMenuItem, helpMenuItem });
            menuMain.Location = new Point(0, 0);
            menuMain.Name = "menuMain";
            menuMain.Size = new Size(1124, 28);
            menuMain.TabIndex = 0;
            menuMain.Text = "menuMain";
            // 
            // fileMenuItem
            // 
            fileMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newMenuItem, menuFileOpen, menuFileSave, exitMenuItem });
            fileMenuItem.Name = "fileMenuItem";
            fileMenuItem.Size = new Size(46, 24);
            fileMenuItem.Text = "File";
            // 
            // newMenuItem
            // 
            newMenuItem.Name = "newMenuItem";
            newMenuItem.Size = new Size(128, 26);
            newMenuItem.Text = "New";
            newMenuItem.Click += newMenuItem_Click;
            // 
            // menuFileOpen
            // 
            menuFileOpen.Name = "menuFileOpen";
            menuFileOpen.Size = new Size(128, 26);
            menuFileOpen.Text = "Open";
            menuFileOpen.Click += menuFileOpen_click;
            // 
            // menuFileSave
            // 
            menuFileSave.Name = "menuFileSave";
            menuFileSave.Size = new Size(128, 26);
            menuFileSave.Text = "Save";
            menuFileSave.Click += menuFileSave_Click;
            // 
            // exitMenuItem
            // 
            exitMenuItem.Name = "exitMenuItem";
            exitMenuItem.Size = new Size(128, 26);
            exitMenuItem.Text = "Exit";
            exitMenuItem.Click += ExitMenuItem_Click;
            // 
            // helpMenuItem
            // 
            helpMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutMenuItem });
            helpMenuItem.Name = "helpMenuItem";
            helpMenuItem.Size = new Size(55, 24);
            helpMenuItem.Text = "Help";
            // 
            // aboutMenuItem
            // 
            aboutMenuItem.Name = "aboutMenuItem";
            aboutMenuItem.Size = new Size(133, 26);
            aboutMenuItem.Text = "About";
            aboutMenuItem.Click += AboutMenuItem_Click;
            // 
            // dateTimePicker
            // 
            dateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm";
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.Location = new Point(156, 80);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(314, 27);
            dateTimePicker.TabIndex = 1;
            toolTip.SetToolTip(dateTimePicker, "Click to open calendar for date, write in time here.");
            // 
            // cmbPriority
            // 
            cmbPriority.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPriority.FormattingEnabled = true;
            cmbPriority.Items.AddRange(new object[] { "Very_important", "Important", "Normal", "Less_important", "Not_important" });
            cmbPriority.Location = new Point(559, 80);
            cmbPriority.Name = "cmbPriority";
            cmbPriority.Size = new Size(150, 28);
            cmbPriority.TabIndex = 2;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(106, 117);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(603, 27);
            txtDescription.TabIndex = 3;
            // 
            // lstTasks
            // 
            lstTasks.Font = new Font("Courier New", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstTasks.FormattingEnabled = true;
            lstTasks.Location = new Point(18, 50);
            lstTasks.Name = "lstTasks";
            lstTasks.Size = new Size(1045, 204);
            lstTasks.TabIndex = 4;
            lstTasks.SelectedIndexChanged += listBoxTasks_SelectedIndexChanged;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(299, 150);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(135, 31);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += BtnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(254, 482);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(180, 30);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += BtnDelete_Click;
            // 
            // btnChange
            // 
            btnChange.Location = new Point(81, 480);
            btnChange.Name = "btnChange";
            btnChange.Size = new Size(140, 30);
            btnChange.TabIndex = 7;
            btnChange.Text = "Change";
            btnChange.UseVisualStyleBackColor = true;
            btnChange.Click += BtnChange_Click;
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTime.ForeColor = Color.Blue;
            lblTime.Location = new Point(650, 482);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(136, 25);
            lblTime.TabIndex = 8;
            lblTime.Text = "Date and Time";
            // 
            // clockTimer
            // 
            clockTimer.Enabled = true;
            clockTimer.Interval = 1000;
            clockTimer.Tick += Timer_Tick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 82);
            label1.Name = "label1";
            label1.Size = new Size(104, 20);
            label1.TabIndex = 9;
            label1.Text = "Date and time";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 120);
            label2.Name = "label2";
            label2.Size = new Size(47, 20);
            label2.TabIndex = 10;
            label2.Text = "To do";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(497, 85);
            label3.Name = "label3";
            label3.Size = new Size(56, 20);
            label3.TabIndex = 11;
            label3.Text = "Priority";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(lstTasks);
            groupBox1.ForeColor = Color.Green;
            groupBox1.Location = new Point(27, 186);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1085, 288);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "To Do";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = SystemColors.ActiveCaptionText;
            label8.Location = new Point(698, 27);
            label8.Name = "label8";
            label8.Size = new Size(85, 20);
            label8.TabIndex = 17;
            label8.Text = "Description";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = SystemColors.ActiveCaptionText;
            label7.Location = new Point(488, 27);
            label7.Name = "label7";
            label7.Size = new Size(56, 20);
            label7.TabIndex = 16;
            label7.Text = "Priority";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = SystemColors.ActiveCaptionText;
            label6.Location = new Point(381, 27);
            label6.Name = "label6";
            label6.Size = new Size(42, 20);
            label6.TabIndex = 15;
            label6.Text = "Hour";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(21, 27);
            label4.Name = "label4";
            label4.Size = new Size(41, 20);
            label4.TabIndex = 13;
            label4.Text = "Date";
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(466, 484);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(147, 28);
            btnPrint.TabIndex = 9;
            btnPrint.Text = "Print";
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += BtnPrint_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1124, 597);
            Controls.Add(btnPrint);
            Controls.Add(groupBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(menuMain);
            Controls.Add(btnDelete);
            Controls.Add(dateTimePicker);
            Controls.Add(btnChange);
            Controls.Add(cmbPriority);
            Controls.Add(txtDescription);
            Controls.Add(btnAdd);
            Controls.Add(lblTime);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuMain;
            Name = "MainForm";
            Text = "ToDo Reminder";
            menuMain.ResumeLayout(false);
            menuMain.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private GroupBox groupBox1;
        private Label label4;
        private Label label8;
        private Label label7;
        private Label label6;
        private System.Windows.Forms.Timer timer1;

    }
}
