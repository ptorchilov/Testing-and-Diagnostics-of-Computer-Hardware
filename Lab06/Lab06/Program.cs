namespace Lab06
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Main class.
    /// </summary>
    public class Program
    {
        #region Constants

        /// <summary>
        /// The sequence size
        /// </summary>W
        private const int SequenceSize = 48;

        /// <summary>
        /// The polinom
        /// </summary>
        private static readonly int[] Polinom = {0, 0, 0, 1, 1, 1, 0, 1};

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

            var correctSignatureSingle = GetSignature(sequence, SignatureAnalyzerType.SingleChannel, matrix);
            Console.WriteLine();
            var correctSignatureDual = GetSignature(sequence, SignatureAnalyzerType.DualChannel, matrix);

            CompareSignatures(correctSignatureSingle, correctSignatureDual);

            for (var i = 1; i < 5; i++)
            {
                var combinations = GetCombinations(sequence, 0, i);

                var singlePercents = TestSignatureAnalyzer(sequence, combinations, matrix, correctSignatureSingle,
                    SignatureAnalyzerType.SingleChannel);

                ShowPercentages(singlePercents, SignatureAnalyzerType.SingleChannel, i);

                var dualPercents = TestSignatureAnalyzer(sequence, combinations, matrix, correctSignatureDual,
                    SignatureAnalyzerType.DualChannel);

                ShowPercentages(dualPercents, SignatureAnalyzerType.DualChannel, i);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Shows the percentages.
        /// </summary>
        /// <param name="percents">The percents.</param>
        /// <param name="type">The type.</param>
        /// <param name="combination">The combination.</param>
        private static void ShowPercentages(double percents, SignatureAnalyzerType type, int combination)
        {
            var sb = new StringBuilder();

            sb.Append("Number of ").Append(combination).Append(" time errors for ");

            sb.Append(type == SignatureAnalyzerType.SingleChannel ? "Single" : "Dual");

            sb.Append(" channel analyzer = ").AppendFormat("{0:0.00}", percents).Append("%");

            Console.WriteLine(sb.ToString());
        }

        /// <summary>
        /// Gets the correct signature.
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        /// <param name="type">The type.</param>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        private static BitArray GetSignature(int[] sequence, SignatureAnalyzerType type, Matrix matrix)
        {
            var analyzer = new SignatureAnalyzer(matrix);

            var sequenceBitArray = Utilities.ConvertSequenceToBitArray(sequence);

            return analyzer.Compress(sequenceBitArray, type);
        }

        /// <summary>
        /// Tests the signature analyzer.
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        /// <param name="combinations">The combinations.</param>
        /// <param name="matrix">The matrix.</param>
        /// <param name="correctSignature">The correct signature.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        private static double TestSignatureAnalyzer(int[] sequence, List<List<int>> combinations, Matrix matrix,
            BitArray correctSignature, SignatureAnalyzerType type)
        {
            var errorCounter = 0;

            for (var i = 0; i < combinations.Count; i++)
            {
                var errorSequence = new int[sequence.Length];

                Array.Copy(sequence, errorSequence, sequence.Length);

                for (var j = 0; j < combinations[i].Count; j++)
                {
                    errorSequence = Utilities.NotOperation(errorSequence, combinations[i][j]);
                }

                var realSignature = GetSignature(errorSequence, type, matrix);

                if (!Utilities.ComapareSignatures(correctSignature, realSignature))
                {
                    errorCounter++;
                }
            }

            return GetPercents(combinations.Count, errorCounter);
        }

        /// <summary>
        /// Gets the percents of errors.
        /// </summary>
        /// <param name="combinations">The combinations.</param>
        /// <param name="errors">The errors.</param>
        /// <returns></returns>
        private static double GetPercents(int combinations, int errors)
        {
            return ((double) errors/combinations)*100;
        }

        /// <summary>
        /// Compares the signatures.
        /// </summary>
        /// <param name="firstSignature">The first signature.</param>
        /// <param name="secondSignature">The second signature.</param>
        public static void CompareSignatures(BitArray firstSignature, BitArray secondSignature)
        {
            if (Utilities.ComapareSignatures(firstSignature, secondSignature))
            {
                Console.WriteLine("Signatures are equal: " + Utilities.ToBitString(firstSignature));
            }
            else
            {
                Console.WriteLine("Signatures are not equal: " + Utilities.ToBitString(firstSignature) +
                                  " and " + Utilities.ToBitString(secondSignature));
            }

            Console.WriteLine();
        }

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

        /// <summary>
        /// Gets the combinations.
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        /// <param name="start">The start.</param>
        /// <param name="level">The level.</param>
        /// <returns></returns>
        private static List<List<int>> GetCombinations(int[] sequence, int start, int level)
        {
            var combinator = new Combinator(sequence);

            return combinator.GetCombinations(start, level);
        }

        #endregion
    }
}