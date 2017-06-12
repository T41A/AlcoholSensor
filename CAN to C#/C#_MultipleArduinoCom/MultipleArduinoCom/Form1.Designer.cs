namespace MultipleArduinoCom
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
            this.lbReadedDataArduino1 = new System.Windows.Forms.ListBox();
            this.lbReadedDataArduino2 = new System.Windows.Forms.ListBox();
            this.btClose = new System.Windows.Forms.Button();
            this.lblArduino1 = new System.Windows.Forms.Label();
            this.lblArduino2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbReadedDataArduino1
            // 
            this.lbReadedDataArduino1.FormattingEnabled = true;
            this.lbReadedDataArduino1.Location = new System.Drawing.Point(12, 12);
            this.lbReadedDataArduino1.Name = "lbReadedDataArduino1";
            this.lbReadedDataArduino1.Size = new System.Drawing.Size(306, 95);
            this.lbReadedDataArduino1.TabIndex = 0;
            // 
            // lbReadedDataArduino2
            // 
            this.lbReadedDataArduino2.FormattingEnabled = true;
            this.lbReadedDataArduino2.Location = new System.Drawing.Point(12, 113);
            this.lbReadedDataArduino2.Name = "lbReadedDataArduino2";
            this.lbReadedDataArduino2.Size = new System.Drawing.Size(306, 95);
            this.lbReadedDataArduino2.TabIndex = 1;
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(324, 185);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 3;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // lblArduino1
            // 
            this.lblArduino1.AutoSize = true;
            this.lblArduino1.Location = new System.Drawing.Point(324, 12);
            this.lblArduino1.Name = "lblArduino1";
            this.lblArduino1.Size = new System.Drawing.Size(127, 13);
            this.lblArduino1.TabIndex = 4;
            this.lblArduino1.Text = "Arduino1: Not Connected";
            // 
            // lblArduino2
            // 
            this.lblArduino2.AutoSize = true;
            this.lblArduino2.Location = new System.Drawing.Point(324, 25);
            this.lblArduino2.Name = "lblArduino2";
            this.lblArduino2.Size = new System.Drawing.Size(127, 13);
            this.lblArduino2.TabIndex = 5;
            this.lblArduino2.Text = "Arduino2: Not Connected";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 215);
            this.Controls.Add(this.lblArduino2);
            this.Controls.Add(this.lblArduino1);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.lbReadedDataArduino2);
            this.Controls.Add(this.lbReadedDataArduino1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbReadedDataArduino1;
        private System.Windows.Forms.ListBox lbReadedDataArduino2;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Label lblArduino1;
        private System.Windows.Forms.Label lblArduino2;
        private System.Windows.Forms.Timer timer1;
    }
}

