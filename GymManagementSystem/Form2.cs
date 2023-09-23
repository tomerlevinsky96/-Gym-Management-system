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
using WindowsFormsApp4;
namespace WindowsFormsApp3
{
    public partial class Form2 : Form
    {
        public static string SetValueForText = "";
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(@"Data Source = TARYA-ISR-204\MSSQLSERVER03; 
                                                         Initial Catalog =RuppinGYM_DB;
                                                         Integrated Security = true;
                                                         User id = Trainee;
                                                         Password = Hefr1234678;");
                sqlCon.Open();
                SqlCommand command = new SqlCommand(null, sqlCon);
                SqlParameter usermail = new SqlParameter("@userEmail1", SqlDbType.Text, 50);
                SqlParameter usermail2 = new SqlParameter("@userEmail2", SqlDbType.VarChar, 50);
                SqlParameter PasswordUser = new SqlParameter("@PasswordUser1", SqlDbType.Text, 50);
                command.CommandText = "EXEC USER_AND_PASSWORD_Trainee @userEmail=@userEmail1,@PasswordUser=@PasswordUser1";
                usermail.Value = Usermail.Text;
                SetValueForText = Usermail.Text;
                PasswordUser.Value = textBox1.Text;
                command.Parameters.Add(usermail);
                command.Parameters.Add(PasswordUser);
                command.Prepare();
                command.ExecuteNonQuery();
                usermail2.Value = Usermail.Text;
                command.CommandText = "select top 1 * from  LogTable as LT where LT.UserEmailConnected=@userEmail2  order by LT.ConnectionDateAndHour desc";
                command.Parameters.Add(usermail2);
                command.Prepare();
                SqlDataReader reader3 = command.ExecuteReader();
                string status;
                while (reader3.Read())
                {
                    status = reader3[3].ToString();
                    if (status == "S")
                    {
                        MessageBox.Show("The User name and Password you entered is correct.Please press OK to continue");
                        Form3 f3 = new Form3();
                        this.Hide();
                        f3.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("The User name or Password you entered is incorrect.Please try again");
                        break;
                    }
                }
            }
            catch
            {
                MessageBox.Show("The User name or Password you entered is incorrect.Please try again");
                Form2 f2 = new Form2();
                this.Hide();
                f2.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            this.Hide();
            f4.ShowDialog();
        }
        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection sqlCon = new SqlConnection(@"Data Source =TARYA-ISR-204\MSSQLSERVER03; 
                                                         Initial Catalog =RuppinGYM_DB;
                                                         Integrated Security = true;
                                                         User id = MANAGER;
                                                         Password = Hefr12345678913;");
                sqlCon.Open();
                SqlCommand command = new SqlCommand(null, sqlCon);
                SqlParameter usermail = new SqlParameter("@userEmail1", SqlDbType.Text, 50);
                SqlParameter usermail2 = new SqlParameter("@userEmail2", SqlDbType.VarChar, 50);
                SqlParameter PasswordUser = new SqlParameter("@PasswordUser1", SqlDbType.Text, 50);
                command.CommandText = "EXEC USER_AND_PASSWORD_MANAGER @userEmail=@userEmail1,@PasswordUser=@PasswordUser1";
                usermail.Value = Usermail.Text;
                SetValueForText = Usermail.Text;
                PasswordUser.Value = textBox1.Text;
                command.Parameters.Add(usermail);
                command.Parameters.Add(PasswordUser);
                command.Prepare();
                command.ExecuteNonQuery();
                usermail2.Value = Usermail.Text;
                command.CommandText = "select top 1 * from  LogTable as LT where LT.UserEmailConnected=@userEmail2  order by LT.ConnectionDateAndHour desc";
                command.Parameters.Add(usermail2);
                command.Prepare();
                SqlDataReader reader3 = command.ExecuteReader();
                string status;
                while (reader3.Read())
                {
                    status = reader3[3].ToString();
                    if (status == "S")
                    {
                        MessageBox.Show("The User name and Password you entered is correct.Please press OK to continue");
                        Form5 f3 = new Form5();
                        this.Hide();
                        f3.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("The User name or Password you entered is incorrect.Please try again");
                        break;
                    }
                }
            }
            catch
            {
                MessageBox.Show("The User name or Password you entered is incorrect.Please try again");
                Form5 f2 = new Form5();
                this.Hide();
                f2.ShowDialog();
            }
        }  
        private void button5_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection sqlCon = new SqlConnection(@"Data Source = TARYA-ISR-204\MSSQLSERVER03; 
                                                         Initial Catalog =RuppinGYM_DB;
                                                         Integrated Security = true;
                                                         User id = Trainer;
                                                         Password = Hefr123456789;");
                sqlCon.Open();
                SqlCommand command = new SqlCommand(null, sqlCon);
                SqlParameter usermail = new SqlParameter("@userEmail1", SqlDbType.Text, 50);
                SqlParameter usermail2 = new SqlParameter("@userEmail2", SqlDbType.VarChar, 50);
                SqlParameter PasswordUser = new SqlParameter("@PasswordUser1", SqlDbType.Text, 50);
                command.CommandText = "EXEC USER_AND_PASSWORD_Trainer @userEmail=@userEmail1,@PasswordUser=@PasswordUser1";
                usermail.Value = Usermail.Text;
                SetValueForText = Usermail.Text;
                PasswordUser.Value = textBox1.Text;
                command.Parameters.Add(usermail);
                command.Parameters.Add(PasswordUser);
                command.Prepare();
                command.ExecuteNonQuery();
                usermail2.Value = Usermail.Text;
                command.CommandText = "select top 1 * from  LogTable as LT where LT.UserEmailConnected=@userEmail2  order by LT.ConnectionDateAndHour desc";
                command.Parameters.Add(usermail2);
                command.Prepare();
                SqlDataReader reader3 = command.ExecuteReader();
                string status;
                while (reader3.Read())
                {
                    status = reader3[3].ToString();
                    if (status == "S")
                    {
                        MessageBox.Show("The User name and Password you entered is correct.Please press OK to continue");
                        Form6 f3 = new Form6();
                        this.Hide();
                        f3.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("The User name or Password you entered is incorrect.Please try again");
                        break;
                    }
                }
            }
            catch
            {
                MessageBox.Show("The User name or Password you entered is incorrect.Please try again");
                Form2 f2 = new Form2();
                this.Hide();
                f2.ShowDialog();
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Form1 f2 = new Form1();
            this.Hide();
            f2.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
    }
}
        
    


