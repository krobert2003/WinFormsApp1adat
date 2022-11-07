using MySql.Data.MySqlClient;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace WinFormsApp1adat

{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "orszagok";
            MySqlConnection connection = new MySqlConnection(builder.ConnectionString);
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT id, orszag, fovaros, terulet,nepesseg, allamforma  FROM `orszagok` WHERE 1";
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Orszag orszag = new Orszag(dr.GetInt32("id"), dr.GetString("orszag"), dr.GetString("fovaros"), dr.GetDouble("terulet"), dr.GetDouble("nepesseg"), dr.GetString("allamforma"));
                        Listboxorszagok.Items.Add(orszag);
                    }
                }
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message+Environment.NewLine+"A program leáll");
                Environment.Exit(0);
                throw;
            }
        }

        private void Listboxorszagok_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Listboxorszagok.SelectedIndex<0)
            {
                return;

            }
            Orszag kivalasztottOrszag = (Orszag)Listboxorszagok.SelectedItem;
            textBox1.Text = kivalasztottOrszag.Id.ToString();
            textBox2.Text = kivalasztottOrszag.OrszagNev;
            textBox6.Text = kivalasztottOrszag.Allamforma;
            textBox5.Text = kivalasztottOrszag.Fovaros;
            textBox4.Text = kivalasztottOrszag.Terulet.ToString();
            textBox3.Text = kivalasztottOrszag.Nepesseg.ToString();

        }
    }
}