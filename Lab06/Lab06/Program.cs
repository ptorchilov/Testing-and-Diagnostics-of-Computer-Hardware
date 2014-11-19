namespace Lab06
{
    using System;

    public class Program
    {
        public static void Main(String[] args)
        {
            var matrix = new Matrix(8, 8);
            var firstRow = new [] {0, 1, 0, 0, 1, 0, 0, 1};
            
            matrix = Matrix.SetFirstRow(firstRow, matrix);
            matrix = Matrix.SetRunningOne(matrix);

            Utilities.ShowMessage("Single channel signature analyzer:");
            Matrix.ShowMatrix(matrix);
            
            matrix = Matrix.XorMutliplication(matrix, matrix);

            Utilities.ShowMessage("Dual channel signature analyzer:");
            Matrix.ShowMatrix(matrix);

            var sequence = Utilities.GenarateRandomSequence(56);
            Utilities.ShowSequence(sequence);

            var combinator = new Combinator(sequence);

            var combinations = combinator.GetCombinations(0, 2);

            var i = 0;
        }
    }
}
