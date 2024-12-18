namespace ProjetCsharp
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblWelcome;

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
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // lblWelcome
            this.lblWelcome.Location = new System.Drawing.Point(210, 20);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(400, 50);
            this.lblWelcome.TabIndex = 5;
            this.lblWelcome.Text = "Item Order Management";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWelcome.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;



        // lblEmail
        this.lblEmail.Location = new System.Drawing.Point(200, 120); // Ajuster la position
        this.lblEmail.Name = "lblEmail";
        this.lblEmail.Size = new System.Drawing.Size(120, 40); // Taille augmentée
        this.lblEmail.Font = new System.Drawing.Font("Arial", 12F); // Police augmentée
        this.lblEmail.Text = "Email ";

        // txtEmail
        this.txtEmail.Location = new System.Drawing.Point(340, 120);
        this.txtEmail.Name = "txtEmail";
        this.txtEmail.Size = new System.Drawing.Size(250, 40); // Taille augmentée
        this.txtEmail.Font = new System.Drawing.Font("Arial", 12F); // Police augmentée

        // lblPassword
        this.lblPassword.Location = new System.Drawing.Point(200, 180);
        this.lblPassword.Name = "lblPassword";
        this.lblPassword.Size = new System.Drawing.Size(120, 40); // Taille augmentée
        this.lblPassword.Font = new System.Drawing.Font("Arial", 12F); // Police augmentée
        this.lblPassword.Text = "Password ";

        // txtPassword
        this.txtPassword.Location = new System.Drawing.Point(340, 180);
        this.txtPassword.Name = "txtPassword";
        this.txtPassword.Size = new System.Drawing.Size(250, 40); // Taille augmentée
        this.txtPassword.Font = new System.Drawing.Font("Arial", 12F); // Police augmentée
        this.txtPassword.UseSystemPasswordChar = true;

        // btnLogin
        this.btnLogin.Location = new System.Drawing.Point(400, 250); // Ajuster la position
        this.btnLogin.Name = "btnLogin";
        this.btnLogin.Size = new System.Drawing.Size(120, 40); // Taille augmentée
        this.btnLogin.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold); // Police augmentée
        this.btnLogin.Text = "Login";
        this.btnLogin.UseVisualStyleBackColor = true;
        this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);


            // LoginForm
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnLogin);
            this.Name = "LoginForm";
            this.Text = "Item Order Management";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
