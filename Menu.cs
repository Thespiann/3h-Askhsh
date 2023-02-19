using System;
using System.Drawing;
using System.Windows.Forms;

namespace KEP
{
    public partial class Menu : Form
    {

        public Menu()
        {
            InitializeComponent();
        }
        //Constructor that takes the object of class employee as a parameter
        public Menu(Employee myemployee)
        {
            InitializeComponent();
            welcomelabel.Text ="Καλώς ήρθες, "+ myemployee.getName();// it then takes the employees name
            todaysdate.Text = myemployee.getDate();//and the date from the object
            
        }
        //closing button
        private void closebutton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        //Buttons for functions of app
        private void EnterRequest_Click(object sender, EventArgs e)
        {
            EnterRequest enterrequest = new EnterRequest();//Create and show form for entering requests
            enterrequest.Show();
        }
        private void AllRequests_Click(object sender, EventArgs e)
        {
            CitizenRequests citizens = new CitizenRequests();
            citizens.Show();
        }

        private void edit_MouseClick(object sender, MouseEventArgs e)
        {
            Edit edit = new Edit();
            edit.Show();

        }

        private void CitizenRequests_Click(object sender, EventArgs e)
        {
            PerCitizen percitizen= new PerCitizen();
            percitizen.Show();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            Search search= new Search();
            search.Show();
        }
        //Graphics

        private void EnterRequest_MouseHover(object sender, EventArgs e)
        {
            EnterRequest.BackColor = Color.MidnightBlue;
            EnterRequest.ForeColor = Color.White;
        }

        private void EnterRequest_MouseLeave(object sender, EventArgs e)
        {

            EnterRequest.ForeColor = Color.MidnightBlue;
            EnterRequest.BackColor = Color.White;
        }

        private void AllRequests_MouseEnter(object sender, EventArgs e)
        {
            AllRequests.BackColor = Color.MidnightBlue;
            AllRequests.ForeColor = Color.White;
        }

        private void AllRequests_MouseLeave(object sender, EventArgs e)
        {
            AllRequests.ForeColor= Color.MidnightBlue;
            AllRequests.BackColor= Color.White;
        }

        private void CitizenRequests_MouseEnter(object sender, EventArgs e)
        {
            CitizenRequests.BackColor = Color.MidnightBlue;
            CitizenRequests.ForeColor = Color.White;
        }

        private void CitizenRequests_MouseLeave(object sender, EventArgs e)
        {
            CitizenRequests.ForeColor= Color.MidnightBlue;
            CitizenRequests.BackColor = Color.White;
        }

        private void Search_MouseEnter(object sender, EventArgs e)
        {
            Search.BackColor = Color.MidnightBlue;
            Search.ForeColor = Color.White;
        }

        private void Search_MouseLeave(object sender, EventArgs e)
        {
            Search.ForeColor= Color.MidnightBlue;
            Search.BackColor = Color.White;
        }
        private void Edit_MouseEnter(object sender, EventArgs e)
        {
            edit.BackColor = Color.MidnightBlue;
            edit.ForeColor = Color.White;
        }

        private void Edit_MouseLeave(object sender, EventArgs e)
        {
            edit.ForeColor = Color.MidnightBlue;
            edit.BackColor = Color.White;
        }

   
    }
}
