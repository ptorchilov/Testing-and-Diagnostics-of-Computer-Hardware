namespace Lab06
{
    using System.Collections;

    /// <summary>
    /// Class for represent signature analyzer.
    /// </summary>
    public class SignatureAnalyzer
    {
        #region Fields

        /// <summary>
        /// The polinom size
        /// </summary>
        private const int PolinomSize = 8;

        private readonly int[] firstRow;

        private readonly int[] secondRow;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SignatureAnalyzer" /> class.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        public SignatureAnalyzer(Matrix matrix)
        {
            firstRow = new int[matrix.Width];
            secondRow = new int[matrix.Width];

            for (var j = 0; j < matrix.Width; j++)
            {
                firstRow[j] = matrix[0, j];
                secondRow[j] = matrix[1, j];
            }
        } 

        #endregion

        #region Public Methods

        /// <summary>
        /// Compresses the specified outputs.
        /// </summary>
        /// <param name="outputs">The outputs.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public BitArray Compress(BitArray outputs, SignatureAnalyzerType type)
        {
            var signature = new BitArray(new[] {1}) {Length = PolinomSize};

            switch (type)
            {
                case SignatureAnalyzerType.SingleChannel:
                {
                    return SingleChannelPolinom(signature, outputs);
                }
                case SignatureAnalyzerType.DualChannel:
                {
                    return DualChannelPolinom(signature, outputs);
                }
                default:
                {
                    return signature;
                }
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Singles the channel polinom.
        /// </summary>
        /// <param name="signature">The signature.</param>
        /// <param name="outputs">The outputs.</param>
        /// <returns></returns>
        private BitArray SingleChannelPolinom(BitArray signature, BitArray outputs)
        {
            for (var i = 0; i < outputs.Length; i++)
            {
                signature[7] = signature[6];
                signature[6] = signature[5];
                signature[5] = signature[4];
                signature[4] = signature[3];
                signature[3] = signature[2];
                signature[2] = signature[1];
                signature[1] = signature[0];
                signature[0] = GetXorBit(secondRow, signature, outputs[i]);
            }

            return signature;
        }

        /// <summary>
        /// Duals the channel polinom.
        /// </summary>
        /// <param name="signature">The signature.</param>
        /// <param name="outputs">The outputs.</param>
        /// <returns></returns>
        private BitArray DualChannelPolinom(BitArray signature, BitArray outputs)
        {
            for (var i = 0; i < outputs.Length; i += 2)
            {
                signature[7] = signature[5];
                signature[6] = signature[4];
                signature[5] = signature[3];
                signature[4] = signature[2];
                signature[3] = signature[1];
                signature[2] = signature[0];
                signature[1] = GetXorBit(secondRow, signature, outputs[i]);
                signature[0] = GetXorBit(firstRow, signature, outputs[i]);
            }

            return signature;
        }

        private bool GetXorBit(int[] row, BitArray signature, bool output)
        {
            var resultBit = output;

            for (var i = 0; i < row.Length; i++)
            {
                if (row[i] == 1)
                {
                    resultBit ^= signature[i];
                }
            }

            return resultBit;
        }

        #endregion
    }
}