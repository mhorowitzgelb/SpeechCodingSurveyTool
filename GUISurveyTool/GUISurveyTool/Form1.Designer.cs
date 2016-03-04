namespace GUISurveyTool
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxSampleOutput = new System.Windows.Forms.TextBox();
            this.cancelCommitBtn = new System.Windows.Forms.Button();
            this.commitBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(242, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 52);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start Recoding";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxSampleOutput
            // 
            this.textBoxSampleOutput.Location = new System.Drawing.Point(12, 198);
            this.textBoxSampleOutput.Multiline = true;
            this.textBoxSampleOutput.Name = "textBoxSampleOutput";
            this.textBoxSampleOutput.Size = new System.Drawing.Size(533, 274);
            this.textBoxSampleOutput.TabIndex = 2;
            // 
            // cancelCommitBtn
            // 
            this.cancelCommitBtn.Location = new System.Drawing.Point(447, 127);
            this.cancelCommitBtn.Name = "cancelCommitBtn";
            this.cancelCommitBtn.Size = new System.Drawing.Size(75, 49);
            this.cancelCommitBtn.TabIndex = 3;
            this.cancelCommitBtn.Text = "Cancel";
            this.cancelCommitBtn.UseVisualStyleBackColor = true;
            this.cancelCommitBtn.Visible = false;
            this.cancelCommitBtn.Click += new System.EventHandler(this.cancelCommitBtn_Click);
            // 
            // commitBtn
            // 
            this.commitBtn.Location = new System.Drawing.Point(36, 127);
            this.commitBtn.Name = "commitBtn";
            this.commitBtn.Size = new System.Drawing.Size(75, 49);
            this.commitBtn.TabIndex = 4;
            this.commitBtn.Text = "Commit";
            this.commitBtn.UseVisualStyleBackColor = true;
            this.commitBtn.Visible = false;
            this.commitBtn.Click += new System.EventHandler(this.commitBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 484);
            this.Controls.Add(this.commitBtn);
            this.Controls.Add(this.cancelCommitBtn);
            this.Controls.Add(this.textBoxSampleOutput);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxSampleOutput;
        private System.Windows.Forms.Button cancelCommitBtn;
        private System.Windows.Forms.Button commitBtn;
    }
}

