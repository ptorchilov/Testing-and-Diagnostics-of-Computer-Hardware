using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab06
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var matrix = new Matrix(8, 8);
            var firstRow = new int[8] {0, 1, 0, 0, 1, 0, 0, 1};

            matrix = Matrix.SetFirstRow(firstRow, matrix);

            Matrix.ShowMatrix(matrix);

            matrix = Matrix.SetRunningOne(matrix);

            Matrix.ShowMatrix(matrix);

            matrix = Matrix.XorMutliplication(matrix, matrix);

            Matrix.ShowMatrix(matrix);
        }


    }
}
