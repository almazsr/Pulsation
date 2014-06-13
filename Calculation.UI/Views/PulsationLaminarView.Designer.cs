namespace Calculation.UI.Views
{
    partial class PulsationLaminarView
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
            this.tbs = new System.Windows.Forms.TextBox();
            this.tbNTime = new System.Windows.Forms.TextBox();
            this.tbNGrid = new System.Windows.Forms.TextBox();
            this.tbRe = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSolve = new System.Windows.Forms.Button();
            this.cbExact = new System.Windows.Forms.CheckBox();
            this.cbImplicit = new System.Windows.Forms.CheckBox();
            this.cbCrankNikolson = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbdAngle = new System.Windows.Forms.TextBox();
            this.cbIsComplexMode = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbbeta = new System.Windows.Forms.TextBox();
            this.cbTurbulent = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbepsilon = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbH3 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbH2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbH1 = new System.Windows.Forms.TextBox();
            this.cbExplicit = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tbs
            // 
            this.tbs.Location = new System.Drawing.Point(46, 23);
            this.tbs.Name = "tbs";
            this.tbs.Size = new System.Drawing.Size(100, 20);
            this.tbs.TabIndex = 0;
            // 
            // tbNTime
            // 
            this.tbNTime.Location = new System.Drawing.Point(201, 49);
            this.tbNTime.Name = "tbNTime";
            this.tbNTime.Size = new System.Drawing.Size(100, 20);
            this.tbNTime.TabIndex = 1;
            // 
            // tbNGrid
            // 
            this.tbNGrid.Location = new System.Drawing.Point(201, 23);
            this.tbNGrid.Name = "tbNGrid";
            this.tbNGrid.Size = new System.Drawing.Size(100, 20);
            this.tbNGrid.TabIndex = 2;
            // 
            // tbRe
            // 
            this.tbRe.Location = new System.Drawing.Point(45, 49);
            this.tbRe.Name = "tbRe";
            this.tbRe.Size = new System.Drawing.Size(100, 20);
            this.tbRe.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "s";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Re";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(160, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "NGrid";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(156, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "NTime";
            // 
            // btnSolve
            // 
            this.btnSolve.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSolve.Location = new System.Drawing.Point(226, 200);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(75, 23);
            this.btnSolve.TabIndex = 8;
            this.btnSolve.Text = "Решить";
            this.btnSolve.UseVisualStyleBackColor = true;
            // 
            // cbExact
            // 
            this.cbExact.AutoSize = true;
            this.cbExact.Location = new System.Drawing.Point(36, 251);
            this.cbExact.Name = "cbExact";
            this.cbExact.Size = new System.Drawing.Size(109, 17);
            this.cbExact.TabIndex = 12;
            this.cbExact.Text = "Точное решение";
            this.cbExact.UseVisualStyleBackColor = true;
            // 
            // cbImplicit
            // 
            this.cbImplicit.AutoSize = true;
            this.cbImplicit.Location = new System.Drawing.Point(35, 295);
            this.cbImplicit.Name = "cbImplicit";
            this.cbImplicit.Size = new System.Drawing.Size(70, 17);
            this.cbImplicit.TabIndex = 13;
            this.cbImplicit.Text = "Неявная";
            this.cbImplicit.UseVisualStyleBackColor = true;
            // 
            // cbCrankNikolson
            // 
            this.cbCrankNikolson.AutoSize = true;
            this.cbCrankNikolson.Location = new System.Drawing.Point(35, 318);
            this.cbCrankNikolson.Name = "cbCrankNikolson";
            this.cbCrankNikolson.Size = new System.Drawing.Size(122, 17);
            this.cbCrankNikolson.TabIndex = 14;
            this.cbCrankNikolson.Text = "Кранка Николсона";
            this.cbCrankNikolson.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(151, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "dt (deg)";
            // 
            // tbdAngle
            // 
            this.tbdAngle.Location = new System.Drawing.Point(201, 75);
            this.tbdAngle.Name = "tbdAngle";
            this.tbdAngle.Size = new System.Drawing.Size(100, 20);
            this.tbdAngle.TabIndex = 15;
            // 
            // cbIsComplexMode
            // 
            this.cbIsComplexMode.AutoSize = true;
            this.cbIsComplexMode.Location = new System.Drawing.Point(45, 132);
            this.cbIsComplexMode.Name = "cbIsComplexMode";
            this.cbIsComplexMode.Size = new System.Drawing.Size(77, 17);
            this.cbIsComplexMode.TabIndex = 17;
            this.cbIsComplexMode.Text = "Комплекс";
            this.cbIsComplexMode.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "beta";
            // 
            // tbbeta
            // 
            this.tbbeta.Location = new System.Drawing.Point(45, 75);
            this.tbbeta.Name = "tbbeta";
            this.tbbeta.Size = new System.Drawing.Size(100, 20);
            this.tbbeta.TabIndex = 18;
            // 
            // cbTurbulent
            // 
            this.cbTurbulent.AutoSize = true;
            this.cbTurbulent.Location = new System.Drawing.Point(35, 343);
            this.cbTurbulent.Name = "cbTurbulent";
            this.cbTurbulent.Size = new System.Drawing.Size(177, 17);
            this.cbTurbulent.TabIndex = 20;
            this.cbTurbulent.Text = "Турбулентный неявная схема";
            this.cbTurbulent.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "epsilon";
            // 
            // tbepsilon
            // 
            this.tbepsilon.Location = new System.Drawing.Point(46, 101);
            this.tbepsilon.Name = "tbepsilon";
            this.tbepsilon.Size = new System.Drawing.Size(100, 20);
            this.tbepsilon.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 210);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "H3";
            // 
            // tbH3
            // 
            this.tbH3.Location = new System.Drawing.Point(47, 207);
            this.tbH3.Name = "tbH3";
            this.tbH3.Size = new System.Drawing.Size(100, 20);
            this.tbH3.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 184);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "H2";
            // 
            // tbH2
            // 
            this.tbH2.Location = new System.Drawing.Point(46, 181);
            this.tbH2.Name = "tbH2";
            this.tbH2.Size = new System.Drawing.Size(100, 20);
            this.tbH2.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 158);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "H1";
            // 
            // tbH1
            // 
            this.tbH1.Location = new System.Drawing.Point(46, 155);
            this.tbH1.Name = "tbH1";
            this.tbH1.Size = new System.Drawing.Size(100, 20);
            this.tbH1.TabIndex = 23;
            // 
            // cbExplicit
            // 
            this.cbExplicit.AutoSize = true;
            this.cbExplicit.Location = new System.Drawing.Point(35, 272);
            this.cbExplicit.Name = "cbExplicit";
            this.cbExplicit.Size = new System.Drawing.Size(58, 17);
            this.cbExplicit.TabIndex = 29;
            this.cbExplicit.Text = "Явная";
            this.cbExplicit.UseVisualStyleBackColor = true;
            // 
            // PulsationLaminarView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 403);
            this.Controls.Add(this.cbExplicit);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbH3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbH2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbH1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbepsilon);
            this.Controls.Add(this.cbTurbulent);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbbeta);
            this.Controls.Add(this.cbIsComplexMode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbdAngle);
            this.Controls.Add(this.cbCrankNikolson);
            this.Controls.Add(this.cbImplicit);
            this.Controls.Add(this.cbExact);
            this.Controls.Add(this.btnSolve);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbRe);
            this.Controls.Add(this.tbNGrid);
            this.Controls.Add(this.tbNTime);
            this.Controls.Add(this.tbs);
            this.Name = "PulsationLaminarView";
            this.Text = "Пульсация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbs;
        private System.Windows.Forms.TextBox tbNTime;
        private System.Windows.Forms.TextBox tbNGrid;
        private System.Windows.Forms.TextBox tbRe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.CheckBox cbExact;
        private System.Windows.Forms.CheckBox cbImplicit;
        private System.Windows.Forms.CheckBox cbCrankNikolson;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbdAngle;
        private System.Windows.Forms.CheckBox cbIsComplexMode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbbeta;
        private System.Windows.Forms.CheckBox cbTurbulent;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbepsilon;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbH3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbH2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbH1;
        private System.Windows.Forms.CheckBox cbExplicit;
    }
}