package bilinearinterpolation;

import java.awt.image.BufferedImage;
import java.awt.image.DataBufferByte;
import java.awt.image.WritableRaster;
import java.io.File;
import java.io.IOException;
import javax.imageio.ImageIO;

public class BilinearInterpolation
{
    public static void main(String[] args)
    {   
        try
        {
            File imageFile = new File("C:\\Users\\Дима\\Desktop\\Wallpapers\\stockvault-pedal-background121015.jpg");
            //File imageFile = new File("C:\\Users\\Дима\\Desktop\\Wallpapers\\aa373a26ecc731f5b9c2d6cf031e4374.jpg");
            BufferedImage image = ImageIO.read(imageFile);
            
            int w = image.getWidth(), h = image.getHeight();
            byte[] gray = ((DataBufferByte) image.getRaster().getDataBuffer()).getData();
            //int[] rgb = image.getRGB(0, 0, w, h, null, 0, w);
            
            double scale = 1.5;
            int newWidth = (int)(w * scale);
            int newHeigth = (int)(h * scale);
            
//            int[] newRGB = resizeBilinear(rgb, w, h, newWidth, newHeigth);
//            BufferedImage resizedImage = new BufferedImage(newWidth, newHeigth, BufferedImage.TYPE_3BYTE_BGR);
//            resizedImage.setRGB(0, 0, newWidth, newHeigth, newRGB, 0, newWidth);
            
            int[] newGray = resizeBilinear(gray, w, h, newWidth, newHeigth);
            BufferedImage resizedImage = new BufferedImage(newWidth, newHeigth, BufferedImage.TYPE_BYTE_GRAY);
            WritableRaster raster = resizedImage.getRaster();
//            
            for(int i = 0; i < newWidth; ++i)
            {
                for(int j = 0; j < newHeigth; ++j)
                {
                    int index = j * newWidth + i;
                    raster.setSample(i, j, 0, newGray[index]);
                }
            }
            
            ImageIO.write(resizedImage, "JPEG", new File("C:\\Users\\Дима\\Desktop\\Wallpapers\\lol.jpg"));
        }
        catch(IOException e)
        {
            System.out.println(e.getMessage());
        }
    }
    
    static int[] resizeBilinear(byte[] pixels, int w, int h, int w2, int h2)
    {
        int[] temp = new int[w2 * h2] ;
        int a, b, c, d, x, y, index ;
        float x_ratio = ((float)(w - 1)) / w2, y_ratio = ((float)(h - 1)) / h2 ;
        float x_diff, y_diff/*, blue, green, red*/;
        int offset = 0 ;
        
        for (int i=0; i < h2; ++i)
        {
            for (int j=0; j < w2; ++j)
            {
                x = (int)(x_ratio * j);
                y = (int)(y_ratio * i);
                x_diff = (x_ratio * j) - x;
                y_diff = (y_ratio * i) - y;
                
                index = (y * w + x);
                a = pixels[index] & 0xff;
                b = pixels[index + 1] & 0xff;
                c = pixels[index + w] & 0xff;
                d = pixels[index + w + 1] & 0xff;
                               
                temp[offset++] = (int)
                   (a * (1 - x_diff) * (1 - y_diff) +  b * x_diff * (1 - y_diff) +
                    c * y_diff * (1 - x_diff) + d * x_diff * y_diff);
//                blue = (a&0xff)*(1-x_diff)*(1-y_diff) + (b&0xff)*(x_diff)*(1-y_diff) +
//                   (c&0xff)*(y_diff)*(1-x_diff)   + (d&0xff)*(x_diff*y_diff);
//
//                // Yg = Ag(1-w)(1-h) + Bg(w)(1-h) + Cg(h)(1-w) + Dg(wh)
//                green = ((a>>8)&0xff)*(1-x_diff)*(1-y_diff) + ((b>>8)&0xff)*(x_diff)*(1-y_diff) +
//                        ((c>>8)&0xff)*(y_diff)*(1-x_diff)   + ((d>>8)&0xff)*(x_diff*y_diff);
//
//                // Yr = Ar(1-w)(1-h) + Br(w)(1-h) + Cr(h)(1-w) + Dr(wh)
//                red = ((a>>16)&0xff)*(1-x_diff)*(1-y_diff) + ((b>>16)&0xff)*(x_diff)*(1-y_diff) +
//                      ((c>>16)&0xff)*(y_diff)*(1-x_diff)   + ((d>>16)&0xff)*(x_diff*y_diff);
//
//                temp[offset++] = 
//                        0xff000000 |
//                        ((((int)red)<<16)&0xff0000) |
//                        ((((int)green)<<8)&0xff00) |
//                        ((int)blue) ;
            }
        }
        
        return temp ;
    }
}
