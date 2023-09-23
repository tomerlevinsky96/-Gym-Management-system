using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp3;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp4
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            SqlConnection sqlCon = new SqlConnection(@"Data Source = TARYA-ISR-204\MSSQLSERVER03; 
                                                    Initial Catalog =RuppinGYM_DB;
                                                    Integrated Security = true;
                                                     User id = Trainer;
                                                    Password = Hefr123456789;");
                                                                                
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
            command.CommandText = "select* from Equipment ";
            command.Prepare();
            SqlDataReader reader200 = command.ExecuteReader();
            comboBox3.Items.Clear();
            while (reader200.Read())
            {
                comboBox3.Items.Add(reader200[0].ToString().Trim());
            }
            reader200.Close();
            reader200.Dispose();
            SqlParameter usemail = new SqlParameter("@usermail", SqlDbType.VarChar, 20);
            usemail.Value = Form2.SetValueForText;
            command.CommandText = "select C.CourseId from Course as C where C.TrainerMail=@usermail";
            command.Parameters.Add(usemail);
            command.Prepare();
            SqlDataReader reader201 = command.ExecuteReader();
            while (reader201.Read())
            {
                comboBox2.Items.Add(reader201[0].ToString().Trim());
            }
            reader201.Close();
            reader201.Dispose();
            SqlParameter usemail2 = new SqlParameter("@usermail2", SqlDbType.VarChar, 20);
            usemail2.Value = Form2.SetValueForText;
            command.CommandText = "select * from users as u where u.userEmail=@usermail2";
            command.Parameters.Add(usemail2);
            command.Prepare();
            SqlDataReader reader700 = command.ExecuteReader();
            while (reader700.Read())
            {
                textBox1.Text = "Welcome" + ' ' + reader700[1].ToString().Trim() + "\r\n";
            }
            reader700.Close();
            reader700.Dispose();
        }
        private void button1_Click(object sender, EventArgs e)
        {

                SqlConnection sqlCon = new SqlConnection(@"Data Source = TARYA-ISR-204\MSSQLSERVER03; 
                                                    Initial Catalog =RuppinGYM_DB;
                                                    Integrated Security = true;
                                                     User id = Trainer;
                                                    Password = Hefr123456789;");
                sqlCon.Open();
                SqlCommand command = new SqlCommand(null, sqlCon);
                SqlParameter usemail = new SqlParameter("@usermail", SqlDbType.VarChar, 20);
                usemail.Value = Form2.SetValueForText;
                command.CommandText = "select C.CourseId,C.CourseName,C.DateOfCourse,C.RoomNum,C.Duraition,U.userEmail,U.FirstName,U.LastName from DecidedFor as Df inner join users as u on Df.TraineeMail=U.userEmail inner join Course  as C on C.CourseId=Df.CourseId where C.TrainerMail=@usermail";
                command.Parameters.Add(usemail);
                SqlDataReader reader600 = command.ExecuteReader();
                richTextBox1.Clear();
                richTextBox1.Text = richTextBox1.Text + "Course Id" + "  |  " + "Course name" + "    |    " + "DateOfCourse" + "     |    " + "Room num" + "     |    " + "Time" + "  |  " + "Trainee Mail" + "     |      " + "Trainee's First name" + "    |    " + "Trainee's Last name" + "\r\n";
                while (reader600.Read())
                {
                    richTextBox1.Text = richTextBox1.Text + reader600[0].ToString().Trim() + "        |           " + reader600[1].ToString().Trim() + "          |          " + reader600[2].ToString().Trim() + "        |          " + reader600[3].ToString().Trim() + "    |   " + reader600[4].ToString().Trim() + "  |  " + reader600[5].ToString().Trim() + "  |    " + reader600[6].ToString().Trim() + "             |             " + reader600[7].ToString().Trim() + "\r\n";
                }
                reader600.Close();
                reader600.Dispose();
                SqlParameter usemail2 = new SqlParameter("@usermail2", SqlDbType.VarChar, 20);
                usemail2.Value = Form2.SetValueForText;
                command.CommandText = "select C.CourseId,C.CourseName,C.DateOfCourse,C.RoomNum,C.Duraition from  Course  as C where C.TrainerMail=@usermail2";
                command.Parameters.Add(usemail2);
                SqlDataReader reader601 = command.ExecuteReader();
                richTextBox2.Clear();
                richTextBox2.Text = richTextBox2.Text + "Course Id" + "  |  " + "Course name" + "    |    " + "DateOfCourse" + "     |    " + "Room num" + "     |    " + "Time"  + "\r\n";
                while (reader601.Read())
                {
                richTextBox2.Text = richTextBox2.Text + reader601[0].ToString().Trim() + "        |           " + reader601[1].ToString().Trim() + "          |          " + reader601[2].ToString().Trim() + "        |          " + reader601[3].ToString().Trim() + "    |   " + reader601[4].ToString().Trim()  + "\r\n";
                }
               reader601.Close();
               reader601.Dispose();
        }
        private void button3_Click(object sender, EventArgs e)
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
                SqlParameter CourseId = new SqlParameter("@CourseId ", SqlDbType.VarChar, 20);
                CourseId.Value = comboBox2.Text;
                SqlParameter EquipmentName = new SqlParameter("@EquipmentName ", SqlDbType.VarChar, 20);
                EquipmentName.Value = comboBox3.Text;
                SqlParameter EquipmentSum = new SqlParameter("@EquipmentSum", SqlDbType.VarChar, 20);
                EquipmentSum.Value = comboBox4.Text;
                command.CommandText = "EXEC Equipment_for_Trainer @SumOfEquipment=@EquipmentSum,@EquipmentName=@EquipmentName,@CourseId=@CourseId";
                command.Parameters.Add(CourseId);
                command.Parameters.Add(EquipmentName);
                command.Parameters.Add(EquipmentSum);
                command.Prepare();
                command.ExecuteNonQuery();
                MessageBox.Show("The Equipment added successfully");
            }
            catch
            {
                MessageBox.Show("Either  you put incorrect value/s or the equipment has allready been sent  to the course");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source = TARYA-ISR-204\MSSQLSERVER03; 
                                                    Initial Catalog =RuppinGYM_DB;
                                                    Integrated Security =true;
                                                     User id = Trainer;
                                                    Password = Hefr123456789;");
            sqlCon.Open();
            richTextBox3.Clear();
            SqlCommand command = new SqlCommand(null, sqlCon);
            SqlParameter usemail3 = new SqlParameter("@usermail3", SqlDbType.VarChar, 20);
            usemail3.Value = Form2.SetValueForText;
            command.CommandText = " select C.CourseId,C.CourseName,C.DateOfCourse,C.Duraition,C.RoomNum,FC.EquipmentName,FC.SumOfEquipment from  Course  as C inner join ForCourse AS FC on C.CourseId=FC.CourseId where C.TrainerMail=@usermail3 ";
            command.Parameters.Add(usemail3);
            SqlDataReader reader601 = command.ExecuteReader();
            richTextBox3.Text = richTextBox3.Text + "Course Id" + "  |  " + "Course name" + "    |    " + "DateOfCourse" + "     |    " + "Time" + "     |    " + "Room num" + "     |    " + "Equipment Name" + "     |    " + "Sum of equipment" + "\r\n";
            while (reader601.Read())
            {
                richTextBox3.Text = richTextBox3.Text + reader601[0].ToString().Trim() + "        |           " + reader601[1].ToString().Trim() + "          |          " + reader601[2].ToString().Trim() + "        |          " + reader601[3].ToString().Trim() + "    |   " + reader601[4].ToString().Trim() + "    |   " + reader601[5].ToString().Trim() + "    |   " + reader601[6].ToString().Trim()+ "\r\n";
            }
            reader601.Close();
            reader601.Dispose();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source = TARYA-ISR-204\MSSQLSERVER03; 
                                                    Initial Catalog =RuppinGYM_DB;
                                                    Integrated Security = true;
                                                     User id = Trainer;
                                                    Password = Hefr123456789;");
            sqlCon.Open();
            SqlCommand command = new SqlCommand(null, sqlCon);
            SqlParameter usermail = new SqlParameter("@userEmail2", SqlDbType.VarChar, 50);
            usermail.Value = Form2.SetValueForText;
            command.CommandText = "EXEC for_user_connected @userEmail=@userEmail2";
            command.Parameters.Add(usermail);
            command.Prepare();
            SqlDataReader reader = command.ExecuteReader();
            int indexquestion = 1;
            richTextBox8.Clear();
            richTextBox8.Text = "connection number" + ' ' + "Connection date and time" + ' ' + "ConnectionState status" + "\r\n";
            while (reader.Read())
            {
                richTextBox8.Text = richTextBox8.Text + indexquestion.ToString().Trim() + "    ,                        " + reader[1].ToString().Trim() + "   ,    " + reader[2].ToString().Trim() + "\r\n";
                indexquestion++;
            }
            reader.Close();
            reader.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.ShowDialog();
        }
    }
}
