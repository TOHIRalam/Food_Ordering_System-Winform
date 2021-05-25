
namespace Food_Ordering_System
{
    partial class HomeScreenUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeScreenUser));
            this.HomeButton = new System.Windows.Forms.Button();
            this.sidePanel = new System.Windows.Forms.Panel();
            this.orderHistoryButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.myCart = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.customFoodItems1 = new Food_Ordering_System.CustomFoodItems();
            this.customMyCart1 = new Food_Ordering_System.processingShow();
            this.customUserHistory1 = new Food_Ordering_System.customUserHistory();
            this.sidePanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // HomeButton
            // 
            this.HomeButton.BackColor = System.Drawing.Color.Crimson;
            this.HomeButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.HomeButton.FlatAppearance.BorderSize = 0;
            this.HomeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HomeButton.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeButton.ForeColor = System.Drawing.Color.White;
            this.HomeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.HomeButton.Location = new System.Drawing.Point(0, 206);
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Size = new System.Drawing.Size(238, 75);
            this.HomeButton.TabIndex = 1;
            this.HomeButton.Text = "Home";
            this.HomeButton.UseVisualStyleBackColor = false;
            this.HomeButton.Click += new System.EventHandler(this.HomeButtonClick);
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.sidePanel.Controls.Add(this.orderHistoryButton);
            this.sidePanel.Controls.Add(this.button1);
            this.sidePanel.Controls.Add(this.pictureBox1);
            this.sidePanel.Controls.Add(this.HomeButton);
            this.sidePanel.Controls.Add(this.myCart);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePanel.Location = new System.Drawing.Point(0, 0);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(239, 753);
            this.sidePanel.TabIndex = 4;
            // 
            // orderHistoryButton
            // 
            this.orderHistoryButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.orderHistoryButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.orderHistoryButton.FlatAppearance.BorderSize = 0;
            this.orderHistoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.orderHistoryButton.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderHistoryButton.ForeColor = System.Drawing.Color.White;
            this.orderHistoryButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.orderHistoryButton.Location = new System.Drawing.Point(0, 357);
            this.orderHistoryButton.Name = "orderHistoryButton";
            this.orderHistoryButton.Size = new System.Drawing.Size(238, 75);
            this.orderHistoryButton.TabIndex = 5;
            this.orderHistoryButton.Text = "History";
            this.orderHistoryButton.UseVisualStyleBackColor = false;
            this.orderHistoryButton.Click += new System.EventHandler(this.orderHistoryButton_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(1, 433);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(238, 75);
            this.button1.TabIndex = 4;
            this.button1.Text = "Log Out";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // myCart
            // 
            this.myCart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.myCart.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.myCart.FlatAppearance.BorderSize = 0;
            this.myCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.myCart.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myCart.ForeColor = System.Drawing.Color.White;
            this.myCart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.myCart.Location = new System.Drawing.Point(0, 281);
            this.myCart.Name = "myCart";
            this.myCart.Size = new System.Drawing.Size(238, 75);
            this.myCart.TabIndex = 0;
            this.myCart.Text = "My Cart";
            this.myCart.UseVisualStyleBackColor = false;
            this.myCart.Click += new System.EventHandler(this.myCart_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Crimson;
            this.panel1.Controls.Add(this.UsernameLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(239, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1143, 62);
            this.panel1.TabIndex = 6;
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.UsernameLabel.Location = new System.Drawing.Point(15, 19);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(107, 23);
            this.UsernameLabel.TabIndex = 2;
            this.UsernameLabel.Text = "username";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(232, 190);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // customFoodItems1
            // 
            this.customFoodItems1.BackColor = System.Drawing.Color.Snow;
            this.customFoodItems1.Location = new System.Drawing.Point(238, 62);
            this.customFoodItems1.Name = "customFoodItems1";
            this.customFoodItems1.Size = new System.Drawing.Size(1144, 688);
            this.customFoodItems1.TabIndex = 7;
            // 
            // customMyCart1
            // 
            this.customMyCart1.BackColor = System.Drawing.Color.Snow;
            this.customMyCart1.Location = new System.Drawing.Point(238, 62);
            this.customMyCart1.Name = "customMyCart1";
            this.customMyCart1.Size = new System.Drawing.Size(1144, 703);
            this.customMyCart1.TabIndex = 8;
            this.customMyCart1.Load += new System.EventHandler(this.pageLoad);
            // 
            // customUserHistory1
            // 
            this.customUserHistory1.BackColor = System.Drawing.Color.Snow;
            this.customUserHistory1.Location = new System.Drawing.Point(238, 62);
            this.customUserHistory1.Name = "customUserHistory1";
            this.customUserHistory1.Size = new System.Drawing.Size(1144, 691);
            this.customUserHistory1.TabIndex = 9;
            // 
            // HomeScreenUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(1382, 753);
            this.Controls.Add(this.customUserHistory1);
            this.Controls.Add(this.customMyCart1);
            this.Controls.Add(this.customFoodItems1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sidePanel);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "HomeScreenUser";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PaantaHaari";
            this.Load += new System.EventHandler(this.pageLoad);
            this.sidePanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button myCart;
        private System.Windows.Forms.Button HomeButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Button orderHistoryButton;
        private CustomFoodItems customFoodItems1;
        private processingShow customMyCart1;
        private customUserHistory customUserHistory1;
    }
}