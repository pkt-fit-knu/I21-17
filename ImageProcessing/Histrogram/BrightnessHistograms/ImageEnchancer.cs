using System;
using System.Drawing;
using System.Linq;

namespace BrightnessHistograms
{
    class ImageEnchancer
    {
        int[,] imageWithBorders;
        int[,] mask = new int[,] { { 1, 1, 1 }, { 1, -8, 1 }, { 1, 1, 1 } };

        public ImageEnchancer(Bitmap bitmap)
        {
            imageWithBorders = GetArrayFromBitmap(bitmap);
        }

        int[,] GetArrayFromBitmap(Bitmap bitmap)
        {
            int[,] array = new int[bitmap.Width + 4, bitmap.Height + 4];
            int width = array.GetLength(0);
            int height = array.GetLength(1);

            for (int x = 2; x < width - 2; ++x)
            {
                for(int y = 2; y < height - 2; ++y)
                {
                    array[x, y] = bitmap.GetPixel(x - 2, y - 2).R;
                }
            }

            return array;
        }

        public Bitmap EnchanceSharpness()
        {
            int[,] imageWithMask = ImposeMask();

            int[,] substractedImage = ImageSubstraction(imageWithMask);

            int[,] imageWithoutNegatives = RemoveNegatives(substractedImage);

            int[,] result = Compress(imageWithoutNegatives);

            return CreateBitmap(result);
        }

        int[,] ImposeMask()
        {
            int width = imageWithBorders.GetLength(0);
            int height = imageWithBorders.GetLength(1);
            int[,] imageWithMask = new int[width, height];

            for(int x = 1; x < width - 1; ++x)
            {
                for(int y = 1; y < height - 1; ++y)
                {
                    imageWithMask[x, y] = imageWithBorders[x - 1, y - 1] * mask[0, 0] +
                                          imageWithBorders[x, y - 1] * mask[1, 0] +
                                          imageWithBorders[x + 1, y - 1] * mask[2, 0] +
                                          imageWithBorders[x - 1, y] * mask[0, 1] +
                                          imageWithBorders[x, y] * mask[1, 1] +
                                          imageWithBorders[x + 1, y] * mask[2, 1] +
                                          imageWithBorders[x - 1, y + 1] * mask[0, 2] +
                                          imageWithBorders[x, y + 1] * mask[1, 2] +
                                          imageWithBorders[x + 1, y + 1] * mask[2, 2];
                }
            }

            return imageWithMask;
        }

        int[,] ImageSubstraction(int[,] imageWithMask)
        {
            int width = imageWithMask.GetLength(0);
            int height = imageWithMask.GetLength(1);
            int[,] substractedImage = new int[width, height];

            for(int x = 0; x < width; ++x)
            {
                for(int y = 0; y < height; ++y)
                {
                    substractedImage[x, y] = imageWithBorders[x, y] - imageWithMask[x, y];
                }
            }

            return substractedImage;
        }

        int[,] RemoveNegatives(int[,] image)
        {
            int width = image.GetLength(0);
            int height = image.GetLength(1);
            //int minBrightness = int.MaxValue;

            int[,] newImage = new int[width, height];

            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    if (image[x, y] < 0)
                    {
                        newImage[x, y] = -image[x, y];
                    }
                    else
                    {
                        newImage[x, y] = image[x, y];
                    }
                }
            }

            #region WrongAlg

            //for (int x = 0; x < width; ++x)
            //{
            //    for (int y = 0; y < height; ++y)
            //    {
            //        if (image[x, y] < minBrightness)
            //        {
            //            minBrightness = image[x, y];
            //        }
            //    }
            //}

            //int[,] newImage = new int[width, height];

            //for (int x = 0; x < width; ++x)
            //{
            //    for (int y = 0; y < height; ++y)
            //    {
            //        newImage[x, y] = image[x, y] - minBrightness;
            //    }
            //}

            #endregion

            return newImage;
        }

        int[,] Compress(int[,] image)
        {
            int width = image.GetLength(0);
            int height = image.GetLength(1);
            //int maxBrightness = int.MinValue;

            int[,] newImage = new int[width, height];

            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    if (image[x, y] > 255)
                    {
                        newImage[x, y] = 255;
                    }
                    else
                    {
                        newImage[x, y] = image[x, y];
                    }
                }
            }

            #region WrongAlg

            //for (int x = 0; x < width; ++x)
            //{
            //    for (int y = 0; y < height; ++y)
            //    {
            //        if (maxBrightness < image[x, y])
            //        {
            //            maxBrightness = image[x, y];
            //        }
            //    }
            //}

            //int[,] newImage = new int[width, height];
            //double coef = 255 / (double)maxBrightness;

            //for (int x = 0; x < width; ++x)
            //{
            //    for (int y = 0; y < height; ++y)
            //    {
            //        newImage[x, y] = Convert.ToInt32(image[x, y] * coef);
            //    }
            //}

            #endregion

            return newImage;
        }

        Bitmap CreateBitmap(int[,] image)
        {
            int width = image.GetLength(0);
            int height = image.GetLength(1);
            Bitmap bitmap = new Bitmap(width, height);

            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    int color = image[x, y];
                    bitmap.SetPixel(x, y, Color.FromArgb(color, color, color));
                }
            }

            return bitmap;
        }
    }
}
