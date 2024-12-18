namespace ProjetCsharp.Views
{
    partial class AddEditOrderForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.ComboBox cmbClients;
        private System.Windows.Forms.DataGridView dgvArticles;
        private System.Windows.Forms.Button btnSave;

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
            this.lblClient = new System.Windows.Forms.Label();
            this.cmbClients = new System.Windows.Forms.ComboBox();
            this.dgvArticles = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticles)).BeginInit();
            this.SuspendLayout();

            // Label Client
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(20, 20);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(70, 15);
            this.lblClient.Text = "Select customer";

            // ComboBox Clients
            this.cmbClients.FormattingEnabled = true;
            this.cmbClients.Location = new System.Drawing.Point(120, 20);
            this.cmbClients.Name = "cmbClients";
            this.cmbClients.Size = new System.Drawing.Size(200, 23);

            // DataGridView Articles
            this.dgvArticles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticles.Location = new System.Drawing.Point(20, 60);
            this.dgvArticles.Name = "dgvArticles";
            this.dgvArticles.Size = new System.Drawing.Size(500, 300);
            this.dgvArticles.Columns.Add("Selected", "Selected");
            this.dgvArticles.Columns.Add("Name", "Article Name");
            this.dgvArticles.Columns.Add("Quantity", "Quantity");

            // Save Button
            this.btnSave.Location = new System.Drawing.Point(250, 380);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // AddEditOrderForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.lblClient);
            this.Controls.Add(this.cmbClients);
            this.Controls.Add(this.dgvArticles);
            this.Controls.Add(this.btnSave);
            this.Text = "Order Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
