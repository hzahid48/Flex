using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

   
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-G70308R\\SQLEXPRESS;Initial Catalog=try;Integrated Security=True");
        conn.Open();

        string em = TextBox1.Text;
        string pass = TextBox2.Text;

        string query = "SELECT User_ID, Role FROM Users WHERE Email = @Email AND Password = @Password";
        int ID;

   
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@Email", em);
            cmd.Parameters.AddWithValue("@Password", pass);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (!reader.HasRows)
                {     
                        ErrorMessageLabel.Text = "Email or Password not matched";
                        pnlErrorMessage.Visible = true;
                }
                else
                {
                    pnlErrorMessage.Visible = false;

                    if (reader.Read())
                    {
                        ID = reader.GetInt32(0);
                        Session["ID"] = ID;
                        string role = reader.GetString(1);
                        if (role == "Faculty")
                            Response.Redirect("FacultyHome.aspx?ID=");
                        else if (role == "Student")
                            Response.Redirect("StudentHome.aspx?ID=");
                        else if (role == "Admin")
                            Response.Redirect("AdminHome.aspx?ID=");
                    }
                }
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Sign_up.aspx");
    }
}