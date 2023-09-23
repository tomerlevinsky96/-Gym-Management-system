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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using WindowsFormsApp3;
using System.Runtime.Remoting.Messaging;

namespace WindowsFormsApp4
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            SqlConnection sqlCon = new SqlConnection
                          (@"Data Source = TARYA-ISR-204\MSSQLSERVER03; 
                          Initial Catalog =RuppinGYM_DB;
                          Integrated Security = true;
                          User id = MANAGER;
                          Password = Hefr12345678913;");

            sqlCon.Open();
            SqlCommand command = new SqlCommand(null, sqlCon);
            InitializeComponent();
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
            command.CommandText = "select T.userEmail from Trainer as T";
            command.Prepare();
            SqlDataReader reader2 = command.ExecuteReader();
            comboBox1.Items.Clear();
            comboBox3.Items.Clear();
            comboBox5.Items.Clear();
            while (reader2.Read())
            {
                comboBox3.Items.Add(reader2[0].ToString().Trim());
                comboBox5.Items.Add(reader2[0].ToString().Trim());
            }
            reader2.Close();
            reader2.Dispose();
            command.CommandText = "select C.CourseId from Course as C";
            command.Prepare();
            SqlDataReader reader200 = command.ExecuteReader();
            comboBox1.Items.Clear();
            while (reader200.Read())
            {
                comboBox1.Items.Add(reader200[0].ToString().Trim());
            }
            reader200.Close();
            reader200.Dispose();
            SqlParameter usermail700 = new SqlParameter("@userEmail700", SqlDbType.VarChar, 50);
            usermail700.Value = Form2.SetValueForText;
            command.CommandText = "select * from users as u where u.userEmail=@userEmail700";
            command.Parameters.Add(usermail700);
            command.Prepare();
            SqlDataReader reader700 = command.ExecuteReader();
            while (reader700.Read())
            {
                textBox2.Text ="Welcome"+' '+reader700[1].ToString().Trim() + "\r\n";
            }
            reader700.Close();
            reader700.Dispose();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            
            try
            {
                SqlConnection sqlCon = new SqlConnection
                              (@"Data Source = TARYA-ISR-204\MSSQLSERVER03; 
                               Initial Catalog =RuppinGYM_DB;
                                Integrated Security = true;
                                User id = MANAGER;
                                Password = Hefr12345678913;");
                sqlCon.Open();
                SqlCommand command = new SqlCommand(null, sqlCon);
                SqlParameter Trainer = new SqlParameter("@TrainerEmail1", SqlDbType.Text, 50);
                Trainer.Value = comboBox5.Text;      
                SqlParameter CourseName2 = new SqlParameter("@CourseName2", SqlDbType.Text, 50);
                CourseName2.Value = textBox1.Text;
                SqlParameter room = new SqlParameter("@room1", SqlDbType.Int, 50);
                room.Value = comboBox4.Text;
                SqlParameter date = new SqlParameter("@date", SqlDbType.VarChar, 50);
                date.Value = dateTimePicker1.Text;
                SqlParameter Duration = new SqlParameter("@Duration", SqlDbType.VarChar, 50);
                Duration.Value = comboBox2.Text;
                command.CommandText = "EXEC insert_course @usermail=@TrainerEmail1,@CourseName=@CourseName2,@room=@room1,@CourseDate=@date,@Duration=@Duration;";
                command.Parameters.Add(Trainer);
                command.Parameters.Add(CourseName2);
                command.Parameters.Add(room);
                command.Parameters.Add(date);
                command.Parameters.Add(Duration);
                command.Prepare();
                command.ExecuteNonQuery();
                command.CommandText = "select C.CourseId from Course as C";
                command.Prepare();
                SqlDataReader reader300 = command.ExecuteReader();
                comboBox1.Items.Clear();
                while (reader300.Read())
                {
                    comboBox1.Items.Add(reader300[0].ToString().Trim());
                }
                reader300.Close();
                reader300.Dispose();
                MessageBox.Show("The Course was added successfully");
            }
            catch
            {
                MessageBox.Show("You either put incorrect values or There is allready a course filled in that date,time and room please check again");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            SqlConnection sqlCon = new SqlConnection
                              (@"Data Source = TARYA-ISR-204\MSSQLSERVER03; 
                               Initial Catalog =RuppinGYM_DB;
                                Integrated Security = true;
                                User id = MANAGER;
                                Password = Hefr12345678913;");
            sqlCon.Open();
            SqlCommand command = new SqlCommand(null, sqlCon);
            command.CommandText = "select * from TrainerView";
            command.Prepare();
            SqlDataReader reader2 = command.ExecuteReader();
            int indexquestion = 1;
            richTextBox1.Clear();
            while (reader2.Read())
            {
                richTextBox1.Text = richTextBox1.Text + "Email:" + reader2[0].ToString().Trim() + "\r\n" + "First Name:" + reader2[1].ToString().Trim() + "\r\n" + "Last Name:" + reader2[2].ToString().Trim() + "\r\n"+ "Birth Date:" + "\r\n" + reader2[3].ToString().Trim() + "\r\n";
                indexquestion++;
            }
            reader2.Close();
            reader2.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection
                                (@"Data Source = TARYA-ISR-204\MSSQLSERVER03; 
                                Initial Catalog =RuppinGYM_DB;
                                Integrated Security = true;
                                User id = MANAGER;
                                Password = Hefr12345678913;");
                sqlCon.Open();
                SqlCommand command = new SqlCommand(null, sqlCon);
                command.CommandText = "select * from TraineeView";
                command.Prepare();
                SqlDataReader reader40 = command.ExecuteReader();
                int indexquestion = 1;
                richTextBox2.Clear();
                while (reader40.Read())
                {
                    richTextBox2.Text = richTextBox2.Text + "\r\n" + "Email:" + reader40[0].ToString().Trim() + "\r\n" + "First Name:" + reader40[1].ToString().Trim() + "\r\n" + "Last Name:" + reader40[2].ToString().Trim() + "\r\n"+ "Birth Date:" + reader40[3].ToString().Trim() + "\r\n" + "Package:" + reader40[5].ToString().Trim() + "\r\n" + "Last Date of Package:" + reader40[6].ToString().Trim()+ "\r\n"  ;
                    indexquestion++;
                }
                reader40.Close();
                reader40.Dispose();
            }
            catch
            {
                MessageBox.Show("There aren't any trainees ");
            }
        }

        

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(@"Data Source = TARYA-ISR-204\MSSQLSERVER03; 
                                Initial Catalog =RuppinGYM_DB;
                                Integrated Security = true;
                                User id = MANAGER;
                                Password = Hefr12345678913;");
                sqlCon.Open();
                SqlParameter usermail15 = new SqlParameter("@userEmail15", SqlDbType.VarChar, 50);
                usermail15.Value = comboBox3.Text;
                SqlCommand command = new SqlCommand(null, sqlCon);
                command.CommandText = "EXEC delete_user @usermail = @userEmail15;";
                command.Parameters.Add(usermail15);
                command.Prepare();
                command.ExecuteNonQuery();
                command.CommandText = "select T.userEmail from Trainer as T";
                command.Prepare();
                SqlDataReader reader31 = command.ExecuteReader();
                comboBox3.Items.Clear();
                comboBox5.Items.Clear();
                while (reader31.Read())
                {
                    comboBox5.Items.Add(reader31[0].ToString().Trim());
                    comboBox3.Items.Add(reader31[0].ToString().Trim());
                }
                reader31.Close();
                reader31.Dispose();
            }
            catch
            {
                MessageBox.Show("The value is incorrect or the Trianer has allready been deleted");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(@"Data Source = TARYA-ISR-204\MSSQLSERVER03; 
                                Initial Catalog =RuppinGYM_DB;
                                Integrated Security = true;
                                User id = MANAGER;
                                Password = Hefr12345678913;");
                sqlCon.Open();
                SqlParameter courseId= new SqlParameter("@id", SqlDbType.Int, 50);
                courseId.Value = comboBox1.Text;
                SqlCommand command = new SqlCommand(null, sqlCon);
                command.CommandText = "EXEC delete_course @id = @id;";
                command.Parameters.Add(courseId);
                command.Prepare();
                command.ExecuteNonQuery();
                command.CommandText = "select C.CourseId from Course as C";
                command.Prepare();
                SqlDataReader reader48 = command.ExecuteReader();
                comboBox1.Items.Clear();
                while (reader48.Read())
                {
                    comboBox1.Items.Add(reader48[0].ToString().Trim());
                }
                reader48.Close();
                reader48.Dispose();
            }
            catch
            {
                MessageBox.Show("The value is incorrect or the Course has allready been deleted");
            }
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
            command.CommandText = "select C.CourseId,C.CourseName,C.RoomNum,C.DateOfCourse,C.Duraition,C.TrainerMail,U.FirstName,U.LastName from Course as C inner join users as U on U.userEmail=C.TrainerMail";
            SqlDataReader reader23 = command.ExecuteReader();
            int indexquestion = 1;
            richTextBox3.Clear();
            richTextBox3.Text = richTextBox3.Text + "Course Id" + "  |  " + "Course name" + "    |    " + "Room num" + "     |    " + "DateOfCourse" + "     |    " + "Time" + "  |  " + "Trainer Mail" + "     |      " + "Trainer's First name" + "    |    " + "Trainer's Last name" + "\r\n";
            while (reader23.Read())
            {
                richTextBox3.Text = richTextBox3.Text + reader23[0].ToString().Trim() + "        |           " + reader23[1].ToString().Trim() + "          |          " + reader23[2].ToString().Trim() + "        |          " + reader23[3].ToString().Trim() + "    |   " + reader23[4].ToString().Trim() + "  |  " + reader23[5].ToString().Trim() + "  |    " + reader23[6].ToString().Trim() + "             |             " + reader23[7].ToString().Trim() + "\r\n";
                indexquestion++;
            }
            reader23.Close();
            reader23.Dispose();
        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            
                SqlConnection sqlCon = new SqlConnection(@"Data Source = TARYA-ISR-204\MSSQLSERVER03; 
                                Initial Catalog =RuppinGYM_DB;
                                Integrated Security = true;
                                User id = MANAGER;
                                Password = Hefr12345678913;");
                sqlCon.Open();
                SqlCommand command = new SqlCommand(null, sqlCon);
                command.CommandText = "select C.CourseId,C.CourseName,C.DateOfCourse,C.RoomNum,C.Duraition,U.userEmail,U.FirstName,U.LastName from DecidedFor as Df inner join users as u on Df.TraineeMail=U.userEmail inner join Course  as C on C.CourseId=Df.CourseId ";
                SqlDataReader reader600 = command.ExecuteReader();
                int indexquestion = 1;
                richTextBox4.Clear();
                richTextBox4.Text = richTextBox4.Text + "Course Id" + "  |  " + "Course name" + "    |    " + "DateOfCourse" + "     |    " + "Room num" + "     |    " + "Time" + "  |  " + "Trainee Mail" + "     |      " + "Trainee's First name" + "    |    " + "Trainee's Last name" + "\r\n";
                while (reader600.Read())
                {
                    richTextBox4.Text = richTextBox4.Text + reader600[0].ToString().Trim() + "        |           " + reader600[1].ToString().Trim() + "          |          " + reader600[2].ToString().Trim() + "        |          " + reader600[3].ToString().Trim() + "    |   " + reader600[4].ToString().Trim() + "  |  " + reader600[5].ToString().Trim() + "  |    " + reader600[6].ToString().Trim() + "             |             " + reader600[7].ToString().Trim() + "\r\n";
                    indexquestion++;
                }
                reader600.Close();
                reader600.Dispose();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.ShowDialog();
        }
        private void button7_Click_1(object sender, EventArgs e)
        {
            Form7 f2 = new Form7();
            this.Hide();
            f2.ShowDialog();
        }
    }
}

