using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SqlToGrid
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=remotemysql.com; Port=3306; Database=GuiiqZpv0C; Uid=GuiiqZpv0C; Pwd=NVJ658aHjO";
            MySqlConnection sc = new MySqlConnection(connectionString);
            sc.Open();

            string command = "desc table1";
            MySqlCommand comm = new MySqlCommand(command, sc);
            MySqlDataReader reader = comm.ExecuteReader();

       //     string out_put = "";

            this.Width = 800;
            this.Height = 450;
            dataGridView1.Width = 50;

            dataGridView1 = new DataGridView();
            this.dataGridView1.Location = new System.Drawing.Point(13, 42);
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 1;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
          this.SuspendLayout();//???
            this.Controls.Add(dataGridView1);

            int _i = 0;
            while (reader.Read())
            {
                dataGridView1.Columns.Add("string", reader.GetValue(0).ToString());
                dataGridView1.Width += dataGridView1.Columns[_i++].Width;
            }

            reader.Close();
            comm.Dispose();

            command = "select * from table1";
            comm = new MySqlCommand(command, sc);
            reader = comm.ExecuteReader();

            while (reader.Read())
            {
                string[] list = new string[dataGridView1.ColumnCount];
                
                for (int i = 0; i < reader.FieldCount; ++i)
                {
                    list[i] = reader.GetValue(i).ToString();
                }

                dataGridView1.Rows.Add(list);
            }

           // MessageBox.Show(out_put);
            // https://webphpmyadmin.com/sql.php?server=1&db=GuiiqZpv0C&table=table1&pos=0

            reader.Close();
            comm.Dispose();
            sc.Close();
        }
    }
}
