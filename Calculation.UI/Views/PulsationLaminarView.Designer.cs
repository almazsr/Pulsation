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
            this.btnShow = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // tbs
            // 
            this.tbs.Location = new System.Drawing.Point(78, 11);
            this.tbs.Name = "tbs";
            this.tbs.Size = new System.Drawing.Size(100, 20);
            this.tbs.TabIndex = 0;
            // 
            // tbNTime
            // 
            this.tbNTime.Location = new System.Drawing.Point(78, 89);
            this.tbNTime.Name = "tbNTime";
            this.tbNTime.Size = new System.Drawing.Size(100, 20);
            this.tbNTime.TabIndex = 1;
            // 
            // tbNGrid
            // 
            this.tbNGrid.Location = new System.Drawing.Point(78, 63);
            this.tbNGrid.Name = "tbNGrid";
            this.tbNGrid.Size = new System.Drawing.Size(100, 20);
            this.tbNGrid.TabIndex = 2;
            // 
            // tbRe
            // 
            this.tbRe.Location = new System.Drawing.Point(77, 37);
            this.tbRe.Name = "tbRe";
            this.tbRe.Size = new System.Drawing.Size(100, 20);
            this.tbRe.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "s";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Re";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "NGrid";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "NTime";
            // 
            // btnSolve
            // 
            this.btnSolve.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSolve.Location = new System.Drawing.Point(146, 116);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(75, 23);
            this.btnSolve.TabIndex = 8;
            this.btnSolve.Text = "Решить";
            this.btnSolve.UseVisualStyleBackColor = true;
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(146, 174);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 9;
            this.btnShow.Text = "Показать";
            this.btnShow.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 145);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(209, 23);
            this.progressBar1.TabIndex = 11;
            // 
            // PulsationLaminarView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 209);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnShow);
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
            this.Text = "PulsationLaminarView";
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
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}