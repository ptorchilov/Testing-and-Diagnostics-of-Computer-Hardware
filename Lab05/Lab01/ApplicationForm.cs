namespace Lab01
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// Main class for start window.
    /// </summary>
    public partial class ApplicationForm : Form
    {
        #region Constants

        /// <summary>
        /// The combinations count
        /// </summary>
        private readonly int combinationsCount = (int)Math.Pow(2, 7);

        /// <summary>
        /// The inputs number
        /// </summary>
        private const int InputsNumber = 7;

        #endregion

        #region Fields

        /// <summary>
        /// The cover
        /// </summary>
        private readonly bool[] cover = new bool[13 * 2]; 

        #endregion

        #region Public Methods

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationForm"/> class.
        /// </summary>
        public ApplicationForm()
        {
            InitializeComponent();
        } 

        #endregion

        #region Private Methods

        #region For lab 4

        /// <summary>
        /// Buttons the test click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonTestClick(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            var inputs = GetInputs(new BitArray(new[] { 1 }) { Length = InputsNumber });

            var count = combinationsCount;
            var startCase = new BitArray(new[] { 1 }) { Length = InputsNumber };

            foreach (var input in inputs)
            {
                var inputCases = GetInputs(input);

                for (var i = 0; i < inputCases.Count; i++)
                {
                    for (byte faultNumber = 0; faultNumber < 13; faultNumber++)
                    {
                        for (byte faultType = 0; faultType <= 1; faultType++)
                        {
                            var correctFunc = CalculateFunction(inputCases[i]);
                            var realFunc = CalculateFunction(inputCases[i], faultNumber + 1, faultType != 0);

                            if (correctFunc == realFunc)
                            {
                                continue;
                            }

                            cover[faultNumber * 2 + faultType] = true;
                        }
                    }

                    if (IsCovereged() && i < count)
                    {
                        count = i;
                        startCase = input;
                        ResetCover();
                        break;
                    }
                }

                ResetCover();
            }

            var resultInputs = GetInputs(startCase);

            for (byte i = 0; i <= count; i++)
            {
                for (byte faultNumber = 0; faultNumber < 13; faultNumber++)
                {
                    for (byte faultType = 0; faultType <= 1; faultType++)
                    {
                        var correctFunc = CalculateFunction(resultInputs[i]);
                        var realFunc = CalculateFunction(resultInputs[i], faultNumber + 1, faultType != 0);

                        if (correctFunc == realFunc)
                        {
                            continue;
                        }

                        cover[faultNumber * 2 + faultType] = true;

                    }
                }

                var bits = BitArrayToString(resultInputs[i]);

                listBox1.Items.Add(AddCover(bits));
            }

            label4.Text = count.ToString(CultureInfo.InvariantCulture);
        } 

        #endregion


        /// <summary>
        /// Buttons the sa click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonSaClick(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            listBox2.Items.Clear();

            var startLFSR = new BitArray(new[] { 1 }) { Length = InputsNumber };

            var inputLFSR = GetInputs(startLFSR);

            var correctSequence = new BitArray(inputLFSR.Count);
            var realSequence = new BitArray(inputLFSR.Count);

            for (var i = 0; i < inputLFSR.Count; i++)
            {
                correctSequence[i] = CalculateFunction(inputLFSR[i]);
            }

            for (var polinom = 0; polinom < 10; polinom++)
            {
                var notCoveredFaultsNumber = 0;

                for (byte faultNumber = 0; faultNumber < 13; faultNumber++)
                {
                    for (byte faultType = 0; faultType <= 1; faultType++)
                    {
                        for (var i = 0; i < inputLFSR.Count; i++)
                        {
                            realSequence[i] = CalculateFunction(inputLFSR[i], faultNumber + 1, faultType != 0);
                        }

                        if (Analyze(correctSequence, realSequence, polinom))
                        {
                            notCoveredFaultsNumber++;

                            var analyzer = new SignatureAnalyzer();

                            var polinomString = analyzer.GetPolunomString(polinom);

                            listBox2.Items.Add(polinomString + " --- " + 
                                (faultNumber + 1) + " вход" + " --- " +
                                "=" + faultType);
                        }
                    }
                }

                ShowStatictics(notCoveredFaultsNumber, polinom);
            }
        }

        /// <summary>
        /// Shows the statictics.
        /// </summary>
        /// <param name="notCoveredFaults">The not covered faults.</param>
        /// <param name="polinom">The polinom.</param>
        private void ShowStatictics(int notCoveredFaults, int polinom)
        {
            var analyzer = new SignatureAnalyzer();

            var covered = 100 - ((double)(notCoveredFaults * 100) / 26); // 26 - numbers of faults
            
            dataGridView1.Rows.Insert(polinom, 
                analyzer.GetPolunomString(polinom), 
                String.Format("{0:0.00}",covered), 
                analyzer.GetPolunomDifficult(polinom));
        }

        /// <summary>
        /// Analyzes the specified correct sequence.
        /// </summary>
        /// <param name="correctSequence">The correct sequence.</param>
        /// <param name="realSequence">The real sequence.</param>
        /// <param name="polinom">The polinom.</param>
        /// <returns></returns>
        private bool Analyze(BitArray correctSequence, BitArray realSequence, int polinom)
        {
            var analyzer = new SignatureAnalyzer();

            //var correctSequenceString = ToBitString(correctSequence);
            //var realSequenceString = ToBitString(realSequence);

            var correctSignature = analyzer.Compress(correctSequence, polinom);
            //var correctSignatureString = ToBitString(correctSignature);

            var realSignature = analyzer.Compress(realSequence, polinom);
            //var realSignatureString = ToBitString(realSignature);

            return Compare(correctSignature, realSignature);

        }

        #region Test Method

        //        public static string ToBitString(BitArray bits)
        //        {
        //            var sb = new StringBuilder();
        //
        //            for (int i = 0; i < bits.Count; i++)
        //            {
        //                char c = bits[i] ? '1' : '0';
        //                sb.Append(c);
        //            }
        //
        //            return sb.ToString();
        //        } 

        #endregion

        /// <summary>
        /// Compares the specified correct signature.
        /// </summary>
        /// <param name="correctSignature">The correct signature.</param>
        /// <param name="realSiganture">The real siganture.</param>
        /// <returns></returns>
        private bool Compare(BitArray correctSignature, BitArray realSiganture)
        {
            if (correctSignature.Length != realSiganture.Length)
            {
                return false;
            }

            for (var i = 0; i < correctSignature.Length; i++)
            {
                if (correctSignature[i] != realSiganture[i])
                {
                    return false;
                }
            }

            return true;
        }

        #region For lab 4

        /// <summary>
        /// Adds the cover.
        /// </summary>
        /// <param name="inputs">The inputs.</param>
        /// <returns></returns>
        private String AddCover(String inputs)
        {
            var builder = new StringBuilder(inputs);

            builder.Append("   ");

            for (byte i = 0; i < cover.Length; i++)
            {
                builder.Append(cover[i] == false ? "0 " : "1 ");

                if (i % 2 == 1)
                {
                    builder.Append("  ");
                }
            }

            return builder.ToString();
        }

        /// <summary>
        /// Determines whether this instance is covereged.
        /// </summary>
        /// <returns></returns>
        private bool IsCovereged()
        {
            for (byte i = 0; i < cover.Length; i++)
            {
                if (cover[i] == false)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Resets the cover.
        /// </summary>
        private void ResetCover()
        {
            for (byte i = 0; i < cover.Length; i++)
            {
                cover[i] = false;
            }
        }

        /// <summary>
        /// Gets the inputs.
        /// </summary>
        /// <param name="startInput">The start input.</param>
        /// <returns></returns>
        private List<BitArray> GetInputs(BitArray startInput)
        {
            var lfsr = new LfsrUtil();

            lfsr.Generate(startInput);

            var inputs = lfsr.GetAllCombinations;

            return inputs;
        }

        /// <summary>
        /// Calculates the function.
        /// </summary>
        /// <param name="inputs">The inputs.</param>
        /// <param name="faultNumber">The fault number.</param>
        /// <param name="faultType">if set to <c>true</c> [fault type].</param>
        /// <returns></returns>
        private bool CalculateFunction(BitArray inputs, int faultNumber = -1, bool faultType = false)
        {
            var saveInput = false;

            if (faultNumber >= 7 && faultNumber <= 13)
            {
                saveInput = inputs[faultNumber - 7];
                inputs[faultNumber - 7] = faultType;
            }

            var f1 = !(inputs[0] | inputs[1]);
            var f2 = !inputs[2];
            var f3 = !(inputs[4] & inputs[5]);

            bool f4, f5, f6;

            if (faultNumber == 3)
            {
                f4 = !(inputs[3] & faultType & inputs[6]);
            }
            else
            {
                f4 = !(inputs[3] & f3 & inputs[6]);
            }

            if (faultNumber == 2)
            {
                f5 = faultType | f4;
            }
            else if (faultNumber == 4)
            {
                f5 = f2 | faultType;
            }
            else
            {
                f5 = f2 | f4;
            }

            if (faultNumber == 5)
            {
                f6 = f1 & faultType;
            }
            else if (faultNumber == 1)
            {
                f6 = faultType & f5;
            }
            else if (faultNumber == 6)
            {
                f6 = faultType;
            }
            else
            {
                f6 = f1 & f5;
            }

            if (faultNumber >= 7 && faultNumber <= 13)
            {
                inputs[faultNumber - 7] = saveInput;
            }

            return f6;
        }

        /// <summary>
        /// Bits the array automatic string.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns></returns>
        private string BitArrayToString(BitArray array)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < array.Length; i++)
            {
                sb.Append(array[i] ? "1   " : "0   ");
            }

            return sb.ToString();
        }  

        #endregion

        #endregion
    }
}