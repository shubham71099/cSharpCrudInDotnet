using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamFinalCRUD
{
    public partial class ShowData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                gvBind();
            }
            
        }
        public void gettime(object sender, EventArgs e)
        {
            Label1.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }
        void gvBind()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Shubham\dotnet\ExamFinalCRUD\ExamFinalCRUD\App_Data\Database1.mdf;Integrated Security=True");
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Student", con);
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            gvBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Shubham\dotnet\ExamFinalCRUD\ExamFinalCRUD\App_Data\Database1.mdf;Integrated Security=True");
            con.Open();
            int Id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            string Name = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            int Age = Convert.ToInt32(((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text);
            string City = ((TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
            string Gender = ((TextBox)GridView1.Rows[e.RowIndex].Cells[4].Controls[0]).Text;
            SqlCommand cmd = new SqlCommand("update student set Name=@Name,Age=@Age,City=@City,Gender=@Gender where Id=@Id",con);
            cmd.Parameters.AddWithValue("Name", Name);
            cmd.Parameters.AddWithValue("Age", Age);
            cmd.Parameters.AddWithValue("City", City);
            cmd.Parameters.AddWithValue("Gender", Gender);
            cmd.Parameters.AddWithValue("Id", Id);
            int i = cmd.ExecuteNonQuery();
            
            if(i>0)
            {
                Response.Write("<script>alert('Data deleted successfully')</script>");
            }
            else
            {
                Response.Write("<script>alert('Data not deleted')</script>");
            }
            con.Close();
            GridView1.EditIndex = -1;
            gvBind();
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            gvBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Shubham\dotnet\ExamFinalCRUD\ExamFinalCRUD\App_Data\Database1.mdf;Integrated Security=True");
            con.Open();
            int Id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["Id"].ToString());
            SqlCommand cmd = new SqlCommand("delete from Student where Id=@Id",con);
            cmd.Parameters.AddWithValue("Id", @Id);
            int i = cmd.ExecuteNonQuery();
            if(i>0)
            {
                Response.Write("<script>alert('Record deleted successfully')</script>");
            }
            gvBind();
        }

        
    }
}