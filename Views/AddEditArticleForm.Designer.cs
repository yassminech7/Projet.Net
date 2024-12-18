namespace ProjetCsharp.Views
{
    partial class AddEditArticleForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtName;
        private TextBox txtPrice;
        private TextBox txtStock;
        private Button btnSave;
        private Label lblName;
        private Label lblPrice;
        private Label lblStock;

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
            this.txtName = new TextBox();
            this.txtPrice = new TextBox();
            this.txtStock = new TextBox();
            this.btnSave = new Button();
            this.lblName = new Label();
            this.lblPrice = new Label();
            this.lblStock = new Label();

            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(120, 30);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 20);

            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(120, 60);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(200, 20);

            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(120, 90);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(200, 20);

            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(160, 130);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(40, 33);
            this.lblName.Text = "Article Name ";

            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(40, 63);
            this.lblPrice.Text = "Article Price ";

            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(40, 93);
            this.lblStock.Text = "Article Stock ";

            // 
            // AddEditArticleForm
            // 
            this.ClientSize = new System.Drawing.Size(450,250);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblStock);
            this.Text = "Article Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
