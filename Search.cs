using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace KEP
{
    public partial class Search : Form
    {
        SQLiteConnection connection;
        public Search()
        {
            InitializeComponent();
            database Database = new database(connection);//create table if it doesnt exist
        }

        //close button
        private void closebutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void withphone_Click(object sender, EventArgs e)//search with phone num
        {

            if (withphone.Text.Length == 0)//if the phone field is empty display error message
            {
                MessageBox.Show("Παρακαλώ εισάγετε τηλέφωνο πρώτα.");
            }
            else
            {
                Request.Clear();//clear textbox of searching with request
                searchinfo.Clear();//clear rich textbox
                connection = new SQLiteConnection("Data source= database.db;Version=3");//create connection
                connection.Open();
                String selectSQL = "Select * from Customers where PhoneNum=@phonenum";//string of command to select all entries where the phonenum is the given phone number
                SQLiteCommand command2 = new SQLiteCommand(selectSQL, connection);//create command
                command2.Parameters.AddWithValue("phonenum", PhoneNum.Text);//add phone number as parameter
                SQLiteDataReader reader = command2.ExecuteReader();//execute commad
                while (reader.Read())
                {//read info
                    searchinfo.AppendText("•Ονοματεπώνυμο: ");
                    searchinfo.AppendText(reader.GetString(1));
                    searchinfo.AppendText(" •E-mail: ");
                    searchinfo.AppendText(reader.GetString(2));
                    searchinfo.AppendText(" •Τηλέφωνο: ");
                    searchinfo.AppendText(reader.GetString(3));
                    searchinfo.AppendText(" •Ημερομηνία Γέννησης: ");
                    searchinfo.AppendText(reader.GetString(4));
                    searchinfo.AppendText(" •Διεύθυνση: ");
                    searchinfo.AppendText(reader.GetString(6));
                    searchinfo.AppendText(" •Ημερομηνία αιτήματος: ");
                    searchinfo.AppendText(reader.GetString(7));
                    searchinfo.AppendText(" •Αίτημα: ");
                    searchinfo.AppendText(reader.GetString(5));
                    searchinfo.AppendText(" •ID: ");
                    searchinfo.AppendText(reader.GetInt16(0).ToString());
                    searchinfo.AppendText(Environment.NewLine);
                    searchinfo.AppendText(Environment.NewLine);
                }
                connection.Close();//close connection
            }

        }

        private void withrequest_Click(object sender, EventArgs e)//search with request, identical process but with another parameter for searching
        {
            if (withrequest.Text.Length == 0)
            {
                MessageBox.Show("Παρακαλώ εισάγετε είδος αιτηματος πρώτα.");
            }
            else
            {
                PhoneNum.Clear();
                searchinfo.Clear();
                connection = new SQLiteConnection("Data source= database.db;Version=3");
                connection.Open();
                String selectSQL = "Select * from Customers where Request=@request";
                SQLiteCommand command2 = new SQLiteCommand(selectSQL, connection);
                command2.Parameters.AddWithValue("request", Request.Text);
                SQLiteDataReader reader = command2.ExecuteReader();
                while (reader.Read())
                {
                    searchinfo.AppendText("•Ονοματεπώνυμο: ");
                    searchinfo.AppendText(reader.GetString(1));
                    searchinfo.AppendText(" •E-mail: ");
                    searchinfo.AppendText(reader.GetString(2));
                    searchinfo.AppendText(" •Τηλέφωνο: ");
                    searchinfo.AppendText(reader.GetString(3));
                    searchinfo.AppendText(" •Ημερομηνία Γέννησης: ");
                    searchinfo.AppendText(reader.GetString(4));
                    searchinfo.AppendText(" •Διεύθυνση: ");
                    searchinfo.AppendText(reader.GetString(6));
                    searchinfo.AppendText(" •Ημερομηνία αιτήματος: ");
                    searchinfo.AppendText(reader.GetString(7));
                    searchinfo.AppendText(" •Αίτημα: ");
                    searchinfo.AppendText(reader.GetString(5));
                    searchinfo.AppendText(" •ID: ");
                    searchinfo.AppendText(reader.GetInt16(0).ToString());
                    searchinfo.AppendText(Environment.NewLine);
                    searchinfo.AppendText(Environment.NewLine);
                }
                connection.Close();
            }
        }

    }
}