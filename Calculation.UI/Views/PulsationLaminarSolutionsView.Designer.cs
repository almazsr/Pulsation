namespace Calculation.UI.Views
{
    partial class PulsationLaminarSolutionsView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbLayersCount = new System.Windows.Forms.TextBox();
            this.tbtdeg = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbtrad = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.trbnt = new System.Windows.Forms.TrackBar();
            this.occLayers = new OpenGlExtensions.OpenGlChartControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lvSolutions = new System.Windows.Forms.ListView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbnt)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lvSolutions);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.trbnt);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 422);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(845, 200);
            this.panel1.TabIndex = 24;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(175, 91);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 31;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "N";
            // 
            // tbLayersCount
            // 
            this.tbLayersCount.Location = new System.Drawing.Point(150, 13);
            this.tbLayersCount.Name = "tbLayersCount";
            this.tbLayersCount.Size = new System.Drawing.Size(100, 20);
            this.tbLayersCount.TabIndex = 29;
            // 
            // tbtdeg
            // 
            this.tbtdeg.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbtdeg.Location = new System.Drawing.Point(150, 65);
            this.tbtdeg.Name = "tbtdeg";
            this.tbtdeg.ReadOnly = true;
            this.tbtdeg.Size = new System.Drawing.Size(100, 20);
            this.tbtdeg.TabIndex = 28;
            this.tbtdeg.TextChanged += new System.EventHandler(this.tbtdeg_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(107, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "t (deg)";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tbtrad
            // 
            this.tbtrad.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbtrad.Location = new System.Drawing.Point(150, 39);
            this.tbtrad.Name = "tbtrad";
            this.tbtrad.ReadOnly = true;
            this.tbtrad.Size = new System.Drawing.Size(100, 20);
            this.tbtrad.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(116, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "t (rad)";
            // 
            // trbnt
            // 
            this.trbnt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.trbnt.Location = new System.Drawing.Point(0, 155);
            this.trbnt.Name = "trbnt";
            this.trbnt.Size = new System.Drawing.Size(845, 45);
            this.trbnt.TabIndex = 24;
            // 
            // occLayers
            // 
            this.occLayers.AccumBits = ((byte)(0));
            this.occLayers.AutoCheckErrors = false;
            this.occLayers.AutoFinish = false;
            this.occLayers.AutoMakeCurrent = true;
            this.occLayers.AutoSwapBuffers = true;
            this.occLayers.BackColor = System.Drawing.Color.White;
            this.occLayers.ColorBits = ((byte)(32));
            this.occLayers.DepthBits = ((byte)(16));
            this.occLayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.occLayers.Location = new System.Drawing.Point(0, 0);
            this.occLayers.Name = "occLayers";
            this.occLayers.Size = new System.Drawing.Size(845, 422);
            this.occLayers.StencilBits = ((byte)(0));
            this.occLayers.TabIndex = 25;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbLayersCount);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.tbtrad);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.tbtdeg);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(264, 155);
            this.panel2.TabIndex = 33;
            // 
            // lvSolutions
            // 
            this.lvSolutions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSolutions.FullRowSelect = true;
            this.lvSolutions.Location = new System.Drawing.Point(264, 0);
            this.lvSolutions.Name = "lvSolutions";
            this.lvSolutions.Size = new System.Drawing.Size(581, 155);
            this.lvSolutions.TabIndex = 34;
            this.lvSolutions.UseCompatibleStateImageBehavior = false;
            this.lvSolutions.View = System.Windows.Forms.View.List;
            // 
            // PulsationLaminarSolutionsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 622);
            this.Controls.Add(this.occLayers);
            this.Controls.Add(this.panel1);
            this.Name = "PulsationLaminarSolutionsView";
            this.Text = "График";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbnt)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbtdeg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbtrad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar trbnt;
        private OpenGlExtensions.OpenGlChartControl occLayers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbLayersCount;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ListView lvSolutions;
        private System.Windows.Forms.Panel panel2;

    }
}