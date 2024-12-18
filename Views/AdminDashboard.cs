using System;
using System.Windows.Forms;
using ProjetCsharp.Views;

namespace ProjetCsharp
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        // Événement pour gérer les articles
        private void btnManageArticles_Click(object sender, EventArgs e)
        {
            this.Hide(); // Cacher le formulaire de connexion
            AdminArticleForm adminArticleForm = new AdminArticleForm();
            adminArticleForm.Show(); // Ouvrir le tableau de bord admin
        }

        // Événement pour gérer les commandes
        private void btnManageOrders_Click(object sender, EventArgs e)
        {
            this.Hide(); // Cacher le formulaire de connexion
            AdminOrderForm adminOrderForm = new AdminOrderForm();
            adminOrderForm.Show(); // Ouvrir le tableau de bord admin
        }

        // Événement pour gérer les clients
        private void btnManageClients_Click(object sender, EventArgs e)
        {
            this.Hide(); // Cacher le formulaire de connexion
            AdminClientForm adminClientForm = new AdminClientForm();
            adminClientForm.Show(); // Ouvrir le tableau de bord admin
        }

        // Événement pour la déconnexion
        private void btnLogout_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Do you really want to log out?",
"Confirmation", 
                                                MessageBoxButtons.YesNo, 
                                                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                this.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
        }
    }
}
