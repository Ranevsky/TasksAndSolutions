namespace TasksAndSolutions.Codewars;

internal class Matrix_Determinant
{
    public static int Determinant(int[][] matrix)
    {
        if (matrix.Length == 1)
        {
            return matrix[0][0];
        }

        return DeterminantMoreOne(matrix);
    }

    public static int DeterminantMoreOne(int[][] matrix)
    {
        if (matrix.Length == 2)
        {
            return DeterminantSecondOrder(matrix);
        }

        int determinant = 0;
        for (int i = 0; i < matrix.Length; i++)
        {
            if (matrix[0][i] == 0)
            {
                continue;
            }

            determinant += matrix[0][i] * Pow(i) * Determinant(MatrixException(matrix, 0, i));
        }

        return determinant;
    }
    private static int[][] MatrixException(int[][] matrix, int i, int j)
    {
        int[][] newMatrix = new int[matrix.Length - 1][];

        int countI = 0;
        int countJ;

        for (int ii = 0; ii < matrix.Length; ii++)
        {
            if (ii == i)
            {
                continue;
            }
            countJ = 0;
            newMatrix[countI] = new int[matrix.Length - 1];
            for (int jj = 0; jj < matrix[ii].Length; jj++)
            {
                if (jj == j)
                {
                    continue;
                }

                newMatrix[countI][countJ] = matrix[ii][jj];
                countJ++;
            }
            countI++;
        }


        return newMatrix;
    }
    private static int Pow(int n)
    {
        return n % 2 == 0 ? 1 : -1;
    }
    private static int DeterminantSecondOrder(int[][] matrix)
    {
        return matrix[0][0] * matrix[1][1] - matrix[0][1] * matrix[1][0];
    }
}
