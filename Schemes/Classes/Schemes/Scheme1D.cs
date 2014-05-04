using System.Collections.Generic;
using System.Linq;
using Schemes.Enums;
using Schemes.Interfaces;
using Schemes.TimeDependent1D;

namespace Schemes.Classes.Schemes
{
    public abstract class Scheme1D : IScheme1D
    {
        protected Scheme1D(IList<BoundaryCondition> boundaryConditions)
        {
            BoundaryConditions = boundaryConditions;
        }

        protected virtual internal TriDiagMatrix BuildMatrix(double[] currentLayer, Grid1D grid, double t, double dt)
        {            
            // Решение.
            TriDiagMatrix matrix = new TriDiagMatrix(grid.N);

            // На левой границе.
            SetLeftBoundaryCondition(matrix, t);

            // Заполнение матрицы.
            FillMatrix(matrix, currentLayer, grid, t, dt);

            // На правой границе.
            SetRightBoundaryCondition(matrix, t);

            return matrix;
        }

        protected virtual internal double[] SolveLayer(double[] currentLayer, Grid1D grid, double t, double dt)
        {
            // Решение СЛАУ методом прогонки.
            var matrix = BuildMatrix(currentLayer, grid, t, dt);

            // Решение СЛАУ методом прогонки.
            return matrix.Solve();
        }

        protected internal abstract void FillMatrix(TriDiagMatrix matrix, double[] currentLayer, Grid1D grid, double t, double dt);

        #region Boundary conditions

        public IList<BoundaryCondition> BoundaryConditions { get; private set; }

        protected internal virtual void SetLeftBoundaryCondition(TriDiagMatrix matrix, double t)
        {
            // Левая граница.
            var leftBoundaryCondition =
                BoundaryConditions.FirstOrDefault(bc => bc.Location == BoundaryConditionLocation.Left);
            if (leftBoundaryCondition != null)
            {
                matrix.F[0] = leftBoundaryCondition.Value(t);
                switch (leftBoundaryCondition.Type)
                {
                    case BoundaryConditionType.Dirichlet:
                        matrix.C[0] = 1;
                        break;
                    case BoundaryConditionType.Neumann:
                        matrix.B[0] = 1;
                        matrix.C[0] = -1;
                        break;
                }
            }
        }

        protected internal virtual void SetRightBoundaryCondition(TriDiagMatrix matrix, double t)
        {
            // Правая граница.
            int N = matrix.N;
            var rightBoundaryCondition =
                BoundaryConditions.FirstOrDefault(bc => bc.Location == BoundaryConditionLocation.Right);
            if (rightBoundaryCondition != null)
            {
                matrix.F[N - 1] = rightBoundaryCondition.Value(t);
                switch (rightBoundaryCondition.Type)
                {
                    case BoundaryConditionType.Dirichlet:
                        matrix.C[N - 1] = 1;
                        break;
                    case BoundaryConditionType.Neumann:
                        matrix.A[N - 1] = -1;
                        matrix.C[N - 1] = 1;
                        break;
                }
            }
        } 
        #endregion

        public TimeDependent1DSolution Solve(IStopCondition stopCondition, Grid1D grid, double[] initialLayer, double dt)
        {
            TimeDependent1DSolution solution = new TimeDependent1DSolution(grid, dt);
            solution.Initialize(initialLayer);
            do
            {
                // Следующий шаг по времени.
                solution.Next();

                // Решение.
                var newLayer = SolveLayer(solution.CurrentLayer, grid, solution.tCurrent, solution.dt);

                // Добавления нового слоя в результат.
                solution.AddLayer(newLayer);
            }
            while (!stopCondition.IsFinish(solution));
            return solution;
        }
    }
}