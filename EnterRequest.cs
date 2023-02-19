using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;


namespace KEP
{
    
    public partial class EnterRequest : Form
    {
        SQLiteConnection connection;
        public EnterRequest()
        {
            InitializeComponent();
            database Database = new database(connection);//establishing connection,creating database if it doesnt already exist
        }
        //close button
        private void closebutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //submitting requests
        private void Submit_Click(object sender, EventArgs e)
        {
            if(FullName.Text.Length== 0|| Email.Text.Length==0||PhoneNum.Text.Length==0||Birthday.Text.Length==0|| Address.Text.Length==0|| Request.Text.Length == 0 || Date.Text.Length == 0)//if any of the needed info isnt filled in
            {
                error.Show();
                error.ForeColor = Color.DarkRed;// display error message
            }
            else
            {
                error.Hide();//hide error message
                connection = new SQLiteConnection("Data source= database.db;Version=3");//connect to database
                connection.Open();
                String insertSQL = "Insert into Customers(Fullname, Email, PhoneNum, Birthday, Request, Address, Date) values(@fullname,@email,@phonenum,@birthday,@request,@address,@date)";//enter values into table customers
                SQLiteCommand command = new SQLiteCommand(insertSQL, connection);//create command in sql
                command.Parameters.AddWithValue("fullname", FullName.Text);//Making parameters
                command.Parameters.AddWithValue("email", Email.Text);
                command.Parameters.AddWithValue("phonenum", PhoneNum.Text);
                command.Parameters.AddWithValue("birthday", Birthday.Text);
                command.Parameters.AddWithValue("request", Request.Text);
                command.Parameters.AddWithValue("address", Address.Text);
                command.Parameters.AddWithValue("date", Date.Text);

                command.ExecuteNonQuery();//execute command
                connection.Close();//close connection
                MessageBox.Show("Το αίτημα υποβλήθηκε, επιστροφή στην αρχική σελίδα.");//display confirmation an after user's "OK"
                this.Hide();//close request form

            }

        }
        //Graphics
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

      
    }
}
