using ProjetCsharp.Controllers;
using ProjetCsharp.Models;
using System;
using System.Windows.Forms;

namespace ProjetCsharp
{
    public partial class LoginForm : Form
    {
        private LoginController loginController;

        public LoginForm()
        {
            InitializeComponent();
            loginController = new LoginController();  // Initialisation du contrôleur
        }

        // Événement pour la connexion lorsque le bouton est cliqué
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Authentifier l'utilisateur via le contrôleur
            User user = loginController.AuthenticateUser(email, password);

            if (user != null)
            {
                // Vérification du rôle pour rediriger l'utilisateur
                if (user.Role == "admin")
                {
                    MessageBox.Show("Welcome, Administrateur !");
                    this.Hide(); // Cacher le formulaire de connexion
                    AdminDashboard adminDashboard = new AdminDashboard();
                    adminDashboard.Show(); // Ouvrir le tableau de bord admin
                }
                else if (user.Role == "commercial")
                {
                    MessageBox.Show("Welcome, Commercial !");
                    this.Hide(); // Cacher le formulaire de connexion
                    CommercialDashboard commercialDashboard = new CommercialDashboard();
                    commercialDashboard.Show(); // Ouvrir le tableau de bord commercial
                }
                else
                {
                    MessageBox.Show("Role not recognized. Please contact administrator.");
                }
            }
            else
            {
                MessageBox.Show("Incorrect credentials, please try again.");
            }
        }
    }
}
