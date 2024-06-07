using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamFinalCRUD
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Shubham\dotnet\ExamFinalCRUD\ExamFinalCRUD\App_Data\Database1.mdf;Integrated Security=True");
                con.Open();
                int Id = Convert.ToInt32(TextBox1.Text);
                String Name = TextBox2.Text;
                int Age = Convert.ToInt32(TextBox3.Text);
                String City = DropDownList1.SelectedValue;
                String Gender = RadioButtonList1.SelectedValue;
                SqlCommand cmd = new SqlCommand("insert into Student values (@Id,@Name,@Age,@City,@Gender)",con);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Age", Age);
                cmd.Parameters.AddWithValue("@City", City);
                cmd.Parameters.AddWithValue("@Gender", Gender);
                int i = cmd.ExecuteNonQuery();
                if(i>0)
                {
                    Response.Redirect("ShowData.aspx");
                    Response.Write("<script>alert('Data inserted')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Data not inserted')</script>");
                } 
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}