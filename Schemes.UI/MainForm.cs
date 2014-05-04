using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenGlExtensions.Classes;
using OpenGlExtensions.Interfaces;
using Schemes.Classes;
using Schemes.Classes.Schemes;
using Schemes.Enums;
using Schemes.TimeDependent1D;

namespace Schemes.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {            
            InitializeComponent();
            openGlChartControl1.InitializeContexts();
            Timer = new Timer();
            shapes = new List<Shape2D>();
            Timer.Interval = 1000;
            Timer.Tick += Timer_Tick;
            Init();
            Timer.Start();
        }

        private int n = 0;

        void Timer_Tick(object sender, EventArgs e)
        {
            if (n < shapes.Count)
            {
                ((IOpenGlContext2D) openGlChartControl1).ClearArea();
                ((IOpenGlContext2D) openGlChartControl1).AddShape(shapes[n]);
                ((IOpenGlContext2D) openGlChartControl1).SetAreaBoundaries(0, 1, 0, 1, 0.3);
                openGlChartControl1.Refresh();
                n++;
            }
        }

        public List<Shape2D> shapes;

        public Timer Timer { get; set; }

        public void Init()
        {
            Func<double, double, double> rightPart = (r, t) => 0;
            Grid1D grid = Grid1D.Build(0, 1, 100);
            double[] ut0 = new double[grid.N];
            for (int i = 0; i < grid.N; i++)
            {
                ut0[i] = 0;
            }
            TimeLimitCondition timeLimitCondition = new TimeLimitCondition(2*Math.PI);
            var boundaryConditions = new[]
                                         {
                                             new BoundaryCondition(t => 0, BoundaryConditionLocation.Left,
                                                                   BoundaryConditionType.Dirichlet),
                                             new BoundaryCondition(t => Math.Cos(t), BoundaryConditionLocation.Right,
                                                                   BoundaryConditionType.Dirichlet)
                                         };
            var scheme = new CrankNicolsonCylindricScheme1D(boundaryConditions, (r, t) => -(Math.Cos(t) / r) - r * Math.Sin(t), 1);
            var solution = scheme.Solve(timeLimitCondition, grid, ut0, 1E-3);

            Func<double, double, double> uExact = (r, t) => r * t;
            int n = 0;
            foreach (var layer in solution.Layers)
            {
                double[] g = new double[grid.N];
                grid.CopyTo(g, 0);
                Shape2D shape = new Curve2D(g, layer);
                shape.Color = Color.Black;
                shape.Visible = true;
                shapes.Add(shape);
            }
        }
    }
}
