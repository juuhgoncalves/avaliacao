using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;



namespace desafio_15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)

        {

            string conexao = "Data Source=(LocalDB)/MSSQLLocalDB;AttachDbFilename=C:/Users/Aluno/Downloads/conexao_bd_DS/meudatabase.mdf;Integrated Security=True";

            string comando_insert = "INSERT INTO cadastro (Nome, Idade, Curso, Matricula) VALUES (@VarNome, @VarIdade, @VarCurso, @VarMatricula)";
            SqlConnection con = null;


            try

            {
                con = new SqlConnection(conexao);

                con.Open();

                SqlCommand comand = new SqlCommand(comando_insert, con);

                comand.Parameters.AddWithValue("@VarNome", textBox1.Text);

                comand.Parameters.AddWithValue("@VarIdade", textBox2.Text);

                comand.Parameters.AddWithValue("@VarCurso", textBox3.Text);

                comand.Parameters.AddWithValue("@VarMatricula", textBox4.Text);


                comand.ExecuteNonQuery();

            }

            catch (Exception ex)

            {

                MessageBox.Show(ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            finally

            {

                if (con != null)

                {

                    con.Close();

                }

            }

        }



        private void button2_Click(object sender, EventArgs e)

        {

            string conexao = "Data Source=(LocalDB)/MSSQLLocalDB;AttachDbFilename=C:/Users/Aluno/Downloads/conexao_bd_DS/meudatabase.mdf;Integrated Security=True";

            string comando_consulta = "SELECT * FROM cadastro WHERE Matricula=@VarMatricula";

            SqlConnection con = null;



            try

            {

                con = new SqlConnection(conexao);

                SqlCommand comand = new SqlCommand(comando_consulta, con);

                comand.Parameters.AddWithValue("@VarMatricula", textBox4.Text);



                DataTable dt = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(comand);

                con.Open();

                adapter.Fill(dt);

                dataGridView1.DataSource = dt;

            }

            catch (Exception ex)

            {

                MessageBox.Show(ex.Message, "Exceção", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            finally

            {

                if (con != null)

                {

                    con.Close();

                }

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }

} 
  
