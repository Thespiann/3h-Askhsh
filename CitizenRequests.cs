using System;
using System.Data.SQLite;
using System.Windows.Forms;


namespace KEP
{
    public partial class CitizenRequests : Form//form to display all requests
    {
        SQLiteConnection connection;
        public CitizenRequests()
        {
            InitializeComponent();
            database Database = new database(connection);//create table if it doesnt exist
        }

        private void CitizenRequests_Load(object sender, EventArgs e)
        {
            allcustomerinfo.Clear();//on load, clear rich textbox
            connection = new SQLiteConnection("Data source= database.db;Version=3");//establish connection
            connection.Open();
            String selectSQL = "Select * from Customers";//string of command to select everything from table customers
            SQLiteCommand command2 = new SQLiteCommand(selectSQL, connection);//create command
            SQLiteDataReader reader = command2.ExecuteReader();//execute command
            while (reader.Read())//while there is sth to read
            {
                allcustomerinfo.AppendText("•Ονοματεπώνυμο: ");//add the name
                allcustomerinfo.AppendText(reader.GetString(1));
                allcustomerinfo.AppendText(" •E-mail: ");//the email
                allcustomerinfo.AppendText(reader.GetString(2));
                allcustomerinfo.AppendText(" •Τηλέφωνο: ");//etc
                allcustomerinfo.AppendText(reader.GetString(3));
                allcustomerinfo.AppendText(" •Ημερομηνία Γέννησης: ");
                allcustomerinfo.AppendText(reader.GetString(4));
                allcustomerinfo.AppendText(" •Διεύθυνση: ");
                allcustomerinfo.AppendText(reader.GetString(6));
                allcustomerinfo.AppendText(" •Ημερομηνία αιτήματος: ");
                allcustomerinfo.AppendText(reader.GetString(7));
                allcustomerinfo.AppendText(" •Αίτημα: ");
                allcustomerinfo.AppendText(reader.GetString(5));
                allcustomerinfo.AppendText(" •ID: ");
                allcustomerinfo.AppendText(reader.GetInt16(0).ToString());
                allcustomerinfo.AppendText(Environment.NewLine);
                allcustomerinfo.AppendText(Environment.NewLine);//to the textbox, then go again for the next entry
            }
            connection.Close();//closing connection
        }

        private void closebutton_Click(object sender, EventArgs e)//close button
        {
            this.Close();
        }
    }
}
