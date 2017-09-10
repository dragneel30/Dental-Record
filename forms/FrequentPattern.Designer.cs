namespace DentalRecordApplication
{
    partial class FrequentPattern
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
            this.root = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.analysis = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // root
            // 
            this.root.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.root.FullRowSelect = true;
            this.root.GridLines = true;
            this.root.Location = new System.Drawing.Point(0, -2);
            this.root.Margin = new System.Windows.Forms.Padding(2);
            this.root.Name = "root";
            this.root.Size = new System.Drawing.Size(254, 527);
            this.root.TabIndex = 0;
            this.root.UseCompatibleStateImageBehavior = false;
            this.root.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "PATIENT ID";
            this.columnHeader1.Width = 106;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ITEMS";
            this.columnHeader2.Width = 173;
            // 
            // analysis
            // 
            this.analysis.Location = new System.Drawing.Point(251, -2);
            this.analysis.Margin = new System.Windows.Forms.Padding(2);
            this.analysis.Name = "analysis";
            this.analysis.SelectedIndex = 0;
            this.analysis.Size = new System.Drawing.Size(498, 527);
            this.analysis.TabIndex = 1;
            // 
            // FrequentPattern
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(746, 530);
            this.Controls.Add(this.analysis);
            this.Controls.Add(this.root);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrequentPattern";
            this.Text = "FrequentPattern";
            this.Load += new System.EventHandler(this.FrequentPattern_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView root;
        private System.Windows.Forms.TabControl analysis;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}