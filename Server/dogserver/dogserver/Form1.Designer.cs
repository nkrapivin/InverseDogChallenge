namespace dogserver
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
            this.FastestTextBox = new System.Windows.Forms.TextBox();
            this.FastestLabel = new System.Windows.Forms.Label();
            this.LogBox = new System.Windows.Forms.RichTextBox();
            this.LogLabel = new System.Windows.Forms.Label();
            this.HTTPBgWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // FastestTextBox
            // 
            this.FastestTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FastestTextBox.Location = new System.Drawing.Point(62, 13);
            this.FastestTextBox.Name = "FastestTextBox";
            this.FastestTextBox.ReadOnly = true;
            this.FastestTextBox.Size = new System.Drawing.Size(706, 20);
            this.FastestTextBox.TabIndex = 0;
            // 
            // FastestLabel
            // 
            this.FastestLabel.AutoSize = true;
            this.FastestLabel.Location = new System.Drawing.Point(12, 16);
            this.FastestLabel.Name = "FastestLabel";
            this.FastestLabel.Size = new System.Drawing.Size(44, 13);
            this.FastestLabel.TabIndex = 1;
            this.FastestLabel.Text = "Fastest:";
            // 
            // LogBox
            // 
            this.LogBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogBox.Location = new System.Drawing.Point(15, 57);
            this.LogBox.Name = "LogBox";
            this.LogBox.ReadOnly = true;
            this.LogBox.Size = new System.Drawing.Size(752, 381);
            this.LogBox.TabIndex = 2;
            this.LogBox.Text = "";
            // 
            // LogLabel
            // 
            this.LogLabel.AutoSize = true;
            this.LogLabel.Location = new System.Drawing.Point(12, 41);
            this.LogLabel.Name = "LogLabel";
            this.LogLabel.Size = new System.Drawing.Size(28, 13);
            this.LogLabel.TabIndex = 3;
            this.LogLabel.Text = "Log:";
            // 
            // HTTPBgWorker
            // 
            this.HTTPBgWorker.WorkerReportsProgress = true;
            this.HTTPBgWorker.WorkerSupportsCancellation = true;
            this.HTTPBgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.HTTPBgWorker_DoWork);
            this.HTTPBgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.HTTPBgWorker_ProgressChanged);
            this.HTTPBgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.HTTPBgWorker_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 450);
            this.Controls.Add(this.LogLabel);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.FastestLabel);
            this.Controls.Add(this.FastestTextBox);
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "Form1";
            this.Text = "Inverse Dog Challenge Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FastestTextBox;
        private System.Windows.Forms.Label FastestLabel;
        private System.Windows.Forms.RichTextBox LogBox;
        private System.Windows.Forms.Label LogLabel;
        private System.ComponentModel.BackgroundWorker HTTPBgWorker;
    }
}

