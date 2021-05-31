using System;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TBD_FILM
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection = null;
        private SqlDataAdapter dataAdapter = null;
        private DataSet dataSet = null;
        private SqlCommand command = null;
        private void view(string str)
        {
            dataAdapter = new SqlDataAdapter(str, sqlConnection);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
            dataAdapter.Dispose();
            dataSet.Dispose();
        }
        private void procedure(string str)
        {
            command = new SqlCommand(str, sqlConnection);
            if (command.ExecuteNonQuery().ToString() == "-1")
            {
                MessageBox.Show("Ошибка!");
            }
            else
            {
                MessageBox.Show("Успешно!");
            }
            command.Dispose();
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FILMDB"].ConnectionString);
            sqlConnection.Open();
            if (sqlConnection.State == ConnectionState.Open)
            {
                MessageBox.Show("Подключение к БД установлено");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            procedure($"INSERT INTO t_places(f_name, f_category, f_halls)VALUES(N'{textBox1.Text}', N'{textBox2.Text}', N'{textBox3.Text}');");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            procedure($"EXECUTE p_sessions @new_hall = N'{textBox4.Text}', @new_film = N'{textBox5.Text}', @new_data = N'{textBox6.Text}';");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            procedure($"EXECUTE p_tickets @new_place = N'{textBox7.Text}', @new_session = N'{textBox8.Text}', @new_status = N'{textBox9.Text}';");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            procedure($"EXECUTE p_sales @new_ticket = N'{textBox10.Text}', @new_employee = N'{textBox11.Text}', @new_price = N'{textBox12.Text}';");
        }
        private void button5_Click(object sender, EventArgs e)
        {
            view("select * from v_places");
        }
        private void button6_Click(object sender, EventArgs e)
        {
            view("select * from v_place_categories");
        }
        private void button7_Click(object sender, EventArgs e)
        {
            view("select * from v_sessions");
        }
        private void button8_Click(object sender, EventArgs e)
        {
            view("select * from v_films");
        }
        private void button9_Click(object sender, EventArgs e)
        {
            view("select * from v_halls");
        }
        private void button10_Click(object sender, EventArgs e)
        {
            view("select * from v_tickets");
        }
        private void button11_Click(object sender, EventArgs e)
        {
            view("select * from v_ticket_statuses");
        }
        private void button12_Click(object sender, EventArgs e)
        {
            view("select * from v_sales");
        }
        private void button13_Click(object sender, EventArgs e)
        {
            view("select * from v_employees");
        }
    }
}
