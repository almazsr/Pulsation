namespace Calculation.UI.Views
{
    partial class SolutionsView
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
            this.occLayers = new OpenGlExtensions.OpenGlChartControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lvSolutions = new System.Windows.Forms.ListView();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.occLayers.Size = new System.Drawing.Size(768, 415);
            this.occLayers.StencilBits = ((byte)(0));
            this.occLayers.TabIndex = 27;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lvSolutions);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 415);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(768, 183);
            this.panel1.TabIndex = 26;
            // 
            // lvSolutions
            // 
            this.lvSolutions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSolutions.FullRowSelect = true;
            this.lvSolutions.Location = new System.Drawing.Point(0, 0);
            this.lvSolutions.Name = "lvSolutions";
            this.lvSolutions.Size = new System.Drawing.Size(768, 183);
            this.lvSolutions.TabIndex = 35;
            this.lvSolutions.UseCompatibleStateImageBehavior = false;
            this.lvSolutions.View = System.Windows.Forms.View.List;
            // 
            // SolutionsComparisonView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 598);
            this.Controls.Add(this.occLayers);
            this.Controls.Add(this.panel1);
            this.Name = "SolutionsComparisonView";
            this.Text = "SolutionComparisonView";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OpenGlExtensions.OpenGlChartControl occLayers;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lvSolutions;
    }
}