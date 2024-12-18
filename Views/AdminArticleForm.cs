using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ProjetCsharp.Controllers;
using ProjetCsharp.Models;

namespace ProjetCsharp.Views
{
    public partial class AdminArticleForm : Form
    {
        private ArticleController articleController;

        public AdminArticleForm()
        {
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

        // Ajouter un nouvel article
        // Ouvrir le formulaire d'ajout
private void btnAdd_Click(object sender, EventArgs e)
{
    using (var form = new AddEditArticleForm())
    {
        if (form.ShowDialog() == DialogResult.OK)
        {
            articleController.AddArticle(form.Article);
            LoadArticles(); // Recharger la liste
        }
    }
}



        // Modifier l'article sélectionné
       private void btnEdit_Click(object sender, EventArgs e)
{
    if (dgvArticles.SelectedRows.Count > 0)
    {
        int id = (int)dgvArticles.SelectedRows[0].Cells["Id"].Value;

        // Récupérer l'article sélectionné
        var article = articleController.GetAllArticles().Find(a => a.Id == id);

        using (var form = new AddEditArticleForm(article))
        {
            if (form.ShowDialog() == DialogResult.OK)
            {
                articleController.UpdateArticle(form.Article);
                LoadArticles(); // Recharger la liste
            }
        }
    }
}


        // Supprimer l'article sélectionné
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvArticles.SelectedRows.Count > 0)
            {
                int id = (int)dgvArticles.SelectedRows[0].Cells["Id"].Value;
                articleController.DeleteArticle(id);
                LoadArticles(); // Recharger la liste
            }
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
    AdminDashboard adminDashboard = new AdminDashboard();
    adminDashboard.Show(); // Ouvrir le tableau de bord admin
}

    }
}
