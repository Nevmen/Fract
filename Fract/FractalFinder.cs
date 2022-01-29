using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Fract
{
    public static class FractalFinder
    {
        public static Bitmap FractalCreator(Sets sets,  Complex c, double xMin, double xMax, double yMin, double yMax, int width, int height, int iterations)
        {

            double xStep = Math.Abs(xMax - xMin) / width;
            double yStep = Math.Abs(yMax - yMin) / height;
            var matrix = new List<List<int>>();

            for (int i = 0; i < width; i++)
            {
                matrix.Add(new List<int>());
                for(int j = 0; j < height; j++)
                {
                    double x = xMin + i * xStep;
                    double y = yMin + j * yStep;
                    Complex z = new Complex(x,y);

                    
                    matrix[i].Add(SetChooser(sets,z,c,iterations));
                }
            }


            var bmp = BitmapCreator(width,height,iterations,matrix);

            return bmp;
        }

        private static Bitmap BitmapCreator(int width,  int height, int iterations,  List<List<int>> matrix)
        {
            var bmp = new Bitmap(width, height);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    int k = matrix[i][j];
                    var color = new Color();
                    if (k < iterations)
                    {
                        color = Color.FromArgb((k % 2) * 32 + 128, (k % 4) * 64, (k % 2) * 32 + 128);
                    }

                    bmp.SetPixel(i, j, color);
                }
            }
            return bmp;
        }

        private static int JuliaSetIterator(Complex z, Complex c, int  iterations)
        {
            int n = 0;
            for (int k = 0; k < iterations; k++)
            {
                if (z.Magnitude > 2)
                    break;
                z = z * z + c;
                n++;
            }
            return n;
        }
        private static int MadelbrotSetIterator(Complex z, int iterations)
        {
            int n = 0;
            for(int k = 0; k < iterations; k++)
            {
                if (z.Magnitude > 2)
                    break;
                z += z * z;
                n++;
            }

            return n;
        }
        private static int NewtonSetIterator(Complex z, int iterations)
        {
            int n = 0;

            for( int k = 0; k < iterations; k++)
            {
                if (Complex.Pow(Complex.Abs(Complex.Pow(z, 4) - 1), 2).Magnitude < 0.001)
                    break;
                z = (3 * Complex.Pow(z, 4) + 1) / (4 * Complex.Pow(z, 3));
                //z -= (Complex.Pow(z, 3) - 1) / (3 * z * z);
                n++;
            }

            return n;

        }
        private static int SetChooser(Sets sets, Complex z, Complex c, int iterations)
        {
            switch (sets)
            {
                case Sets.Mandelbrot:
                    return MadelbrotSetIterator(z, iterations);
                case Sets.Julia:
                    return JuliaSetIterator(z, c, iterations);
                case Sets.Newton:
                    return NewtonSetIterator(z, iterations);
                default: throw new NotImplementedException();
            } 
        }

    
    }
    public enum Sets
    {
        Mandelbrot = 1,
        Julia =  2,
        Newton = 3
    }
}
