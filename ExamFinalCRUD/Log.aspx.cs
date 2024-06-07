using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamFinalCRUD
{
    public partial class Log : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Shubham\dotnet\ExamFinalCRUD\ExamFinalCRUD\App_Data\Database1.mdf;Integrated Security=True");
            con.Open();
            string Email = TextBox1.Text;
            string Password = TextBox2.Text;
            SqlCommand cmd = new SqlCommand("select Name,Email from Reg where Email=@Email and Password=@Password",con);
            cmd.Parameters.AddWithValue("Email", Email);
            cmd.Parameters.AddWithValue("Password", Password);
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                Session["Name"] = reader.GetValue(0).ToString();
                Session["Email"] = reader.GetValue(1).ToString();
                Response.Redirect("Home.aspx");

                //Response.Cookies["userName"].Value = "Annathurai";
                //Response.Cookies["userColor"].Value = "Black";
                //Response.Cookies["userName"].Expires = DateTime.Now.AddMinutes(30);
                //Response.Cookies["userColor"].Expires = DateTime.Now.AddMinutes(30);
                /*HttpCookie reqCookies = Request.Cookies["userName"];
                if (reqCookies != null)
                {
                    string User_name = reqCookies.Value; // Read the value of the "userName" cookie
                }
                reqCookies = Request.Cookies["userColor"];
                if (reqCookies != null)
                {
                    string User_color = reqCookies.Value;
                }*/
            }
            else
            {
                Label6.Text = "Invalid Email or Password";
            }
        }
    }
}