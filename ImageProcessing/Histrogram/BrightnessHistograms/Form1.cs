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

        private void enchanceContrast_Click(object sender, EventArgs e)
        {
            Bitmap def = new Bitmap(Image.FromFile(@"C:\Users\Дима\Desktop\Wallpapers\sample2.jpg"), new Size(500, 375));

            defaultImage.Image = def;

            ImageProcessor ip = new ImageProcessor();

            ip.CreateHisto(def, ChartOriginal);

            Bitmap ench = ip.Enchance(def);

            enchancedImage.Image = ench;

            ip.CreateHisto(ench, ChartEnchanced);
        }

        private void enchanceSharpness_Click(object sender, EventArgs e)
        {
            Bitmap def = new Bitmap(Image.FromFile(@"C:\Users\Дима\Desktop\Wallpapers\SourceImage2.png"));

            ImageEnchancer ie = new ImageEnchancer(def);

            Bitmap result = ie.EnchanceSharpness();

            result.Save(@"C:\Users\Дима\Desktop\Wallpapers\resultEnch.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
}
