using System;
using System.Windows.Forms;
using ProjetCsharp.Controllers;
using ProjetCsharp.Models;

namespace ProjetCsharp.Views
{
    public partial class CommercialOrderForm : Form
    {
        private OrderController orderController;

        public CommercialOrderForm()
        {
            InitializeComponent();
            orderController = new OrderController();
            LoadOrders();
        }

        private void LoadOrders()
{
    dgvOrders.DataSource = null;
    dgvOrders.DataSource = orderController.GetAllOrders();

    // Ajouter un gestionnaire d'événements pour le clic sur les boutons
    dgvOrders.CellContentClick += dgvOrders_CellContentClick;
}


        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            var addOrderForm = new AddEditOrderForm();
            if (addOrderForm.ShowDialog() == DialogResult.OK)
            {
                orderController.CreateOrder(addOrderForm.Order);
                LoadOrders();
            }
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                var selectedOrder = (Order)dgvOrders.SelectedRows[0].DataBoundItem;
                orderController.UpdateOrderStatus(selectedOrder.Id, !selectedOrder.IsDelivered);
                LoadOrders();
            }
            else
            {
                MessageBox.Show("Please select an order to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
{
    if (e.ColumnIndex == dgvOrders.Columns["ViewItems"].Index)
    {
        // Récupérer l'ID de la commande de la ligne sélectionnée
        var selectedOrder = (Order)dgvOrders.Rows[e.RowIndex].DataBoundItem;

        // Afficher les articles associés à la commande
        ShowOrderItems(selectedOrder);
    }
}

private void ShowOrderItems(Order order)
{
    // Créer une nouvelle fenêtre pour afficher les articles
    var itemsForm = new Form
    {
        Text = "Order items",
        Size = new System.Drawing.Size(800, 500), // Taille ajustée pour inclure le bouton
        StartPosition = FormStartPosition.CenterScreen // Centrer la fenêtre
    };

    var itemsDataGridView = new DataGridView
    {
        Dock = DockStyle.Top,
        Height = 400, // Réduire la hauteur pour laisser de la place au bouton
        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill // Ajuster les colonnes pour remplir la fenêtre
    };

    itemsForm.Controls.Add(itemsDataGridView);

    // Ajouter les colonnes au DataGridView
    itemsDataGridView.Columns.Add("ArticleName", "Item");
    itemsDataGridView.Columns.Add("Quantity", "Quantity");

    // Ajouter une colonne pour le bouton "Modifier"
    var editButtonColumn = new DataGridViewButtonColumn
    {
        Name = "EditQuantity",
        HeaderText = "Action",
        Text = "Edit",
        UseColumnTextForButtonValue = true,
        Width = 100 // Largeur spécifique pour cette colonne
    };
    itemsDataGridView.Columns.Add(editButtonColumn);

    // Ajouter une colonne pour le bouton "Supprimer"
    var deleteButtonColumn = new DataGridViewButtonColumn
    {
        Name = "DeleteItem",
        HeaderText = "Action",
        Text = "Delete",
        UseColumnTextForButtonValue = true,
        Width = 100 // Largeur spécifique pour cette colonne
    };
    itemsDataGridView.Columns.Add(deleteButtonColumn);

    // Ajouter les articles au DataGridView
    foreach (var item in order.OrderItems)
    {
        itemsDataGridView.Rows.Add(item.ArticleName, item.Quantity);
    }

    // Améliorer le design du DataGridView
    itemsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    itemsDataGridView.AllowUserToAddRows = false;

    // Gestion des clics sur les boutons
    itemsDataGridView.CellContentClick += (sender, e) =>
    {
        if (e.RowIndex >= 0)
        {
            var selectedItem = order.OrderItems[e.RowIndex];

            if (e.ColumnIndex == itemsDataGridView.Columns["EditQuantity"].Index)
            {
                // Modifier la quantité
                var input = Microsoft.VisualBasic.Interaction.InputBox(
                    "Enter the new quantity :",
                    "Change quantity",
                    selectedItem.Quantity.ToString()
                );

                if (int.TryParse(input, out int newQuantity) && newQuantity > 0)
                {
                    selectedItem.Quantity = newQuantity;
                    itemsDataGridView.Rows[e.RowIndex].Cells["Quantity"].Value = newQuantity;

                    // Mise à jour dans la base de données
                    orderController.UpdateOrderItem(order.Id, selectedItem);
                }
                else
                {
                    MessageBox.Show("Invalid quantity.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (e.ColumnIndex == itemsDataGridView.Columns["DeleteItem"].Index)
            {
                // Supprimer l'article
                var confirmResult = MessageBox.Show(
                    "Are you sure you want to delete this item ?",
                    "Confirm deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmResult == DialogResult.Yes)
                {
                    order.OrderItems.Remove(selectedItem);
                    itemsDataGridView.Rows.RemoveAt(e.RowIndex);

                    // Suppression dans la base de données
                    orderController.DeleteOrderItem(order.Id, selectedItem.ArticleId);
                }
            }
        }
    };

    // Ajouter un bouton "OK" pour fermer la fenêtre
    var okButton = new Button
    {
        Text = "Close",
        Width = 100, // Définir une largeur fixe pour le bouton
        Height = 40, // Ajuster la hauteur du bouton
        Left = (itemsForm.ClientSize.Width - 100) / 2, // Centrer le bouton horizontalement
        Top = itemsDataGridView.Bottom + 10
    };
    okButton.Click += (sender, e) => itemsForm.Close(); // Fermer la fenêtre au clic

    itemsForm.Controls.Add(okButton);

    // Afficher la fenêtre
    itemsForm.ShowDialog();
}



private void btnDeleteOrder_Click(object sender, EventArgs e)
{
    if (dgvOrders.SelectedRows.Count > 0)
    {
        var selectedOrder = (Order)dgvOrders.SelectedRows[0].DataBoundItem;
        var confirmResult = MessageBox.Show("Are you sure you want to delete this order?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (confirmResult == DialogResult.Yes)
        {
            orderController.DeleteOrder(selectedOrder.Id);
            LoadOrders();
        }
    }
    else
    {
        MessageBox.Show("Please select an order to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}
private void btnEditOrder_Click(object sender, EventArgs e)
{
    if (dgvOrders.SelectedRows.Count > 0)
    {
        var selectedOrder = (Order)dgvOrders.SelectedRows[0].DataBoundItem;
        var editOrderForm = new AddEditOrderForm(selectedOrder);
        if (editOrderForm.ShowDialog() == DialogResult.OK)
        {
            orderController.UpdateOrder(editOrderForm.Order); // Utilisez les données mises à jour
            LoadOrders();
        }
    }
    else
    {
        MessageBox.Show("Please select an order to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}

private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide(); // Cacher le formulaire de gestion des clients
            CommercialDashboard commercialDashboard = new CommercialDashboard();
            commercialDashboard.Show(); // Ouvrir le tableau de bord admin
        }
    }
}
