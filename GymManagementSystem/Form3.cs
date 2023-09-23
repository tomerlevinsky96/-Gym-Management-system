using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp3
{
    public partial class Form3 : Form
    {
        public Form3()
        {
          InitializeComponent();
          SqlConnection sqlCon = new SqlConnection(@"Data Source = TARYA-ISR-204\MSSQLSERVER03; 
                                                         Initial Catalog =RuppinGYM_DB;
                                                         Integrated Security = true;
                                                         User id = Trainee;
                                                         Password = Hefr1234678;");
          sqlCon.Open();
          SqlCommand command = new SqlCommand(null, sqlCon);
          SqlParameter usermail2 = new SqlParameter("@userEmail98", SqlDbType.VarChar, 50);
          usermail2.Value = Form2.SetValueForText;
          command.CommandText = "EXEC USER_PROC @userEmail1=@userEmail98";
          command.Parameters.Add(usermail2);
          command.Prepare();
          command.ExecuteNonQuery();
          SqlParameter usermail3 = new SqlParameter("@userEmail3", SqlDbType.VarChar, 50);
          usermail3.Value = Form2.SetValueForText;
          command.CommandText = "select top 1  s.StatusConnection from SUCSSESFULCONNECTION as s where s.UserEmailConnected=@userEmail3 order by  s.ConnectionDateAndHour desc";
          command.Parameters.Add(usermail3);
          command.Prepare();
          SqlDataReader reader3 = command.ExecuteReader();
          string status;
          while (reader3.Read())
            {
                status = reader3[0].ToString();
                if (status == "n")
                {
                    MessageBox.Show("Connection has timed out!.you need to make a new connection");
                    Form2 f3 = new Form2();
                    this.Hide();
                    f3.ShowDialog();
                }
            }
          reader3.Close();
          reader3.Dispose();
          SqlParameter usermail5 = new SqlParameter("@userEmail6", SqlDbType.VarChar, 50);
          usermail5.Value = Form2.SetValueForText;
          command.CommandText = "select * from users as u where u.userEmail=@userEmail6";
          command.Parameters.Add(usermail5);
          command.Prepare();
          SqlDataReader reader1 = command.ExecuteReader();
          while (reader1.Read())
           {
             textBox1.Text = reader1[6].ToString().Trim() + "\r\n";
           }
          reader1.Close();
          reader1.Dispose();
          SqlParameter usermail6 = new SqlParameter("@userEmail7", SqlDbType.VarChar, 50);
          usermail6.Value = Form2.SetValueForText;
          command.CommandText = "select * from users as u where u.userEmail=@userEmail7";
          command.Parameters.Add(usermail6);
          command.Prepare();
          SqlDataReader reader2 = command.ExecuteReader();
          while (reader2.Read())
          {
            textBox2.Text = reader2[5].ToString().Trim() + "\r\n";
          }
          reader2.Close();
          reader2.Dispose();
          SqlParameter usermail21 = new SqlParameter("@userEmail21", SqlDbType.VarChar, 50);
          usermail21.Value = Form2.SetValueForText;
          command.CommandText = "select * from users as u where u.userEmail=@userEmail21";
          command.Parameters.Add(usermail21);
          command.Prepare();
          SqlDataReader reader21 = command.ExecuteReader();
          while (reader21.Read())
          {
            textBox3.Text = "Welcome"+' '+ reader21[1].ToString().Trim() + "\r\n";
          }
          reader21.Close();
          reader21.Dispose();
          SqlParameter usermail78 = new SqlParameter("@TraineeMail", SqlDbType.VarChar, 50);
          usermail78.Value = Form2.SetValueForText;
          comboBox1.Items.Clear();
          comboBox4.Items.Clear();
          command.CommandText = "EXEC CourseId_user_requested @usermail=@TraineeMail";
          command.Parameters.Add(usermail78);
          command.Prepare();
          SqlDataReader reader700 = command.ExecuteReader();
          while (reader700.Read())
          {
             comboBox1.Items.Add(reader700[0].ToString().Trim());
             comboBox4.Items.Add(reader700[0].ToString().Trim());
          }
          reader700.Close();
          reader700.Dispose();
          SqlParameter usermail79 = new SqlParameter("@TraineeMail2", SqlDbType.VarChar, 50);
          usermail79.Value = Form2.SetValueForText;
          command.CommandText = "Select * from Course as c inner join  DecidedFor as df on c.CourseId=df.CourseId where df.TraineeMail=@TraineeMail2";
          command.Parameters.Add(usermail79);
          command.Prepare();
          comboBox3.Items.Clear();
          SqlDataReader reader701 = command.ExecuteReader();
          while (reader701.Read())
          {
            comboBox3.Items.Add(reader701[0].ToString().Trim());
          }
          reader701.Close();
          reader701.Dispose();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source = TARYA-ISR-204\MSSQLSERVER03; 
                                                         Initial Catalog =RuppinGYM_DB;
                                                         Integrated Security = true;
                                                         User id = Trainee;
                                                         Password = Hefr1234678;");
            sqlCon.Open();
            SqlCommand command = new SqlCommand(null, sqlCon);
            SqlParameter usermail = new SqlParameter("@userEmail2", SqlDbType.VarChar, 50);
            usermail.Value = Form2.SetValueForText;
            command.CommandText = "EXEC for_user_connected @userEmail=@userEmail2";
            command.Parameters.Add(usermail);
            command.Prepare();
            SqlDataReader reader = command.ExecuteReader();
            int indexquestion = 1;
            richTextBox1.Text = "connection number" + ' ' + "Connection date and time" + ' ' + "ConnectionState status"+ "\r\n";
            while (reader.Read())
            {
                richTextBox1.Text = richTextBox1.Text + indexquestion.ToString().Trim() +"    ,                        "+ reader[1].ToString().Trim()+"   ,    "+ reader[2].ToString().Trim()+"\r\n";
                indexquestion++;
            }
            reader.Close();
            reader.Dispose();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
           Form2 f2 = new Form2();
           this.Hide();
           f2.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
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
                SqlParameter usermail2 = new SqlParameter("@userEmail3", SqlDbType.VarChar, 50);
                SqlParameter usermail4 = new SqlParameter("@userEmail4", SqlDbType.VarChar, 50);
                usermail2.Value = Form2.SetValueForText;
                usermail4.Value = Form2.SetValueForText;
                DateTime date = DateTime.Now;
                SqlParameter Package = new SqlParameter("@Package", SqlDbType.VarChar, 50);
                SqlParameter NewDate = new SqlParameter("@Date", SqlDbType.Date, 50);
                Package.Value = comboBox2.Text;
                if (Package.Value.ToString() == "Daily-20")
                {
                    NewDate.Value = date.AddDays(1);

                }
                if (Package.Value.ToString() == "Monthly-200")
                {
                    NewDate.Value = date.AddMonths(1);
                }
                if (Package.Value.ToString() == "Yearly-2000")
                {
                    NewDate.Value = date.AddYears(1);
                }
                SqlParameter usermail10 = new SqlParameter("@userEmail9", SqlDbType.VarChar, 50);
                usermail10.Value = Form2.SetValueForText;
                command.CommandText = "UPDATE users SET Package=@Package  WHERE userEmail = @userEmail9";
                command.Parameters.Add(usermail10);
                command.Parameters.Add(Package);
                command.Prepare();
                command.ExecuteNonQuery();
                command.CommandText = "UPDATE users SET LastDate=@Date  WHERE userEmail = @userEmail3";
                command.Parameters.Add(usermail2);
                command.Parameters.Add(NewDate);
                command.Prepare();
                command.ExecuteNonQuery();
                command.CommandText = "select * from users as u where u.userEmail=@userEmail4";
                command.Parameters.Add(usermail4);
                command.Prepare();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    textBox1.Text = reader[6].ToString().Trim() + "\r\n";
                }
                reader.Close();
                reader.Dispose();
                SqlParameter usermail11 = new SqlParameter("@userEmail10", SqlDbType.VarChar, 50);
                usermail11.Value = Form2.SetValueForText;
                command.CommandText = "select * from users as u where u.userEmail=@userEmail10";
                command.Parameters.Add(usermail11);
                command.Prepare();
                SqlDataReader reader2 = command.ExecuteReader();
                while (reader2.Read())
                {
                    textBox2.Text = reader2[5].ToString().Trim() + "\r\n";
                }
                reader2.Close();
                reader2.Dispose();
            }
            catch
            {
                MessageBox.Show("Incorrect value");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(@"Data Source = TARYA-ISR-204\MSSQLSERVER03; 
                                                         Initial Catalog =RuppinGYM_DB;
                                                         Integrated Security = true;
                                                         User id = Trainee;
                                                         Password = Hefr1234678;");
                sqlCon.Open();
                SqlParameter usermail15 = new SqlParameter("@userEmail15", SqlDbType.VarChar, 50);
                SqlParameter usermail16 = new SqlParameter("@userEmail16", SqlDbType.VarChar, 50);
                usermail16.Value = Form2.SetValueForText;
                usermail15.Value = Form2.SetValueForText;
                SqlCommand command = new SqlCommand(null, sqlCon);
                command.CommandText = "EXEC delete_Trainee_from_courses @usermail = @userEmail16;";
                command.Parameters.Add(usermail16);
                command.Prepare();
                command.ExecuteNonQuery();
                command.CommandText = "EXEC delete_Trainee  @usermail  = @userEmail15;";
                command.Parameters.Add(usermail15);
                command.Prepare();
                command.ExecuteNonQuery();
                MessageBox.Show("Your subscription has been deleted successfuly.Bye ");
                Form2 f2 = new Form2();
                this.Hide();
                f2.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Your subscription has been deleted successfuly.Bye ");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source = TARYA-ISR-204\MSSQLSERVER03; 
                                                         Initial Catalog =RuppinGYM_DB;
                                                         Integrated Security = true;
                                                         User id = Trainee;
                                                         Password = Hefr1234678;");
            sqlCon.Open();
            SqlCommand command = new SqlCommand(null, sqlCon);
            SqlParameter usermail800 = new SqlParameter("@userEmail800", SqlDbType.VarChar, 50);
            usermail800.Value = Form2.SetValueForText;
            command.CommandText = " EXEC for_user_request @usermail=@userEmail800 ";
            command.Parameters.Add(usermail800);
            SqlDataReader reader23 = command.ExecuteReader();
            int indexquestion = 1;
            richTextBox2.Clear();
            richTextBox2.Text = richTextBox2.Text + "Course Id" + "  |  " + "Course name" + "    |    " + "Room num" + "     |    " + "DateOfCourse" + "     |    " + "Time" + "  |  " + "Trainer Mail" + "     |      " + "Trainer's First name" + "    |    " + "Trainer's Last name" + "\r\n";
            while (reader23.Read())
            {
                richTextBox2.Text = richTextBox2.Text + reader23[0].ToString().Trim() + "        |           " + reader23[1].ToString().Trim() + "          |          " + reader23[2].ToString().Trim() + "        |          " + reader23[3].ToString().Trim() + "    |   " + reader23[4].ToString().Trim() + "  |  " + reader23[5].ToString().Trim() + "  |    " + reader23[6].ToString().Trim() + "             |             " + reader23[7].ToString().Trim() + "\r\n";
                indexquestion++;
            }
        }

        private void button3_Click(object sender, EventArgs e)
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
                SqlParameter usermail78 = new SqlParameter("@TraineeMail", SqlDbType.VarChar, 50);
                SqlParameter usermail79 = new SqlParameter("@TraineeMail2", SqlDbType.VarChar, 50);
                SqlParameter courseid = new SqlParameter("@courseId", SqlDbType.VarChar, 50);
                usermail78.Value = Form2.SetValueForText;
                courseid.Value = comboBox1.Text;
                command.CommandText = "EXEC Insert_course_for_trainee @usermail=@TraineeMail,@CourseId=@courseId";
                command.Parameters.Add(usermail78);
                command.Parameters.Add(courseid);
                command.Prepare();
                command.ExecuteNonQuery();
                SqlParameter usermail80 = new SqlParameter("@TraineeMail30", SqlDbType.VarChar, 50);
                usermail80.Value = Form2.SetValueForText;
                comboBox1.Items.Clear();
                comboBox4.Items.Clear();
                command.CommandText = "EXEC CourseId_user_requested @usermail=@TraineeMail30";
                command.Parameters.Add(usermail80);
                command.Prepare();
                SqlDataReader reader700 = command.ExecuteReader();
                while (reader700.Read())
                {
                    comboBox1.Items.Add(reader700[0].ToString().Trim());
                    comboBox4.Items.Add(reader700[0].ToString().Trim());
                }
                reader700.Close();
                reader700.Dispose();
                SqlParameter usermail81 = new SqlParameter("@TraineeMail23", SqlDbType.VarChar, 50);
                usermail81.Value = Form2.SetValueForText;
                command.CommandText = "Select * from Course as c inner join  DecidedFor as df on c.CourseId=df.CourseId where df.TraineeMail=@TraineeMail23";
                command.Parameters.Add(usermail81);
                command.Prepare();
                comboBox3.Items.Clear();
                SqlDataReader reader701 = command.ExecuteReader();
                while (reader701.Read())
                {
                    comboBox3.Items.Add(reader701[0].ToString().Trim());
                }
                reader701.Close();
                reader701.Dispose();
                MessageBox.Show("The course was requested successfuly");
            }
            catch
            {
                MessageBox.Show("Either your value/s are incorrect or the course as already been requested");
            }
        }
        private void button7_Click(object sender, EventArgs e)
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
                SqlParameter usermail78 = new SqlParameter("@TraineeMail", SqlDbType.VarChar, 50);
                SqlParameter courseid = new SqlParameter("@courseId", SqlDbType.VarChar, 50);
                SqlParameter courseid2 = new SqlParameter("@NewcourseId", SqlDbType.VarChar, 50);
                usermail78.Value = Form2.SetValueForText;
                courseid.Value = comboBox3.Text;
                courseid2.Value = comboBox4.Text;
                command.CommandText = "BEGIN TRANSACTION UPDATE DecidedFor SET CourseId=@NewcourseId  WHERE CourseId=@courseId and TraineeMail=@TraineeMail COMMIT";
                command.Parameters.Add(usermail78);
                command.Parameters.Add(courseid2);
                command.Parameters.Add(courseid);
                command.Prepare();
                command.ExecuteNonQuery();
                SqlParameter usermail80 = new SqlParameter("@TraineeMail2", SqlDbType.VarChar, 50);
                usermail80.Value = Form2.SetValueForText;
                comboBox1.Items.Clear();
                comboBox4.Items.Clear();
                command.CommandText = "EXEC CourseId_user_requested @usermail=@TraineeMail2";
                command.Parameters.Add(usermail80);
                command.Prepare();
                SqlDataReader reader700 = command.ExecuteReader();
                while (reader700.Read())
                {
                    comboBox1.Items.Add(reader700[0].ToString().Trim());
                    comboBox4.Items.Add(reader700[0].ToString().Trim());
                }
                reader700.Close();
                reader700.Dispose();
                SqlParameter usermail79 = new SqlParameter("@TraineeMail3", SqlDbType.VarChar, 50);
                usermail79.Value = Form2.SetValueForText;
                command.CommandText = "Select * from Course as c inner join  DecidedFor as df on c.CourseId=df.CourseId where df.TraineeMail=@TraineeMail3";
                command.Parameters.Add(usermail79);
                command.Prepare();
                comboBox3.Items.Clear();
                SqlDataReader reader701 = command.ExecuteReader();
                while (reader701.Read())
                {
                    comboBox3.Items.Add(reader701[0].ToString().Trim());
                }
                reader701.Close();
                reader701.Dispose();
                MessageBox.Show("The course changed successfuly");
            }
            catch
            {
                MessageBox.Show("Either your value/s are incorrect or the course has already been Changed");
            }
        }
    }
}
