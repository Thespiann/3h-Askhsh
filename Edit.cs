using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace KEP
{
    public partial class Edit : Form//form to edit info or delete entry
    {
        SQLiteConnection connection;
        public Edit()
        {
            InitializeComponent();
            database Database = new database(connection);//creating table
        }
        //close button
        private void closebutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Submit_Click(object sender, EventArgs e)
        {

            if (ID.Text.Length==0||FullName.Text.Length == 0 || Email.Text.Length == 0 || PhoneNum.Text.Length == 0 || Birthday.Text.Length == 0 || Address.Text.Length == 0 || Request.Text.Length == 0 || Date.Text.Length == 0)
            {
                error.Show();
                error.ForeColor = Color.DarkRed;//If a field is missing, display error message
            }
            else
            {
                connection = new SQLiteConnection("Data source= database.db;Version=3");//create connection
                connection.Open();
                String EditSQL = "update Customers set FullName = @fullname, Email = @email ,PhoneNum = @phonenum ,Birthday = @birthday ,Request = @request ,Address = @request ,Date = @date where id = @id ";//string for updating info where id is the given id
                SQLiteCommand command2 = new SQLiteCommand(EditSQL, connection);//creating command
                command2.Parameters.AddWithValue("fullname", FullName.Text);//passing values
                command2.Parameters.AddWithValue("email", Email.Text);
                command2.Parameters.AddWithValue("phonenum", PhoneNum.Text);
                command2.Parameters.AddWithValue("birthday", Birthday.Text);
                command2.Parameters.AddWithValue("request", Request.Text);
                command2.Parameters.AddWithValue("address", Address.Text);
                command2.Parameters.AddWithValue("date", Date.Text);
                command2.Parameters.AddWithValue("id", Int16.Parse(ID.Text));
                command2.ExecuteNonQuery();//executing command
                connection.Close();//closing connection
                MessageBox.Show("Η τροποποίηση υποβλήθηκε. Επιστροφη στην αρχική");
                this.Close();
            }

        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (ID.Text.Length != 0)//if the id is filled
            {
                connection = new SQLiteConnection("Data source= database.db;Version=3");//create connection
                connection.Open();
                String DeleteSQL = "delete from Customers where id = @id ";//sting of command to delete the entry with the specific id
                SQLiteCommand command3 = new SQLiteCommand(DeleteSQL, connection);//create command
                command3.Parameters.AddWithValue("id", Int16.Parse(ID.Text));//pass id parameter
                command3.ExecuteNonQuery();//execute command
                connection.Close();//close connection
                MessageBox.Show("Η διαγραφή πραγματοποιήθηκε. Επιστροφη στην αρχική");//display confirmation message
                this.Close();
            }
            else
            {
                error.Show();
                error.ForeColor = Color.DarkRed;//If a field is missing, display error message
            }
        }
        //grahics
        private void Submit_MouseEnter(object sender, EventArgs e)
        {
            Submit.BackColor = Color.MidnightBlue;
            Submit.ForeColor = Color.White;
        }

        private void Submit_MouseLeave(object sender, EventArgs e)
        {
            Submit.ForeColor = Color.MidnightBlue;
            Submit.BackColor = Color.White;
        }
        private void Delete_MouseEnter(object sender, EventArgs e)
        {
            delete.BackColor = Color.MidnightBlue;
            delete.ForeColor = Color.White;
        }

        private void Delete_MouseLeave(object sender, EventArgs e)
        {
            delete.ForeColor = Color.MidnightBlue;
            delete.BackColor = Color.White;
        }

        
    }
}
