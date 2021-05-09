using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contact_Book_CS_2017_020
{
    public partial class Form1 : Form
    {
        int Rowclick;
        DataTable table = new DataTable();

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GridView.ColumnHeadersVisible = false;
            GridView.RowHeadersVisible = false;

            table.Columns.Add("ContactName");
            table.Columns.Add("Number1");
            table.Columns.Add("Number2");
            table.Columns.Add("Number3");
            GridView.DataSource = table;

            StreamReader phonebook = new StreamReader("phonebook.txt");

            String newline;
            while ((newline = phonebook.ReadLine()) != null)
            {
                DataRow rowData = table.NewRow();
                string[] values;
                values = newline.Split('|');
                for (int i = 0; i < values.Length; i++)
                {
                    rowData[i] = values[i];

                }
                table.Rows.Add(rowData);
            }
            phonebook.Close();
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            table.Rows.Add(txtCName.Text, txtN1.Text, txtN2.Text, txtN3.Text);
            GridView.DataSource = table;
            MessageBox.Show("Record inserted Successfully", "Message");
            txtCName.Clear();
            txtN1.Clear();
            txtN2.Clear();
            txtN3.Clear();

            StreamWriter write = new StreamWriter(@"phonebook.txt");
            int i;
            for (i=0 ; i < GridView.Rows.Count - 1; i++)
            {
                int j;
                for (j = 0; j < GridView.Columns.Count - 1; j++)
                {
                    write.Write(GridView.Rows[i].Cells[j].Value.ToString() + "\t" + "|");

                }
                write.Write(GridView.Rows[i].Cells[j].Value.ToString() + "\t");
                write.WriteLine("");

            }
            write.Close();

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewRow newRow = GridView.Rows[Rowclick];
            newRow.Cells[0].Value = CName.Text;
            newRow.Cells[1].Value = N1.Text;
            newRow.Cells[2].Value = N2.Text;
            newRow.Cells[3].Value = N3.Text;


            TextWriter write = new StreamWriter("phonebook.txt");
            int i = 0;
            for (; i < GridView.Rows.Count - 1; i++)
            {
                int j = 0;
                for (; j < GridView.Columns.Count - 1; j++)
                {
                    write.Write(GridView.Rows[i].Cells[j].Value.ToString() + "\t" + "|");

                }
                write.Write(GridView.Rows[i].Cells[j].Value.ToString() + "\t");
                write.WriteLine("");

            }
            write.Close();
            CName.Text = "";
            N1.Text = "";
            N2.Text = "";
            N3.Text = "";
            MessageBox.Show("Record updated Successfully", "Message");
        }

        private void GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DataView abs = table.DefaultView;
            abs.RowFilter = "ContactName LIKE '" + txtsearch.Text + "%' OR Number1 LIKE '" + txtsearch.Text + "%' OR Number2 LIKE '" + txtsearch.Text + "%' OR Number3 LIKE '" + txtsearch.Text + "%'";
            GridView.DataSource = abs;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Rowclick = GridView.CurrentCell.RowIndex;
            GridView.Rows.RemoveAt(Rowclick);

            TextWriter write = new StreamWriter("phonebook.txt");
            int i = 0;
            for (; i < GridView.Rows.Count - 1; i++)
            {
                int j = 0;
                for (; j < GridView.Columns.Count - 1; j++)
                {
                    write.Write(GridView.Rows[i].Cells[j].Value.ToString() + "\t" + "|");

                }
                write.Write(GridView.Rows[i].Cells[j].Value.ToString() + "\t");
                write.WriteLine("");

            }
            write.Close();
            CName.Text = "";
            N1.Text = "";
            N2.Text = "";
            N3.Text = "";
            MessageBox.Show("Record deleted Successfully", "Message");
        }

        private void GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Rowclick = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow rows = this.GridView.Rows[Rowclick];

                CName.Text = rows.Cells[0].Value.ToString();
                N1.Text = rows.Cells[1].Value.ToString();
                N2.Text = rows.Cells[2].Value.ToString();
                N3.Text = rows.Cells[3].Value.ToString();
            }
        }

        private void txtN1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtN1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }

        private void txtN2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtN3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
