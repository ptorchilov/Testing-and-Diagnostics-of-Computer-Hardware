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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplicationForm));
            this.groupBoxScheme = new System.Windows.Forms.GroupBox();
            this.buttonTest = new System.Windows.Forms.Button();
            this.groupBoxTests = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxTests.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxScheme
            // 
            this.groupBoxScheme.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBoxScheme.BackgroundImage")));
            this.groupBoxScheme.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBoxScheme.Location = new System.Drawing.Point(495, 13);
            this.groupBoxScheme.Name = "groupBoxScheme";
            this.groupBoxScheme.Size = new System.Drawing.Size(546, 384);
            this.groupBoxScheme.TabIndex = 0;
            this.groupBoxScheme.TabStop = false;
            this.groupBoxScheme.Text = "Scheme";
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(932, 427);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(89, 31);
            this.buttonTest.TabIndex = 6;
            this.buttonTest.Text = "Start";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.ButtonTestClick);
            // 
            // groupBoxTests
            // 
            this.groupBoxTests.Controls.Add(this.listBox1);
            this.groupBoxTests.Controls.Add(this.label1);
            this.groupBoxTests.Location = new System.Drawing.Point(12, 13);
            this.groupBoxTests.Name = "groupBoxTests";
            this.groupBoxTests.Size = new System.Drawing.Size(474, 477);
            this.groupBoxTests.TabIndex = 1;
            this.groupBoxTests.TabStop = false;
            this.groupBoxTests.Text = "Tests";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(14, 33);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(454, 433);
            this.listBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "X1 X2 X3 X4 X5 X6 X7        Cover";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(492, 412);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Полином: F(x) = x7+x5+x3+x+1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(492, 445);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Количество тактов LFSR: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(631, 445);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 9;
            // 
            // ApplicationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1043, 502);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonTest);
            this.Controls.Add(this.groupBoxTests);
            this.Controls.Add(this.groupBoxScheme);
            this.Name = "ApplicationForm";
            this.Text = "Лабораторная работа №4. Вариант 1.";
            this.groupBoxTests.ResumeLayout(false);
            this.groupBoxTests.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxScheme;
        private System.Windows.Forms.GroupBox groupBoxTests;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;


    }
}

