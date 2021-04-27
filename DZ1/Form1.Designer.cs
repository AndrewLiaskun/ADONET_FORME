
namespace DZ1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.AddButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.IDtextBox = new System.Windows.Forms.TextBox();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.IDCategoryTextBox = new System.Windows.Forms.TextBox();
            this.IDLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.IDCategoryLabel = new System.Windows.Forms.Label();
            this.PriceLabel = new System.Windows.Forms.Label();
            this.PriceTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(788, 344);
            this.dataGridView1.TabIndex = 0;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(836, 200);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(88, 36);
            this.AddButton.TabIndex = 1;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(930, 200);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(88, 36);
            this.DeleteButton.TabIndex = 2;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(1024, 200);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(88, 36);
            this.UpdateButton.TabIndex = 3;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            // 
            // IDtextBox
            // 
            this.IDtextBox.Location = new System.Drawing.Point(901, 30);
            this.IDtextBox.Name = "IDtextBox";
            this.IDtextBox.Size = new System.Drawing.Size(237, 22);
            this.IDtextBox.TabIndex = 4;
            this.IDtextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IDtextBox_KeyPress);
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Location = new System.Drawing.Point(901, 58);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(237, 22);
            this.TitleTextBox.TabIndex = 5;
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Location = new System.Drawing.Point(901, 86);
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(237, 22);
            this.DescriptionTextBox.TabIndex = 6;
            // 
            // IDCategoryTextBox
            // 
            this.IDCategoryTextBox.Location = new System.Drawing.Point(901, 114);
            this.IDCategoryTextBox.Name = "IDCategoryTextBox";
            this.IDCategoryTextBox.Size = new System.Drawing.Size(237, 22);
            this.IDCategoryTextBox.TabIndex = 7;
            this.IDCategoryTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IDCategoryTextBox_KeyPress);
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.Location = new System.Drawing.Point(807, 35);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(21, 17);
            this.IDLabel.TabIndex = 8;
            this.IDLabel.Text = "ID";
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Location = new System.Drawing.Point(807, 63);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(35, 17);
            this.TitleLabel.TabIndex = 9;
            this.TitleLabel.Text = "Title";
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(807, 91);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(79, 17);
            this.DescriptionLabel.TabIndex = 10;
            this.DescriptionLabel.Text = "Description";
            // 
            // IDCategoryLabel
            // 
            this.IDCategoryLabel.AutoSize = true;
            this.IDCategoryLabel.Location = new System.Drawing.Point(807, 119);
            this.IDCategoryLabel.Name = "IDCategoryLabel";
            this.IDCategoryLabel.Size = new System.Drawing.Size(78, 17);
            this.IDCategoryLabel.TabIndex = 11;
            this.IDCategoryLabel.Text = "IDCategory";
            // 
            // PriceLabel
            // 
            this.PriceLabel.AutoSize = true;
            this.PriceLabel.Location = new System.Drawing.Point(807, 147);
            this.PriceLabel.Name = "PriceLabel";
            this.PriceLabel.Size = new System.Drawing.Size(40, 17);
            this.PriceLabel.TabIndex = 13;
            this.PriceLabel.Text = "Price";
            // 
            // PriceTextBox
            // 
            this.PriceTextBox.Location = new System.Drawing.Point(901, 142);
            this.PriceTextBox.Name = "PriceTextBox";
            this.PriceTextBox.Size = new System.Drawing.Size(237, 22);
            this.PriceTextBox.TabIndex = 12;
            this.PriceTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PriceTextBox_KeyPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 552);
            this.Controls.Add(this.PriceLabel);
            this.Controls.Add(this.PriceTextBox);
            this.Controls.Add(this.IDCategoryLabel);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.IDLabel);
            this.Controls.Add(this.IDCategoryTextBox);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.TitleTextBox);
            this.Controls.Add(this.IDtextBox);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.TextBox IDtextBox;
        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.TextBox IDCategoryTextBox;
        private System.Windows.Forms.Label IDLabel;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label IDCategoryLabel;
        private System.Windows.Forms.Label PriceLabel;
        private System.Windows.Forms.TextBox PriceTextBox;
    }
}

