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

        private void InitializeComboBoxes()
        {
            comboBox1.DataSource = new BindingSource(faultTypes, "");
            comboBox2.DataSource = new BindingSource(faultTypes, "");
            comboBox3.DataSource = new BindingSource(faultTypes, "");
            comboBox4.DataSource = new BindingSource(faultTypes, "");
            comboBox5.DataSource = new BindingSource(faultTypes, "");
            comboBox6.DataSource = new BindingSource(faultTypes, "");
        }

        private void SelectValue1Changed(object sender, EventArgs e)
        {
            
        }
    }
}
