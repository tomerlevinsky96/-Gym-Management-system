using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp3;

namespace WindowsFormsApp4
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 f2 = new Form5();
            this.Hide();
            f2.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source = TARYA-ISR-204\MSSQLSERVER03; 
                                                     Initial Catalog =RuppinGYM_DB;
                                                     Integrated Security = true;
                                                        User id = MANAGER;
                                                       Password = Hefr12345678913;");
            sqlCon.Open();
            SqlCommand command = new SqlCommand(null, sqlCon);
            SqlParameter usermail = new SqlParameter("@userEmail2", SqlDbType.VarChar, 50);
            usermail.Value = Form2.SetValueForText;
            command.CommandText = "EXEC for_user_connected @userEmail=@userEmail2";
            command.Parameters.Add(usermail);
            command.Prepare();
            SqlDataReader reader = command.ExecuteReader();
            int indexquestion = 1;
            richTextBox1.Text = "connection number" + ' ' + "Connection date and time" + ' ' + "ConnectionState status" + "\r\n";
            while (reader.Read())
            {
                richTextBox1.Text = richTextBox1.Text + indexquestion.ToString().Trim() + "    ,                        " + reader[1].ToString().Trim() + "   ,    " + reader[2].ToString().Trim() + "\r\n";
                indexquestion++;
            }
            reader.Close();
            reader.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source = TARYA-ISR-204\MSSQLSERVER03; 
                                                     Initial Catalog =RuppinGYM_DB;
                                                     Integrated Security = true;
                                                        User id = MANAGER;
                                                       Password = Hefr12345678913;");
            sqlCon.Open();
            SqlCommand command = new SqlCommand(null, sqlCon);
            SqlParameter usermail = new SqlParameter("@userEmail2", SqlDbType.VarChar, 50);
            usermail.Value = Form2.SetValueForText;
            command.CommandText = "EXEC for_manager @userEmail=@userEmail2";
            command.Parameters.Add(usermail);
            command.Prepare();
            SqlDataReader reader = command.ExecuteReader();
            richTextBox2.Text = "User mail" + "\r\n";
            while (reader.Read())
            {
                richTextBox2.Text = richTextBox2.Text+reader[0].ToString().Trim() +  "\r\n";
            }
            reader.Close();
            reader.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(@"Data Source = TARYA-ISR-204\MSSQLSERVER03; 
                                                     Initial Catalog =RuppinGYM_DB;
                                                     Integrated Security = true;
                                                        User id = MANAGER;
                                                       Password = Hefr12345678913;");
                sqlCon.Open();
                SqlCommand command = new SqlCommand(null, sqlCon);
                SqlParameter usermail = new SqlParameter("@userEmail2", SqlDbType.VarChar, 50);
                usermail.Value = Form2.SetValueForText;
                command.CommandText = "EXEC for_manager2 @userEmail=@userEmail2";
                command.Parameters.Add(usermail);
                command.Prepare();
                SqlDataReader reader = command.ExecuteReader();
                richTextBox3.Text = "User mail" + "    " + "User first name " + "    " + "User last name" + "     " + "Connection Date and hour" + "     " + "\r\n";
                while (reader.Read())
                {
                    richTextBox3.Text = richTextBox3.Text + reader[0].ToString().Trim() + "   ,    " + reader[1].ToString().Trim() + "   ,    " + reader[2].ToString().Trim() + " ,   " + reader[3].ToString().Trim() + "\r\n";
                }
                reader.Close();
                reader.Dispose();
            }
            catch
            {

            }
        }
    }
}
