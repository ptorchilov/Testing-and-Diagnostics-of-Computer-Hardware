namespace Lab07_08.FaultModels
{
    public enum FaultsMode
    {
        /// <summary>
        /// The sell not available
        /// </summary>
        SellNotAvailable = 1,

        /// <summary>
        /// The several writes
        /// </summary>
        SeveralAddress = 2,



        UpZeroToOneInverse = 3,

        DownZeroToOneInverse = 4,

        UpOneToZeroInverse = 5,

        DownOneToZeroInverse = 6,



        UpZeroToOneConst0 = 7,

        UpZeroToOneConst1 = 8,

        UpOneToZeroConst0 = 9,

        UpOneToZeroConst1 = 10,

        DownZeroToOneConst0 = 11,

        DownZeroToOneConst1 = 12,

        DownOneToZeroConst0 = 13,

        DownOneToZeroConst1 = 14,


    }
}
