namespace Lab06
{
    using System;

    /// <summary>
    /// Main class.
    /// </summary>
    public class Program
    {
        #region Constants

        /// <summary>
        /// The sequence size
        /// </summary>
        private const int SequenceSize = 48;

        /// <summary>
        /// The polinom
        /// </summary>
        private static readonly int[] Polinom = { 0, 0, 0, 1, 1, 1, 0, 1 }; 

        #endregion

        #region Main Method

        /// <summary>
        /// Mains the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(String[] args)
        {
            var matrix = CreateSignatureAnalyzers(Polinom);

            var sequence = CreateRandomSequence(SequenceSize);

            var combinator = new Combinator(sequence);

            var combinations = combinator.GetCombinations(0, 2);

            var i = 0;
        } 

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates the signature analyzers.
        /// </summary>
        /// <param name="polinom">The polinom.</param>
        /// <returns></returns>
        private static Matrix CreateSignatureAnalyzers(int[] polinom)
        {
            var matrix = new Matrix(8, 8);

            matrix = Matrix.SetFirstRow(polinom, matrix);
            matrix = Matrix.SetRunningOne(matrix);

            Utilities.ShowMessage("Single channel signature analyzer:");
            Matrix.ShowMatrix(matrix);

            matrix = Matrix.XorMutliplication(matrix, matrix);

            Utilities.ShowMessage("Dual channel signature analyzer:");
            Matrix.ShowMatrix(matrix);

            return matrix;
        }

        /// <summary>
        /// Creates the random sequence.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        private static int[] CreateRandomSequence(int size)
        {
            var sequence = Utilities.GenarateRandomSequence(size);
            Utilities.ShowSequence(sequence);

            return sequence;
        } 

        #endregion
    }
}
