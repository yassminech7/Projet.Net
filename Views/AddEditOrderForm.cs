using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ProjetCsharp.Controllers;
using ProjetCsharp.Models;

namespace ProjetCsharp.Views
{
    public partial class AddEditOrderForm : Form
    {
        private ArticleController articleController;
        private ClientController clientController;
        public Order Order { get; private set; }

        public AddEditOrderForm(Order order = null)
        {
            InitializeComponent();
            articleController = new ArticleController();
            clientController = new ClientController();

            // Charger la liste des clients
            cmbClients.DataSource = clientController.GetAllClients();
            cmbClients.DisplayMember = "Name";
            cmbClients.ValueMember = "Id";

            // Charger la liste des articles
            dgvArticles.DataSource = articleController.GetAllArticles();
            dgvArticles.Columns["Quantity"].Visible = true;

            // Initialiser la liste des articles de la commande
            Order = order ?? new Order { OrderItems = new List<OrderItem>() };

            if (order != null)
            {
                // Pré-remplir les informations de la commande
                cmbClients.SelectedValue = order.ClientId;

                // Marquer les articles de la commande comme sélectionnés
                foreach (var item in order.OrderItems)
                {
                    foreach (DataGridViewRow row in dgvArticles.Rows)
                    {
                        var articleId = (int)row.Cells["Id"].Value;
                        if (item.ArticleId == articleId)
                        {
                            row.Cells["Selected"].Value = true;
                            row.Cells["Quantity"].Value = item.Quantity;
                        }
                    }
                }
            }
        }



        private void btnSave_Click(object sender, EventArgs e)
{
    // Mettre à jour les informations de la commande
    Order.ClientId = (int)cmbClients.SelectedValue;
    Order.OrderDate = DateTime.Now;
    Order.IsDelivered = false;  // Exemple, vous pouvez définir si la commande est livrée ou non.

    // Ajouter les articles sélectionnés à la commande
    Order.OrderItems.Clear(); // Réinitialiser les articles de la commande
    foreach (DataGridViewRow row in dgvArticles.Rows)
    {
        // Vérifiez si l'article est sélectionné et que la quantité est valide
        if (Convert.ToBoolean(row.Cells["Selected"].Value))
        {
            var quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
            if (quantity > 0)
            {
                var articleName = row.Cells["Name"].Value.ToString(); // Récupérer le nom de l'article

                Order.OrderItems.Add(new OrderItem
                {
                    ArticleId = (int)row.Cells["Id"].Value,
                    ArticleName = articleName, // Affecter le nom de l'article
                    Quantity = quantity
                });
            }
        }
    }

    // Vérification des articles ajoutés
    Console.WriteLine($"Number of selected items: {Order.OrderItems.Count}");

    // Si des articles ont été ajoutés, sauvegarder la commande
    if (Order.OrderItems.Count > 0)
    {
        // Sauvegarder la commande (exemple d'appel à la méthode de contrôleur)
        var orderController = new OrderController();
        if (Order.Id == 0)  // Si la commande n'a pas encore d'ID, c'est une nouvelle commande
        {
            orderController.CreateOrder(Order);
        }
        else  // Sinon, c'est une commande existante, il faut la mettre à jour
        {
            orderController.UpdateOrder(Order);
        }

    }
    else
    {
        MessageBox.Show("Please select at least one article.");
    }
    DialogResult = DialogResult.OK;
    Close();
}



    }
}
