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

            string command = "select * from table1";
            MySqlCommand comm = new MySqlCommand(command, sc);
            MySqlDataReader reader = comm.ExecuteReader();

            string out_put = "";

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; ++i)
                {
                    out_put += (reader.GetValue(i) + " ");
                }
                out_put += "\n";
            }

            //            MessageBox.Show(out_put);
            // https://webphpmyadmin.com/sql.php?server=1&db=GuiiqZpv0C&table=table1&pos=0

            label1.Text = out_put;

            reader.Close();
            comm.Dispose();
            sc.Close();
        }
    }
}
