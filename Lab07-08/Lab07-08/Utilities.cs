namespace Lab07_08
{
    using System;
    using System.Collections.Generic;
    
    /// <summary>
    /// Class for store utilities methods.
    /// </summary>
    public class Utilities
    {
        public static List<List<int>> GetRandomErrors(int count, int matrixSize, bool directionJ = true,
            bool directionI = true, int conditionJ = 0, int conditionI = 0)
        {
            var random = new Random();
            var result = new List<List<int>>(count);

            while (result.Count < count)
            {
                int i;

                if (directionI)
                {
                    i = random.Next(conditionI, matrixSize - conditionI);
                }
                else
                {
                    i = random.Next(matrixSize - conditionI);
                }

                int j;

                if (directionJ)
                {
                    if (!directionI)
                    {
                        j = random.Next(conditionJ, matrixSize);
                    }
                    else
                    {
                        j = random.Next(conditionJ, matrixSize - conditionJ);
                    }
                }
                else
                {
                    j = random.Next(matrixSize - conditionJ);
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