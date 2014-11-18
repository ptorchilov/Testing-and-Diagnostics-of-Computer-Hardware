using System;
using System.Windows.Forms;

namespace Lab06
{
    using System.Text;

    public partial class ApplicationForm : Form
    {
        public ApplicationForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
//            var matrix = new Matrix(8, 8);
//            var firstRow = new [] {0, 1, 0, 0, 1, 0, 0, 1};
//
//            matrix = Matrix.SetFirstRow(firstRow, matrix);
//
//            Matrix.ShowMatrix(matrix);
//
//            matrix = Matrix.SetRunningOne(matrix);
//
//            Matrix.ShowMatrix(matrix);
//
//            matrix = Matrix.XorMutliplication(matrix, matrix);
//
//            Matrix.ShowMatrix(matrix);

            var sequence = Utilities.GenarateRandomSequence(10);

            var combinator = new Combinator(sequence);

            var combinations = combinator.GetCombinations(0, 2);

            var i = 0;

        }
    }
}
