namespace Lab06
{
    using System;

    /// <summary>
    /// Class for utilities
    /// </summary>
    public static class Utilities
    {
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
    }
}
