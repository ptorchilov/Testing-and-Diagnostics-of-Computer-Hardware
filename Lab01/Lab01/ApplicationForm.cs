namespace Lab01
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Main class for start window.
    /// </summary>
    public partial class ApplicationForm : Form
    {

        #region Constants

        private readonly String[] faultTypes = { "", "=0", "=1" };

        private readonly int combinationsCount = (int) Math.Pow(2, 7); 

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
            var daultType = GetFaultType(faultNumber);

            listView1.Items.Clear();
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
                        return comboBox1.SelectedItem.ToString() != "=0";
                    }
                case 3:
                    {
                        return comboBox1.SelectedItem.ToString() != "=0";
                    }
                case 4:
                    {
                        return comboBox1.SelectedItem.ToString() != "=0";
                    }
                case 5:
                    {
                        return comboBox1.SelectedItem.ToString() != "=0";
                    }
                case 6:
                    {
                        return comboBox1.SelectedItem.ToString() != "=0";
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
