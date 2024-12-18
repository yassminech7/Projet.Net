namespace ProjetCsharp
{
    partial class CommercialDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnManageArticles;
        private System.Windows.Forms.Button btnManageOrders;
        private System.Windows.Forms.Button btnViewClients;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblWelcome;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Méthode nécessaire pour la prise en charge du concepteur.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnManageArticles = new System.Windows.Forms.Button();
            this.btnManageOrders = new System.Windows.Forms.Button();
            this.btnViewClients = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();

 // 
 // lblWelcome
            this.lblWelcome.Location = new System.Drawing.Point(210, 20);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(400, 50);
            this.lblWelcome.TabIndex = 5;
            this.lblWelcome.Text = "Commercial Dashboard";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWelcome.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            // btnManageArticles
            // 
            this.btnManageArticles.Location = new System.Drawing.Point(300, 100);
            this.btnManageArticles.Name = "btnManageArticles";
            this.btnManageArticles.Size = new System.Drawing.Size(200, 50);
            this.btnManageArticles.TabIndex = 0;
            this.btnManageArticles.Text = "Manage Articles";
            this.btnManageArticles.UseVisualStyleBackColor = true;
            this.btnManageArticles.Click += new System.EventHandler(this.btnManageArticles_Click);

            // 
            // btnManageOrders
            // 
            this.btnManageOrders.Location = new System.Drawing.Point(300, 180);
            this.btnManageOrders.Name = "btnManageOrders";
            this.btnManageOrders.Size = new System.Drawing.Size(200, 50);
            this.btnManageOrders.TabIndex = 3;
            this.btnManageOrders.Text = "Manage Orders";
            this.btnManageOrders.UseVisualStyleBackColor = true;
            this.btnManageOrders.Click += new System.EventHandler(this.btnManageOrders_Click);

            // 
            // btnViewClients
            // 
            this.btnViewClients.Location = new System.Drawing.Point(300, 260);
            this.btnViewClients.Name = "btnViewClients";
            this.btnViewClients.Size = new System.Drawing.Size(200, 50);
            this.btnViewClients.TabIndex = 1;
            this.btnViewClients.Text = "Manage Customers";
            this.btnViewClients.UseVisualStyleBackColor = true;
            this.btnViewClients.Click += new System.EventHandler(this.btnViewClients_Click);

            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(300, 340);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(200, 50);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // 
            // CommercialDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnManageOrders);
            this.Controls.Add(this.btnViewClients);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnManageArticles);
            this.Controls.Add(this.lblWelcome);
            this.Name = "CommercialDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard - Commercial";
        }
    }
}
