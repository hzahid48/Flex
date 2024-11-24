using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FacultyHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox1_TextChanged(null, EventArgs.Empty);
    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-G70308R\\SQLEXPRESS;Initial Catalog=try;Integrated Security=True");
        conn.Open();

        
        int ID = (int)Session["ID"];
        SqlCommand cmd = new SqlCommand("Select * from Users where User_ID = @ID", conn);
        cmd.Parameters.AddWithValue("@ID", ID);
        SqlDataReader da = cmd.ExecuteReader();
        while (da.Read())
        {
            Label11.Text =ID.ToString();
            Label12.Text = da.GetValue(5).ToString();
            Label14.Text = da.GetValue(3).ToString();
            Label15.Text = da.GetValue(4).ToString();
            Label17.Text = da.GetValue(6).ToString();
            Label16.Text = da.GetValue(1).ToString();
           
        }
        da.Close();
        SqlCommand cmd2 = new SqlCommand("Select NumCourses from Faculty where Faculty_ID = @ID", conn);
        cmd2.Parameters.AddWithValue("@ID", ID);
        SqlDataReader da2 = cmd2.ExecuteReader();

        if (da2.Read())
        {
            Label13.Text = da2.GetValue(0).ToString();
            //TextBox6.Text = da.GetValue(3).ToString();
            da2.Close(); // close the second data reader
        }
        conn.Close();
    }

}
