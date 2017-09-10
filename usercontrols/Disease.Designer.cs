namespace DentalRecordApplication.UserControls
{
    partial class Disease
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
            this.checkbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checkbox
            // 
            this.checkbox.AutoSize = true;
            this.checkbox.Location = new System.Drawing.Point(3, 3);
            this.checkbox.Name = "checkbox";
            this.checkbox.Size = new System.Drawing.Size(98, 21);
            this.checkbox.TabIndex = 0;
            this.checkbox.Text = "checkBox1";
            this.checkbox.UseVisualStyleBackColor = true;
            this.checkbox.CheckedChanged += new System.EventHandler(this.checkbox_CheckedChanged);
            // 
            // Disease
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.checkbox);
            this.Name = "Disease";
            this.Size = new System.Drawing.Size(121, 27);
            this.Load += new System.EventHandler(this.Disease_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkbox;
    }
}
