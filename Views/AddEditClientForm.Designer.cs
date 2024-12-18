namespace ProjetCsharp.Views
{
    partial class AddEditClientForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtName;
        private TextBox txtAddress;
        private TextBox txtPhone;
        private Button btnSave;
        private Label lblName;
        private Label lblAddress;
        private Label lblPhone;

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
            this.txtAddress = new TextBox();
            this.txtPhone = new TextBox();
            this.btnSave = new Button();
            this.lblName = new Label();
            this.lblAddress = new Label();
            this.lblPhone = new Label();

            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(120, 30);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 20);

            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(120, 60);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(200, 20);

            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(120, 90);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(200, 20);

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
            this.lblName.Text = "Customer Name ";

            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(40, 63);
            this.lblAddress.Text = "Customer Address ";

            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(40, 93);
            this.lblPhone.Text = "Customer Phone ";

            // 
            // AddEditClientForm
            // 
            this.ClientSize = new System.Drawing.Size(450, 250);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblPhone);
            this.Text = "Customer Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();
            
        }
    }
}
