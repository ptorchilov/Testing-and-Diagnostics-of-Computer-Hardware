namespace Lab06
{
    using System;
    using System.Collections;
    using System.Text;

    /// <summary>
    /// Class for utilities
    /// </summary>
    public static class Utilities
    {
        #region Sequence Utilities

        /// <summary>
        /// Genarates the random sequence.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public static int[] GenarateRandomSequence(int size)
        {
            var random = new Random();
            var resultSequence = new int[size];

            for (var i = 0; i < resultSequence.Length; i++)
            {
                resultSequence[i] = random.Next(2);
            }

            return resultSequence;
        }

        /// <summary>
        /// Converts the sequence to bit array.
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        /// <returns></returns>
        public static BitArray ConvertSequenceToBitArray(int[] sequence)
        {
            var resultBitArray = new BitArray(sequence.Length);

            for (var i = 0; i < sequence.Length; i++)
            {
                resultBitArray[i] = Convert.ToBoolean(sequence[i]);
            }

            return resultBitArray;
        }

        #endregion

        #region Signature Utilities

        /// <summary>
        /// Comapares the signatures.
        /// </summary>
        /// <param name="firstSignature">The first signature.</param>
        /// <param name="secondSignature">The second signature.</param>
        /// <returns></returns>
        public static bool ComapareSignatures(BitArray firstSignature, BitArray secondSignature)
        {
            if (firstSignature.Length != secondSignature.Length)
            {
                return false;
            }

            for (var i = 0; i < firstSignature.Length; i++)
            {
                if (firstSignature[i] != secondSignature[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Nots the operation.
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public static int[] NotOperation(int[] sequence, int index)
        {
            if (sequence[index] == 1)
            {
                sequence[index] = 0;
            }
            else
            {
                sequence[index] = 1;
            }

            return sequence;
        }

        #endregion

        #region Test Methods

        /// <summary>
        /// To the bit string.
        /// </summary>
        /// <param name="bits">The bits.</param>
        /// <returns></returns>
        public static string ToBitString(BitArray bits)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < bits.Count; i++)
            {
                char c = bits[i] ? '1' : '0';
                sb.Append(c);
            }

            return sb.ToString();
        }  

        #endregion

        #region Console Output

        /// <summary>
        /// Shows the message.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public static void ShowMessage(String msg)
        {
            Console.WriteLine(msg + Environment.NewLine);
        }

        /// <summary>
        /// Shows the sequence.
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        public static void ShowSequence(int[] sequence)
        {
            Console.WriteLine("Output sequence:");

            foreach (var bit in sequence)
            {
                Console.Write(bit + " ");
            }

            Console.WriteLine();
        } 

        #endregion
    }
}
