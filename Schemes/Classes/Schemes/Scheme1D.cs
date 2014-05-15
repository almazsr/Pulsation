using System;
using System.Collections.Generic;
using System.Linq;
using Calculation.Enums;
using Calculation.Interfaces;

namespace Calculation.Classes.Schemes
{
    public abstract class Scheme1D : IScheme1D
    {
        protected Scheme1D(IList<BoundaryCondition> boundaryConditions)
        {
            BoundaryConditions = boundaryConditions;
        }

        protected virtual internal TriDiagMatrix BuildMatrix(ILayer1D currentLayer, IGrid1D grid, double t, double dt)
        {            
            // �������.
            TriDiagMatrix matrix = new TriDiagMatrix(grid.N);

            // �� ����� �������.
            SetLeftBoundaryCondition(matrix, t);

            // ���������� �������.
            FillMatrix(matrix, currentLayer, grid, t, dt);

            // �� ������ �������.
            SetRightBoundaryCondition(matrix, t);

            return matrix;
        }

        public virtual double[] SolveLayer(ILayer1D currentLayer, IGrid1D grid, double t, double dt)
        {
            // ������� ���� ������� ��������.
            var matrix = BuildMatrix(currentLayer, grid, t, dt);

            // ������� ���� ������� ��������.
            return matrix.Solve();
        }

        protected internal abstract void FillMatrix(TriDiagMatrix matrix, ILayer1D currentLayer, IGrid1D grid, double t, double dt);

        #region Boundary conditions

        public IList<BoundaryCondition> BoundaryConditions { get; private set; }

        public void BeginSolve(IStopCondition stopCondition, IGrid1D grid, double[] initialvalues, double dt)
        {
            var solution = Factory.Instance.CreateSolution(grid, dt);            
            solution.AddLayer(initialvalues);
            Action cycle = () =>
                               {
                                   do
                                   {
                                       // ��������� ��� �� �������.
                                       solution.NextTime();

                                       // �������.
                                       var newLayer = SolveLayer(solution.CurrentLayer, grid, solution.CurrentTime,
                                                                 solution.TimeStep);

                                       // ���������� ������ ���� � ���������.
                                       solution.AddLayer(newLayer);
                                   } while (!stopCondition.IsFinish(solution));
                               };
            cycle.BeginInvoke(null, null);
        }

        public event EventHandler Solved;

        protected internal virtual void SetLeftBoundaryCondition(TriDiagMatrix matrix, double t)
        {
            // ����� �������.
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
            // ������ �������.
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