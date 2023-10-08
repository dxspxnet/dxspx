using System.Collections.Generic;
using System.Linq;

namespace Lib_10
{
    public class MatrixSolver
    {
        public static int FindColumnWithMostDuplicates(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int maxDuplicateCount = 0;
            int columnIndexWithMaxDuplicates = -1;

            for (int j = 0; j < cols; j++)
            {
                Dictionary<int, int> elementCount = new Dictionary<int, int>();

                for (int i = 0; i < rows; i++)
                {
                    int element = matrix[i, j];

                    if (elementCount.ContainsKey(element))
                        elementCount[element]++;
                    else
                        elementCount[element] = 1;
                }

                int duplicateCount = elementCount.Values.Max();

                if (duplicateCount > maxDuplicateCount)
                {
                    maxDuplicateCount = duplicateCount;
                    columnIndexWithMaxDuplicates = j;
                }
            }

            return columnIndexWithMaxDuplicates;
        }
    }
}
