namespace ProjetCsharp.Views
{
    partial class CommercialOrderForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Button btnAddOrder;
        private System.Windows.Forms.Button btnUpdateStatus;
        private System.Windows.Forms.Button btnEditOrder;
        private System.Windows.Forms.Button btnDeleteOrder;
        private System.Windows.Forms.Button btnBack; // Nouveau bouton Back

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.btnAddOrder = new System.Windows.Forms.Button();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            this.btnEditOrder = new System.Windows.Forms.Button();
            this.btnDeleteOrder = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button(); // Initialisation du bouton Back
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();

            // DataGridView Orders
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(30, 70);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.Size = new System.Drawing.Size(600, 250);
            this.dgvOrders.TabIndex = 0;
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // Add a button column for each order
            DataGridViewButtonColumn viewItemsColumn = new DataGridViewButtonColumn();
            viewItemsColumn.Name = "ViewItems";
            viewItemsColumn.HeaderText = "View Items";
            viewItemsColumn.Text = "View";
            viewItemsColumn.UseColumnTextForButtonValue = true;
            this.dgvOrders.Columns.Add(viewItemsColumn);

            // Add Order Button
            this.btnAddOrder.Location = new System.Drawing.Point(30, 340);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(100, 30); // Taille uniforme pour tous les boutons
            this.btnAddOrder.Text = "Add Order";
            this.btnAddOrder.Click += new System.EventHandler(this.btnAddOrder_Click);

            // Update Status Button
            this.btnUpdateStatus.Location = new System.Drawing.Point(140, 340);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.Size = new System.Drawing.Size(100, 30); // Taille uniforme pour tous les boutons
            this.btnUpdateStatus.Text = "Update Status";
            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);

            // Delete Order Button
            this.btnDeleteOrder.Location = new System.Drawing.Point(250, 340);
            this.btnDeleteOrder.Name = "btnDeleteOrder";
            this.btnDeleteOrder.Size = new System.Drawing.Size(100, 30); // Taille uniforme pour tous les boutons
            this.btnDeleteOrder.Text = "Delete Order";
            this.btnDeleteOrder.Click += new System.EventHandler(this.btnDeleteOrder_Click);

            // Edit Order Button
            this.btnEditOrder.Location = new System.Drawing.Point(360, 340);
            this.btnEditOrder.Name = "btnEditOrder";
            this.btnEditOrder.Size = new System.Drawing.Size(100, 30); // Taille uniforme pour tous les boutons
            this.btnEditOrder.Text = "Edit Order";
            this.btnEditOrder.Click += new System.EventHandler(this.btnEditOrder_Click);

            // Back Button
            this.btnBack.Location = new System.Drawing.Point(470, 340); // Positionner le bouton Back
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 30); // Taille uniforme pour tous les boutons
            this.btnBack.Text = "Back";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click); // Gérer l'événement de retour

            // CommercialOrderForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.btnAddOrder);
            this.Controls.Add(this.btnUpdateStatus);
            this.Controls.Add(this.btnDeleteOrder);
            this.Controls.Add(this.btnEditOrder);
            this.Controls.Add(this.btnBack); // Ajouter le bouton Back au formulaire
            this.Text = "Manage Orders - Commercial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
        }

    }
}
