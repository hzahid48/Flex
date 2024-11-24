using System;
using System.Activities.Expressions;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
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

        string name = NameTextBox.Text;
        string code = CodeTextBox.Text;
        string credit = HoursTextBox.Text;
        string prereq = prereqTextBox.Text;

        while (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(code) || string.IsNullOrEmpty(credit))
        {
            ErrorMessageLabel.Text = "Please fill in the first 3 boxes";
            pnlErrorMessage.Visible = true;
            return;
        }

        bool n = false;
        bool c = false;
        bool req = false;
        int hours = int.Parse(credit);

        string q1 = "SELECT CASE WHEN EXISTS (Select Course_Name from Courses where Course_Name = @Course_Name)  THEN 1 ELSE 0 END";
        SqlCommand cmd = new SqlCommand(q1, conn);
        cmd.Parameters.AddWithValue("@Course_Name", name);
        int res = (int)cmd.ExecuteScalar();

        if (res == 0)
        {
            n = true;
        }
        else
        {
            ErrorMessageLabel.Text = "Course with same name already exists";
            pnlErrorMessage.Visible = true;
        }

        string q3 = "SELECT CASE WHEN EXISTS (Select Course_Code from Courses where Course_Code = @CourseCode)  THEN 1 ELSE 0 END";
        SqlCommand cmd3 = new SqlCommand(q3, conn);
        cmd3.Parameters.AddWithValue("@Course_Code", code);
        int res3 = (int)cmd.ExecuteScalar();

        if (res3 == 0)
        {
            c = true;
        }
        else
        {
            ErrorMessageLabel.Text = "Course with same code already exists";
            pnlErrorMessage.Visible = true;
        }

        string q2 = "SELECT CASE WHEN EXISTS (Select Course_Name from Courses where Course_Name=@Pre_Req )THEN 1 ELSE 0 END";
        SqlCommand cmd2 = new SqlCommand(q2, conn);
        cmd2.Parameters.AddWithValue("@Pre_Req", prereq);
        int res2 = (int)cmd2.ExecuteScalar();
        Debug.Write("pre ree qres: ");
        Debug.WriteLine(res2);

        if(res2 == 1 || prereq == "")
        {
            req= true;
        }
        else
        {
            ErrorMessageLabel.Text = "This cannnot be a pre-requisite";
            pnlErrorMessage.Visible = true;
        }

        if(n == true && c == true && req == true)
        {
            string q4 = "Insert into Courses(Course_Code,Course_Name,Credit_Hours,Pre_Req) values (@Course_Code,@Course_Name,@Credit_Hours,@Pre_Req) ";
            SqlCommand cmd4 = new SqlCommand(q4, conn);

            cmd4.Parameters.AddWithValue("@Course_Code", code);
            cmd4.Parameters.AddWithValue("@Course_Name", name);
            cmd4.Parameters.AddWithValue("@Credit_Hours", credit);
            cmd4.Parameters.AddWithValue("@Pre_Req", prereq);
            cmd4.ExecuteNonQuery();
            cmd4.Dispose();
        }

        conn.Close();
    }
}