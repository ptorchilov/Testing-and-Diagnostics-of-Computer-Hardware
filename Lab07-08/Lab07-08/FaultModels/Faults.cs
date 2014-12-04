namespace Lab07_08.FaultModels
{
    /// <summary>
    /// Enumneration for store fault types.
    /// </summary>
    public enum Faults
    {
        /// <summary>
        /// The Address Decoder Faults
        /// </summary>
        // ReSharper disable once InconsistentNaming
        AF = 1,

        /// <summary>
        /// The Stuck-At Fults.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        SAF = 2,

        /// <summary>
        /// The Inversion Coupling Faults
        /// </summary>
        CFin = 3,

        /// <summary>
        /// The Idempotent Coupling Faults.
        /// </summary>
        CFid = 4,

        /// <summary>
        /// The Passive NPSF K = 9
        /// </summary>
        // ReSharper disable once InconsistentNaming
        PNPSFK9 = 5,

        /// <summary>
        /// The Active NPSF K = 3
        /// </summary>
        // ReSharper disable once InconsistentNaming
        ANPSFK3 = 6
    }
}
