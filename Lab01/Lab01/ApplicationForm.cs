namespace Lab01
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Main class for start window.
    /// </summary>
    public partial class ApplicationForm : Form
    {

        private readonly String[] faultTypes = {"", "=0", "=1"};

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
    }
}
