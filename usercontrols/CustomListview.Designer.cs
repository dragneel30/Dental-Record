namespace DentalRecordApplication
{
    partial class CustomListview
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
            this.components = new System.ComponentModel.Container();
            this.view = new System.Windows.Forms.ListView();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // view
            // 
            this.view.FullRowSelect = true;
            this.view.GridLines = true;
            this.view.LabelEdit = true;
            this.view.Location = new System.Drawing.Point(0, 0);
            this.view.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.view.MultiSelect = false;
            this.view.Name = "view";
            this.view.Size = new System.Drawing.Size(827, 248);
            this.view.TabIndex = 0;
            this.view.UseCompatibleStateImageBehavior = false;
            this.view.View = System.Windows.Forms.View.Details;
            this.view.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.view_AfterLabelEdit);
            this.view.BeforeLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.view_BeforeLabelEdit);
            this.view.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.view_ItemSelectionChanged);
            this.view.MouseClick += new System.Windows.Forms.MouseEventHandler(this.view_MouseClick);
            this.view.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.view_MouseDoubleClick);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(123, 52);
            // 
            // CustomListview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.view);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CustomListview";
            this.Size = new System.Drawing.Size(827, 248);
            this.Load += new System.EventHandler(this.CustomListview_Load);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView view;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
    }
}
