using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ProjetCsharp.Controllers;
using ProjetCsharp.Models;

namespace ProjetCsharp.Views
{
    public partial class CommercialArcticleForm : Form
    {
        private ArticleController articleController;
        public CommercialArcticleForm(){
            InitializeComponent();
            articleController = new ArticleController();
            LoadArticles(); // Charger les articles au démarrage
        }

        // Charger les articles dans le DataGridView
        private void LoadArticles()
        {
            List<Article> articles = articleController.GetAllArticles();
            dgvArticles.DataSource = articles; // Liaison des données
        }

        // Rechercher des articles
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text;
            List<Article> articles = articleController.SearchArticles(searchTerm);
            dgvArticles.DataSource = articles; // Mettre à jour la vue
        }
        // Méthode associée au bouton Retour
private void btnBack_Click(object sender, EventArgs e)
{
    this.Hide(); // Cacher le formulaire de connexion
    CommercialDashboard commercialDashboard = new CommercialDashboard();
    commercialDashboard.Show(); // Ouvrir le tableau de bord admin
}

    }
}