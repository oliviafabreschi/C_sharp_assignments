using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Assignment_6
{
    public partial class MainForm : Form
    {

        private TaskManager taskManager;
        string fileName = Application.StartupPath + "\\Tasks.txt";
        public MainForm()
        {
            InitializeComponent();
            InitializeGUI();
        }

        //initialisation
        private void InitializeGUI()
        {
            this.Text = "To Do Reminder by Olivia";

            taskManager = new TaskManager();

            cmbxPriority.Items.Clear();
            cmbxPriority.Items.AddRange(Enum.GetNames(typeof(PriorityType)));
            cmbxPriority.SelectedIndex = (int)PriorityType.Normal;
            //initialisation of text boxes and time
            lstTasks.Items.Clear();
            lblClock.Text = string.Empty; //to make
            clockTimer.Start();
            lblClock.Text = DateTime.Now.ToString();
            txtbxToDo.Text = string.Empty;

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm";

            toolTip1.ShowAlways = true; 
            //tooltips showing information

            toolTip1.SetToolTip(dateTimePicker1, "click to open calendar");
            toolTip1.SetToolTip(cmbxPriority, "select priority");
            toolTip1.SetToolTip(txtbxToDo, "Describe the task");
            toolTip1.SetToolTip(btnAdd, "Add the task");

            string tips = "TO CHANGE: Select an item first!" + Environment.NewLine;
            tips += "Make changes in the input controls," + Environment.NewLine;
            tips += "Click the change button" + Environment.NewLine;

            toolTip1.SetToolTip(lstTasks, tips);
            toolTip1.SetToolTip(btnChange, tips);

            string delTips = "Select an item then click delete button";
            toolTip1.SetToolTip(btnDelete, delTips);

           // string desTips = "Write your sins here";
           // toolTip1.SetToolTip(txtbxToDo, desTips);

            openDataFileToolStripMenuItem.Enabled = true;
            saveDataFileToolStripMenuItem.Enabled = true;

            //disable deleteand change button
            btnDelete.Enabled = false;
            btnChange.Enabled = false;
        }

  
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Task task = ReadInput();
            if (taskManager.AddNewTask (task))
            {
                UpdateGUI();
            }    

        }
        private Task ReadInput()
        {
            Task task = new Task();
            if (string.IsNullOrEmpty(txtbxToDo.Text))
            {
                MessageBox.Show("No subject? Write something please", "Hello...");
                return null;
            } 
            task.Description = txtbxToDo.Text;
            task.TaskDate = dateTimePicker1.Value;
            task.Priority = (PriorityType)cmbxPriority.SelectedIndex;

            return task;
        }

        private void UpdateGUI()
        {
            lstTasks.Items.Clear();
            string[] infoStrings = taskManager.GetInfoStringsList();
            if (infoStrings != null)
                lstTasks.Items.AddRange(infoStrings);
            btnDelete.Enabled = true;
            btnChange.Enabled = true;

        }
        //when exiting menu
        private void menuFileExit_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = MessageBox.Show("Sure to exit?", "Think twice", MessageBoxButtons.OKCancel);

                if (dlgResult == DialogResult.OK)
                Application.Exit();
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitializeGUI();
        }

        private void openDataFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool ok = taskManager.ReadDataFromFile(fileName);
            if (!ok)
            {
                string errmessage = "something went wrong when opening the file";
                MessageBox.Show(errmessage);
            }
            else
                UpdateGUI();

        }

        private void saveDataFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string errMessage = "something went wrong while saving";
            bool ok = taskManager.WriteDataToFile(fileName);
            if (!ok)
                MessageBox.Show(errMessage);
            else
                MessageBox.Show("Data saved to file:" + Environment.NewLine + fileName);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = MessageBox.Show("Sure to exit?", "Think twice", MessageBoxButtons.OKCancel);

            if (dlgResult == DialogResult.OK)
                Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }


        //to delete a task as per index
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string[] infoStrings = taskManager.GetInfoStringsList();
            int index = lstTasks.SelectedIndex;

            if (index >= 0)
            {
                taskManager.DeleteTaskAt(index);

            }

            UpdateGUI();
        }
        
        //in order to show the time as label
        private void clockTimer_Tick(object sender, EventArgs e)
        {
            this.lblClock.Text = DateTime.Now.ToString();
        }

        //to select index of task to change 
        private void btnChange_Click(object sender, EventArgs e)
        {
            Task task = new Task();
            string[] infoStrings = taskManager.GetInfoStringsList();
            int index = lstTasks.SelectedIndex;

            if (index >= 0)
            {
                taskManager.ChangeTaskAt(task, index);

            }

            UpdateGUI();
        }

    }
}
