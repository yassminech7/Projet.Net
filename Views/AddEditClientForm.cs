using System;
using System.Windows.Forms;
using ProjetCsharp.Models;

namespace ProjetCsharp.Views
{
    public partial class AddEditClientForm : Form
    {
        public Client Client { get; private set; }
        public bool IsEditMode { get; private set; }

        public AddEditClientForm(Client client = null)
        {
            InitializeComponent();

            if (client != null)
            {
                IsEditMode = true;
                Client = client;

                // Préremplir les champs pour le mode édition
                txtName.Text = client.Name;
                txtAddress.Text = client.Address;
                txtPhone.Text = client.Phone;
                Text = "Modifier un Client";
                btnSave.Text = "Modifier";
            }
            else
            {
                IsEditMode = false;
                Client = new Client();
                Text = "Ajouter un Client";
                btnSave.Text = "Ajouter";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Valider les champs
            if (string.IsNullOrWhiteSpace(txtName.Text) || 
                string.IsNullOrWhiteSpace(txtAddress.Text) || 
                string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs correctement.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mettre à jour l'objet Client
            Client.Name = txtName.Text;
            Client.Address = txtAddress.Text;
            Client.Phone = txtPhone.Text;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
