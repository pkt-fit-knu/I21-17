using System.Collections.Generic;
using System.Drawing;

namespace BrightnessHistograms
{
    class ImageProcessor
    {
        public Bitmap CreateHisto(Bitmap image)
        {
            Dictionary<int, int> colors = new Dictionary<int, int>();

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
                for(int y = 0; y < pair.Value / 10; ++y)
                {
                    if (y < histo.Height)
                    {
                        histo.SetPixel(pair.Key, y, Color.Red);
                    }
                }
            }

            return histo;
        }

        int GetBrightness(Color c) => (int)(0.3 * c.R + 0.59 * c.G + 0.11 * c.B);
        Color GetNewColor(Color c, int diff)
        {
            int red = c.R + diff;
            int green = c.G + diff;
            int blue = c.B + diff;

            if (red > 255)
            {
                red = 255;
            }
            if (green > 255)
            {
                green = 255;
            }
            if (blue > 255)
            {
                blue = 255;
            }

            return Color.FromArgb(red, green, blue);
        }
        public Bitmap Enchance(Bitmap image)
        {
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
            Color newColor;

            if (GetBrightness(color) < 35)
            {
                newColor = GetNewColor(color, 20);
            }
            else if (GetBrightness(color) < 55)
            {
                newColor = GetNewColor(color, 15);
            }
            else if (GetBrightness(color) < 75)
            {
                newColor = GetNewColor(color, 10);
            }
            else if (GetBrightness(color) < 95)
            {
                newColor = GetNewColor(color, 5);
            }
            else
            {
                newColor = color;
            }

            return newColor;
        }
    }
}
