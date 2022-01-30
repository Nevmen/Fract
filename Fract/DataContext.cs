using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private double xMin = -2;
        public double XMin { get => xMin; set { xMin = value; OnPropertyChanged("XMin"); } }
        private double xMax = 2;
        public double XMax { get => xMax; set { xMax = value; OnPropertyChanged("XMax"); } }
        private double yMin = -2;
        public double YMin { get => yMin; set { yMin = value; OnPropertyChanged("YMin"); } }
        private double yMax = 2;
        public double YMax { get => yMax; set { yMax = value; OnPropertyChanged("YMax"); } }
        private RelayCommand reFind;
        public RelayCommand ReFind { get
            {
                return reFind ??
                    (reFind = new RelayCommand(obj =>
                    {
                        Pict = FractalFinder.FractalCreator(Sets, C, XMin, XMax, YMin, YMax, 500, 500, 200);
                    },
                    (obj => xMax > xMin && yMax > yMin)
                    ));
            } }
        private RelayCommand reFindVar1;
        public RelayCommand ReFindVar1
        {
            get
            {
                return reFindVar1 ??
                    (reFindVar1 = new RelayCommand(obj =>
                    {
                        Pict = FractalFinder.FractalCreator(Sets.Mandelbrot, new Complex(-0.74543, 0.11301), -2.2, 1.0, -1.2, 1.2, 500, 500, 200);
                    }));
            }
        }
        private RelayCommand reFindVar2;
        public RelayCommand ReFindVar2
        {
            get
            {
                return reFindVar2 ??
                    (reFindVar2 = new RelayCommand(obj =>
                    {
                        Pict = FractalFinder.FractalCreator(Sets.Mandelbrot, new Complex(-0.74543, 0.11301), -2.0, 0.8, -1.0, 1.0, 500, 500, 200);
                    }));
            }
        }
        private RelayCommand reFindVar3;
        public RelayCommand ReFindVar3
        {
            get
            {
                return reFindVar3 ??
                    (reFindVar3 = new RelayCommand(obj =>
                    {
                        Pict = FractalFinder.FractalCreator(Sets.Mandelbrot, new Complex(-0.74543, 0.11301), -1.8, 0.5, -1.2, 1.1, 500, 500, 200);
                    }));
            }
        }
        private RelayCommand reFindVar4;
        public RelayCommand ReFindVar4
        {
            get
            {
                return reFindVar4 ??
                    (reFindVar4 = new RelayCommand(obj =>
                    {
                        Pict = FractalFinder.FractalCreator(Sets.Mandelbrot, new Complex(-0.74543, 0.11301), -1.5, 1.0, -0.8, 0.8, 500, 500, 200);
                    }));
            }
        }
        private RelayCommand reFindVar5;
        public RelayCommand ReFindVar5
        {
            get
            {
                return reFindVar5 ??
                    (reFindVar5 = new RelayCommand(obj =>
                    {
                        Pict = FractalFinder.FractalCreator(Sets.Julia, new Complex(-0.74543, 0.11301), -1.0, 1.0, -1.2, 1.2, 500, 500, 200);
                    }));
            }
        }
        private RelayCommand reFindVar6;
        public RelayCommand ReFindVar6
        {
            get
            {
                return reFindVar6 ??
                    (reFindVar6 = new RelayCommand(obj =>
                    {
                        Pict = FractalFinder.FractalCreator(Sets.Julia, new Complex(-0.74543, 0.11301), -0.9, 0.9, -1.1, 1.0, 500, 500, 200);
                    }));
            }
        }
        private RelayCommand reFindVar7;
        public RelayCommand ReFindVar7
        {
            get
            {
                return reFindVar7 ??
                    (reFindVar7 = new RelayCommand(obj =>
                    {
                        Pict = FractalFinder.FractalCreator(Sets.Julia, new Complex(-0.74543, 0.11301), -1.0, 0.7, -0.9, 1.1, 500, 500, 200);
                    }));
            }
        }
        private RelayCommand reFindVar8;
        public RelayCommand ReFindVar8
        {
            get
            {
                return reFindVar8 ??
                    (reFindVar8 = new RelayCommand(obj =>
                    {
                        Pict = FractalFinder.FractalCreator(Sets.Newton, new Complex(-0.74543, 0.11301), -1.0, 1.0, -1.0, 1.0, 500, 500, 200);
                    }));
            }
        }
        private RelayCommand reFindVar9;
        public RelayCommand ReFindVar9
        {
            get
            {
                return reFindVar9 ??
                    (reFindVar9 = new RelayCommand(obj =>
                    {
                        Pict = FractalFinder.FractalCreator(Sets.Newton, new Complex(-0.74543, 0.11301), -0.9, 0.9, -0.8, 0.8, 500, 500, 200);
                    }));
            }
        }
        private RelayCommand reFindVar10;
        public RelayCommand ReFindVar10
        {
            get
            {
                return reFindVar10 ??
                    (reFindVar10 = new RelayCommand(obj =>
                    {
                        Pict = FractalFinder.FractalCreator(Sets.Newton, new Complex(-0.74543, 0.11301), -1.0, 0.7, -0.7, 1.0, 500, 500, 200);
                    }));
            }
        }
        

        private Bitmap pict;
        public Bitmap Pict { get => pict; 
            set 
            { 
                pict = value;
                OnPropertyChanged("Pict");
            } 
        }

        private Sets sets = Sets.Julia;
        public Sets Sets { get => sets; set  { sets = value; OnPropertyChanged("Sets"); } }

        public ObservableCollection<string> FractSets { get; private set; } 
        public ObservableCollection<string> CSet { get; private set; }

        private Complex c;

        public Complex C
        {
            get { return c; }
            set { c = value; OnPropertyChanged("C"); }
        }


        public PointCollection PointsSector { get; set; }
        public DataContext() 
        { 
            header = "Fractal";
            FractSets = new ObservableCollection<string>() { "Мандельброт", "Джулиа", "Ньютон" };
            CSet = new ObservableCollection<string>() { "0.36 + 0.36i", "-0.8 + 0.156i", "-0.74543 + 0.11301i", "0.285 + 0.01i", "-0.0085 + 0.71i" };
            C = new Complex(-0.74543, 0.11301);
        }


        


        

        
    }
}
