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
    public partial class Teeth : UserControl
    {
        public Teeth()
        {
            InitializeComponent();
            
            images = new List<Image>();
            colors = new List<Color>();
            indexes = new List<int>();
        
        }
        
        //dirty code, will encapsulate it soon
        List<Image> images;
        List<Color> colors;
        List<int> indexes;
        //

        public List<Color> Colors
        {
            get { return colors; }
            set { colors = value; }
        }
        public void copyTo(Teeth destination)
        {
            destination.Images = Images;
            destination.Number = Number;
            destination.Area = Area;
            destination.Part = Part;
            destination.IsPermanent = IsPermanent;
            destination.ID = ID;
            destination.Colors = Colors;
            destination.Refresh();
        }
        int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public List<Image> Images
        {
            get { return images; }
            set { images = value; }
        }

        public List<int> Indexes
        {
            get { return indexes; }
            set { indexes = value; }
        }

        public PictureBox getPicture()
        {
            return teethImage;
        }

        [Description("Tooth Number"), Category("Data")]
        public String Number
        {
            get { return lblNumber.Text; }
            set { lblNumber.Text = value; }
        }

        public String Area
        {
            get { return area; }
            set { area = value; }
        }

        public String Part
        {
            get { return part; }
            set { part = value; }
        }

        public bool IsPermanent
        {
            get { return is_permanent; }
            set { is_permanent = value; }
        }
        private String part;
        private String area;
        private bool is_permanent;

        public string getImageFileName()
        {
            return teethImage.ImageLocation.Substring(teethImage.ImageLocation.LastIndexOf("\\") + 1);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            clickHandler(this, e);
        }

        private void lblNumber_Click(object sender, EventArgs e)
        {
            clickHandler(this, e);
        }
  

        public void setClickHandler(EventHandler handler)
        {
            clickHandler = handler;
        }
        EventHandler clickHandler;

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Point topleft = new Point(0, 0);
            for ( int a = 0; a < images.Count; a++ )
            {  
                e.Graphics.DrawImage(images[a], new Rectangle(topleft.X, topleft.Y, teethImage.Width, teethImage.Height));
            }
        }

    
    }
}
