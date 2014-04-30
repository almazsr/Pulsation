namespace Schemes.UI
{
    partial class MainForm
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
            this.openGlChartControl1 = new OpenGlExtensions.OpenGlChartControl();
            this.SuspendLayout();
            // 
            // openGlChartControl1
            // 
            this.openGlChartControl1.AccumBits = ((byte)(0));
            this.openGlChartControl1.AutoCheckErrors = false;
            this.openGlChartControl1.AutoFinish = false;
            this.openGlChartControl1.AutoMakeCurrent = true;
            this.openGlChartControl1.AutoSwapBuffers = true;
            this.openGlChartControl1.ColorBits = ((byte)(32));
            this.openGlChartControl1.DepthBits = ((byte)(16));
            this.openGlChartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openGlChartControl1.Location = new System.Drawing.Point(0, 0);
            this.openGlChartControl1.Name = "openGlChartControl1";
            this.openGlChartControl1.Size = new System.Drawing.Size(685, 534);
            this.openGlChartControl1.StencilBits = ((byte)(0));
            this.openGlChartControl1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 534);
            this.Controls.Add(this.openGlChartControl1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private OpenGlExtensions.OpenGlChartControl openGlChartControl1;
    }
}

