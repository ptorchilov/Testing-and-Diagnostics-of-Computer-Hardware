namespace Lab07_08
{
    using System;
    using System.Collections.Generic;
    
    /// <summary>
    /// Class for store utilities methods.
    /// </summary>
    public class Utilities
    {
        /// <summary>
        /// Gets the random errors.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="matrixSize">Size of the matrix.</param>
        /// <param name="direction">if set to <c>true</c> [direction].</param>
        /// <param name="condition">The condition.</param>
        /// <returns></returns>
        public static List<List<int>> GetRandomErrors(int count, int matrixSize, bool direction = true,
            int condition = 0)
        {
            var random = new Random();
            var result = new List<List<int>>(count);

            while (result.Count < count)
            {
                var i = random.Next(matrixSize);

                int j;

                if (direction)
                {
                    j = random.Next(condition, matrixSize);
                }
                else
                {
                    j = random.Next(matrixSize - condition);
                }
            

                var containsFlag = false;

                if (result.Count == 0)
                {
                    var indeces = new List<int> {i, j};

                    result.Add(indeces);
                }
                else
                {
                    foreach (var index in result)
                    {
                        if (index[0] == i && index[1] == j)
                        {
                            containsFlag = true;
                            break;
                        }
                    }

                    if (!containsFlag)
                    {
                        var indeces = new List<int> {i, j};

                        result.Add(indeces);
                    }
                }
            }

            return result;
        }
    }
}