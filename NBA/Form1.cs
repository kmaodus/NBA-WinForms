using NBA.NBAklase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NBA
{
    public partial class NBA : Form
    {
        public NBA()
        {
            InitializeComponent();
        }
        Klub k = new Klub();

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            k.Naziv = textBoxNaziv.Text;
            k.Grad = textBoxGrad.Text;
            k.SaveznaDrzavaID = textBoxState.Text;
            k.KonferencijaID = comboBoxKonferencija.Text;
            k.DivizijaID = comboBoxDivizija.Text;
            k.Trener = textBoxTrener.Text;

            bool success = k.Insert(k);
            if (success == true)
            {
                MessageBox.Show("Uspjesno ste dodali klub!");
                Clear();
            }
            else
            {
                MessageBox.Show("Neuspjesan unos. Pokusajte ponovno!");
            }
            DataTable dt = k.Select();
            dataGridView1.DataSource = dt;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DataTable dt = k.Select();
            dataGridView1.DataSource = dt;
        }

        private void textBoxNaziv_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxKonferencija_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void Clear()
        {
            textBoxNaziv.Text = "";
            textBoxGrad.Text = "";
            textBoxState.Text = "";
            comboBoxKonferencija.Text = "";
            comboBoxDivizija.Text = "";
            textBoxTrener.Text = "";
        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex; 
            textBoxKlubID.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            textBoxNaziv.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            textBoxGrad.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            textBoxState.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
            comboBoxKonferencija.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
            comboBoxDivizija.Text = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
            textBoxTrener.Text = dataGridView1.Rows[rowIndex].Cells[6].Value.ToString();
        }

        private void Kucica_pritisnuta(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            textBoxKlubID.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            textBoxNaziv.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            textBoxGrad.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            textBoxState.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
            comboBoxKonferencija.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
            comboBoxDivizija.Text = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
            textBoxTrener.Text = dataGridView1.Rows[rowIndex].Cells[6].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            k.KlubID = int.Parse(textBoxKlubID.Text);
            k.Naziv = textBoxNaziv.Text;
            k.Grad = textBoxGrad.Text;
            k.SaveznaDrzavaID = textBoxState.Text;
            k.KonferencijaID = comboBoxKonferencija.Text;
            k.DivizijaID = comboBoxDivizija.Text;
            k.Trener = textBoxTrener.Text;

            bool success = k.Delete(k);
            if (success == true)
            {
                MessageBox.Show("Uspjesno ste obrisali klub!");
                Clear(); 
            }
            else
            {
                MessageBox.Show("Neuspjesan pokušaj brisanja. Pokusajte ponovno!");
            }
            DataTable dt = k.Select();
            dataGridView1.DataSource = dt;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            k.KlubID = int.Parse(textBoxKlubID.Text);
            k.Naziv = textBoxNaziv.Text;
            k.Grad = textBoxGrad.Text;
            k.SaveznaDrzavaID = textBoxState.Text;
            k.KonferencijaID = comboBoxKonferencija.Text;
            k.DivizijaID = comboBoxDivizija.Text;
            k.Trener = textBoxTrener.Text;

            bool success = k.Update(k);
            if (success == true)
            {
                MessageBox.Show("Uspjesno ste azurirali klub!");
                Clear();
            }
            else
            {
                MessageBox.Show("Neuspjesan pokusaj azuriranja. Pokusajte ponovno!");
            }
            DataTable dt = k.Select();
            dataGridView1.DataSource = dt;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBoxKlubID.Text = string.Empty;
            Clear();
        }

        private void NBA_Load(object sender, EventArgs e)
        {

        }
    }
}
