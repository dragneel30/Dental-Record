namespace DentalRecordApplication
{
    partial class Question
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.q = new System.Windows.Forms.Label();
            this.No = new System.Windows.Forms.RadioButton();
            this.yes = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // q
            // 
            this.q.AutoSize = true;
            this.q.Location = new System.Drawing.Point(117, 4);
            this.q.Name = "q";
            this.q.Size = new System.Drawing.Size(65, 17);
            this.q.TabIndex = 2;
            this.q.Text = "Question";
            // 
            // No
            // 
            this.No.AutoSize = true;
            this.No.Checked = true;
            this.No.Location = new System.Drawing.Point(63, 0);
            this.No.Name = "No";
            this.No.Size = new System.Drawing.Size(47, 21);
            this.No.TabIndex = 3;
            this.No.TabStop = true;
            this.No.Text = "No";
            this.No.UseVisualStyleBackColor = true;
            // 
            // yes
            // 
            this.yes.AutoSize = true;
            this.yes.Location = new System.Drawing.Point(4, 0);
            this.yes.Name = "yes";
            this.yes.Size = new System.Drawing.Size(53, 21);
            this.yes.TabIndex = 4;
            this.yes.Text = "Yes";
            this.yes.UseVisualStyleBackColor = true;
            // 
            // Question
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.yes);
            this.Controls.Add(this.No);
            this.Controls.Add(this.q);
            this.Name = "Question";
            this.Size = new System.Drawing.Size(683, 25);
            this.Load += new System.EventHandler(this.Question_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label q;
        private System.Windows.Forms.RadioButton No;
        private System.Windows.Forms.RadioButton yes;
    }
}
