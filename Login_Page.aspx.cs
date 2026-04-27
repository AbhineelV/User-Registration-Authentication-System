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
    public partial class Login_Page : System.Web.UI.Page
    {
        //Database Object 
        SqlConnection con;
        SqlCommand com;
        SqlDataReader dr;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //Open Connection
            string path = @"Data Source = DESKTOP-K59HESF\SQLEXPRESS;Initial Catalog=RegistrationLoginDB;Integrated Security=True";
            con = new SqlConnection(path);
            con.Open();

            //Matching Email and Passwrod
            string match = "SELECT * FROM registrationDB WHERE email = @email AND password = @password ";
            com = new SqlCommand(match, con);
            com.Parameters.AddWithValue("@email", txtEmail.Text);
            com.Parameters.AddWithValue("@password", txtPassword.Text);
            dr = com.ExecuteReader();

            if (dr.Read())
            {
                Session["email"] = dr["email"].ToString();
                Session["passwors"] = dr["password"].ToString();

                Response.Write("Login Successfully");
            }
            else
            {
                Response.Write("Please Enter Valid Email ID and Password");
            }

            dr.Close();

            

        }
    }
}