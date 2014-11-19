namespace Lab06
{
    using System;

    /// <summary>
    /// Class for utilities
    /// </summary>
    public static class Utilities
    {
        #region Sequence generator

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
            foreach (var bit in sequence)
            {
                Console.Write(bit + " ");
            }
        } 

        #endregion
    }
}
