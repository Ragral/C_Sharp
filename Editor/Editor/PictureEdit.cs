using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Editor
{
    public partial class PictureEdit : UserControl
    {
        public PictureEdit()
        {
            InitializeComponent();
        }

        public void LoadImage(byte[] img)
        {
            Image ImagePic = byteArrayToImage(img);
            //  pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            pictureBoxImage.Image = ImagePic;


            //this.pictureBoxImage.Refresh();
        }

        public void GetImage()
        {
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.FileName = "Изображение";
            SFD.Filter = "JPEG Images|*.jpg|GIF Images|*.gif|BITMAPS|*.bmp|PNG Images|*.png";
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                pictureBoxImage.Image.Save(SFD.FileName);
            }
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private void leftButton_Click(object sender, EventArgs e)
        {
            pictureBoxImage.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            pictureBoxImage.Refresh();
        }

        private void rightButton_Click(object sender, EventArgs e)
        {
            pictureBoxImage.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBoxImage.Refresh();
        }

        private void mirrorImage_Click(object sender, EventArgs e)
        {
            pictureBoxImage.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            pictureBoxImage.Refresh();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            GetImage();
        }
    }
}