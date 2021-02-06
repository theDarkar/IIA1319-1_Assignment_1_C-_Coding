
namespace DAQ_Simulator
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
            this.components = new System.ComponentModel.Container();
            this.btnSampling = new System.Windows.Forms.Button();
            this.btnLogOnFile = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.grpBoxSampling = new System.Windows.Forms.GroupBox();
            this.lblNxtSampTime = new System.Windows.Forms.Label();
            this.grpBocLogging = new System.Windows.Forms.GroupBox();
            this.lblNxtLogTime = new System.Windows.Forms.Label();
            this.grpBoxSensorVal = new System.Windows.Forms.GroupBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnMenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMenuOperations = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMenuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.grpBoxSampling.SuspendLayout();
            this.grpBocLogging.SuspendLayout();
            this.grpBoxSensorVal.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSampling
            // 
            this.btnSampling.Location = new System.Drawing.Point(34, 95);
            this.btnSampling.Name = "btnSampling";
            this.btnSampling.Size = new System.Drawing.Size(98, 23);
            this.btnSampling.TabIndex = 0;
            this.btnSampling.Text = "Sampling";
            this.btnSampling.UseVisualStyleBackColor = true;
            // 
            // btnLogOnFile
            // 
            this.btnLogOnFile.Location = new System.Drawing.Point(34, 104);
            this.btnLogOnFile.Name = "btnLogOnFile";
            this.btnLogOnFile.Size = new System.Drawing.Size(93, 23);
            this.btnLogOnFile.TabIndex = 1;
            this.btnLogOnFile.Text = "Logging on File";
            this.btnLogOnFile.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(157, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(183, 20);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(157, 35);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(183, 20);
            this.textBox2.TabIndex = 3;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(6, 19);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(319, 296);
            this.textBox3.TabIndex = 4;
            // 
            // grpBoxSampling
            // 
            this.grpBoxSampling.Controls.Add(this.lblNxtSampTime);
            this.grpBoxSampling.Controls.Add(this.btnSampling);
            this.grpBoxSampling.Controls.Add(this.textBox1);
            this.grpBoxSampling.Location = new System.Drawing.Point(36, 84);
            this.grpBoxSampling.Name = "grpBoxSampling";
            this.grpBoxSampling.Size = new System.Drawing.Size(363, 150);
            this.grpBoxSampling.TabIndex = 5;
            this.grpBoxSampling.TabStop = false;
            this.grpBoxSampling.Text = "Sampling";
            // 
            // lblNxtSampTime
            // 
            this.lblNxtSampTime.AutoSize = true;
            this.lblNxtSampTime.Location = new System.Drawing.Point(31, 33);
            this.lblNxtSampTime.Name = "lblNxtSampTime";
            this.lblNxtSampTime.Size = new System.Drawing.Size(101, 13);
            this.lblNxtSampTime.TabIndex = 3;
            this.lblNxtSampTime.Text = "Next Sampling Time";
            // 
            // grpBocLogging
            // 
            this.grpBocLogging.Controls.Add(this.lblNxtLogTime);
            this.grpBocLogging.Controls.Add(this.btnLogOnFile);
            this.grpBocLogging.Controls.Add(this.textBox2);
            this.grpBocLogging.Location = new System.Drawing.Point(36, 240);
            this.grpBocLogging.Name = "grpBocLogging";
            this.grpBocLogging.Size = new System.Drawing.Size(363, 165);
            this.grpBocLogging.TabIndex = 6;
            this.grpBocLogging.TabStop = false;
            this.grpBocLogging.Text = "Logging";
            // 
            // lblNxtLogTime
            // 
            this.lblNxtLogTime.AutoSize = true;
            this.lblNxtLogTime.Location = new System.Drawing.Point(31, 42);
            this.lblNxtLogTime.Name = "lblNxtLogTime";
            this.lblNxtLogTime.Size = new System.Drawing.Size(96, 13);
            this.lblNxtLogTime.TabIndex = 4;
            this.lblNxtLogTime.Text = "Next Logging Time";
            // 
            // grpBoxSensorVal
            // 
            this.grpBoxSensorVal.Controls.Add(this.textBox3);
            this.grpBoxSensorVal.Location = new System.Drawing.Point(424, 84);
            this.grpBoxSensorVal.Name = "grpBoxSensorVal";
            this.grpBoxSensorVal.Size = new System.Drawing.Size(331, 321);
            this.grpBoxSensorVal.TabIndex = 7;
            this.grpBoxSensorVal.TabStop = false;
            this.grpBoxSensorVal.Text = "Sensor Value";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMenuFile,
            this.btnMenuOperations,
            this.btnMenuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnMenuFile
            // 
            this.btnMenuFile.Name = "btnMenuFile";
            this.btnMenuFile.Size = new System.Drawing.Size(37, 20);
            this.btnMenuFile.Text = "File";
            // 
            // btnMenuOperations
            // 
            this.btnMenuOperations.Name = "btnMenuOperations";
            this.btnMenuOperations.Size = new System.Drawing.Size(77, 20);
            this.btnMenuOperations.Text = "Operations";
            // 
            // btnMenuHelp
            // 
            this.btnMenuHelp.Name = "btnMenuHelp";
            this.btnMenuHelp.Size = new System.Drawing.Size(44, 20);
            this.btnMenuHelp.Text = "Help";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.grpBoxSensorVal);
            this.Controls.Add(this.grpBocLogging);
            this.Controls.Add(this.grpBoxSampling);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpBoxSampling.ResumeLayout(false);
            this.grpBoxSampling.PerformLayout();
            this.grpBocLogging.ResumeLayout(false);
            this.grpBocLogging.PerformLayout();
            this.grpBoxSensorVal.ResumeLayout(false);
            this.grpBoxSensorVal.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSampling;
        private System.Windows.Forms.Button btnLogOnFile;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.GroupBox grpBoxSampling;
        private System.Windows.Forms.Label lblNxtSampTime;
        private System.Windows.Forms.GroupBox grpBocLogging;
        private System.Windows.Forms.Label lblNxtLogTime;
        private System.Windows.Forms.GroupBox grpBoxSensorVal;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnMenuFile;
        private System.Windows.Forms.ToolStripMenuItem btnMenuOperations;
        private System.Windows.Forms.ToolStripMenuItem btnMenuHelp;
    }
}

