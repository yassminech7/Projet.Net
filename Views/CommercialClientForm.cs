using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ProjetCsharp.Controllers;
using ProjetCsharp.Models;

namespace ProjetCsharp.Views
{
    public partial class CommercialClientForm : Form
    {
        private ClientController clientController;

        public CommercialClientForm()
        {
            InitializeComponent();
            clientController = new ClientController();
            LoadClients(); // Charger les clients au démarrage
        }

        // Charger les clients dans le DataGridView
        private void LoadClients()
        {
            List<Client> clients = clientController.GetAllClients();
            dgvClients.DataSource = clients; // Liaison des données
        }

        // Ajouter un nouveau client
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new AddEditClientForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    clientController.AddClient(form.Client);
                    LoadClients(); // Recharger la liste
                }
            }
        }

        // Modifier le client sélectionné
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvClients.SelectedRows.Count > 0)
            {
                int id = (int)dgvClients.SelectedRows[0].Cells["Id"].Value;

                // Récupérer le client sélectionné
                var client = clientController.GetAllClients().Find(c => c.Id == id);

                using (var form = new AddEditClientForm(client))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        clientController.UpdateClient(form.Client);
                        LoadClients(); // Recharger la liste
                    }
                }
            }
        }

        // Supprimer le client sélectionné
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvClients.SelectedRows.Count > 0)
            {
                int id = (int)dgvClients.SelectedRows[0].Cells["Id"].Value;
                clientController.DeleteClient(id);
                LoadClients(); // Recharger la liste
            }
        }

        // Rechercher des clients
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text;
            List<Client> clients = clientController.SearchClients(searchTerm);
            dgvClients.DataSource = clients; // Mettre à jour la vue
        }

        // Méthode associée au bouton Retour
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide(); // Cacher le formulaire de gestion des clients
            CommercialDashboard commercialDashboard = new CommercialDashboard();
            commercialDashboard.Show(); // Ouvrir le tableau de bord admin
        }
    }
}
