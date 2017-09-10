namespace DentalRecordApplication
{
    partial class Teeth
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Teeth));
            this.teethImage = new System.Windows.Forms.PictureBox();
            this.lblNumber = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.teethImage)).BeginInit();
            this.SuspendLayout();
            // 
            // teethImage
            // 
            this.teethImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("teethImage.BackgroundImage")));
            this.teethImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.teethImage.Location = new System.Drawing.Point(0, 0);
            this.teethImage.Name = "teethImage";
            this.teethImage.Size = new System.Drawing.Size(49, 49);
            this.teethImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.teethImage.TabIndex = 0;
            this.teethImage.TabStop = false;
            this.teethImage.Click += new System.EventHandler(this.pictureBox1_Click);
            this.teethImage.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumber.Location = new System.Drawing.Point(16, 17);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(13, 13);
            this.lblNumber.TabIndex = 1;
            this.lblNumber.Text = "0";
            this.lblNumber.Click += new System.EventHandler(this.lblNumber_Click);
            // 
            // Teeth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.teethImage);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "Teeth";
            this.Size = new System.Drawing.Size(49, 49);
            ((System.ComponentModel.ISupportInitialize)(this.teethImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox teethImage;
        private System.Windows.Forms.Label lblNumber;

    }
}
