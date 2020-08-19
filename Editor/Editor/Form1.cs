using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog PathImage = new OpenFileDialog();
            PictureEdit pe = new PictureEdit();
            panel1.Controls.Add(pe);
            if (PathImage.ShowDialog() == DialogResult.OK)
            {
                Image newImage = Image.FromFile(PathImage.FileName);
               // MessageBox.Show(PathImage.FileName);
                byte[] img = CopyImageToByteArray(newImage);
                pe.LoadImage(img);
            }
        }

        public static byte[] CopyImageToByteArray(Image theImage)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                theImage.Save(memoryStream, ImageFormat.Png);
                return memoryStream.ToArray();
            }
        }
    }
}
