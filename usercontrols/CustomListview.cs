using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DentalRecordApplication
{
    public partial class CustomListview : UserControl
    {
        public CustomListview()
        {
            InitializeComponent();
            editor = new TextBox();
            
            editor.BorderStyle = BorderStyle.None;
            editor.LostFocus += new EventHandler(editor_lostFocus);
            editedCell = new EditedCell();

            
        }


        public void setViewItemDeleted(EventHandler iViewItemDeleted)
        {
            viewItemDeleted = iViewItemDeleted;
        }
        public void setEditorHandler(EventHandler iEditorEventHandlerLostFocus)
        {
            editorEventHandlerLostFocus = iEditorEventHandlerLostFocus;
        }
        public void setSelectedIndexChanged(EventHandler iSelectedIndexChanged)
        {
            view.SelectedIndexChanged += iSelectedIndexChanged;
        }
        public void setItemDoubleClicked(MouseEventHandler iItemDoubleClicked)
        {
            view.MouseDoubleClick += iItemDoubleClicked;
        }
        private EventHandler editorEventHandlerLostFocus;
        
        public struct EditedCell
        {
            public String newVal;
            public String columnName;
            public String id;
        }
        EditedCell editedCell;
        public EditedCell getEditedCell()
        {
            return editedCell;
        }

        public void editor_lostFocus(object sender, EventArgs e)
        {
            ListViewItem item = view.Items[rowCol.Y];
            item.SubItems[rowCol.X].Text = editor.Text;
            view.Controls.Remove(editor);
            editedCell.columnName = view.Columns[rowCol.X].Text;
            editedCell.newVal = editor.Text;
            editedCell.id = item.SubItems[0].Text;
            if (!Utils.isObjectNull(editorEventHandlerLostFocus))
                editorEventHandlerLostFocus(sender, e);
        }

       

        TextBox editor;
        Point rowCol;

        public void fill(DataTable table)
        {
            if (Utils.isObjectNull(table)) return;
            view.Clear();
            for (int column = 0; column < table.Columns.Count; column++)
            {
                view.Columns.Add(table.Columns[column].ToString(), 200, HorizontalAlignment.Left);
            }
            fillRow(table);
        }
        public void fillRow(DataTable table)
        {
            if (Utils.isObjectNull(table)) return;
            view.Items.Clear();
            for (int row = 0; row < table.Rows.Count; row++)
            {
                DataRow currRow = table.Rows[row];
                ListViewItem item = new ListViewItem(currRow[0].ToString());
                for (int column = 1; column < table.Columns.Count; column++)
                {
                    item.SubItems.Add(currRow[column].ToString());
                }
                view.Items.Add(item);
            }
        }


        public ListView get()
        {
            return view;
        }

        private void view_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            setEditing(Cursor.Position);
        }
        void setEditing(Point mousePos)
        {
            Point coord = view.PointToClient(mousePos);
            ListViewHitTestInfo info = view.HitTest(coord);
            ListViewItem item = view.HitTest(coord).Item;
            ListViewItem.ListViewSubItem editingSubItem = item.GetSubItemAt(coord.X, coord.Y);

            Rectangle bound = editingSubItem.Bounds;
            editor.Text = editingSubItem.Text;
            int width = bound.Width;
            if (item.SubItems[0] == editingSubItem)
            {
                width = view.Columns[0].Width;
            }
            int unitWidth = coord.X / width;
            rowCol = new Point(unitWidth, item.Index);
            editor.SetBounds(bound.X, bound.Y, width, bound.Height);
            view.Controls.Add(editor);
        }

        private void CustomListview_Load(object sender, EventArgs e)
        {/*
            ContextMenu menu = new ContextMenu();
            menu.MenuItems.Add("edit");
            menu.MenuItems.Add("delete");
            view.ContextMenu = menu;*/
        }

        private void view_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            MessageBox.Show("TEsT");
        }

        private void view_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
        }

        private void view_BeforeLabelEdit(object sender, LabelEditEventArgs e)
        {
            MessageBox.Show("Tewt");
        }

        private void view_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                rightClickPos = Cursor.Position;
                contextMenu.Show(rightClickPos);
            }
        }

        Point rightClickPos;
        int deletedId;
        public int getDeletedId()
        {
            return deletedId;
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (view.SelectedItems.Count > 0)
            {
                
                deletedId = Convert.ToInt32(view.SelectedItems[0].SubItems[0].Text);
                viewItemDeleted(sender, null);
                view.Items.Remove(view.SelectedItems[0]);
            }
        }
        EventHandler viewItemDeleted;
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setEditing(rightClickPos);
        }

        
    }
}
