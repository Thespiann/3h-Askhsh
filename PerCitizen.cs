using System;
using System.Data.SQLite;
using System.Windows.Forms;


namespace KEP
{
    public partial class PerCitizen : Form//form to display requests per citizen
    {
        SQLiteConnection connection;
        public PerCitizen()
        {
            InitializeComponent();
            database Database = new database(connection);//create table if it doesnt exist
        }

        private void percitizenbutton_Click(object sender, EventArgs e)
        {
            if (FullName.Text.Length == 0)//if the name field is empty display error message
            {
                MessageBox.Show("Παρακαλώ εισάγετε ονοματεπώνυμο πρώτα.");
            }
            else
            {
                percitizeninfo.Clear();//clear the textbox
                connection = new SQLiteConnection("Data source= database.db;Version=3");//establish connection
                connection.Open();
                String selectSQL = "Select * from Customers where FullName=@fullname";//string of command to select all entries where the name field is the given name
                SQLiteCommand command2 = new SQLiteCommand(selectSQL, connection);//creating command
                command2.Parameters.AddWithValue("fullname", FullName.Text);//adding the given name as a parameter
                SQLiteDataReader reader = command2.ExecuteReader();//executing reader
                while (reader.Read())//while there is sth to read
                {//add info to the textbox percitizen
                    percitizeninfo.AppendText("•Ονοματεπώνυμο: ");
                    percitizeninfo.AppendText(reader.GetString(1));
                    percitizeninfo.AppendText(" •E-mail: ");
                    percitizeninfo.AppendText(reader.GetString(2));
                    percitizeninfo.AppendText(" •Τηλέφωνο: ");
                    percitizeninfo.AppendText(reader.GetString(3));
                    percitizeninfo.AppendText(" •Ημερομηνία Γέννησης: ");
                    percitizeninfo.AppendText(reader.GetString(4));
                    percitizeninfo.AppendText(" •Διεύθυνση: ");
                    percitizeninfo.AppendText(reader.GetString(6));
                    percitizeninfo.AppendText(" •Ημερομηνία αιτήματος: ");
                    percitizeninfo.AppendText(reader.GetString(7));
                    percitizeninfo.AppendText(" •Αίτημα: ");
                    percitizeninfo.AppendText(reader.GetString(5));
                    percitizeninfo.AppendText(" •ID: ");
                    percitizeninfo.AppendText(reader.GetInt16(0).ToString());
                    percitizeninfo.AppendText(Environment.NewLine);
                    percitizeninfo.AppendText(Environment.NewLine);//and go again for other entries
                }
                connection.Close();//close connection
            }

        }
        //closing button
        private void closebutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
        
}
