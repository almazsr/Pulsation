namespace Calculation.UI.Views
{
    partial class SolutionListView
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
            VIBlend.WinForms.DataGridView.DataGridLocalization dataGridLocalization2 = new VIBlend.WinForms.DataGridView.DataGridLocalization();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnAlpha = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCompare = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.vDataGridViewGroupsHeader1 = new VIBlend.WinForms.DataGridView.vDataGridViewGroupsHeader();
            this.dgvSolutions = new VIBlend.WinForms.DataGridView.vDataGridView();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 512);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(750, 69);
            this.panel2.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnAlpha);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnCreate);
            this.panel1.Controls.Add(this.btnCompare);
            this.panel1.Controls.Add(this.btnShow);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(97, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(653, 69);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(404, 19);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 10;
            this.btnExport.Text = "Экспорт";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // btnAlpha
            // 
            this.btnAlpha.Location = new System.Drawing.Point(485, 19);
            this.btnAlpha.Name = "btnAlpha";
            this.btnAlpha.Size = new System.Drawing.Size(75, 23);
            this.btnAlpha.TabIndex = 9;
            this.btnAlpha.Text = "alpha";
            this.btnAlpha.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(99, 19);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(18, 19);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(566, 19);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 6;
            this.btnCreate.Text = "Создать";
            this.btnCreate.UseVisualStyleBackColor = true;
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(182, 19);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(75, 23);
            this.btnCompare.TabIndex = 5;
            this.btnCompare.Text = "Сравнить";
            this.btnCompare.UseVisualStyleBackColor = true;
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(263, 19);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 4;
            this.btnShow.Text = "Показать";
            this.btnShow.UseVisualStyleBackColor = true;
            // 
            // vDataGridViewGroupsHeader1
            // 
            this.vDataGridViewGroupsHeader1.AllowDragDrop = true;
            this.vDataGridViewGroupsHeader1.BackColor = System.Drawing.Color.White;
            this.vDataGridViewGroupsHeader1.ConnectingLinesColor = System.Drawing.Color.DarkGray;
            this.vDataGridViewGroupsHeader1.DataGridView = this.dgvSolutions;
            this.vDataGridViewGroupsHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.vDataGridViewGroupsHeader1.HeaderItemsAlignment = VIBlend.WinForms.DataGridView.HeaderGroupsAlignment.Near;
            this.vDataGridViewGroupsHeader1.IsThemeSynchronized = true;
            this.vDataGridViewGroupsHeader1.Location = new System.Drawing.Point(0, 0);
            this.vDataGridViewGroupsHeader1.Name = "vDataGridViewGroupsHeader1";
            this.vDataGridViewGroupsHeader1.PromptText = "";
            this.vDataGridViewGroupsHeader1.PromptTextColor = System.Drawing.Color.DarkGray;
            this.vDataGridViewGroupsHeader1.Size = new System.Drawing.Size(750, 28);
            this.vDataGridViewGroupsHeader1.TabIndex = 5;
            this.vDataGridViewGroupsHeader1.Text = "vDataGridViewGroupsHeader1";
            this.vDataGridViewGroupsHeader1.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
            // 
            // dgvSolutions
            // 
            this.dgvSolutions.AllowAnimations = true;
            this.dgvSolutions.AllowCellMerge = true;
            this.dgvSolutions.AllowClipDrawing = true;
            this.dgvSolutions.AllowContextMenuColumnChooser = true;
            this.dgvSolutions.AllowContextMenuFiltering = true;
            this.dgvSolutions.AllowContextMenuGrouping = true;
            this.dgvSolutions.AllowContextMenuSorting = true;
            this.dgvSolutions.AllowCopyPaste = false;
            this.dgvSolutions.AllowDefaultContextMenu = true;
            this.dgvSolutions.AllowDragDropIndication = true;
            this.dgvSolutions.AllowDrop = true;
            this.dgvSolutions.AllowHeaderItemHighlightOnCellSelection = true;
            this.dgvSolutions.AutoUpdateOnListChanged = false;
            this.dgvSolutions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.dgvSolutions.BindingProgressEnabled = false;
            this.dgvSolutions.BindingProgressSampleRate = 20000;
            this.dgvSolutions.BorderColor = System.Drawing.Color.Empty;
            this.dgvSolutions.CellsArea.AllowCellMerge = true;
            this.dgvSolutions.CellsArea.ConditionalFormattingEnabled = false;
            this.dgvSolutions.ColumnsHierarchy.AllowDragDrop = false;
            this.dgvSolutions.ColumnsHierarchy.AllowResize = true;
            this.dgvSolutions.ColumnsHierarchy.AutoStretchColumns = false;
            this.dgvSolutions.ColumnsHierarchy.Fixed = false;
            this.dgvSolutions.ColumnsHierarchy.ShowExpandCollapseButtons = true;
            this.dgvSolutions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSolutions.EnableColumnChooser = false;
            this.dgvSolutions.EnableResizeToolTip = true;
            this.dgvSolutions.EnableToolTips = true;
            this.dgvSolutions.FilterDisplayMode = VIBlend.WinForms.DataGridView.FilterDisplayMode.Default;
            this.dgvSolutions.GridLinesDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.dgvSolutions.GridLinesDisplayMode = VIBlend.WinForms.DataGridView.GridLinesDisplayMode.DISPLAY_ALL;
            this.dgvSolutions.GroupingEnabled = true;
            this.dgvSolutions.HorizontalScroll = 0;
            this.dgvSolutions.HorizontalScrollBarLargeChange = 20;
            this.dgvSolutions.HorizontalScrollBarSmallChange = 5;
            this.dgvSolutions.ImageList = null;
            this.dgvSolutions.Localization = dataGridLocalization2;
            this.dgvSolutions.Location = new System.Drawing.Point(0, 28);
            this.dgvSolutions.MultipleSelectionEnabled = true;
            this.dgvSolutions.Name = "dgvSolutions";
            this.dgvSolutions.PivotColumnsTotalsEnabled = false;
            this.dgvSolutions.PivotColumnsTotalsMode = VIBlend.WinForms.DataGridView.PivotTotalsMode.DISPLAY_BOTH;
            this.dgvSolutions.PivotRowsTotalsEnabled = false;
            this.dgvSolutions.PivotRowsTotalsMode = VIBlend.WinForms.DataGridView.PivotTotalsMode.DISPLAY_BOTH;
            this.dgvSolutions.RowsHierarchy.AllowDragDrop = false;
            this.dgvSolutions.RowsHierarchy.AllowResize = true;
            this.dgvSolutions.RowsHierarchy.CompactStyleRenderingEnabled = false;
            this.dgvSolutions.RowsHierarchy.CompactStyleRenderingItemsIndent = 15;
            this.dgvSolutions.RowsHierarchy.Fixed = false;
            this.dgvSolutions.RowsHierarchy.ShowExpandCollapseButtons = true;
            this.dgvSolutions.ScrollBarsEnabled = true;
            this.dgvSolutions.SelectionBorderDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.dgvSolutions.SelectionBorderEnabled = true;
            this.dgvSolutions.SelectionBorderWidth = 2;
            this.dgvSolutions.SelectionMode = VIBlend.WinForms.DataGridView.vDataGridView.SELECTION_MODE.FULL_ROW_SELECT;
            this.dgvSolutions.Size = new System.Drawing.Size(750, 484);
            this.dgvSolutions.TabIndex = 6;
            this.dgvSolutions.Text = "vDataGridView1";
            this.dgvSolutions.ToolTipDuration = 5000;
            this.dgvSolutions.ToolTipShowDelay = 1500;
            this.dgvSolutions.VerticalScroll = 0;
            this.dgvSolutions.VerticalScrollBarLargeChange = 20;
            this.dgvSolutions.VerticalScrollBarSmallChange = 5;
            this.dgvSolutions.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
            this.dgvSolutions.VirtualModeCellDefault = false;
            // 
            // SolutionListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 581);
            this.Controls.Add(this.dgvSolutions);
            this.Controls.Add(this.vDataGridViewGroupsHeader1);
            this.Controls.Add(this.panel2);
            this.Name = "SolutionListView";
            this.Text = "Решения";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnAlpha;
        private System.Windows.Forms.Button btnExport;
        private VIBlend.WinForms.DataGridView.vDataGridViewGroupsHeader vDataGridViewGroupsHeader1;
        private VIBlend.WinForms.DataGridView.vDataGridView dgvSolutions;
    }
}