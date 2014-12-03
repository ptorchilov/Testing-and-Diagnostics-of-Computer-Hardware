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
        /// <returns></returns>
        public static List<List<int>> GetRandomErrors(int count, int matrixSize)
        {
            var random = new Random();
            var result = new List<List<int>>(count);

            while(result.Count < count) 
            {
                var i = random.Next(matrixSize);
                var j = random.Next(matrixSize);
                var containsFlag = false;

                if (result.Count == 0)
                {
                    var indeces = new List<int> { i, j };

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
                        var indeces = new List<int> { i, j };

                        result.Add(indeces);
                    }
                }
                
            }

            return result;
        } 
    }
}
