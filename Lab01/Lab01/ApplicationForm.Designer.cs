namespace Lab01
{
    partial class ApplicationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxScheme = new System.Windows.Forms.GroupBox();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBoxTests = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.buttonTest = new System.Windows.Forms.Button();
            this.groupBoxScheme.SuspendLayout();
            this.groupBoxTests.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxScheme
            // 
            this.groupBoxScheme.BackgroundImage = global::Lab01.Properties.Resources.Variant_21;
            this.groupBoxScheme.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBoxScheme.Controls.Add(this.buttonTest);
            this.groupBoxScheme.Controls.Add(this.comboBox6);
            this.groupBoxScheme.Controls.Add(this.comboBox5);
            this.groupBoxScheme.Controls.Add(this.comboBox4);
            this.groupBoxScheme.Controls.Add(this.comboBox3);
            this.groupBoxScheme.Controls.Add(this.comboBox2);
            this.groupBoxScheme.Controls.Add(this.comboBox1);
            this.groupBoxScheme.Location = new System.Drawing.Point(334, 12);
            this.groupBoxScheme.Name = "groupBoxScheme";
            this.groupBoxScheme.Size = new System.Drawing.Size(663, 478);
            this.groupBoxScheme.TabIndex = 0;
            this.groupBoxScheme.TabStop = false;
            this.groupBoxScheme.Text = "Scheme";
            // 
            // comboBox6
            // 
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Location = new System.Drawing.Point(613, 103);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(44, 21);
            this.comboBox6.TabIndex = 5;
            this.comboBox6.SelectionChangeCommitted += new System.EventHandler(this.Selected6ValueChanged);
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(472, 236);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(43, 21);
            this.comboBox5.TabIndex = 4;
            this.comboBox5.SelectionChangeCommitted += new System.EventHandler(this.Selected5ValueChanged);
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(330, 339);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(41, 21);
            this.comboBox4.TabIndex = 3;
            this.comboBox4.SelectionChangeCommitted += new System.EventHandler(this.Selected4ValueChanged);
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(174, 397);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(40, 21);
            this.comboBox3.TabIndex = 2;
            this.comboBox3.SelectionChangeCommitted += new System.EventHandler(this.Selected3ValueChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(180, 210);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(40, 21);
            this.comboBox2.TabIndex = 1;
            this.comboBox2.SelectionChangeCommitted += new System.EventHandler(this.Selected2ValueChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(180, 89);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(40, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.SelectValue1Changed);
            // 
            // groupBoxTests
            // 
            this.groupBoxTests.Controls.Add(this.label1);
            this.groupBoxTests.Controls.Add(this.listView1);
            this.groupBoxTests.Location = new System.Drawing.Point(13, 13);
            this.groupBoxTests.Name = "groupBoxTests";
            this.groupBoxTests.Size = new System.Drawing.Size(315, 477);
            this.groupBoxTests.TabIndex = 1;
            this.groupBoxTests.TabStop = false;
            this.groupBoxTests.Text = "Tests";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "X1 X2 X3 X4 X5 X6 X7";
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(7, 31);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(302, 440);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(556, 427);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(89, 31);
            this.buttonTest.TabIndex = 6;
            this.buttonTest.Text = "Test";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.ButtonTestClick);
            // 
            // ApplicationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1009, 502);
            this.Controls.Add(this.groupBoxTests);
            this.Controls.Add(this.groupBoxScheme);
            this.Name = "ApplicationForm";
            this.Text = "Лабораторная работа №1. Вариант 21.";
            this.groupBoxScheme.ResumeLayout(false);
            this.groupBoxTests.ResumeLayout(false);
            this.groupBoxTests.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxScheme;
        private System.Windows.Forms.GroupBox groupBoxTests;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button buttonTest;


    }
}

