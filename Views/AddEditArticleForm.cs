using System;
using System.Windows.Forms;
using ProjetCsharp.Models;

namespace ProjetCsharp.Views
{
    public partial class AddEditArticleForm : Form
    {
        public Article Article { get; private set; }
        public bool IsEditMode { get; private set; }

        public AddEditArticleForm(Article article = null)
        {
            InitializeComponent();

            if (article != null)
            {
                IsEditMode = true;
                Article = article;

                // Préremplir les champs pour le mode édition
                txtName.Text = article.Name;
                txtPrice.Text = article.Price.ToString();
                txtStock.Text = article.Stock.ToString();
                Text = "Edit Article";
                btnSave.Text = "Edit";
            }
            else
            {
                IsEditMode = false;
                Article = new Article();
                Text = "Add Article";
                btnSave.Text = "Add";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Valider les champs
            if (string.IsNullOrWhiteSpace(txtName.Text) || 
                !double.TryParse(txtPrice.Text, out double price) || 
                !int.TryParse(txtStock.Text, out int stock))
            {
                MessageBox.Show("Please fill in all fields correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mettre à jour l'objet Article
            Article.Name = txtName.Text;
            Article.Price = price;
            Article.Stock = stock;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
