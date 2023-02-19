using System;
using System.Drawing;
using System.Windows.Forms;


namespace KEP
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            
        }

        private void enter_Click(object sender, EventArgs e)//On pressing the enter button
        {
            if (name.Text.Length==0) {//If the name field isnt filled in
                enterlabel.ForeColor = Color.Red;//Display needing name
            }
            if(date.Text.Length == 0){//if the date isnt filled in
                enterlabel2.ForeColor = Color.Red;//Display needing date
            }
            else//open the menu with constructor and its name parameter
            {
                Employee myemployee = new Employee(name.Text, date.Text);
                Menu menu = new Menu(myemployee);//Creating form menu
                menu.Show();//showing new form
                this.Hide();//Hiding form login
            }
        }

        private void closebutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // Graphics
        private void enter_MouseEnter(object sender, EventArgs e)
        {
            enter.BackColor = Color.SlateGray;
            enter.ForeColor = Color.White;
        }

        private void enter_MouseLeave(object sender, EventArgs e)
        {
            enter.BackColor = Color.White;
            enter.ForeColor = Color.SlateGray;
        }
    }

}
