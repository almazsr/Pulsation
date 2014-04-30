namespace Pulsation.WinForms.Views
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
            this.components = new System.ComponentModel.Container();
            this.btnSolve = new System.Windows.Forms.Button();
            this.tbs = new System.Windows.Forms.TextBox();
            this.tbRe = new System.Windows.Forms.TextBox();
            this.tbdAngle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNGrid = new System.Windows.Forms.TextBox();
            this.trbLayer = new System.Windows.Forms.TrackBar();
            this.occChart = new OpenGlExtensions.OpenGlChartControl();
            this.point2DBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbAngle = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbdt = new System.Windows.Forms.TextBox();
            this.cbImplicitScheme = new System.Windows.Forms.CheckBox();
            this.cbExactSolution = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.trbLayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.point2DBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(384, 477);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(75, 23);
            this.btnSolve.TabIndex = 1;
            this.btnSolve.Text = "Решить";
            this.btnSolve.UseVisualStyleBackColor = true;
            // 
            // tbs
            // 
            this.tbs.Location = new System.Drawing.Point(51, 424);
            this.tbs.Name = "tbs";
            this.tbs.Size = new System.Drawing.Size(100, 20);
            this.tbs.TabIndex = 2;
            // 
            // tbRe
            // 
            this.tbRe.Location = new System.Drawing.Point(196, 424);
            this.tbRe.Name = "tbRe";
            this.tbRe.Size = new System.Drawing.Size(100, 20);
            this.tbRe.TabIndex = 6;
            // 
            // tbdAngle
            // 
            this.tbdAngle.Location = new System.Drawing.Point(196, 450);
            this.tbdAngle.Name = "tbdAngle";
            this.tbdAngle.Size = new System.Drawing.Size(100, 20);
            this.tbdAngle.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(152, 453);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "dAngle";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 454);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "NGrid";
            // 
            // tbNGrid
            // 
            this.tbNGrid.Location = new System.Drawing.Point(51, 451);
            this.tbNGrid.Name = "tbNGrid";
            this.tbNGrid.Size = new System.Drawing.Size(100, 20);
            this.tbNGrid.TabIndex = 10;
            // 
            // trbLayer
            // 
            this.trbLayer.Location = new System.Drawing.Point(27, 506);
            this.trbLayer.Name = "trbLayer";
            this.trbLayer.Size = new System.Drawing.Size(432, 45);
            this.trbLayer.TabIndex = 11;
            // 
            // occChart
            // 
            this.occChart.AccumBits = ((byte)(0));
            this.occChart.AutoCheckErrors = false;
            this.occChart.AutoFinish = false;
            this.occChart.AutoMakeCurrent = true;
            this.occChart.AutoSwapBuffers = true;
            this.occChart.BackColor = System.Drawing.Color.White;
            this.occChart.ColorBits = ((byte)(32));
            this.occChart.DepthBits = ((byte)(16));
            this.occChart.Dock = System.Windows.Forms.DockStyle.Top;
            this.occChart.Location = new System.Drawing.Point(0, 0);
            this.occChart.Name = "occChart";
            this.occChart.Size = new System.Drawing.Size(473, 418);
            this.occChart.StencilBits = ((byte)(0));
            this.occChart.TabIndex = 0;
            // 
            // point2DBindingSource
            // 
            this.point2DBindingSource.DataSource = typeof(OpenGlExtensions.Classes.Point2D);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 427);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "s";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(169, 427);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Re";
            // 
            // tbAngle
            // 
            this.tbAngle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbAngle.Location = new System.Drawing.Point(51, 480);
            this.tbAngle.Name = "tbAngle";
            this.tbAngle.ReadOnly = true;
            this.tbAngle.Size = new System.Drawing.Size(100, 20);
            this.tbAngle.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 483);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Angle";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(315, 430);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "dt";
            // 
            // tbdt
            // 
            this.tbdt.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbdt.Location = new System.Drawing.Point(337, 427);
            this.tbdt.Name = "tbdt";
            this.tbdt.ReadOnly = true;
            this.tbdt.Size = new System.Drawing.Size(100, 20);
            this.tbdt.TabIndex = 20;
            // 
            // cbImplicitScheme
            // 
            this.cbImplicitScheme.AutoSize = true;
            this.cbImplicitScheme.Location = new System.Drawing.Point(190, 479);
            this.cbImplicitScheme.Name = "cbImplicitScheme";
            this.cbImplicitScheme.Size = new System.Drawing.Size(104, 17);
            this.cbImplicitScheme.TabIndex = 22;
            this.cbImplicitScheme.Text = "Неявная схема";
            this.cbImplicitScheme.UseVisualStyleBackColor = true;
            // 
            // cbExactSolution
            // 
            this.cbExactSolution.AutoSize = true;
            this.cbExactSolution.Location = new System.Drawing.Point(300, 481);
            this.cbExactSolution.Name = "cbExactSolution";
            this.cbExactSolution.Size = new System.Drawing.Size(62, 17);
            this.cbExactSolution.TabIndex = 23;
            this.cbExactSolution.Text = "Точное";
            this.cbExactSolution.UseVisualStyleBackColor = true;
            // 
            // PulsationLaminarView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 567);
            this.Controls.Add(this.cbExactSolution);
            this.Controls.Add(this.cbImplicitScheme);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbdt);
            this.Controls.Add(this.tbAngle);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.trbLayer);
            this.Controls.Add(this.tbNGrid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbdAngle);
            this.Controls.Add(this.tbRe);
            this.Controls.Add(this.tbs);
            this.Controls.Add(this.btnSolve);
            this.Controls.Add(this.occChart);
            this.Name = "PulsationLaminarView";
            this.Text = "Пульсация";
            ((System.ComponentModel.ISupportInitialize)(this.trbLayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.point2DBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenGlExtensions.OpenGlChartControl occChart;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.TextBox tbs;
        private System.Windows.Forms.TextBox tbRe;
        private System.Windows.Forms.TextBox tbdAngle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource point2DBindingSource;
        private System.Windows.Forms.TextBox tbNGrid;
        private System.Windows.Forms.TrackBar trbLayer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbAngle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbdt;
        private System.Windows.Forms.CheckBox cbImplicitScheme;
        private System.Windows.Forms.CheckBox cbExactSolution;
    }
}

