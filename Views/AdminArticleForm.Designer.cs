namespace ProjetCsharp.Views
{
    partial class AdminArticleForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
private System.Windows.Forms.Button btnBack;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur.
        /// </summary>
       private void InitializeComponent()
{
    this.dgvArticles = new System.Windows.Forms.DataGridView();
    this.txtSearch = new System.Windows.Forms.TextBox();
    this.btnSearch = new System.Windows.Forms.Button();
    this.btnAdd = new System.Windows.Forms.Button();
    this.btnEdit = new System.Windows.Forms.Button();
    this.btnDelete = new System.Windows.Forms.Button();
    this.btnBack = new System.Windows.Forms.Button(); // Bouton Retour ajouté
    this.lblSearch = new System.Windows.Forms.Label();
    ((System.ComponentModel.ISupportInitialize)(this.dgvArticles)).BeginInit();
    this.SuspendLayout();

    // 
    // dgvArticles
    // 
    this.dgvArticles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
    this.dgvArticles.Location = new System.Drawing.Point(30, 70);
    this.dgvArticles.Name = "dgvArticles";
    this.dgvArticles.Size = new System.Drawing.Size(600, 250);
    this.dgvArticles.TabIndex = 0;
    this.dgvArticles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

    // 
    // txtSearch
    // 
    this.txtSearch.Location = new System.Drawing.Point(380, 30);
    this.txtSearch.Name = "txtSearch";
    this.txtSearch.Size = new System.Drawing.Size(150, 20);
    this.txtSearch.TabIndex = 1;

    // 
    // btnSearch
    // 
    this.btnSearch.Location = new System.Drawing.Point(540, 28);
    this.btnSearch.Name = "btnSearch";
    this.btnSearch.Size = new System.Drawing.Size(90, 25);
    this.btnSearch.TabIndex = 2;
    this.btnSearch.Text = "Search";
    this.btnSearch.UseVisualStyleBackColor = true;
    this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

    // 
    // btnAdd
    // 
    this.btnAdd.Location = new System.Drawing.Point(30, 340);
    this.btnAdd.Name = "btnAdd";
    this.btnAdd.Size = new System.Drawing.Size(100, 30);
    this.btnAdd.TabIndex = 3;
    this.btnAdd.Text = "Add";
    this.btnAdd.UseVisualStyleBackColor = true;
    this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

    // 
    // btnEdit
    // 
    this.btnEdit.Location = new System.Drawing.Point(140, 340);
    this.btnEdit.Name = "btnEdit";
    this.btnEdit.Size = new System.Drawing.Size(100, 30);
    this.btnEdit.TabIndex = 4;
    this.btnEdit.Text = "Edit";
    this.btnEdit.UseVisualStyleBackColor = true;
    this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

    // 
    // btnDelete
    // 
    this.btnDelete.Location = new System.Drawing.Point(250, 340);
    this.btnDelete.Name = "btnDelete";
    this.btnDelete.Size = new System.Drawing.Size(100, 30);
    this.btnDelete.TabIndex = 5;
    this.btnDelete.Text = "Delete";
    this.btnDelete.UseVisualStyleBackColor = true;
    this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

    // 
    // btnBack
    // 
    this.btnBack.Location = new System.Drawing.Point(360, 340);
    this.btnBack.Name = "btnBack";
    this.btnBack.Size = new System.Drawing.Size(100, 30);
    this.btnBack.TabIndex = 6;
    this.btnBack.Text = "Back";
    this.btnBack.UseVisualStyleBackColor = true;
    this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

    // 
    // lblSearch
    // 
    this.lblSearch.AutoSize = true;
    this.lblSearch.Location = new System.Drawing.Point(310, 33);
    this.lblSearch.Name = "lblSearch";
    this.lblSearch.Size = new System.Drawing.Size(64, 13);
    this.lblSearch.TabIndex = 7;
    this.lblSearch.Text = "Search :";

    // 
    // AdminArticleForm
    // 
    this.ClientSize = new System.Drawing.Size(800, 450);
    this.Controls.Add(this.dgvArticles);
    this.Controls.Add(this.txtSearch);
    this.Controls.Add(this.btnSearch);
    this.Controls.Add(this.btnAdd);
    this.Controls.Add(this.btnEdit);
    this.Controls.Add(this.btnDelete);
    this.Controls.Add(this.btnBack); // Ajouter le bouton Retour
    this.Controls.Add(this.lblSearch);
    this.Name = "AdminArticleForm";
    this.Text = "Manage Articles - Administrateur";
    this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
    this.ResumeLayout(false);
    this.PerformLayout();
}



        #endregion

        private System.Windows.Forms.DataGridView dgvArticles;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblSearch;
    }
}
