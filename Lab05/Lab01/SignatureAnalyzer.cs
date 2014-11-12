namespace Lab01
{
    using System;
    using System.Collections;

    /// <summary>
    /// Class for create signatures based on different polinoms.
    /// </summary>
    public class SignatureAnalyzer
    {
        #region Constants

        /// <summary>
        /// The polinom size
        /// </summary>
        private const int PolinomSize = 7; 

        #endregion

        #region Public Methods

        /// <summary>
        /// Compresses the specified outputs.
        /// </summary>
        /// <param name="outputs">The outputs.</param>
        /// <param name="polinomNumber">The polinom number.</param>
        /// <returns></returns>
        public BitArray Compress(BitArray outputs, int polinomNumber)
        {
            var signature = new BitArray(new[] { 1 }) { Length = PolinomSize };

            switch (polinomNumber)
            {
                case 0:
                    {
                        return Polinom0(signature, outputs);
                    }
                case 1:
                    {
                        return Polinom1(signature, outputs);
                    }
                case 2:
                    {
                        return Polinom2(signature, outputs);
                    }
                case 3:
                    {
                        return Polinom3(signature, outputs);
                    }
                case 4:
                    {
                        return Polinom4(signature, outputs);
                    }
                case 5:
                    {
                        return Polinom5(signature, outputs);
                    }
                case 6:
                    {
                        return Polinom6(signature, outputs);
                    }
                case 7:
                    {
                        return Polinom7(signature, outputs);
                    }
                case 8:
                    {
                        return Polinom8(signature, outputs);
                    }
                case 9:
                    {
                        return Polinom9(signature, outputs);
                    }
                default:
                    {
                        return signature;
                    }
            }
        }

        /// <summary>
        /// Gets the polunom string.
        /// </summary>
        /// <param name="polinomNumber">The polinom number.</param>
        /// <returns></returns>
        public String GetPolunomString(int polinomNumber)
        {
            switch (polinomNumber)
            {
                case 0:
                    {
                        return @"x7 + x + 1";
                    }
                case 1:
                    {
                        return @"x7 + x5 + x4+ x3 + 1";
                    }
                case 2:
                    {
                        return @"x7 + x6 + x5 + x4 + x2 + x + 1";
                    }
                case 3:
                    {
                        return @"x7 + x6 + x5 + x2 + 1";
                    }
                case 4:
                    {
                        return @"x7 + x4 + 1";
                    }
                case 5:
                    {
                        return @"x7 + x6 + x5 + x4 + 1";
                    }
                case 6:
                    {
                        return @"x7 + x6 + x5 + x4 + x3 + x2 + 1";
                    }
                case 7:
                    {
                        return @"x7 + x6 + x3 + x + 1";
                    }
                case 8:
                    {
                        return @"x7 + x6 + 1";
                    }
                case 9:
                    {
                        return @"x7 + x6 + x4 + x2 + 1";
                    }
                default:
                    {
                        return String.Empty;
                    }
            }
        }

        /// <summary>
        /// Gets the polunom difficult.
        /// </summary>
        /// <param name="polinom">The polinom.</param>
        /// <returns></returns>
        public int GetPolunomDifficult(int polinom)
        {
            switch (polinom)
            {
                case 0:
                    {
                        return 2;
                    }
                case 1:
                    {
                        return 4;
                    }
                case 2:
                    {
                        return 6;
                    }
                case 3:
                    {
                        return 4;
                    }
                case 4:
                    {
                        return 2;
                    }
                case 5:
                    {
                        return 4;
                    }
                case 6:
                    {
                        return 6;
                    }
                case 7:
                    {
                        return 4;
                    }
                case 8:
                    {
                        return 2;
                    }
                case 9:
                    {
                        return 4;
                    }
                default:
                    {
                        return 0;
                    }
            }
        } 

        #endregion

        #region Polinoms

        #region Polinom x7 + x + 1

        /// <summary>
        /// Polinom0s the specified signature.
        /// </summary>
        /// <param name="signature">The signature.</param>
        /// <param name="outputs">The outputs.</param>
        /// <returns></returns>
        private BitArray Polinom0(BitArray signature, BitArray outputs)
        {
            for (var i = 0; i < outputs.Length; i++)
            {
                signature[6] = signature[5];
                signature[5] = signature[4];
                signature[4] = signature[3];
                signature[3] = signature[2];
                signature[2] = signature[1];
                signature[1] = signature[0];
                signature[0] = signature[0] ^ signature[6] ^ outputs[i];
            }

            return signature;
        }

        #endregion

        #region Polinom x7 + x5 + x4 + x3 + 1

        /// <summary>
        /// Polinom1s the specified signature.
        /// </summary>
        /// <param name="signature">The signature.</param>
        /// <param name="outputs">The outputs.</param>
        /// <returns></returns>
        private BitArray Polinom1(BitArray signature, BitArray outputs)
        {
            for (var i = 0; i < outputs.Length; i++)
            {
                signature[6] = signature[5];
                signature[5] = signature[4];
                signature[4] = signature[3];
                signature[3] = signature[2];
                signature[2] = signature[1];
                signature[1] = signature[0];
                signature[0] = signature[2] ^ signature[3] ^ signature[4] ^
                            signature[6] ^ outputs[i];
            }

            return signature;
        }

        #endregion

        #region Polinom x7 + x6 + x5 + x4 + x2 + x + 1

        /// <summary>
        /// Polinom2s the specified signature.
        /// </summary>
        /// <param name="signature">The signature.</param>
        /// <param name="outputs">The outputs.</param>
        /// <returns></returns>
        private BitArray Polinom2(BitArray signature, BitArray outputs)
        {
            for (var i = 0; i < outputs.Length; i++)
            {
                signature[6] = signature[5];
                signature[5] = signature[4];
                signature[4] = signature[3];
                signature[3] = signature[2];
                signature[2] = signature[1];
                signature[1] = signature[0];
                signature[0] = signature[0] ^ signature[1] ^ signature[3] ^
                            signature[4] ^ signature[5] ^ signature[6] ^
                            outputs[i];
            }

            return signature;
        }

        #endregion

        #region Polinom x7 + x6 + x5 + x2 + 1

        /// <summary>
        /// Polinom3s the specified signature.
        /// </summary>
        /// <param name="signature">The signature.</param>
        /// <param name="outputs">The outputs.</param>
        /// <returns></returns>
        private BitArray Polinom3(BitArray signature, BitArray outputs)
        {
            for (var i = 0; i < outputs.Length; i++)
            {
                signature[6] = signature[5];
                signature[5] = signature[4];
                signature[4] = signature[3];
                signature[3] = signature[2];
                signature[2] = signature[1];
                signature[1] = signature[0];
                signature[0] = signature[1] ^ signature[4] ^ signature[5] ^
                            signature[6] ^ outputs[i];
            }

            return signature;
        }

        #endregion

        #region Polinom x7 + x4 + 1

        /// <summary>
        /// Polinom4s the specified signature.
        /// </summary>
        /// <param name="signature">The signature.</param>
        /// <param name="outputs">The outputs.</param>
        /// <returns></returns>
        private BitArray Polinom4(BitArray signature, BitArray outputs)
        {
            for (var i = 0; i < outputs.Length; i++)
            {
                signature[6] = signature[5];
                signature[5] = signature[4];
                signature[4] = signature[3];
                signature[3] = signature[2];
                signature[2] = signature[1];
                signature[1] = signature[0];
                signature[0] = signature[3] ^ signature[6] ^ outputs[i];
            }

            return signature;
        }

        #endregion

        #region Polinom x7 + x6 + x5 + x4 + 1

        /// <summary>
        /// Polinom5s the specified signature.
        /// </summary>
        /// <param name="signature">The signature.</param>
        /// <param name="outputs">The outputs.</param>
        /// <returns></returns>
        private BitArray Polinom5(BitArray signature, BitArray outputs)
        {
            for (var i = 0; i < outputs.Length; i++)
            {
                signature[6] = signature[5];
                signature[5] = signature[4];
                signature[4] = signature[3];
                signature[3] = signature[2];
                signature[2] = signature[1];
                signature[1] = signature[0];
                signature[0] = signature[3] ^ signature[4] ^ signature[5] ^
                            signature[6] ^ outputs[i];
            }

            return signature;
        }

        #endregion

        #region Polinom x7 + x6 + x5 + x4 + x3 + x2 + 1

        /// <summary>
        /// Polinom6s the specified signature.
        /// </summary>
        /// <param name="signature">The signature.</param>
        /// <param name="outputs">The outputs.</param>
        /// <returns></returns>
        private BitArray Polinom6(BitArray signature, BitArray outputs)
        {
            for (var i = 0; i < outputs.Length; i++)
            {
                signature[6] = signature[5];
                signature[5] = signature[4];
                signature[4] = signature[3];
                signature[3] = signature[2];
                signature[2] = signature[1];
                signature[1] = signature[0];
                signature[0] = signature[1] ^ signature[2] ^ signature[3] ^
                            signature[4] ^ signature[5] ^ signature[6] ^
                            outputs[i];
            }

            return signature;
        }

        #endregion

        #region Polinom x7 + x6 + x3 + x + 1

        /// <summary>
        /// Polinom7s the specified signature.
        /// </summary>
        /// <param name="signature">The signature.</param>
        /// <param name="outputs">The outputs.</param>
        /// <returns></returns>
        private BitArray Polinom7(BitArray signature, BitArray outputs)
        {
            for (var i = 0; i < outputs.Length; i++)
            {
                signature[6] = signature[5];
                signature[5] = signature[4];
                signature[4] = signature[3];
                signature[3] = signature[2];
                signature[2] = signature[1];
                signature[1] = signature[0];
                signature[0] = signature[0] ^ signature[2] ^ signature[5] ^
                            signature[6] ^ outputs[i];
            }

            return signature;
        }

        #endregion

        #region Polinom x7 + x6 + 1

        /// <summary>
        /// Polinom8s the specified signature.
        /// </summary>
        /// <param name="signature">The signature.</param>
        /// <param name="outputs">The outputs.</param>
        /// <returns></returns>
        private BitArray Polinom8(BitArray signature, BitArray outputs)
        {
            for (var i = 0; i < outputs.Length; i++)
            {
                signature[6] = signature[5];
                signature[5] = signature[4];
                signature[4] = signature[3];
                signature[3] = signature[2];
                signature[2] = signature[1];
                signature[1] = signature[0];
                signature[0] = signature[5] ^ signature[6] ^ outputs[i];
            }

            return signature;
        }

        #endregion

        #region Polinom x7 + x6 + x4 + x2 + 1

        /// <summary>
        /// Polinom9s the specified signature.
        /// </summary>
        /// <param name="signature">The signature.</param>
        /// <param name="outputs">The outputs.</param>
        /// <returns></returns>
        private BitArray Polinom9(BitArray signature, BitArray outputs)
        {
            for (var i = 0; i < outputs.Length; i++)
            {
                signature[6] = signature[5];
                signature[5] = signature[4];
                signature[4] = signature[3];
                signature[3] = signature[2];
                signature[2] = signature[1];
                signature[1] = signature[0];
                signature[0] = signature[1] ^ signature[3] ^ signature[5] ^
                            signature[6] ^ outputs[i];
            }

            return signature;
        }

        #endregion 

        #endregion
    }
}