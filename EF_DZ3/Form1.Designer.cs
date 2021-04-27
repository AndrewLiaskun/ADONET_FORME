
namespace EF_DZ3
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.ADDtoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.UPDATEtoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.DELETEtoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1,
            this.ADDtoolStripButton,
            this.UPDATEtoolStripButton,
            this.DELETEtoolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(953, 28);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "Sage",
            "Book",
            "SageBook"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 28);
            this.toolStripComboBox1.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
            // 
            // ADDtoolStripButton
            // 
            this.ADDtoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ADDtoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ADDtoolStripButton.Image")));
            this.ADDtoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ADDtoolStripButton.Name = "ADDtoolStripButton";
            this.ADDtoolStripButton.Size = new System.Drawing.Size(41, 25);
            this.ADDtoolStripButton.Text = "Add";
            this.ADDtoolStripButton.Click += new System.EventHandler(this.ADDtoolStripButton_Click);
            // 
            // UPDATEtoolStripButton
            // 
            this.UPDATEtoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.UPDATEtoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("UPDATEtoolStripButton.Image")));
            this.UPDATEtoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UPDATEtoolStripButton.Name = "UPDATEtoolStripButton";
            this.UPDATEtoolStripButton.Size = new System.Drawing.Size(62, 25);
            this.UPDATEtoolStripButton.Text = "Update";
            this.UPDATEtoolStripButton.Click += new System.EventHandler(this.UPDATEtoolStripButton_Click);
            // 
            // DELETEtoolStripButton
            // 
            this.DELETEtoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DELETEtoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("DELETEtoolStripButton.Image")));
            this.DELETEtoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DELETEtoolStripButton.Name = "DELETEtoolStripButton";
            this.DELETEtoolStripButton.Size = new System.Drawing.Size(57, 25);
            this.DELETEtoolStripButton.Text = "Delete";
            this.DELETEtoolStripButton.Click += new System.EventHandler(this.DELETEtoolStripButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(953, 517);
            this.dataGridView1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 517);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripButton ADDtoolStripButton;
        private System.Windows.Forms.ToolStripButton UPDATEtoolStripButton;
        private System.Windows.Forms.ToolStripButton DELETEtoolStripButton;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

