using System;
using System.Linq;
using Calculation.Classes.Algorithms.Common;
using Calculation.Classes.Algorithms.Common.Extensions;
using Calculation.Classes.Algorithms.Common.Matrixes;
using Calculation.Classes.Algorithms.TimeDependent;
using Calculation.Classes.Algorithms.TimeDependent.Extensions;
using Calculation.Enums;
using Calculation.Interfaces;

namespace Calculation.Classes.Algorithms.Solvers
{
    public class SchemeSolver<TData> : Solver where TData : class
    {
        public void Solve(string name, TData data, IScheme1D scheme, double[] initialValues, 
            BoundaryCondition leftBoundaryCondition, BoundaryCondition rightBoundaryCondition, params IContinue[] continues)
        {
            var bundle = (SequenceBundle)CreateBundle(name, data);
            try
            {
                bundle.BeginEdit();

                bundle.Save();

                double t = 0;
                int number = 0;

                var grid = bundle.GetGrid();
                double dt = bundle.dt();

                // Начальные условия.
                string layerName = GetLayerName(bundle, number);
                bundle.AddArray(layerName, number, initialValues);

                while (continues.All(c => c.Continue(bundle)))
                {
                    number++;
                    t += dt;

                    var matrix = new TriDiagMatrix(grid.N);

                    // На левой границе.
                    SetLeftBoundaryCondition(matrix, leftBoundaryCondition, t);

                    // Построение матрицы.
                    scheme.FillMatrix(matrix, bundle, grid, t, dt);

                    // На правой границе.
                    SetRightBoundaryCondition(matrix, rightBoundaryCondition, t);

                    // Решение СЛАУ методом прогонки.
                    var newLayer = matrix.Solve();
                    // Добавления нового слоя в результат.  
                    layerName = GetLayerName(bundle, number);

                    bundle.AddArray(layerName, number, newLayer);
                }
                OnSolved(bundle, true);
            }
            catch (Exception exception)
            {
                OnSolved(bundle, false, exception);
            }
        }

        #region Boundary conditions

        protected internal virtual void SetLeftBoundaryCondition(TriDiagMatrix matrix, BoundaryCondition leftBoundaryCondition, double t)
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

        protected internal virtual void SetRightBoundaryCondition(TriDiagMatrix matrix, BoundaryCondition rightBoundaryCondition, double t)
        {
            // Правая граница.
            int N = matrix.N;
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

        #endregion
    }
}