using System;
using System.Collections.Generic;
using System.Linq;
using Schemes.Database;
using Schemes.Enums;
using Schemes.Interfaces;

namespace Schemes.Classes.Schemes
{
    public abstract class Scheme1D : IScheme1D
    {
        protected Scheme1D(IList<BoundaryCondition> boundaryConditions)
        {
            BoundaryConditions = boundaryConditions;
        }

        protected virtual internal TriDiagMatrix BuildMatrix(ILayer1D currentLayer, IGrid1D grid, double t, double dt)
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

        public virtual double[] SolveLayer(ILayer1D currentLayer, IGrid1D grid, double t, double dt)
        {
            // Решение СЛАУ методом прогонки.
            var matrix = BuildMatrix(currentLayer, grid, t, dt);

            // Решение СЛАУ методом прогонки.
            return matrix.Solve();
        }

        protected internal abstract void FillMatrix(TriDiagMatrix matrix, ILayer1D currentLayer, IGrid1D grid, double t, double dt);

        #region Boundary conditions

        public IList<BoundaryCondition> BoundaryConditions { get; private set; }

        public void BeginSolve(IStopCondition stopCondition, IGrid1D grid, double[] initialvalues, double dt)
        {            
            using (DbSolutionContext db = new DbSolutionContext())
            {
                var solution = Factory.Instance.CreateSolution(grid, dt);
                int solutionId = solution.Save();
            }
            solution.dt = dt;
            solution.AddLayer(initialvalues);
            Action cycle = () =>
                               {
                                   do
                                   {
                                       // Следующий шаг по времени.
                                       solution.NextTime();

                                       // Решение.
                                       var newLayer = SolveLayer(solution.CurrentLayer, grid, solution.CurrentTime,
                                                                 solution.dt);

                                       // Добавления нового слоя в результат.
                                       solution.AddLayer(newLayer);
                                   } while (!stopCondition.IsFinish(solution));
                               };
            cycle.BeginInvoke(null, null);
        }

        public event EventHandler Solved;

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
    }
}