namespace Calculation.Classes
{
    public class TriDiagMatrix
    {
        public TriDiagMatrix(int n)
        {
            N = n;
            A = new double[N];
            C = new double[N]; 
            B = new double[N];
            F = new double[N];
        }

        /// <summary>
        /// Количество переменных (уравнений).
        /// </summary>
        public int N { get; set; }

        /// <summary>
        /// Верхняя диагональ.
        /// </summary>
        public double[] A { get; set; }

        /// <summary>
        /// Главная диагональ.
        /// </summary>
        public double[] C { get; set; }

        /// <summary>
        ///  Нижняя диагональ.
        /// </summary>
        public double[] B { get; set; }

        /// <summary>
        /// Правая часть.
        /// </summary>
        public double[] F { get; set; }

        /// <summary>
        /// Метод прогонки.
        /// </summary>
        /// <returns>Вектор решения.</returns>
        public double[] Solve()
        {
            double[] alpha = new double[N];
            double[] beta = new double[N];
            alpha[1] = -B[0] / C[0];
            beta[1] = F[0] / C[0];
            for (int i = 1; i < N - 1; i++)
            {
                alpha[i + 1] = -B[i] / (A[i] * alpha[i] + C[i]);
                beta[i + 1] = (F[i] - A[i] * beta[i]) / (A[i] * alpha[i] + C[i]);
            }
            double[] x = new double[N];
            x[N - 1] = (F[N - 1] - A[N - 1] * beta[N - 1]) / (C[N - 1] + A[N - 1] * alpha[N - 1]);
            for (int i = N - 2; i >= 0; i--)
            {
                x[i] = alpha[i + 1] * x[i + 1] + beta[i + 1];
            }
            return x;
        }
    }
}