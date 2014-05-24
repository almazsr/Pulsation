using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calculation.Enums;
using Calculation.Interfaces;

namespace Calculation.Classes.Schemes
{
    public abstract class Scheme1D : IScheme1D
    {
        protected virtual internal TriDiagMatrix BuildMatrix(IBoundaryCondition leftBoundaryCondition, IBoundaryCondition rightBoundaryCondition, ILayer1D currentLayer, IGrid1D grid, double t, double dt)
        {            
            // �������.
            var matrix = new TriDiagMatrix(grid.N);

            // �� ����� �������.
            SetLeftBoundaryCondition(matrix, leftBoundaryCondition, t);

            // ���������� �������.
            FillMatrix(matrix, currentLayer, grid, t, dt);

            // �� ������ �������.
            SetRightBoundaryCondition(matrix, rightBoundaryCondition, t);

            return matrix;
        }

        protected internal abstract void FillMatrix(TriDiagMatrix matrix, ILayer1D currentLayer, IGrid1D grid, double t, double dt);

        #region Boundary conditions

        public void Solve(ISolution1D solution, IBoundaryCondition leftBoundaryCondition, IBoundaryCondition rightBoundaryCondition, IEnumerable<IStopCondition> stopConditions)
        {
            try
            {
                solution.Start();
                do
                {
                    // ��������� ��� �� �������.
                    solution.NextTime();

                    // ���������� �������.
                    var matrix = BuildMatrix(leftBoundaryCondition, rightBoundaryCondition, solution.CurrentLayer, solution.Grid, solution.tCurrent, solution.dt);

                    // ������� ���� ������� ��������.
                    var newLayer = matrix.Solve();

                    // ���������� ������ ���� � ���������.
                    solution.AddLayer(newLayer);
                }
                while (stopConditions.All(c=>!c.IsFinish(solution)));
                solution.Finish(true);
            }
            catch (Exception exception)
            {
                solution.Finish(false);
            }
        }

        public async void SolveAsync(ISolution1D solution, IBoundaryCondition leftBoundaryCondition,
                               IBoundaryCondition rightBoundaryCondition, IEnumerable<IStopCondition> stopConditions)
        {
            await Task.Run(() => Solve(solution, leftBoundaryCondition, rightBoundaryCondition, stopConditions));
        }

        public event EventHandler Solved;

        protected internal virtual void SetLeftBoundaryCondition(TriDiagMatrix matrix, IBoundaryCondition leftBoundaryCondition, double t)
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

        protected internal virtual void SetRightBoundaryCondition(TriDiagMatrix matrix, IBoundaryCondition rightBoundaryCondition, double t)
        {
            // ������ �������.
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