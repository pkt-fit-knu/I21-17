using System.Collections.Generic;
using System.Drawing;

namespace BrightnessHistograms
{
    class ImageProcessor
    {
        Dictionary<int, int> colors = new Dictionary<int, int>();

        int totalPixels;

        public Bitmap CreateHisto(Bitmap image)
        {
            for(int x = 0; x < image.Width; ++x)
            {
                for(int y = 0; y < image.Height; ++y)
                {
                    int brightness = GetBrightness(image.GetPixel(x, y));

                    if(colors.ContainsKey(brightness))
                    {
                        ++colors[brightness];
                    }
                    else
                    {
                        colors.Add(brightness, 1);
                    }
                }
            }

            Bitmap histo = new Bitmap(400, 400);

            foreach(var pair in colors)
            {
                for(int y = 0; y < pair.Value / 30; ++y)
                {
                    if (y < histo.Height)
                    {
                        histo.SetPixel(pair.Key, y, Color.Gray);
                    }
                }
            }

            return histo;
        }

        int GetBrightness(Color c) => (int)(0.3 * c.R + 0.59 * c.G + 0.11 * c.B);

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
                if (colors.ContainsKey(b))
                {
                    newBrightness += (double)colors[b] / totalPixels;
                }
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
