using System;

namespace LibMas
{
    public class ArrayUtils
    {
        // Метод для создания случайной матрицы
        public static int[,] CreateRandomMatrix(int M, int N)
        {
            int[,] matrix = new int[M, N];
            Random random = new Random();

            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    matrix[i, j] = random.Next(1, 11); 
                }
            }

            return matrix;
        }

    }
}
