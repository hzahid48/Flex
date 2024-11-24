using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }

    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-G70308R\\SQLEXPRESS;Initial Catalog=try;Integrated Security=True");
        conn.Open();

        string fn = TextBox1.Text;
        string ln = TextBox2.Text;
        //string n = fn + " " + ln;
        string em = TextBox3.Text;
        string pass = TextBox5.Text;
        string cpass = TextBox6.Text;
        string cam = DropDownList1.SelectedValue;
        string role = RadioButtonList1.Text;
        string phone = TextBox4.Text;

        while (cpass != pass || string.IsNullOrEmpty(fn) || string.IsNullOrEmpty(ln) || string.IsNullOrEmpty(em) || string.IsNullOrEmpty(role) || string.IsNullOrEmpty(cpass) || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(cam) || string.IsNullOrEmpty(phone))
        {
            ErrorMessageLabel.Text = "Please make sure all boxes are filled and both passwords match";
            pnlErrorMessage.Visible = true;
            return;
        }


        pnlErrorMessage.Visible = false;
        string query;

        // SELECT SCOPE_IDENTITY() retrieves the ID of the newly inserted user
        //if a user with the given email does not already exist
        query = "IF NOT EXISTS (SELECT * FROM Users WHERE Email = @Email) BEGIN " +
                "INSERT INTO Users(Email, Password,FirstName,LastName,Campus,Phone, Role) VALUES (@Email, @Password,@FirstName, @LastName,@Campus,@Phone, @Role) " +
                "SELECT SCOPE_IDENTITY() " +
                "END " +
                "ELSE " +
                "SELECT -1";

        SqlCommand cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@Email", em);
        cmd.Parameters.AddWithValue("@Password", pass);
        cmd.Parameters.AddWithValue("@FirstName", fn);
        cmd.Parameters.AddWithValue("@LastName", ln);
        cmd.Parameters.AddWithValue("@Campus", cam);
        cmd.Parameters.AddWithValue("@Phone",phone);
        cmd.Parameters.AddWithValue("@Role", role);


        int userID = Convert.ToInt32(cmd.ExecuteScalar());

        if (userID == -1)
        {
            // email already exists in the table
            // handle the error as needed
            ErrorMessageLabel.Text = "Email already exists";
            pnlErrorMessage.Visible = true;
        }
        else
        {
            // email does not exist in the table
             pnlErrorMessage.Visible = false;

            if (role == "Student")
            {
                string q2 = "Insert into Students(Student_ID) values ('" + userID +  "')";
                cmd = new SqlCommand(q2, conn);
            }
            else if (role == "Faculty")
            {
                string q2 = "Insert into Faculty(Faculty_ID) values ('" + userID + "')";
                cmd = new SqlCommand(q2, conn);
            }
            else
            {
                string q2 = "Insert into Admin(Admin_ID) values ('" + userID +  "')";
                cmd = new SqlCommand(q2, conn);
            }
            cmd.ExecuteNonQuery();
        }
        cmd.Dispose();
        conn.Close();


    }

    protected void Button2_Click1(object sender, EventArgs e)
    {
        Response.Redirect("Sign_in.aspx");
    }
}