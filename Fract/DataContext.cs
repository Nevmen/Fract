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

        private Sets sets;
        public Sets Sets { get => sets; set  { sets = value; OnPropertyChanged("Sets"); } }


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
            Sets = Sets.Newton;
            Pict = FractalFinder.FractalCreator(Sets, new Complex(-0.74543, 0.11301), -1, 1, -1, 1,500,500,100);
        }


        


        

        
    }
}
