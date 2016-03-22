using System;
using System.Drawing;
using System.Windows.Forms;

namespace BrightnessHistograms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            Bitmap def = new Bitmap(Image.FromFile(@"C:\Users\Дима\Desktop\Wallpapers\sample2.jpg"), new Size(500, 375));

            defaultImage.Image = def;

            ImageProcessor ip = new ImageProcessor();

            defaultHisto.Image = ip.CreateHisto(def);

            Bitmap ench = ip.Enchance(def);

            enchancedImage.Image = ench;

            enchancedHisto.Image = ip.CreateHisto(ench);
        }
    }
}
