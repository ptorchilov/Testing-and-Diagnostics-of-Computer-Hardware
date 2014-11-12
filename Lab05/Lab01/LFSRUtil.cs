namespace Lab01
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Class for realize LFSR.
    /// </summary>
    public class LfsrUtil
    {
        #region Fields

        /// <summary>
        /// The combinations
        /// </summary>
        private readonly List<BitArray> combinations; 

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LfsrUtil"/> class.
        /// </summary>
        public LfsrUtil()
        {
            combinations = new List<BitArray>();
        } 

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the get all combinations.
        /// </summary>
        /// <value>
        /// The get all combinations.
        /// </value>
        public List<BitArray> GetAllCombinations
        {
            get
            {
                return combinations;
            }
        }

        /// <summary>
        /// Generates the specified start combination.
        /// </summary>
        /// <param name="startCombination">The start combination.</param>
        public void Generate(BitArray startCombination)
        {
            combinations.Add(startCombination);

            while (true)
            {
                var nextCombination = GetNextCombination(startCombination);

                if (!IsEqual(nextCombination, combinations[0]))
                {
                    combinations.Add(nextCombination);
                    startCombination = nextCombination;
                }
                else
                {
                    break;
                }
            }
        } 

        #endregion

        #region Private Methods

        /// <summary>
        /// Determines whether the specified first is equal.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns></returns>
        private bool IsEqual(BitArray first, BitArray second)
        {
            if (first.Length != second.Length)
            {
                return false;
            }

            for (var i = 0; i < first.Length; i++)
            {
                if (first[i] != second[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Gets the next combination.
        /// </summary>
        /// <param name="combination">The combination.</param>
        /// <returns></returns>
        private BitArray GetNextCombination(BitArray combination)
        {
            var result = new BitArray(combination);

            result[0] = combination[0] ^ combination[2] ^ combination[4] ^ combination[6];
            result[1] = combination[0];
            result[2] = combination[1];
            result[3] = combination[2];
            result[4] = combination[3];
            result[5] = combination[4];
            result[6] = combination[5];

            return result;
        } 

        #endregion
    }
}