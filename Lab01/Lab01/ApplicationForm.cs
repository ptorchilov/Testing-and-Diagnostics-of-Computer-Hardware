namespace Lab01
{
    using System;
    using System.Collections;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// Main class for start window.
    /// </summary>
    public partial class ApplicationForm : Form
    {
        #region Constants

        private readonly String[] faultTypes = { "", "=0", "=1" };

        private readonly int combinationsCount = (int)Math.Pow(2, 7);

        private const int InputsNumber = 7;

        #endregion

        public ApplicationForm()
        {
            InitializeComponent();
            InitializeComboBoxes();
        }

        #region ComboBoxes

        /// <summary>
        /// Initializes the combo boxes.
        /// </summary>
        private void InitializeComboBoxes()
        {
            comboBox1.DataSource = new BindingSource(faultTypes, "");
            comboBox2.DataSource = new BindingSource(faultTypes, "");
            comboBox3.DataSource = new BindingSource(faultTypes, "");
            comboBox4.DataSource = new BindingSource(faultTypes, "");
            comboBox5.DataSource = new BindingSource(faultTypes, "");
            comboBox6.DataSource = new BindingSource(faultTypes, "");
        }

        /// <summary>
        /// Reset other faults.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SelectValue1Changed(object sender, EventArgs e)
        {
            comboBox2.SelectedItem = faultTypes[0];
            comboBox3.SelectedItem = faultTypes[0];
            comboBox4.SelectedItem = faultTypes[0];
            comboBox5.SelectedItem = faultTypes[0];
            comboBox6.SelectedItem = faultTypes[0];
        }

        /// <summary>
        /// Reset other faults.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Selected2ValueChanged(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = faultTypes[0];
            comboBox3.SelectedItem = faultTypes[0];
            comboBox4.SelectedItem = faultTypes[0];
            comboBox5.SelectedItem = faultTypes[0];
            comboBox6.SelectedItem = faultTypes[0];
        }

        /// <summary>
        /// Reset other faults.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Selected3ValueChanged(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = faultTypes[0];
            comboBox2.SelectedItem = faultTypes[0];
            comboBox4.SelectedItem = faultTypes[0];
            comboBox5.SelectedItem = faultTypes[0];
            comboBox6.SelectedItem = faultTypes[0];
        }

        /// <summary>
        /// Reset other faults.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Selected4ValueChanged(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = faultTypes[0];
            comboBox2.SelectedItem = faultTypes[0];
            comboBox3.SelectedItem = faultTypes[0];
            comboBox5.SelectedItem = faultTypes[0];
            comboBox6.SelectedItem = faultTypes[0];
        }

        /// <summary>
        /// Reset other faults.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Selected5ValueChanged(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = faultTypes[0];
            comboBox2.SelectedItem = faultTypes[0];
            comboBox3.SelectedItem = faultTypes[0];
            comboBox4.SelectedItem = faultTypes[0];
            comboBox6.SelectedItem = faultTypes[0];
        }

        /// <summary>
        /// Reset other faults.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Selected6ValueChanged(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = faultTypes[0];
            comboBox2.SelectedItem = faultTypes[0];
            comboBox3.SelectedItem = faultTypes[0];
            comboBox4.SelectedItem = faultTypes[0];
            comboBox5.SelectedItem = faultTypes[0];
        }

        #endregion

        private void ButtonTestClick(object sender, EventArgs e)
        {
            var faultNumber = GetFaultNumber();
            var faultType = GetFaultType(faultNumber);

            listBox1.Items.Clear();

            for (var i = 0; i < combinationsCount; i++)
            {
                var inputs = new BitArray(new[] { i }) { Length = InputsNumber };

                var correctFunc = CalculateFunction(inputs);
                var realFunc = this.CalculateFunction(inputs, faultNumber, faultType);

                if (correctFunc == realFunc)
                {
                    continue;
                }

                var bits = BitArrayToString(inputs);

                listBox1.Items.Add(bits);
            }
        }

        private bool CalculateFunction(BitArray inputs, int faultNumber = -1, bool faultType = false)
        {
            var f1 = inputs[0] ^ inputs[1];
            var f2 = !inputs[2];
            var f3 = !(inputs[4] & inputs[5]);

            bool f4, f5, f6;

            if (faultNumber == 3)
            {
                f4 = inputs[3] & faultType & inputs[6];
            }
            else
            {
                f4 = inputs[3] & f3 & inputs[6];
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

            return f6;
        }

        private string BitArrayToString(BitArray array)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < array.Length; i++)
            {
                sb.Append(array[i] ? "1   " : "0   ");
            }

            return sb.ToString();
        }

        #region Faults Mangement

        /// <summary>
        /// Gets the type of the fault.
        /// </summary>
        /// <param name="faultNumber">The fault number.</param>
        /// <returns></returns>
        private bool GetFaultType(int faultNumber)
        {
            switch (faultNumber)
            {
                case 1:
                    {
                        return comboBox1.SelectedItem.ToString() != "=0";
                    }
                case 2:
                    {
                        return comboBox2.SelectedItem.ToString() != "=0";
                    }
                case 3:
                    {
                        return comboBox3.SelectedItem.ToString() != "=0";
                    }
                case 4:
                    {
                        return comboBox4.SelectedItem.ToString() != "=0";
                    }
                case 5:
                    {
                        return comboBox5.SelectedItem.ToString() != "=0";
                    }
                case 6:
                    {
                        return comboBox6.SelectedItem.ToString() != "=0";
                    }
                default:
                    {
                        return false;
                    }
            }
        }

        /// <summary>
        /// Gets the fault number.
        /// </summary>
        /// <returns></returns>
        private int GetFaultNumber()
        {
            var result = 0;

            if (comboBox1.SelectedItem.ToString() != "")
            {
                result = 1;
            }
            else if (comboBox2.SelectedItem.ToString() != "")
            {
                result = 2;
            }
            else if (comboBox3.SelectedItem.ToString() != "")
            {
                result = 3;
            }
            else if (comboBox4.SelectedItem.ToString() != "")
            {
                result = 4;
            }
            else if (comboBox5.SelectedItem.ToString() != "")
            {
                result = 5;
            }
            else if (comboBox6.SelectedItem.ToString() != "")
            {
                result = 6;
            }

            return result;
        }

        #endregion
    }
}