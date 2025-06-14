
using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GestionEtudiantsCRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ChargerEtudiants();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand cmd = new MySqlCommand(
                "INSERT INTO etudiants(nom, prenom, email) VALUES (@nom, @prenom, @email)",
                db.GetConnection());

            cmd.Parameters.AddWithValue("@nom", txtNom.Text);
            cmd.Parameters.AddWithValue("@prenom", txtPrenom.Text);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);

            db.OpenConnection();
            if (cmd.ExecuteNonQuery() == 1)
                MessageBox.Show("Ajout réussi !");
            else
                MessageBox.Show("Erreur !");
            db.CloseConnection();
            ChargerEtudiants();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                DB db = new DB();
                MySqlCommand cmd = new MySqlCommand(
                    "UPDATE etudiants SET nom=@nom, prenom=@prenom, email=@email WHERE id=@id",
                    db.GetConnection());

                cmd.Parameters.AddWithValue("@nom", txtNom.Text);
                cmd.Parameters.AddWithValue("@prenom", txtPrenom.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@id", id);

                db.OpenConnection();
                cmd.ExecuteNonQuery();
                db.CloseConnection();
                MessageBox.Show("Modification réussie !");
                ChargerEtudiants();
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                DB db = new DB();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM etudiants WHERE id=@id", db.GetConnection());
                cmd.Parameters.AddWithValue("@id", id);

                db.OpenConnection();
                cmd.ExecuteNonQuery();
                db.CloseConnection();
                MessageBox.Show("Suppression réussie !");
                ChargerEtudiants();
            }
        }

        private void ChargerEtudiants()
        {
            DB db = new DB();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM etudiants", db.GetConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtNom.Text = row.Cells[1].Value.ToString();
                txtPrenom.Text = row.Cells[2].Value.ToString();
                txtEmail.Text = row.Cells[3].Value.ToString();
            }
        }

        private void txtNom_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
