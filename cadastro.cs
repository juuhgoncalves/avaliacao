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
    public partial class cadastro : Form
    {
        public cadastro()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string conexao = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename =C:\\Users\\Aluno\\Desktop\\desafio 15\\Database1.mdf; Integrated Security = True";

            string comando = "INSERT INTO cadastrar (CPF, Login, Senha) VALUES (@VarCPF, @VarLogin, @VarSenha)";
            SqlConnection con = null;


            try

            {
                con = new SqlConnection(conexao);
                SqlCommand comand = new SqlCommand(comando, con);

                comand.Parameters.AddWithValue("@VarCPF", maskedTextBox2.Text);

                comand.Parameters.AddWithValue("@VarLogin", textBox1.Text);

                comand.Parameters.AddWithValue("@VarSenha", maskedTextBox1.Text);

       


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
                    login frm3 = new login();
                    frm3.Show();
                    //Referencia.Show();
                    this.Close();
                }

            }

        
        }
    }
}
