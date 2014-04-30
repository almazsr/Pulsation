using System.Collections.Generic;
using System.Linq;
using Schemes.Enums;
using Schemes.Interfaces;
using Schemes.TimeDependent1D;

namespace Schemes.Classes.Schemes
{
    public abstract class Scheme : TimeMaxFinishCondition, IScheme1D
    {
        protected Scheme(double tMax) : base(tMax)
        {
        }

        protected abstract void SolveInArea(TimeDependent1DSolution solution, TriDiagMatrix matrix);

        public TimeDependent1DSolution Solve(Grid1D grid, IList<BoundaryCondition> boundaryConditions, double[] initialLayer, double dt)
        {
            TimeDependent1DSolution solution = new TimeDependent1DSolution(grid, dt);
            solution.Initialize(initialLayer);
            do
            {
                // ��������� ��� �� �������.
                solution.Next();
                double t = solution.tCurrent;
                // ���������� ��������.
                TriDiagMatrix matrix = new TriDiagMatrix(grid.N);

                // ����� �������.
                var leftBoundaryCondition =
                    boundaryConditions.FirstOrDefault(bc => bc.Location == BoundaryConditionLocation.Left);
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

                // ������� � �������.
                SolveInArea(solution, matrix);

                // ������ �������.
                var rightBoundaryCondition =
                    boundaryConditions.FirstOrDefault(bc => bc.Location == BoundaryConditionLocation.Right);
                if (rightBoundaryCondition != null)
                {
                    matrix.F[grid.N - 1] = rightBoundaryCondition.Value(t);
                    switch (rightBoundaryCondition.Type)
                    {
                        case BoundaryConditionType.Dirichlet:
                            matrix.C[grid.N - 1] = 1;
                            break;
                        case BoundaryConditionType.Neumann:
                            matrix.A[grid.N - 1] = -1;
                            matrix.C[grid.N - 1] = 1;
                            break;
                    }
                }

                // ������� ���� ������� ��������.
                double[] newLayer = matrix.Solve();

                // ���������� ������ ���� � ���������.
                solution.AddLayer(newLayer);
            } 
            while (!IsFinish(solution));
            return solution;
        }
    }
}