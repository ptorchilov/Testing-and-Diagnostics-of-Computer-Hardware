namespace Lab06
{
    using System;
    using System.Text;
    using System.Windows.Forms;

    public class Matrix
    {
        private readonly int[,] matrix;

        public Matrix(int dim1, int dim2)
        {
            matrix = new int[dim1, dim2];
        }

        public int Height
        {
            get { return matrix.GetLength(0); }
        }

        public int Width
        {
            get { return matrix.GetLength(1); }

        }

        public int this[int x, int y]
        {
            get { return matrix[x, y];  }
            set { matrix[x, y] = value; }
        }

        public static Matrix XorMutliplication(Matrix matrix1, Matrix matrix2)
        {
            var resultMatrix = new Matrix(matrix1.Height, matrix2.Width);

            for (var i = 0; i < resultMatrix.Height; i++)
            {
                for (var j = 0; j < resultMatrix.Width; j++)
                {
                    resultMatrix[i, j] = 0;

                    for (var k = 0; k < matrix1.Width; k++)
                    {
                        resultMatrix[i, j] ^= matrix1[i, k] * matrix2[k, j];
                    }
                }
            }

            return resultMatrix;
        }

        public static Matrix SetRunningOne(Matrix matrix)
        {
            for (var i = 1; i < matrix.Height; i++)
            {
                for (var j = 0; j < matrix.Width; j++)
                {
                    if (j == i - 1)
                    {
                        matrix[i, j] = 1;
                    }
                    else
                    {
                        matrix[i, j] = 0;
                    }
                }
            }

            return matrix;
        }

        public static Matrix SetFirstRow(int[] firstRow, Matrix matrix)
        {
            if (firstRow.Length != matrix.Width)
            {
                throw new ArgumentException("Length if row on equal matrix row length.");
            }

            for (var j = 0; j < matrix.Width; j++)
            {
                matrix[0, j] = firstRow[j];
            }

            return matrix;
        }

        public static void ShowMatrix(Matrix matrix)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < matrix.Width; i++)
            {
                for (var j = 0; j < matrix.Height; j++)
                {
                    sb.Append(matrix[i, j]).Append(" ");
                }

                sb.Append(Environment.NewLine);
            }

            MessageBox.Show(sb.ToString());
        }
    }
}
