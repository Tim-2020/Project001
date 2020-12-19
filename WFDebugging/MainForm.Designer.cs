namespace WFDebugging
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.btnTrace2Functions = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExceptionOutRange = new System.Windows.Forms.ToolStripButton();
            this.btnDivideByZero = new System.Windows.Forms.ToolStripButton();
            this.btnCount = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDelay = new System.Windows.Forms.ToolStripButton();
            this.btnGCCount = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRunWork = new System.Windows.Forms.ToolStripButton();
            this.btnWorkInfo = new System.Windows.Forms.ToolStripButton();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.edConsole = new System.Windows.Forms.TextBox();
            this.toolStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMain
            // 
            this.toolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
this.btnTrace2Functions,
this.toolStripButton5,
this.toolStripSeparator2,
this.btnExceptionOutRange,
this.btnDivideByZero,
this.btnCount,
this.toolStripSeparator3,
this.btnDelay,
this.btnGCCount,
this.toolStripSeparator1,
this.btnRunWork,
this.btnWorkInfo});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(865, 46);
            this.toolStripMain.TabIndex = 0;
            this.toolStripMain.Text = "toolStrip1";
            // 
            // btnTrace2Functions
            // 
            this.btnTrace2Functions.Image = ((System.Drawing.Image)(resources.GetObject("btnTrace2Functions.Image")));
            this.btnTrace2Functions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTrace2Functions.Name = "btnTrace2Functions";
            this.btnTrace2Functions.Size = new System.Drawing.Size(102, 43);
            this.btnTrace2Functions.Text = "Trace 2 Functions";
            this.btnTrace2Functions.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnTrace2Functions.Click += new System.EventHandler(this.twoFunctionsDepthToolStripMenuItem_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(102, 43);
            this.toolStripButton5.Text = "Trace 3 Functions";
            this.toolStripButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton5.Click += new System.EventHandler(this.threeFunctionsDepthToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 46);
            // 
            // btnExceptionOutRange
            // 
            this.btnExceptionOutRange.Image = ((System.Drawing.Image)(resources.GetObject("btnExceptionOutRange.Image")));
            this.btnExceptionOutRange.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExceptionOutRange.Name = "btnExceptionOutRange";
            this.btnExceptionOutRange.Size = new System.Drawing.Size(78, 43);
            this.btnExceptionOutRange.Text = "Out of range";
            this.btnExceptionOutRange.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExceptionOutRange.Click += new System.EventHandler(this.outOfRangeExceptionToolStripMenuItem_Click);
            // 
            // btnDivideByZero
            // 
            this.btnDivideByZero.Image = ((System.Drawing.Image)(resources.GetObject("btnDivideByZero.Image")));
            this.btnDivideByZero.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDivideByZero.Name = "btnDivideByZero";
            this.btnDivideByZero.Size = new System.Drawing.Size(85, 43);
            this.btnDivideByZero.Text = "Divide by zero";
            this.btnDivideByZero.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDivideByZero.Click += new System.EventHandler(this.zeroDivisionExceptionToolStripMenuItem_Click);
            // 
            // btnCount
            // 
            this.btnCount.Image = ((System.Drawing.Image)(resources.GetObject("btnCount.Image")));
            this.btnCount.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCount.Name = "btnCount";
            this.btnCount.Size = new System.Drawing.Size(104, 43);
            this.btnCount.Text = "Exceptions Count";
            this.btnCount.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCount.Click += new System.EventHandler(this.btnCount_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 46);
            // 
            // btnDelay
            // 
            this.btnDelay.Image = ((System.Drawing.Image)(resources.GetObject("btnDelay.Image")));
            this.btnDelay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelay.Name = "btnDelay";
            this.btnDelay.Size = new System.Drawing.Size(81, 43);
            this.btnDelay.Text = "Delays Count";
            this.btnDelay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDelay.Click += new System.EventHandler(this.btnDelay_Click);
            // 
            // btnGCCount
            // 
            this.btnGCCount.Image = ((System.Drawing.Image)(resources.GetObject("btnGCCount.Image")));
            this.btnGCCount.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGCCount.Name = "btnGCCount";
            this.btnGCCount.Size = new System.Drawing.Size(63, 43);
            this.btnGCCount.Text = "GC Count";
            this.btnGCCount.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnGCCount.Click += new System.EventHandler(this.btnGCCount_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 46);
            // 
            // btnRunWork
            // 
            this.btnRunWork.Image = ((System.Drawing.Image)(resources.GetObject("btnRunWork.Image")));
            this.btnRunWork.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRunWork.Name = "btnRunWork";
            this.btnRunWork.Size = new System.Drawing.Size(63, 43);
            this.btnRunWork.Text = "Run Work";
            this.btnRunWork.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRunWork.Click += new System.EventHandler(this.btnRunWork_Click);
            // 
            // btnWorkInfo
            // 
            this.btnWorkInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnWorkInfo.Image")));
            this.btnWorkInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnWorkInfo.Name = "btnWorkInfo";
            this.btnWorkInfo.Size = new System.Drawing.Size(63, 43);
            this.btnWorkInfo.Text = "Work Info";
            this.btnWorkInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnWorkInfo.Click += new System.EventHandler(this.btnWorkInfo_Click);
            // 
            // statusStripMain
            // 
            this.statusStripMain.Location = new System.Drawing.Point(0, 470);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(865, 22);
            this.statusStripMain.TabIndex = 2;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // edConsole
            // 
            this.edConsole.BackColor = System.Drawing.Color.Black;
            this.edConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edConsole.ForeColor = System.Drawing.Color.Lime;
            this.edConsole.Location = new System.Drawing.Point(0, 46);
            this.edConsole.Multiline = true;
            this.edConsole.Name = "edConsole";
            this.edConsole.ReadOnly = true;
            this.edConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.edConsole.Size = new System.Drawing.Size(865, 424);
            this.edConsole.TabIndex = 3;
            this.edConsole.WordWrap = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 492);
            this.Controls.Add(this.edConsole);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.toolStripMain);
            this.Name = "MainForm";
            this.Text = "Debugging information handling";
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.TextBox edConsole;
        private System.Windows.Forms.ToolStripButton btnCount;
        private System.Windows.Forms.ToolStripButton btnDelay;
        private System.Windows.Forms.ToolStripButton btnGCCount;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnRunWork;
        private System.Windows.Forms.ToolStripButton btnWorkInfo;
        private System.Windows.Forms.ToolStripButton btnExceptionOutRange;
        private System.Windows.Forms.ToolStripButton btnDivideByZero;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnTrace2Functions;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}
