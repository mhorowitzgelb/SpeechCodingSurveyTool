using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUISurveyTool
{
    public partial class MainForm : Form
    {

        string gitFolderPath;

        public MainForm()
        {
            InitializeComponent();
        }

        private void openFolderBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            DialogResult result = fd.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                gitFolderPath = fd.SelectedPath;
                openFolderBtn.Visible = false;
                startBtn.Visible = true;
                directoryLabel.Text = "Git folder path:" + gitFolderPath;
            }
        }

        private void startBtn_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Please give this interview a name.");

            Console.WriteLine(result.ToString());

            string interviewName = "newInterview";

            if(InputBox("","Please give an interview name", ref interviewName)== DialogResult.OK)
            {
                Form1 child = new Form1(gitFolderPath, interviewName);
                child.ShowDialog(this);
            }

            /*
            string commandText = "/C cd " + gitFolderPath + " & mkdir TestDir & copy NUL " + gitFolderPath + "\\TestDir\\testFile.txt";

            System.Diagnostics.Process.Start("Notepad++.exe");*/
        }

        

        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }
}


}
