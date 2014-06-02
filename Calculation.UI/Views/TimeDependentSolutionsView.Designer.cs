namespace Calculation.UI.Views
{
    partial class TimeDependentSolutionsView
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
            this.lvSolutions = new System.Windows.Forms.ListView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbLayersCount = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.trbnt = new System.Windows.Forms.TrackBar();
            this.occLayers = new OpenGlExtensions.OpenGlChartControl();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbnt)).BeginInit();
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
            // panel2
            // 
            this.panel2.Controls.Add(this.tbLayersCount);
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(264, 155);
            this.panel2.TabIndex = 33;
            // 
            // tbLayersCount
            // 
            this.tbLayersCount.Location = new System.Drawing.Point(150, 13);
            this.tbLayersCount.Name = "tbLayersCount";
            this.tbLayersCount.Size = new System.Drawing.Size(100, 20);
            this.tbLayersCount.TabIndex = 29;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(175, 39);
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
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbnt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar trbnt;
        private OpenGlExtensions.OpenGlChartControl occLayers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbLayersCount;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ListView lvSolutions;
        private System.Windows.Forms.Panel panel2;

    }
}