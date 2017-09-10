using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace DentalRecordApplication
{
    class Utils
    {

        public static void hideAndShow(Form hide, Form show)
        {
            hide.Hide();
        
            show.ShowDialog();

            hide.Show();
        }

        public static Color strToColor(String str)
        {
            if (str == "red")
                return Color.Red;
            else if (str == "blue")
                return Color.Blue;
            return Color.Black;
        }


        public static String colorToStr(Color color)
        {
            if (color == Color.Red)
                return "red";
            else if (color == Color.Blue)
                return "blue";
            return "black";
        }
        public static String toCWD(String path)
        {
            return System.AppDomain.CurrentDomain.BaseDirectory.ToString() + path;
        }
        public static Image loadImageFromFileRelativeToCWD(String path)
        {
            return Image.FromFile(toCWD(path));
        }
        public static bool isFilledUp(Control[] controls)
        {
            for (int a = 0; a < controls.Length; a++)
            {
                if (controls[a].Text.Length <= 0)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool isEmpty(String str)
        {
            return str.Length <= 0;
        }
        public static bool hasExceeded(String str, int max)
        {
            return str.Length > max;
        }
        public static char getLastCharacter(String str)
        {
            if (!isEmpty(str))
            {
                return str[str.Length - 1];
            }
            return '\0';
        }

        public static bool isValidNumber(char character)
        {
            return character >= '0' && character <= '9';
        }

        public static bool isObjectNull(Object obj)
        {
            return obj == null;
        }

        public static int toInt(String str)
        {
            return Convert.ToInt32(str);
        }


        public static void toggleDisabilityControl(Control[] objs)
        {
            for (int a = 0; a < objs.Length; a++)
            {
                objs[a].Enabled = !objs[a].Enabled;
            }
        }
        public static void setEnabledControl(Control[] objs, bool enabled)
        {
            for (int a = 0; a < objs.Length; a++)
            {
                objs[a].Enabled = enabled;
            }
        }


        static private bool handled = false;
        public static void limitedNumberInputOnly(object sender, int max)
        {
            if (!handled)
            {
                TextBox obj = (TextBox)sender;
                if (Utils.hasExceeded(obj.Text, max) || !Utils.isValidNumber(Utils.getLastCharacter(obj.Text)))
                {
                    handled = true;
                    if (!Utils.isEmpty(obj.Text))
                    {
                        obj.Text = obj.Text.Substring(0, obj.Text.Length - 1);
                    }
                }
            }
            else handled = false;
        }


        public static void fillListView(ref ListView view, DataTable table)
        {
            if (isObjectNull(table)) return;
            view.Clear();
            for (int column = 0; column < table.Columns.Count; column++)
            {
                view.Columns.Add(table.Columns[column].ToString(), 200, HorizontalAlignment.Left);
            }
            fillRowListView(ref view, table);
        }
        public static void fillRowListView(ref ListView view, DataTable table)
        {
            if (isObjectNull(table)) return;
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
    }
}
