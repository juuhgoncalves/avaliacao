using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace desafio_15
{
    public partial class login : Form
    {

        private string logincorreto;
        private string senhacorreta;

        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string conexao = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C: \\Users\\Aluno\\Desktop\\desafio 15\\Database1.mdf;Integrated Security=True";
            string query = "SELECT Login, Senha FROM Usuarios WHERE CPF==maskedTextBox2.Text";

            SqlConnection con = null;

            try

            {

                con = new SqlConnection(conexao);

                SqlCommand comand = new SqlCommand(query, con);
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        logincorreto = reader["Login"].ToString();
                        senhacorreta = reader["Senha"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Usuário não encontrado no banco de dados.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message);
            }



            if (textBox1.Text == logincorreto && maskedTextBox1.Text == senhacorreta)
            {
                MessageBox.Show("Acesso liberado");
                Form1 frm1 = new Form1();
                frm1.Show();
                //Referencia.Show();
                this.Close();
            }
            else if (textBox1.Text == "" || maskedTextBox1.Text == "")
            {
                MessageBox.Show("Digite as informações requisitadas!");
            }

            else if (textBox1.Text != logincorreto || maskedTextBox1.Text != senhacorreta)
            {
                MessageBox.Show("informações incorretas");
            }
        }

        public Form Referencia { get; set; }
        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            cadastro frm2 = new cadastro();
            frm2.Show();
            //Referencia.Show();
            this.Close();
        }
    }
}

