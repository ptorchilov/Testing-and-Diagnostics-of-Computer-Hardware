namespace Lab06
{
    using System;
    using System.Text;
    
    /// <summary>
    /// Class for store binary matrix.
    /// </summary>
    public class Matrix
    {
        #region Fields

        /// <summary>
        /// The matrix
        /// </summary>
        private readonly int[,] matrix; 

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix"/> class.
        /// </summary>
        /// <param name="dim1">The dim1.</param>
        /// <param name="dim2">The dim2.</param>
        public Matrix(int dim1, int dim2)
        {
            matrix = new int[dim1, dim2];
        } 

        #endregion

        #region Properties

        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        public int Height
        {
            get { return matrix.GetLength(0); }
        }

        /// <summary>
        /// Gets the width.
        /// </summary>
        /// <value>
        /// The width.
        /// </value>
        public int Width
        {
            get { return matrix.GetLength(1); }

        }

        /// <summary>
        /// Gets or sets the <see cref="System.Int32"/> with the specified x.
        /// </summary>
        /// <value>
        /// The <see cref="System.Int32"/>.
        /// </value>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        public int this[int x, int y]
        {
            get { return matrix[x, y]; }
            set { matrix[x, y] = value; }
        } 

        #endregion

        #region Public Methods

        /// <summary>
        /// Xors the mutliplication.
        /// </summary>
        /// <param name="matrix1">The matrix1.</param>
        /// <param name="matrix2">The matrix2.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Sets the running one.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Sets the first row.
        /// </summary>
        /// <param name="firstRow">The first row.</param>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Length of row on equal matrix row length.</exception>
        public static Matrix SetFirstRow(int[] firstRow, Matrix matrix)
        {
            if (firstRow.Length != matrix.Width)
            {
                throw new ArgumentException("Length of row on equal matrix row length.");
            }

            for (var j = 0; j < matrix.Width; j++)
            {
                matrix[0, j] = firstRow[j];
            }

            return matrix;
        }

        /// <summary>
        /// Shows the matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
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

            Console.WriteLine(sb.ToString());
        } 

        #endregion
    }
}
