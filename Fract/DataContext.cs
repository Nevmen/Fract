using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Fract
{
    public class DataContext:ViewModelBase
    {
        private string header;
        public string Header { get => header; set => header = value; }

        private Bitmap pict;
        public Bitmap Pict { get => pict; 
            set 
            { 
                pict = value;
                OnPropertyChanged("Pict");
            } 
        }

        private double c;

        public double C
        {
            get { return c; }
            set { c = value; OnPropertyChanged("C"); }
        }


        public PointCollection PointsSector { get; set; }
        public DataContext() 
        { 
            header = "Fractal";
            
            Pict = FractalFinder.PlotJuliaSet(new Complex(-0.74543, 0.11301), -2, 2, -2, 2,500,500,250);
        }


        


        

        
    }
}
