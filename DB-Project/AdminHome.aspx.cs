using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Provider;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



public partial class AdminHome : System.Web.UI.Page
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
            Label17.Text = ID.ToString();
            Label18.Text = da.GetValue(5).ToString();
            Label19.Text = da.GetValue(3).ToString();
            Label20.Text = da.GetValue(4).ToString();
            Label21.Text = da.GetValue(1).ToString();
            Label22.Text = da.GetValue(6).ToString();

        }
        da.Close();
        
        conn.Close();
    }

}

