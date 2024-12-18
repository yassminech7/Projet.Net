using System;
using System.Windows.Forms;
using ProjetCsharp.Controllers;
using ProjetCsharp.Models;

namespace ProjetCsharp.Views
{
    public partial class AdminOrderForm : Form
    {
        private OrderController orderController;

        public AdminOrderForm()
        {
            InitializeComponent();
            orderController = new OrderController();
            LoadOrders();
        }

        private void LoadOrders()
        {
            dgvOrders.DataSource = null;
            dgvOrders.DataSource = orderController.GetAllOrders();

            // Éviter l'ajout multiple de l'événement
            dgvOrders.CellContentClick -= dgvOrders_CellContentClick;
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
                var selectedOrder = (Order)dgvOrders.Rows[e.RowIndex].DataBoundItem;
                ShowOrderItems(selectedOrder);
            }
        }

        private void ShowOrderItems(Order order)
        {
            var itemsForm = new Form
            {
                Text = "Order items",
                Size = new System.Drawing.Size(800, 500),
                StartPosition = FormStartPosition.CenterScreen
            };

            var itemsDataGridView = new DataGridView
            {
                Dock = DockStyle.Top,
                Height = 400,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            itemsForm.Controls.Add(itemsDataGridView);

            itemsDataGridView.Columns.Add("ArticleName", "Item");
            itemsDataGridView.Columns.Add("Quantity", "Quantity");

            var editButtonColumn = new DataGridViewButtonColumn
            {
                Name = "EditQuantity",
                HeaderText = "Action",
                Text = "Edit",
                UseColumnTextForButtonValue = true,
                Width = 100
            };
            itemsDataGridView.Columns.Add(editButtonColumn);

            var deleteButtonColumn = new DataGridViewButtonColumn
            {
                Name = "DeleteItem",
                HeaderText = "Action",
                Text = "Delete",
                UseColumnTextForButtonValue = true,
                Width = 100
            };
            itemsDataGridView.Columns.Add(deleteButtonColumn);

            foreach (var item in order.OrderItems)
            {
                itemsDataGridView.Rows.Add(item.ArticleName, item.Quantity);
            }

            itemsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            itemsDataGridView.AllowUserToAddRows = false;

            itemsDataGridView.CellContentClick += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    var selectedItem = order.OrderItems[e.RowIndex];

                    if (e.ColumnIndex == itemsDataGridView.Columns["EditQuantity"].Index)
                    {
                        var input = Microsoft.VisualBasic.Interaction.InputBox(
                            "Enter the new quantity :",
                            "Change quantity",
                            selectedItem.Quantity.ToString()
                        );

                        if (int.TryParse(input, out int newQuantity) && newQuantity > 0)
                        {
                            selectedItem.Quantity = newQuantity;
                            itemsDataGridView.Rows[e.RowIndex].Cells["Quantity"].Value = newQuantity;
                            orderController.UpdateOrderItem(order.Id, selectedItem);
                        }
                        else
                        {
                            MessageBox.Show("Invalid quantity.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (e.ColumnIndex == itemsDataGridView.Columns["DeleteItem"].Index)
                    {
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
                            orderController.DeleteOrderItem(order.Id, selectedItem.ArticleId);
                        }
                    }
                }
            };

            var okButton = new Button
            {
                Text = "Close",
                Width = 100,
                Height = 40,
                Left = (itemsForm.ClientSize.Width - 100) / 2,
                Top = itemsDataGridView.Bottom + 10
            };
            okButton.Click += (s, e) => itemsForm.Close();

            itemsForm.Controls.Add(okButton);
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
                    orderController.UpdateOrder(editOrderForm.Order);
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
            this.Hide();
            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.Show();
        }
    }
}
