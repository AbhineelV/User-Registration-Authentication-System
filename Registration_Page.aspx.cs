using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Including Library
using System.Data.SqlClient;

namespace User_Registration_Login_Prog
{
    public partial class Registration_Page : System.Web.UI.Page
    {
        //Database Object
        SqlCommand com;
        SqlConnection con;
        SqlDataReader dr;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //Open Connection
            string path = @"Data Source = DESKTOP-K59HESF\SQLEXPRESS;Initial Catalog=RegistrationLoginDB;Integrated Security=True";
            con = new SqlConnection(path);
            con.Open();

            //Registration Data into Database
            string send = "INSERT INTO registrationDB(name, mobile, email, password) values (@name, @mobile, @email, @password)";
            com = new SqlCommand(send, con);
            com.Parameters.AddWithValue("@name", txtName.Text);
            com.Parameters.AddWithValue("@mobile", txtMobile.Text);
            com.Parameters.AddWithValue("@email", txtEmail.Text);
            com.Parameters.AddWithValue("@password", txtPassword.Text);

            //Execute Query
            com.ExecuteNonQuery();

            //Redirecting to Login Page
            Response.Redirect("Login_Page.aspx");

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //Redirecting to Login Page
            Response.Redirect("Login_Page.aspx");
        }
    }
}