namespace Lab06
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Class for geterate all combinations of indeces in array.
    /// </summary>
    public class Combinator
    {
        #region Fields

        /// <summary>
        /// Gets the sequence.
        /// </summary>
        /// <value>
        /// The sequence.
        /// </value>
        public int[] Sequence { get; private set; } 

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Combinator"/> class.
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        public Combinator(int[] sequence)
        {
            Sequence = sequence;
        } 

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the combinations.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="level">The level.</param>
        /// <returns></returns>
        public List<List<int>> GetCombinations(int start, int level)
        {
            var combinations = Get(start, level);
            var sb = new StringBuilder();

            foreach (var item in combinations)
            {
                sb.Append(item).Append(";");
            }

            sb.Length--;

            return GetSplittedIndeces(GetSplittedValues(sb.ToString()));
        } 

        #endregion

        #region Private Methdos

        /// <summary>
        /// Gets the splitted indeces.
        /// </summary>
        /// <param name="combinations">The combinations.</param>
        /// <returns></returns>
        private List<List<int>> GetSplittedIndeces(IEnumerable<String> combinations)
        {
            var result = new List<List<int>>();

            foreach (var combination in combinations)
            {
                var indeces = combination.Split(' ');

                result.Add(new List<int>(new[] { Int32.Parse(indeces[0]), Int32.Parse(indeces[1]) }));
            }

            return result;
        }

        /// <summary>
        /// Gets the splitted values.
        /// </summary>
        /// <param name="combinations">The combinations.</param>
        /// <returns></returns>
        private IEnumerable<String> GetSplittedValues(String combinations)
        {
            return combinations.Split(';').ToList();
        }

        /// <summary>
        /// Gets the specified start.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="level">The level.</param>
        /// <returns></returns>
        private IEnumerable<string> Get(int start, int level)
        {
            for (var i = start; i < Sequence.Length; i++)
            {
                if (level == 1)
                {
                    yield return i.ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    foreach (var combination in Get(i + 1, level - 1))
                    {
                        yield return String.Format("{0} {1}", i, combination);
                    }
                }
            }
        } 

        #endregion
    }
}