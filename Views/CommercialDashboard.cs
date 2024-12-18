using System;
using System.Windows.Forms;
using ProjetCsharp.Views;

namespace ProjetCsharp
{
    public partial class CommercialDashboard : Form
    {
        public CommercialDashboard()
        {
            InitializeComponent();
        }
// Événement pour gérer les articles
        private void btnManageArticles_Click(object sender, EventArgs e)
        {
            this.Hide(); // Cacher le formulaire de connexion
            CommercialArcticleForm commercialArcticleForm = new CommercialArcticleForm();
            commercialArcticleForm.Show(); // Ouvrir le tableau de bord admin
        }
        // Événement pour gérer les commandes
        private void btnManageOrders_Click(object sender, EventArgs e)
        {
            this.Hide(); // Cacher le formulaire de connexion
            CommercialOrderForm commercialOrderForm = new CommercialOrderForm();
            commercialOrderForm.Show(); // Ouvrir le tableau de bord admin
        }

        // Événement pour visualiser les clients
        private void btnViewClients_Click(object sender, EventArgs e)
        {
            this.Hide(); // Cacher le formulaire de connexion
            CommercialClientForm commercialClientForm = new CommercialClientForm();
            commercialClientForm.Show(); // Ouvrir le tableau de bord admin
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
