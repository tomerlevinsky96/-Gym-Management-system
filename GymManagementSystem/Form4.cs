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

namespace WindowsFormsApp3
{
    public partial class Form4 : Form
    {
        SqlParameter[] AnsNUM = {
                                  new SqlParameter("@AnsNum1", SqlDbType.Int, 0),
                                  new SqlParameter("@AnsNum2", SqlDbType.Int, 0),
                                  new SqlParameter("@AnsNum3", SqlDbType.Int, 0) };
        SqlParameter[] AnsUser = {
                     new SqlParameter("@ans1", SqlDbType.VarChar, 50),
                     new SqlParameter("@ans2", SqlDbType.VarChar, 50),
                     new SqlParameter("@ans3", SqlDbType.VarChar, 50) };
        SqlParameter[] AnsText = {
                     new SqlParameter("@anser1", SqlDbType.VarChar, 50),
                     new SqlParameter("@anser2", SqlDbType.VarChar, 50),
                     new SqlParameter("@anser3", SqlDbType.VarChar, 50) };
        
        SqlParameter NewPassword = new SqlParameter("@NewPassword", SqlDbType.VarChar, 20);
        SqlParameter usermail3 = new SqlParameter("@userEmail3", SqlDbType.VarChar, 50);
        public Form4()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            try
            {
                SqlParameter usermail = new SqlParameter("@userEmail1", SqlDbType.VarChar, 50);
                SqlParameter usermail1 = new SqlParameter("@userEmail15", SqlDbType.VarChar, 50);
                SqlParameter usermail2 = new SqlParameter("@userEmail2", SqlDbType.VarChar, 50);
                SqlParameter[] questionNUM = {
                                  new SqlParameter("@questionNum1", SqlDbType.Int, 0),
                                  new SqlParameter("@questionNum2", SqlDbType.Int, 0),
                                  new SqlParameter("@questionNum3", SqlDbType.Int, 0) };
                SqlConnection sqlCon = new SqlConnection(@"Data Source =  TARYA-ISR-204\MSSQLSERVER03; 
                                                         Initial Catalog =RuppinGYM_DB;
                                                         Integrated Security = true;
                                                         User id = Trainee;
                                                         Password = Hefr1234678;");

                sqlCon.Open();

                SqlCommand command = new SqlCommand(null, sqlCon);
                usermail.Value = richTextBox1.Text;
                usermail1.Value = richTextBox1.Text;
                command.CommandText = "Select * From Trainee as T where T.userEmail=@userEmail15";
                command.Parameters.Add(usermail1);
                command.Prepare();
                SqlDataReader reader1 = command.ExecuteReader();
                if(reader1.Read()==false)
                {
                    MessageBox.Show("The User email is inncorrect");
                    Form2 f2 = new Form2();
                    this.Hide();
                    f2.ShowDialog();
                }
                int[] array1 = new int[3];
                Random rnd = new Random();
                int flag = 1;
                int num;
                for (int i = 0; i < array1.Length; i++)
                {
                    num = rnd.Next(1, 5);
                    flag = 1;
                    while (flag == 1)
                    {
                        flag = 0;
                        for (int j = 0; j < array1.Length; j++)
                        {
                            if (array1[j] == num)
                            {
                                flag = 1;
                                num = rnd.Next(1, 5);
                            }
                        }
                    }
                    array1[i] = num;
                }
                for (int i = 0; i < 3; i++)
                {
                    questionNUM[i].Value = array1[i];
                }
                reader1.Close();
                reader1.Dispose();
                command.CommandText = "Select * From QuestionsForUser as Q where Q.userEmail=@userEmail1 and (Q.questionNumForUser=@questionNum1 or Q.questionNumForUser=@questionNum2 or Q.questionNumForUser=@questionNum3)";
                command.Parameters.Add(usermail);
                for (int i = 0; i < 3; i++)
                {
                    command.Parameters.Add(questionNUM[i]);
                }
                command.Prepare();
                SqlDataReader reader = command.ExecuteReader();
                int indexquestion = 1;
                while (reader.Read())
                {
                    richTextBox2.Text = richTextBox2.Text + indexquestion.ToString().Trim() + reader[2].ToString().Trim() + "\r\n";
                    indexquestion++;
                }
                reader.Close();
                reader.Dispose();
                command.CommandText = "Select * From Answers as A where A.userEmail=@userEmail1 and (A.AnsNum=@AnsNum1 or A.AnsNum=@AnsNum2 or A.AnsNum=@AnsNum3)";
                for (int i = 0; i < 3; i++)
                {
                    AnsNUM[i].Value = array1[i];
                }
                usermail2.Value = richTextBox1.Text;
                command.Parameters.Add(usermail2);
                for (int i = 0; i < 3; i++)
                {
                    command.Parameters.Add(AnsNUM[i]);
                }
                command.Prepare();
                SqlDataReader reader2 = command.ExecuteReader();
                indexquestion = 1;
                while (reader2.Read())
                {
                    AnsUser[indexquestion - 1].Value = reader2[2].ToString().Trim();
                    indexquestion++;
                }
            }
            catch
            {
                MessageBox.Show("The User email is inncorrect");
                Form2 f2 = new Form2();
                this.Hide();
                f2.ShowDialog();
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlParameter[] AnsText = {
                     new SqlParameter("@anser1", SqlDbType.VarChar, 50),
                     new SqlParameter("@anser2", SqlDbType.VarChar, 50),
                     new SqlParameter("@anser3", SqlDbType.VarChar, 50) };



            AnsText[0].Value = textBox1.Text;
            AnsText[1].Value = textBox2.Text;
            AnsText[2].Value = textBox3.Text;
            

            if (AnsText[0].Value.ToString() == AnsUser[0].Value.ToString()&& AnsText[1].Value.ToString() == AnsUser[1].Value.ToString()&& AnsText[2].Value.ToString() == AnsUser[2].Value.ToString())
            {

                MessageBox.Show("The answers you entered  are correct.You may now change the password");
                NewPassword.Value= textBox4.Text;

            }
            else
            {
                MessageBox.Show("The answers you entered  are incorrect.Please check again your answers");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(@"Data Source = TARYA-ISR-204\MSSQLSERVER03; 
                                                         Initial Catalog =RuppinGYM_DB;
                                                         Integrated Security = true;
                                                         User id = Trainee;
                                                         Password = Hefr1234678;");

                sqlCon.Open();
                NewPassword.Value = textBox4.Text;
                usermail3.Value = richTextBox1.Text;
                SqlCommand command = new SqlCommand(null, sqlCon);
                command.CommandText = "UPDATE users SET PasswordUser =@NewPassword  WHERE userEmail = @userEmail3";
                command.Parameters.Add(NewPassword);
                command.Parameters.Add(usermail3);
                command.Prepare();
                command.ExecuteNonQuery();
                MessageBox.Show("The Password was submitted");
            }
            catch
            {
                MessageBox.Show("The Password was  already submitted");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter usermail = new SqlParameter("@userEmail1", SqlDbType.VarChar, 50);
                SqlParameter usermail1 = new SqlParameter("@userEmail15", SqlDbType.VarChar, 50);
                SqlParameter usermail2 = new SqlParameter("@userEmail2", SqlDbType.VarChar, 50);
                SqlParameter[] questionNUM = {
                                  new SqlParameter("@questionNum1", SqlDbType.Int, 0),
                                  new SqlParameter("@questionNum2", SqlDbType.Int, 0),
                                  new SqlParameter("@questionNum3", SqlDbType.Int, 0) };
                SqlConnection sqlCon = new SqlConnection(@"Data Source = TARYA-ISR-204\MSSQLSERVER03; 
                                                         Initial Catalog =RuppinGYM_DB;
                                                         Integrated Security = true;
                                                         User id = Trainer;
                                                         Password = Hefr123456789;");

                sqlCon.Open();

                SqlCommand command = new SqlCommand(null, sqlCon);
                usermail.Value = richTextBox1.Text;
                usermail1.Value = richTextBox1.Text;
                command.CommandText = "Select * From Trainer as T where T.userEmail=@userEmail15";
                command.Parameters.Add(usermail1);
                command.Prepare();
                SqlDataReader reader1 = command.ExecuteReader();
                if (reader1.Read() == false)
                {
                    MessageBox.Show("The User email is inncorrect");
                    Form2 f2 = new Form2();
                    this.Hide();
                    f2.ShowDialog();
                }
                int[] array1 = new int[3];
                Random rnd = new Random();
                int flag = 1;
                int num;
                for (int i = 0; i < array1.Length; i++)
                {
                    num = rnd.Next(1, 5);
                    flag = 1;
                    while (flag == 1)
                    {
                        flag = 0;
                        for (int j = 0; j < array1.Length; j++)
                        {
                            if (array1[j] == num)
                            {
                                flag = 1;
                                num = rnd.Next(1, 5);
                            }
                        }
                    }
                    array1[i] = num;
                }
                for (int i = 0; i < 3; i++)
                {
                    questionNUM[i].Value = array1[i];
                }
                reader1.Close();
                reader1.Dispose();
                command.CommandText = "Select * From QuestionsForUser as Q where Q.userEmail=@userEmail1 and (Q.questionNumForUser=@questionNum1 or Q.questionNumForUser=@questionNum2 or Q.questionNumForUser=@questionNum3)";
                command.Parameters.Add(usermail);
                for (int i = 0; i < 3; i++)
                {
                    command.Parameters.Add(questionNUM[i]);
                }
                command.Prepare();
                SqlDataReader reader = command.ExecuteReader();
                int indexquestion = 1;
                while (reader.Read())
                {
                    richTextBox2.Text = richTextBox2.Text + indexquestion.ToString().Trim() + reader[2].ToString().Trim() + "\r\n";
                    indexquestion++;
                }
                reader.Close();
                reader.Dispose();
                command.CommandText = "Select * From Answers as A where A.userEmail=@userEmail1 and (A.AnsNum=@AnsNum1 or A.AnsNum=@AnsNum2 or A.AnsNum=@AnsNum3)";
                for (int i = 0; i < 3; i++)
                {
                    AnsNUM[i].Value = array1[i];
                }
                usermail2.Value = richTextBox1.Text;
                command.Parameters.Add(usermail2);
                for (int i = 0; i < 3; i++)
                {
                    command.Parameters.Add(AnsNUM[i]);
                }
                command.Prepare();
                SqlDataReader reader2 = command.ExecuteReader();
                indexquestion = 1;
                while (reader2.Read())
                {
                    AnsUser[indexquestion - 1].Value = reader2[2].ToString().Trim();
                    indexquestion++;
                }
            }
            catch
            {
                MessageBox.Show("The User email is inncorrect");
                Form2 f2 = new Form2();
                this.Hide();
                f2.ShowDialog();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter usermail = new SqlParameter("@userEmail1", SqlDbType.VarChar, 50);
                SqlParameter usermail1 = new SqlParameter("@userEmail15", SqlDbType.VarChar, 50);
                SqlParameter usermail2 = new SqlParameter("@userEmail2", SqlDbType.VarChar, 50);
                SqlParameter[] questionNUM = {
                                  new SqlParameter("@questionNum1", SqlDbType.Int, 0),
                                  new SqlParameter("@questionNum2", SqlDbType.Int, 0),
                                  new SqlParameter("@questionNum3", SqlDbType.Int, 0) };
                SqlConnection sqlCon = new SqlConnection(@"Data Source = TARYA-ISR-204\MSSQLSERVER03; 
                                                         Initial Catalog =RuppinGYM_DB;
                                                         Integrated Security = true;
                                                         User id = MANAGER;
                                                         Password = Hefr12345678913;");

                sqlCon.Open();

                SqlCommand command = new SqlCommand(null, sqlCon);
                usermail.Value = richTextBox1.Text;
                usermail1.Value = richTextBox1.Text;
                command.CommandText = "Select * From Manager as M where M.userEmail=@userEmail15";
                command.Parameters.Add(usermail1);
                command.Prepare();
                SqlDataReader reader1 = command.ExecuteReader();
                if (reader1.Read() == false)
                {
                    MessageBox.Show("The User email is inncorrect");
                    Form2 f2 = new Form2();
                    this.Hide();
                    f2.ShowDialog();
                }
                int[] array1 = new int[3];
                Random rnd = new Random();
                int flag = 1;
                int num;
                for (int i = 0; i < array1.Length; i++)
                {
                    num = rnd.Next(1, 5);
                    flag = 1;
                    while (flag == 1)
                    {
                        flag = 0;
                        for (int j = 0; j < array1.Length; j++)
                        {
                            if (array1[j] == num)
                            {
                                flag = 1;
                                num = rnd.Next(1, 5);
                            }
                        }
                    }
                    array1[i] = num;
                }
                for (int i = 0; i < 3; i++)
                {
                    questionNUM[i].Value = array1[i];
                }
                reader1.Close();
                reader1.Dispose();
                command.CommandText = "Select * From QuestionsForUser as Q where Q.userEmail=@userEmail1 and (Q.questionNumForUser=@questionNum1 or Q.questionNumForUser=@questionNum2 or Q.questionNumForUser=@questionNum3)";
                command.Parameters.Add(usermail);
                for (int i = 0; i < 3; i++)
                {
                    command.Parameters.Add(questionNUM[i]);
                }
                command.Prepare();
                SqlDataReader reader = command.ExecuteReader();
                int indexquestion = 1;
                while (reader.Read())
                {
                    richTextBox2.Text = richTextBox2.Text + indexquestion.ToString().Trim() + reader[2].ToString().Trim() + "\r\n";
                    indexquestion++;
                }
                reader.Close();
                reader.Dispose();
                command.CommandText = "Select * From Answers as A where A.userEmail=@userEmail1 and (A.AnsNum=@AnsNum1 or A.AnsNum=@AnsNum2 or A.AnsNum=@AnsNum3)";
                for (int i = 0; i < 3; i++)
                {
                    AnsNUM[i].Value = array1[i];
                }
                usermail2.Value = richTextBox1.Text;
                command.Parameters.Add(usermail2);
                for (int i = 0; i < 3; i++)
                {
                    command.Parameters.Add(AnsNUM[i]);
                }
                command.Prepare();
                SqlDataReader reader2 = command.ExecuteReader();
                indexquestion = 1;
                while (reader2.Read())
                {
                    AnsUser[indexquestion - 1].Value = reader2[2].ToString().Trim();
                    indexquestion++;
                }
            }
            catch
            {
                MessageBox.Show("The User email is inncorrect");
                Form2 f2 = new Form2();
                this.Hide();
                f2.ShowDialog();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(@"Data Source = TARYA-ISR-204\MSSQLSERVER03; 
                                                         Initial Catalog =RuppinGYM_DB;
                                                         Integrated Security = true;
                                                         User id = MANAGER;
                                                         Password = Hefr12345678913;");

                sqlCon.Open();
                NewPassword.Value = textBox4.Text;
                usermail3.Value = richTextBox1.Text;
                SqlCommand command = new SqlCommand(null, sqlCon);
                command.CommandText = "UPDATE users SET PasswordUser =@NewPassword  WHERE userEmail = @userEmail3";
                command.Parameters.Add(NewPassword);
                command.Parameters.Add(usermail3);
                command.Prepare();
                command.ExecuteNonQuery();
                MessageBox.Show("The Password was submitted");
            }
            catch
            {
                MessageBox.Show("The Password was  already submitted");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(@"Data Source = TARYA-ISR-204\MSSQLSERVER03; 
                                                         Initial Catalog =RuppinGYM_DB;
                                                         Integrated Security = true;
                                                         User id = Trainer;
                                                         Password = Hefr123456789;");

                sqlCon.Open();
                NewPassword.Value = textBox4.Text;
                usermail3.Value = richTextBox1.Text;
                SqlCommand command = new SqlCommand(null, sqlCon);
                command.CommandText = "UPDATE users SET PasswordUser =@NewPassword  WHERE userEmail = @userEmail3";
                command.Parameters.Add(NewPassword);
                command.Parameters.Add(usermail3);
                command.Prepare();
                command.ExecuteNonQuery();
                MessageBox.Show("The Password was submitted");
            }
            catch
            {
                MessageBox.Show("The Password was  already submitted");
            }
        }
    }
}
