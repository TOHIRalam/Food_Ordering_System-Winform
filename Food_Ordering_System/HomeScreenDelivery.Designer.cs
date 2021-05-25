
namespace Food_Ordering_System
{
    partial class HomeScreenDelivery
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
            this.restaurantNameDashboard = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.customDeliveryRequest1 = new Food_Ordering_System.CustomDeliveryRequest();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Crimson;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.restaurantNameDashboard);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1382, 62);
            this.panel1.TabIndex = 2;
            // 
            // restaurantNameDashboard
            // 
            this.restaurantNameDashboard.AutoSize = true;
            this.restaurantNameDashboard.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restaurantNameDashboard.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.restaurantNameDashboard.Location = new System.Drawing.Point(15, 19);
            this.restaurantNameDashboard.Name = "restaurantNameDashboard";
            this.restaurantNameDashboard.Size = new System.Drawing.Size(116, 23);
            this.restaurantNameDashboard.TabIndex = 2;
            this.restaurantNameDashboard.Text = "Dashboard";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(1272, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Log Out";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // customDeliveryRequest1
            // 
            this.customDeliveryRequest1.BackColor = System.Drawing.Color.Snow;
            this.customDeliveryRequest1.Location = new System.Drawing.Point(128, 62);
            this.customDeliveryRequest1.Name = "customDeliveryRequest1";
            this.customDeliveryRequest1.Size = new System.Drawing.Size(1144, 691);
            this.customDeliveryRequest1.TabIndex = 3;
            // 
            // HomeScreenDelivery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(1382, 753);
            this.Controls.Add(this.customDeliveryRequest1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "HomeScreenDelivery";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PaantaHaari (Delivery)";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label restaurantNameDashboard;
        private CustomDeliveryRequest customDeliveryRequest1;
    }
}