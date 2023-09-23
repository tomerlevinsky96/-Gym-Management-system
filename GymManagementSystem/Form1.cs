using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        SqlParameter[] questionNUM = {
                                  new SqlParameter("@questionNum1", SqlDbType.Int, 0),
                                  new SqlParameter("@questionNum2", SqlDbType.Int, 0),
                                  new SqlParameter("@questionNum3", SqlDbType.Int, 0),
                                  new SqlParameter("@questionNum4", SqlDbType.Int, 0),
                                  new SqlParameter("@questionNum5", SqlDbType.Int, 0) };
        SqlParameter[] question = {
                                  new SqlParameter("@question1", SqlDbType.Text, 50),
                                  new SqlParameter("@question2", SqlDbType.Text, 50),
                                  new SqlParameter("@question3", SqlDbType.Text, 50),
                                  new SqlParameter("@question4", SqlDbType.Text, 50),
                                  new SqlParameter("@question5", SqlDbType.Text, 50)};
        public Form1()
        {
            InitializeComponent();
            SqlConnection sqlCon = new SqlConnection
                                (@"Data Source = TARYA-ISR-204\MSSQLSERVER03; 
                                   Initial Catalog =RuppinGYM_DB;
                                   Integrated Security = true;
                                   User id = GuestOfSystem1;
                                   Password = Hefr1234567891;");
            sqlCon.Open();
            int[] array1 = new int[5];
            Random rnd = new Random();
            int flag = 1;
            int num;
            for (int i = 0; i < array1.Length; i++)
            {
                num = rnd.Next(1, 9);
                flag = 1;
                while (flag == 1)
                {
                    flag = 0;
                    for (int j = 0; j < array1.Length; j++)
                    {
                        if (array1[j] == num)
                        {
                            flag = 1;
                            num = rnd.Next(1, 9);
                        }
                    }
                }
                array1[i] = num;
            }
            SqlCommand command = new SqlCommand(null, sqlCon);
            command.CommandText = "Select *From Questions as Q where Q.questionNum=@questionNum1 or Q.questionNum=@questionNum2 or Q.questionNum=@questionNum3 or Q.questionNum=@questionNum4 or Q.questionNum=@questionNum5";
            for (int i = 0; i < 5; i++)
            {
                questionNUM[i].Value = array1[i];
            }
            for (int i = 0; i < 5; i++)
            {
              command.Parameters.Add(questionNUM[i]);
            }
            command.Prepare();
            SqlDataReader reader = command.ExecuteReader();
            int indexquestion = 1;
            while(reader.Read())
            {
                richTextBox1.Text = richTextBox1.Text+ indexquestion.ToString().Trim() + reader[1].ToString().Trim()+"\r\n";
                question[indexquestion - 1].Value = reader[1].ToString().Trim();
                indexquestion++;
            }
            reader.Close();
            reader.Close();
            SqlCommand command2 = new SqlCommand(null, sqlCon);
            command2.CommandText = "Select distinct CourseName From Course";
            command2.Prepare();
            SqlDataReader reader2 = command2.ExecuteReader();
            int indexquestion2 = 1;
            while (reader2.Read())
            {
                richTextBox2.Text = richTextBox2.Text + indexquestion2.ToString().Trim() +'.'+ reader2[0].ToString().Trim() + "\r\n";
                indexquestion2++;
            }
            reader2.Close();
            reader2.Dispose();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(@"Data Source = TARYA-ISR-204\MSSQLSERVER03; 
                                   Initial Catalog =RuppinGYM_DB;
                                   Integrated Security = true;
                                   User id = GuestOfSystem1;
                                   Password = Hefr1234567891;");
                sqlCon.Open();
                SqlCommand command = new SqlCommand(null, sqlCon);
                SqlParameter[] questionNUM = {
                     new SqlParameter("@questionNumForUser1", SqlDbType.Int, 0),
                     new SqlParameter("@questionNumForUser2", SqlDbType.Int, 0),
                     new SqlParameter("@questionNumForUser3", SqlDbType.Int, 0),
                     new SqlParameter("@questionNumForUser4", SqlDbType.Int, 0),
                     new SqlParameter("@questionNumForUser5", SqlDbType.Int, 0) };
                SqlParameter[] usermail = {
                     new SqlParameter("@userEmail1", SqlDbType.Text, 50),
                     new SqlParameter("@userEmail2", SqlDbType.Text, 50),
                     new SqlParameter("@userEmail3", SqlDbType.Text, 50),
                     new SqlParameter("@userEmail4", SqlDbType.Text, 50),
                     new SqlParameter("@userEmail5", SqlDbType.Text, 50),
                     new SqlParameter("@userEmail6", SqlDbType.Text, 50),
                     new SqlParameter("@userEmail7", SqlDbType.Text, 50),
                     new SqlParameter("@userEmail8", SqlDbType.Text, 50),
                     new SqlParameter("@userEmail9", SqlDbType.Text, 50),
                     new SqlParameter("@userEmail10", SqlDbType.Text, 50),
                     new SqlParameter("@userEmail11", SqlDbType.Text, 50)};
                SqlParameter[] AnsNum = {
                     new SqlParameter("@AnsNum1", SqlDbType.Int, 0),
                     new SqlParameter("@AnsNum2", SqlDbType.Int, 0),
                     new SqlParameter("@AnsNum3", SqlDbType.Int, 0),
                     new SqlParameter("@AnsNum4", SqlDbType.Int, 0),
                     new SqlParameter("@AnsNum5", SqlDbType.Int, 0)};
                SqlParameter[] ans = {
                     new SqlParameter("@ans1", SqlDbType.Text, 50),
                     new SqlParameter("@ans2", SqlDbType.Text, 50),
                     new SqlParameter("@ans3", SqlDbType.Text, 50),
                     new SqlParameter("@ans4", SqlDbType.Text, 50),
                     new SqlParameter("@ans5", SqlDbType.Text, 50)};
                command.CommandText = "EXEC insert_user_to_system @usermail=@userEmail, @FirstName=@firstName,@LastName=@LastName, @BirthDate=@BirthDate, @PasswordUser=@PasswordUser";
                SqlParameter userEmail = new SqlParameter("@userEmail", SqlDbType.Text, 50);
                SqlParameter firstName = new SqlParameter("@firstName", SqlDbType.Text, 50);
                SqlParameter LastName = new SqlParameter("@LastName", SqlDbType.Text, 50);
                SqlParameter BirthDate = new SqlParameter("@BirthDate", SqlDbType.VarChar, 50);
                SqlParameter PasswordUser = new SqlParameter("@PasswordUser", SqlDbType.Text, 50);
                userEmail.Value = textBox6.Text;
                firstName.Value = textBox7.Text;
                LastName.Value = textBox8.Text;
                BirthDate.Value = dateTimePicker1.Text;
                PasswordUser.Value = textBox9.Text;
                command.Parameters.Add(userEmail);
                command.Parameters.Add(firstName);
                command.Parameters.Add(LastName);
                command.Parameters.Add(BirthDate);
                command.Parameters.Add(PasswordUser);
                command.Prepare();
                for(int i = 1; i <= 5; i++)
                {
                    questionNUM[i-1].Value = i;
                }
                for (int i = 1; i <= 5; i++)
                {
                    AnsNum[i - 1].Value = i;
                }
                command.ExecuteNonQuery();
                command.CommandText = "EXEC insert_users_Answers @AnsNum=@AnsNum1,@userEmail=@userEmail1,@ans=@ans1";
                ans[0].Value = textBox5.Text;
                usermail[0].Value = textBox6.Text;
                command.Parameters.Add(AnsNum[0]);
                command.Parameters.Add(usermail[0]);
                command.Parameters.Add(ans[0]);
                command.Prepare();
                command.ExecuteNonQuery();
                command.CommandText = "EXEC insert_users_Answers @AnsNum=@AnsNum2,@userEmail=@userEmail2,@ans=@ans2";
                ans[1].Value = textBox1.Text;
                usermail[1].Value = textBox6.Text;
                command.Parameters.Add(AnsNum[1]);
                command.Parameters.Add(usermail[1]);
                command.Parameters.Add(ans[1]);
                command.Prepare();
                command.ExecuteNonQuery();
                command.CommandText = "EXEC insert_users_Answers @AnsNum=@AnsNum3,@userEmail=@userEmail3,@ans=@ans3";
           
                command.Parameters.Add(AnsNum[2]);
                ans[2].Value = textBox2.Text;
                usermail[2].Value = textBox6.Text;
                command.Parameters.Add(usermail[2]);
                command.Parameters.Add(ans[2]);
                command.Prepare();
                command.ExecuteNonQuery();
                command.CommandText = "EXEC insert_users_Answers @AnsNum=@AnsNum4,@userEmail=@userEmail4,@ans=@ans4";
                
                command.Parameters.Add(AnsNum[3]);
                ans[3].Value = textBox3.Text;
                usermail[3].Value = textBox6.Text;
                command.Parameters.Add(usermail[3]);
                command.Parameters.Add(ans[3]);
                command.Prepare();
                command.ExecuteNonQuery();
                command.CommandText = "EXEC insert_users_Answers @AnsNum=@AnsNum5,@userEmail=@userEmail5,@ans=@ans5";
               
                command.Parameters.Add(AnsNum[4]);
                ans[4].Value = textBox4.Text;
                usermail[4].Value = textBox6.Text;
                command.Parameters.Add(usermail[4]);
                command.Parameters.Add(ans[4]);
                command.Prepare();
                command.ExecuteNonQuery();
                command.CommandText = 
                "INSERT INTO QuestionsForUser(questionNumForUser,userEmail,question)" +
                        "VALUES(@questionNumForUser1,@userEmail6,@question1)";
                usermail[5].Value= textBox6.Text;
                command.Parameters.Add(questionNUM[0]);
                command.Parameters.Add(usermail[5]);
                command.Parameters.Add(question[0]);
                command.Prepare();
                command.ExecuteNonQuery();
                command.CommandText = 
                "INSERT INTO QuestionsForUser(questionNumForUser,userEmail,question)" +
                        "VALUES(@questionNumForUser2,@userEmail7,@question2)";
                usermail[6].Value = textBox6.Text;
                command.Parameters.Add(questionNUM[1]);
                command.Parameters.Add(usermail[6]);
                command.Parameters.Add(question[1]);
                command.Prepare();
                command.ExecuteNonQuery();
                command.CommandText = 
                "INSERT INTO QuestionsForUser(questionNumForUser,userEmail,question)" +
                        "VALUES(@questionNumForUser3,@userEmail8,@question3)";
                usermail[7].Value = textBox6.Text;
                command.Parameters.Add(questionNUM[2]);
                command.Parameters.Add(usermail[7]);
                command.Parameters.Add(question[2]);
                command.Prepare();
                command.ExecuteNonQuery();
                command.CommandText = 
                "INSERT INTO QuestionsForUser(questionNumForUser,userEmail,question)" +
                        "VALUES(@questionNumForUser4,@userEmail9,@question4)";
                usermail[8].Value = textBox6.Text;
                command.Parameters.Add(questionNUM[3]);
                command.Parameters.Add(usermail[8]);
                command.Parameters.Add(question[3]);
                command.Prepare();
                command.ExecuteNonQuery();
                command.CommandText = 
                "INSERT INTO QuestionsForUser(questionNumForUser,userEmail,question)" +
                        "VALUES(@questionNumForUser5,@userEmail10,@question5)";
                usermail[9].Value = textBox6.Text;
                command.Parameters.Add(questionNUM[4]);
                command.Parameters.Add(usermail[9]);
                command.Parameters.Add(question[4]);
                command.Prepare();
                command.ExecuteNonQuery();
                command.CommandText =
                        "INSERT INTO Trainer(userEmail)" +
                        "VALUES(@userEmail11)";
                usermail[10].Value = textBox6.Text;
                command.Parameters.Add(usermail[10]);
                command.Prepare();
                command.ExecuteNonQuery();
                MessageBox.Show("Account was created successfuly");
                Form1 f1 = new Form1();
                this.Hide();
                f1.ShowDialog();

            }
            catch 
            {
              MessageBox.Show("The value/s you entered are incorrect.Please check that you enter correct values");
              Form1 f1 = new Form1();
              this.Hide();
              f1.ShowDialog();
            }
          }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(@"Data Source = TARYA-ISR-204\MSSQLSERVER03; 
                                   Initial Catalog =RuppinGYM_DB;
                                   Integrated Security = true;
                                   User id = GuestOfSystem1;
                                   Password = Hefr1234567891;");
                sqlCon.Open();
                SqlCommand command = new SqlCommand(null, sqlCon);
                SqlParameter[] questionNUM = {
                     new SqlParameter("@questionNumForUser1", SqlDbType.Int, 0),
                     new SqlParameter("@questionNumForUser2", SqlDbType.Int, 0),
                     new SqlParameter("@questionNumForUser3", SqlDbType.Int, 0),
                     new SqlParameter("@questionNumForUser4", SqlDbType.Int, 0),
                     new SqlParameter("@questionNumForUser5", SqlDbType.Int, 0) };
                SqlParameter[] usermail = {
                     new SqlParameter("@userEmail1", SqlDbType.Text, 50),
                     new SqlParameter("@userEmail2", SqlDbType.Text, 50),
                     new SqlParameter("@userEmail3", SqlDbType.Text, 50),
                     new SqlParameter("@userEmail4", SqlDbType.Text, 50),
                     new SqlParameter("@userEmail5", SqlDbType.Text, 50),
                     new SqlParameter("@userEmail6", SqlDbType.Text, 50),
                     new SqlParameter("@userEmail7", SqlDbType.Text, 50),
                     new SqlParameter("@userEmail8", SqlDbType.Text, 50),
                     new SqlParameter("@userEmail9", SqlDbType.Text, 50),
                     new SqlParameter("@userEmail10", SqlDbType.Text, 50),
                     new SqlParameter("@userEmail11", SqlDbType.Text, 50)};
                SqlParameter[] AnsNum = {
                     new SqlParameter("@AnsNum1", SqlDbType.Int, 0),
                     new SqlParameter("@AnsNum2", SqlDbType.Int, 0),
                     new SqlParameter("@AnsNum3", SqlDbType.Int, 0),
                     new SqlParameter("@AnsNum4", SqlDbType.Int, 0),
                     new SqlParameter("@AnsNum5", SqlDbType.Int, 0)};
                SqlParameter[] ans = {
                     new SqlParameter("@ans1", SqlDbType.Text, 50),
                     new SqlParameter("@ans2", SqlDbType.Text, 50),
                     new SqlParameter("@ans3", SqlDbType.Text, 50),
                     new SqlParameter("@ans4", SqlDbType.Text, 50),
                     new SqlParameter("@ans5", SqlDbType.Text, 50)};
                command.CommandText = "EXEC insert_user_to_system @usermail=@userEmail, @FirstName=@firstName,@LastName=@LastName, @BirthDate=@BirthDate, @PasswordUser=@PasswordUser";
               
                SqlParameter userEmail = new SqlParameter("@userEmail", SqlDbType.Text, 50);
                SqlParameter firstName = new SqlParameter("@firstName", SqlDbType.Text, 50);
                SqlParameter LastName = new SqlParameter("@LastName", SqlDbType.Text, 50);
                SqlParameter BirthDate = new SqlParameter("@BirthDate", SqlDbType.VarChar, 50);
                SqlParameter PasswordUser = new SqlParameter("@PasswordUser", SqlDbType.Text, 50);
                userEmail.Value = textBox6.Text;
                firstName.Value = textBox7.Text;
                LastName.Value = textBox8.Text;
                BirthDate.Value = dateTimePicker1.Text;
                PasswordUser.Value = textBox9.Text;
                command.Parameters.Add(userEmail);
                command.Parameters.Add(firstName);
                command.Parameters.Add(LastName);
                command.Parameters.Add(BirthDate);
                command.Parameters.Add(PasswordUser);
                command.Prepare();
                for (int i = 1; i <= 5; i++)
                {
                    questionNUM[i - 1].Value = i;
                }
                for (int i = 1; i <= 5; i++)
                {
                    AnsNum[i - 1].Value = i;
                }
                command.ExecuteNonQuery();
                command.CommandText = "EXEC insert_users_Answers @AnsNum=@AnsNum1,@userEmail=@userEmail1,@ans=@ans1";
                
                ans[0].Value = textBox5.Text;
                usermail[0].Value = textBox6.Text;
                command.Parameters.Add(AnsNum[0]);
                command.Parameters.Add(usermail[0]);
                command.Parameters.Add(ans[0]);
                command.Prepare();
                command.ExecuteNonQuery();
                command.CommandText = "EXEC insert_users_Answers @AnsNum=@AnsNum2,@userEmail=@userEmail2,@ans=@ans2";
               
                ans[1].Value = textBox1.Text;
                usermail[1].Value = textBox6.Text;
                command.Parameters.Add(AnsNum[1]);
                command.Parameters.Add(usermail[1]);
                command.Parameters.Add(ans[1]);
                command.Prepare();
                command.ExecuteNonQuery();
                command.CommandText = "EXEC insert_users_Answers @AnsNum=@AnsNum3,@userEmail=@userEmail3,@ans=@ans3";
                
                command.Parameters.Add(AnsNum[2]);
                ans[2].Value = textBox2.Text;
                usermail[2].Value = textBox6.Text;
                command.Parameters.Add(usermail[2]);
                command.Parameters.Add(ans[2]);
                command.Prepare();
                command.ExecuteNonQuery();
                command.CommandText = "EXEC insert_users_Answers @AnsNum=@AnsNum4,@userEmail=@userEmail4,@ans=@ans4";
                
                command.Parameters.Add(AnsNum[3]);
                ans[3].Value = textBox3.Text;
                usermail[3].Value = textBox6.Text;
                command.Parameters.Add(usermail[3]);
                command.Parameters.Add(ans[3]);
                command.Prepare();
                command.ExecuteNonQuery();
                command.CommandText = "EXEC insert_users_Answers @AnsNum=@AnsNum5,@userEmail=@userEmail5,@ans=@ans5";
                
                command.Parameters.Add(AnsNum[4]);
                ans[4].Value = textBox4.Text;
                usermail[4].Value = textBox6.Text;
                command.Parameters.Add(usermail[4]);
                command.Parameters.Add(ans[4]);
                command.Prepare();
                command.ExecuteNonQuery();
                command.CommandText =
                        "INSERT INTO QuestionsForUser(questionNumForUser,userEmail,question)" +
                        "VALUES(@questionNumForUser1,@userEmail6,@question1)";
                usermail[5].Value = textBox6.Text;
                command.Parameters.Add(questionNUM[0]);
                command.Parameters.Add(usermail[5]);
                command.Parameters.Add(question[0]);
                command.Prepare();
                command.ExecuteNonQuery();
                command.CommandText =
                        "INSERT INTO QuestionsForUser(questionNumForUser,userEmail,question)" +
                        "VALUES(@questionNumForUser2,@userEmail7,@question2)";
                usermail[6].Value = textBox6.Text;
                command.Parameters.Add(questionNUM[1]);
                command.Parameters.Add(usermail[6]);
                command.Parameters.Add(question[1]);
                command.Prepare();
                command.ExecuteNonQuery();
                command.CommandText =
                        "INSERT INTO QuestionsForUser(questionNumForUser,userEmail,question)" +
                        "VALUES(@questionNumForUser3,@userEmail8,@question3)";
                usermail[7].Value = textBox6.Text;
                command.Parameters.Add(questionNUM[2]);
                command.Parameters.Add(usermail[7]);
                command.Parameters.Add(question[2]);
                command.Prepare();
                command.ExecuteNonQuery();
                command.CommandText =
                        "INSERT INTO QuestionsForUser(questionNumForUser,userEmail,question)" +
                        "VALUES(@questionNumForUser4,@userEmail9,@question4)";
                usermail[8].Value = textBox6.Text;
                command.Parameters.Add(questionNUM[3]);
                command.Parameters.Add(usermail[8]);
                command.Parameters.Add(question[3]);
                command.Prepare();
                command.ExecuteNonQuery();
                command.CommandText =
                        "INSERT INTO QuestionsForUser(questionNumForUser,userEmail,question)" +
                        "VALUES(@questionNumForUser5,@userEmail10,@question5)";
                usermail[9].Value = textBox6.Text;
                command.Parameters.Add(questionNUM[4]);
                command.Parameters.Add(usermail[9]);
                command.Parameters.Add(question[4]);
                command.Prepare();
                command.ExecuteNonQuery();
                command.CommandText =
                        "INSERT INTO Trainee(userEmail)" +
                        "VALUES(@userEmail11)";
                usermail[10].Value = textBox6.Text;
                command.Parameters.Add(usermail[10]);
                command.Prepare();
                command.ExecuteNonQuery();
                MessageBox.Show("Account was created successfuly");
                Form1 f1 = new Form1();
                this.Hide();
                f1.ShowDialog();

            }
            catch
            {
                MessageBox.Show("The value/s you entered are incorrect.Please check that you enter correct values");
                Form1 f1 = new Form1();
                this.Hide();
                f1.ShowDialog();
            }
        }
    }
 }



