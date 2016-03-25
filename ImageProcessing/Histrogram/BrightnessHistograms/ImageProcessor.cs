using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace BrightnessHistograms
{
    class ImageProcessor
    {
        int[] colors = new int[256];

        int totalPixels;

        public void CreateHisto(Bitmap image, Chart chart)
        {
            for(int x = 0; x < image.Width; ++x)
            {
                for(int y = 0; y < image.Height; ++y)
                {
                    int brightness = image.GetPixel(x, y).R;
                    
                    ++colors[brightness];
                }
            }

            chart.Series["Brightness"].Points.Clear();

            for (int x = 0; x < colors.Length; ++x)
            {
                DataPoint dp = new DataPoint();
                dp.SetValueXY(x, colors[x]);

                chart.Series["Brightness"].Points.Add(dp);
            }
        }

        public Bitmap Enchance(Bitmap image)
        {
            totalPixels = image.Width * image.Height;

            Bitmap newImage = new Bitmap(image.Width, image.Height);

            for(int x = 0; x < image.Width; ++x)
            {
                for(int y = 0; y < image.Height; ++y)
                {
                    newImage.SetPixel(x, y, ChangeBrightness(image.GetPixel(x, y)));
                }
            }

            return newImage;
        }

        Color ChangeBrightness(Color color)
        {
            int brightness = color.R;

            double newBrightness = 0;

            for(int b = 0; b <= brightness; ++b)
            {
                newBrightness += (double)colors[b] / totalPixels;
            }

            newBrightness *= 255;

            int gray;
            if(newBrightness - (int)newBrightness > 0.5)
            {
                gray = (int)newBrightness + 1;
            }
            else
            {
                gray = (int)newBrightness;
            }

            return Color.FromArgb(gray, gray, gray);
        }
    }
}
