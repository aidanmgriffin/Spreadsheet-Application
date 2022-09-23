namespace Interface
{
    partial class Interface
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.interfaceTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFibonacciNumbersFirst50ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFibonacciNumbersFirst100ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // interfaceTextBox
            // 
            this.interfaceTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.interfaceTextBox.Location = new System.Drawing.Point(0, 24);
            this.interfaceTextBox.Multiline = true;
            this.interfaceTextBox.Name = "interfaceTextBox";
            this.interfaceTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.interfaceTextBox.Size = new System.Drawing.Size(800, 426);
            this.interfaceTextBox.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.loadFibonacciNumbersFirst50ToolStripMenuItem,
            this.loadFibonacciNumbersFirst100ToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.openToolStripMenuItem.Text = "Load from file...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // loadFibonacciNumbersFirst50ToolStripMenuItem
            // 
            this.loadFibonacciNumbersFirst50ToolStripMenuItem.Name = "loadFibonacciNumbersFirst50ToolStripMenuItem";
            this.loadFibonacciNumbersFirst50ToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.loadFibonacciNumbersFirst50ToolStripMenuItem.Text = "Load Fibonacci Numbers (First 50)";
            this.loadFibonacciNumbersFirst50ToolStripMenuItem.Click += new System.EventHandler(this.loadFibonacciNumbersFirst50ToolStripMenuItem_Click);
            // 
            // loadFibonacciNumbersFirst100ToolStripMenuItem
            // 
            this.loadFibonacciNumbersFirst100ToolStripMenuItem.Name = "loadFibonacciNumbersFirst100ToolStripMenuItem";
            this.loadFibonacciNumbersFirst100ToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.loadFibonacciNumbersFirst100ToolStripMenuItem.Text = "Load Fibonacci Numbers (First 100)";
            this.loadFibonacciNumbersFirst100ToolStripMenuItem.Click += new System.EventHandler(this.loadFibonacciNumbersFirst100ToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.saveToolStripMenuItem.Text = "Save to file...";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Interface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.interfaceTextBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Interface";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox interfaceTextBox;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private SaveFileDialog saveFileDialog1;
        private OpenFileDialog openFileDialog1;
        private ToolStripMenuItem loadFibonacciNumbersFirst50ToolStripMenuItem;
        private ToolStripMenuItem loadFibonacciNumbersFirst100ToolStripMenuItem;
    }
}