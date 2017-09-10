namespace DentalRecordApplication
{
    partial class ScanResultView
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
            this.view1 = new System.Windows.Forms.ListView();
            this.view2 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // view1
            // 
            this.view1.FullRowSelect = true;
            this.view1.GridLines = true;
            this.view1.Location = new System.Drawing.Point(0, 0);
            this.view1.Name = "view1";
            this.view1.Size = new System.Drawing.Size(276, 533);
            this.view1.TabIndex = 0;
            this.view1.UseCompatibleStateImageBehavior = false;
            this.view1.View = System.Windows.Forms.View.Details;
            // 
            // view2
            // 
            this.view2.FullRowSelect = true;
            this.view2.GridLines = true;
            this.view2.Location = new System.Drawing.Point(282, 0);
            this.view2.Name = "view2";
            this.view2.Size = new System.Drawing.Size(276, 533);
            this.view2.TabIndex = 1;
            this.view2.UseCompatibleStateImageBehavior = false;
            this.view2.View = System.Windows.Forms.View.Details;
            // 
            // ScanResultView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.view2);
            this.Controls.Add(this.view1);
            this.Name = "ScanResultView";
            this.Size = new System.Drawing.Size(559, 533);
            this.Load += new System.EventHandler(this.ScanResultView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView view1;
        private System.Windows.Forms.ListView view2;
    }
}
