using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamFinalCRUD
{
    public partial class Reg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Shubham\dotnet\ExamFinalCRUD\ExamFinalCRUD\App_Data\Database1.mdf;Integrated Security=True");
            con.Open();
            String Name = TextBox1.Text;
            String Email = TextBox2.Text;
            String Password = TextBox3.Text;
            SqlCommand cmd = new SqlCommand("insert into Reg values(@Name,@Email,@Password)",con);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("Email", Email);
            cmd.Parameters.AddWithValue("Password", Password);
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                Response.Write("<script>alert('Register successfully !! ')</script>");
                Response.Redirect("Log.aspx");
            }
            else
            {
                Response.Write("<script>alert('Registration failed !! ')</script>");
            }
            con.Close();

        }
    }
}