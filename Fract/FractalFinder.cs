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
        /// <summary>
        /// Метод возвращающий фрактал в формате .bmp
        /// </summary>
        /// <param name="sets">Название метода построения фрактала</param>
        /// <param name="c">Параметр комплексной переменной для фрактала Джулиа</param>
        /// <param name="xMin">х минимальное</param>
        /// <param name="xMax">х максимальное</param>
        /// <param name="yMin">y минимальное</param>
        /// <param name="yMax">y максимальное</param>
        /// <param name="width">Ширина в пикселях</param>
        /// <param name="height">Высота в пикселях</param>
        /// <param name="iterations">Количество итераций</param>
        /// <param name="power">Степень для фрактала Ньютона</param>
        /// <returns>Файл с  заданным фракталом в формате .bmp</returns>
        public static Bitmap FractalCreator(Sets sets,  Complex c, double xMin, double xMax, double yMin, double yMax, int width, int height, int iterations,int power = 4)
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

                    
                    matrix[i].Add(SetChooser(sets,z,c,iterations, power));
                }
            }


            var bmp = BitmapCreator(width,height,iterations,matrix);

            return bmp;
        }
        /// <summary>
        /// Метод создающий файл .bmp
        /// </summary>
        /// <param name="width">Ширина в пикселях</param>
        /// <param name="height">Высота в пикселях</param>
        /// <param name="iterations">Количество итераций</param>
        /// <param name="matrix">Матрица со значением n для  каждого пикселя</param>
        /// <returns>Файл с  заданным фракталом в формате .bmp</returns>
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
        /// <summary>
        /// Метод рассчитывающий n в заданной точке для фрактала Джулиа
        /// </summary>
        /// <param name="z">Z нулевое</param>
        /// <param name="c">C комплексная константа</param>
        /// <param name="iterations">Кооличество итераций</param>
        /// <returns>n для заданной точки</returns>
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
        /// <summary>
        /// Метод рассчитывающий n в заданной точке для фрактала Мандельброта
        /// </summary>
        /// <param name="z">Z нулевое</param>
        /// <param name="iterations">Количество итераций</param>
        /// <returns>n для заданной точки</returns>
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
        /// <summary>
        /// Метод рассчитывающий n в заданной точке для фрактала Ньютона
        /// </summary>
        /// <param name="z">Z нулевое</param>
        /// <param name="power">Степень</param>
        /// <param name="iterations">Количество итераций</param>
        /// <returns>n для заданной точки</returns>
        private static int NewtonSetIterator(Complex z, int power, int iterations)
        {
            int n = 0;

            for( int k = 0; k < iterations; k++)
            {
                if (Complex.Pow(Complex.Abs(Complex.Pow(z, 4) - 1), 2).Magnitude < 0.001)
                    break;
                z = ((power - 1) * Complex.Pow(z, power) + 1) / (power * Complex.Pow(z, power - 1));
                n++;
            }
            return n;

        }
        private static int SetChooser(Sets sets, Complex z, Complex c, int iterations, int power)
        {
            switch (sets)
            {
                case Sets.Mandelbrot:
                    return MadelbrotSetIterator(z, iterations);
                case Sets.Julia:
                    return JuliaSetIterator(z, c, iterations);
                case Sets.Newton:
                    return NewtonSetIterator(z, power, iterations);
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
