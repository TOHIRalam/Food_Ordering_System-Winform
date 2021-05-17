namespace Food_Ordering_System
{
    partial class CustomMyCart
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cartItemGrid = new System.Windows.Forms.DataGridView();
            this.numberOfItemText = new System.Windows.Forms.Label();
            this.totalPriceText = new System.Windows.Forms.Label();
            this.priceText = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.confirmOrder = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.waitingShow = new System.Windows.Forms.Label();
            this.progressPanel = new System.Windows.Forms.Panel();
            this.processingShow = new System.Windows.Forms.Label();
            this.deliveringShow = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.cartItemGrid)).BeginInit();
            this.progressPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // cartItemGrid
            // 
            this.cartItemGrid.AllowUserToAddRows = false;
            this.cartItemGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.cartItemGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.cartItemGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.cartItemGrid.BackgroundColor = System.Drawing.Color.Snow;
            this.cartItemGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.cartItemGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cartItemGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.cartItemGrid.ColumnHeadersHeight = 32;
            this.cartItemGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.cartItemGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.cartItemGrid.Location = new System.Drawing.Point(25, 64);
            this.cartItemGrid.Name = "cartItemGrid";
            this.cartItemGrid.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cartItemGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.cartItemGrid.RowHeadersVisible = false;
            this.cartItemGrid.RowHeadersWidth = 51;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.cartItemGrid.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.cartItemGrid.RowTemplate.Height = 24;
            this.cartItemGrid.Size = new System.Drawing.Size(1097, 265);
            this.cartItemGrid.TabIndex = 2;
            // 
            // numberOfItemText
            // 
            this.numberOfItemText.AutoSize = true;
            this.numberOfItemText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.numberOfItemText.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberOfItemText.Location = new System.Drawing.Point(21, 38);
            this.numberOfItemText.Name = "numberOfItemText";
            this.numberOfItemText.Size = new System.Drawing.Size(302, 23);
            this.numberOfItemText.TabIndex = 3;
            this.numberOfItemText.Text = "There are _ item(s) in your cart";
            // 
            // totalPriceText
            // 
            this.totalPriceText.AutoSize = true;
            this.totalPriceText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.totalPriceText.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPriceText.Location = new System.Drawing.Point(919, 38);
            this.totalPriceText.Name = "totalPriceText";
            this.totalPriceText.Size = new System.Drawing.Size(115, 23);
            this.totalPriceText.TabIndex = 4;
            this.totalPriceText.Text = "Total Price:";
            // 
            // priceText
            // 
            this.priceText.AutoSize = true;
            this.priceText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.priceText.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceText.Location = new System.Drawing.Point(1040, 38);
            this.priceText.Name = "priceText";
            this.priceText.Size = new System.Drawing.Size(47, 23);
            this.priceText.TabIndex = 5;
            this.priceText.Text = "0 TK";
            // 
            // cancelButton
            // 
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("Microsoft JhengHei UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.ForeColor = System.Drawing.Color.Crimson;
            this.cancelButton.Location = new System.Drawing.Point(460, 605);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(121, 34);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel Order";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // confirmOrder
            // 
            this.confirmOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.confirmOrder.Font = new System.Drawing.Font("Microsoft JhengHei UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmOrder.ForeColor = System.Drawing.Color.DodgerBlue;
            this.confirmOrder.Location = new System.Drawing.Point(587, 605);
            this.confirmOrder.Name = "confirmOrder";
            this.confirmOrder.Size = new System.Drawing.Size(121, 34);
            this.confirmOrder.TabIndex = 7;
            this.confirmOrder.Text = "Confirm Order";
            this.confirmOrder.UseVisualStyleBackColor = true;
            this.confirmOrder.Click += new System.EventHandler(this.confirmOrder_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(346, 342);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(478, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "If you confirm your order then the payment will be through cash on delivery";
            // 
            // waitingShow
            // 
            this.waitingShow.AutoSize = true;
            this.waitingShow.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waitingShow.ForeColor = System.Drawing.Color.LimeGreen;
            this.waitingShow.Location = new System.Drawing.Point(13, 12);
            this.waitingShow.Name = "waitingShow";
            this.waitingShow.Size = new System.Drawing.Size(24, 24);
            this.waitingShow.TabIndex = 9;
            this.waitingShow.Text = "O";
            // 
            // progressPanel
            // 
            this.progressPanel.Controls.Add(this.pictureBox2);
            this.progressPanel.Controls.Add(this.pictureBox1);
            this.progressPanel.Controls.Add(this.deliveringShow);
            this.progressPanel.Controls.Add(this.processingShow);
            this.progressPanel.Controls.Add(this.waitingShow);
            this.progressPanel.Location = new System.Drawing.Point(349, 448);
            this.progressPanel.Name = "progressPanel";
            this.progressPanel.Size = new System.Drawing.Size(475, 66);
            this.progressPanel.TabIndex = 10;
            // 
            // processingShow
            // 
            this.processingShow.AutoSize = true;
            this.processingShow.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.processingShow.ForeColor = System.Drawing.Color.Crimson;
            this.processingShow.Location = new System.Drawing.Point(227, 12);
            this.processingShow.Name = "processingShow";
            this.processingShow.Size = new System.Drawing.Size(24, 24);
            this.processingShow.TabIndex = 11;
            this.processingShow.Text = "O";
            // 
            // deliveringShow
            // 
            this.deliveringShow.AutoSize = true;
            this.deliveringShow.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deliveringShow.ForeColor = System.Drawing.Color.Crimson;
            this.deliveringShow.Location = new System.Drawing.Point(442, 12);
            this.deliveringShow.Name = "deliveringShow";
            this.deliveringShow.Size = new System.Drawing.Size(24, 24);
            this.deliveringShow.TabIndex = 12;
            this.deliveringShow.Text = "O";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.pictureBox1.Location = new System.Drawing.Point(31, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 1);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Gainsboro;
            this.pictureBox2.Location = new System.Drawing.Point(246, 22);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(200, 1);
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // CustomMyCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.Controls.Add(this.progressPanel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.confirmOrder);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.priceText);
            this.Controls.Add(this.totalPriceText);
            this.Controls.Add(this.numberOfItemText);
            this.Controls.Add(this.cartItemGrid);
            this.Name = "CustomMyCart";
            this.Size = new System.Drawing.Size(1144, 703);
            this.Load += new System.EventHandler(this.pageLoad);
            ((System.ComponentModel.ISupportInitialize)(this.cartItemGrid)).EndInit();
            this.progressPanel.ResumeLayout(false);
            this.progressPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView cartItemGrid;
        private System.Windows.Forms.Label numberOfItemText;
        private System.Windows.Forms.Label totalPriceText;
        private System.Windows.Forms.Label priceText;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button confirmOrder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label waitingShow;
        private System.Windows.Forms.Panel progressPanel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label deliveringShow;
        private System.Windows.Forms.Label processingShow;
    }
}
